#!/usr/bin/env node

/**
 * MarkdownファイルをPDFに変換するスクリプト
 *
 * 使用方法:
 *   npm run pdf                     # 全MarkdownファイルをPDF化
 *   npm run pdf -- docs/wiki/*.md   # 特定のファイルをPDF化
 *   node docs/script/generate-pdf.js <file-pattern>
 */

const fs = require('fs');
const path = require('path');
const { mdToPdf } = require('md-to-pdf');
const { glob } = require('glob');

// CSS読み込み
const cssPath = path.join(__dirname, 'github-markdown.css');
let githubCss = '';
try {
  githubCss = fs.readFileSync(cssPath, 'utf-8');
} catch (error) {
  console.warn('警告: github-markdown.cssの読み込みに失敗しました:', error.message);
  console.warn('デフォルトのスタイルを使用します。');
}

// 設定
const config = {
  // デフォルトの対象ファイルパターン
  defaultPattern: 'docs/**/*.md',

  // 出力ディレクトリ
  outputDir: 'pdf-output',

  // PDF設定
  pdf_options: {
    format: 'A4',
    margin: {
      top: '20mm',
      right: '20mm',
      bottom: '20mm',
      left: '20mm'
    },
    printBackground: true
  },

  // CSS設定（GitHubスタイル）
  css: githubCss || `
    /* フォールバックスタイル */
    body {
      font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", "Noto Sans", Helvetica, Arial, sans-serif;
      font-size: 16px;
      line-height: 1.5;
      color: #24292f;
    }
  `,

  // body_class: GitHubスタイルのクラス名
  body_class: 'markdown-body'
};

/**
 * ファイルパターンに一致するMarkdownファイルを取得
 */
async function getMarkdownFiles(pattern) {
  try {
    // Windowsのバックスラッシュをスラッシュに変換（globはスラッシュのみ対応）
    const normalizedPattern = pattern.replace(/\\/g, '/');
    const files = await glob(normalizedPattern, {
      ignore: ['node_modules/**', '**/node_modules/**'],
      nodir: true
    });
    return files.filter(file => file.endsWith('.md'));
  } catch (error) {
    console.error(`ファイル検索エラー: ${error.message}`);
    return [];
  }
}

/**
 * MarkdownファイルをPDFに変換
 */
async function convertToPdf(markdownPath) {
  try {
    // 出力パスを生成
    const relativePath = path.relative(process.cwd(), markdownPath);
    const outputPath = path.join(
      config.outputDir,
      relativePath.replace(/\.md$/, '.pdf')
    );

    // 出力ディレクトリを作成
    const outputDirPath = path.dirname(outputPath);
    if (!fs.existsSync(outputDirPath)) {
      fs.mkdirSync(outputDirPath, { recursive: true });
    }

    console.log(`変換中: ${relativePath}`);

    // PDFに変換
    const pdf = await mdToPdf(
      { path: markdownPath },
      {
        dest: outputPath,
        css: config.css,  // CSSテキストは 'css' オプションで指定
        body_class: config.body_class,
        pdf_options: config.pdf_options,
        launch_options: {
          args: ['--no-sandbox', '--disable-setuid-sandbox']
        }
      }
    );

    if (pdf) {
      console.log(`✓ 完了: ${outputPath}`);
      return { success: true, input: markdownPath, output: outputPath };
    }
  } catch (error) {
    console.error(`✗ エラー: ${markdownPath}`);
    console.error(`  ${error.message}`);
    return { success: false, input: markdownPath, error: error.message };
  }
}

/**
 * メイン処理
 */
async function main() {
  console.log('═══════════════════════════════════════════════════════');
  console.log('  Markdown to PDF Converter');
  console.log('═══════════════════════════════════════════════════════\n');

  // コマンドライン引数からパターンを取得
  const args = process.argv.slice(2);
  const pattern = args.length > 0 ? args.join(' ') : config.defaultPattern;

  console.log(`対象パターン: ${pattern}\n`);

  // Markdownファイルを取得
  const markdownFiles = await getMarkdownFiles(pattern);

  if (markdownFiles.length === 0) {
    console.log('対象ファイルが見つかりませんでした。');
    return;
  }

  console.log(`${markdownFiles.length} 件のファイルを処理します\n`);

  // 出力ディレクトリを作成
  if (!fs.existsSync(config.outputDir)) {
    fs.mkdirSync(config.outputDir, { recursive: true });
  }

  // 各ファイルを変換
  const results = [];
  for (const file of markdownFiles) {
    const result = await convertToPdf(file);
    results.push(result);
  }

  // 結果サマリー
  console.log('\n═══════════════════════════════════════════════════════');
  console.log('  変換結果');
  console.log('═══════════════════════════════════════════════════════\n');

  const successCount = results.filter(r => r.success).length;
  const failureCount = results.filter(r => !r.success).length;

  console.log(`成功: ${successCount} 件`);
  console.log(`失敗: ${failureCount} 件`);

  if (failureCount > 0) {
    console.log('\n失敗したファイル:');
    results
      .filter(r => !r.success)
      .forEach(r => console.log(`  - ${r.input}: ${r.error}`));
  }

  console.log(`\n出力先: ${path.resolve(config.outputDir)}`);

  // 明示的にプロセスを終了（Puppeteerのクリーンアップ待ちを回避）
  process.exit(failureCount > 0 ? 1 : 0);
}

// 実行
main().catch(error => {
  console.error('予期しないエラー:', error);
  process.exit(1);
});
