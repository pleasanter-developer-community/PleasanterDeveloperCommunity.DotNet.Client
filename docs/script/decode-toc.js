/**
 * doctocが生成したTOCを後処理するスクリプト
 * - URLエンコードされた日本語をデコード
 * - H1へのリンク（ファイルのH1タイトルと一致する項目）を削除
 * - 中黒（・）をアンカーから削除（GitHub仕様に準拠）
 * - インデントを2スペースから4スペースに変換（MD007対応）
 *
 * 使用方法:
 *   node docs/script/decode-toc.js
 */

const fs = require("fs");
const path = require("path");

const docsDir = path.join(__dirname, "..");
const rootDir = path.join(__dirname, "..", "..");

// docs配下の全ディレクトリを処理対象にする
const targetDirs = fs
    .readdirSync(docsDir, { withFileTypes: true })
    .filter((dirent) => dirent.isDirectory() && dirent.name !== "script")
    .map((dirent) => dirent.name);

// 各ディレクトリ内のmdファイルを収集
const files = [];
targetDirs.forEach((dir) => {
    const dirPath = path.join(docsDir, dir);
    if (fs.existsSync(dirPath)) {
        fs.readdirSync(dirPath)
            .filter((f) => f.endsWith(".md"))
            .forEach((f) => files.push(path.join(dirPath, f)));
    }
});

// docs直下のmdファイルも追加
fs.readdirSync(docsDir)
    .filter((f) => f.endsWith(".md"))
    .forEach((f) => files.push(path.join(docsDir, f)));

// ルートディレクトリのmdファイルも追加
fs.readdirSync(rootDir)
    .filter((f) => f.endsWith(".md"))
    .forEach((f) => files.push(path.join(rootDir, f)));

files.forEach((filePath) => {
    let content = fs.readFileSync(filePath, "utf8");

    // ファイルのH1タイトルを取得
    const h1Match = content.match(/^# (.+)$/m);
    const h1Title = h1Match ? h1Match[1].trim() : null;

    // doctocマーカー内を処理
    const doctocRegex =
        /(<!-- START doctoc[\s\S]*?)(- \[[\s\S]*?)(<!-- END doctoc[\s\S]*?-->)/g;
    content = content.replace(doctocRegex, (match, start, tocContent, end) => {
        // 1. URLエンコードをデコード
        let processedToc = tocContent.replace(
            /\(#([^)]+)\)/g,
            (linkMatch, encoded) => {
                try {
                    const decoded = decodeURIComponent(encoded);
                    return `(#${decoded})`;
                } catch {
                    return linkMatch;
                }
            }
        );

        // 2. H1へのリンク（ファイルのH1タイトルと一致する項目）を削除
        if (h1Title) {
            const escapedTitle = h1Title.replace(/[.*+?^${}()|[\]\\]/g, "\\$&");
            const h1LinkRegex = new RegExp(
                `^- \\[${escapedTitle}\\]\\([^)]+\\)\\n`,
                "m"
            );
            const hasH1Link = h1LinkRegex.test(processedToc);

            if (hasH1Link) {
                processedToc = processedToc.replace(h1LinkRegex, "");
                // H1を削除した場合のみ、残りの項目のインデントを1レベル下げる
                processedToc = processedToc.replace(/^    /gm, "");
            }
        }

        // 3. 中黒（・）をアンカーから削除（GitHub仕様）
        processedToc = processedToc.replace(
            /\(#([^)]+)\)/g,
            (linkMatch, anchor) => {
                const fixedAnchor = anchor.replace(/・/g, "");
                return `(#${fixedAnchor})`;
            }
        );

        // 4. インデントを2スペースから4スペースに変換（MD007対応）
        processedToc = processedToc.replace(/^( +)-/gm, (match, spaces) => {
            const level = spaces.length / 2;
            return "    ".repeat(level) + "-";
        });

        return start + processedToc + end;
    });

    fs.writeFileSync(filePath, content, "utf8");
});

console.log(`Processed TOC in ${files.length} files.`);
