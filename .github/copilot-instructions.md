# Copilot Instructions

このリポジトリは **VehicleVision.Pleasanter.DotNet.Client** - プリザンターAPIの.NETクライアントライブラリです。

## プロジェクト情報

- **ターゲット**: .NET 10
- **言語バージョン**: C# latest
- **Nullable**: 有効
- **JSONライブラリ**: System.Text.Json

## コントリビューションガイドライン

コードやドキュメントを変更する際は、以下のガイドラインを必ず参照すること：

| ガイドライン | パス                                                                            | 内容                                     |
| ------------ | ------------------------------------------------------------------------------- | ---------------------------------------- |
| コーディング | [coding-guidelines.md](../docs/contributing/coding-guidelines.md)               | 命名規則、フォーマット、コードスタイル   |
| テスト       | [testing-guidelines.md](../docs/contributing/testing-guidelines.md)             | テストの書き方、実行方法、カバレッジ     |
| ドキュメント | [documentation-guidelines.md](../docs/contributing/documentation-guidelines.md) | Markdown記法、ファイル構成、同期ルール   |
| ブランチ戦略 | [branch-strategy.md](../docs/contributing/branch-strategy.md)                   | ブランチ命名、マージ方針                 |
| CI/CD        | [ci-workflow.md](../docs/contributing/ci-workflow.md)                           | 自動テスト、リリースプロセス             |
| 開発環境     | [development-environment.md](../docs/contributing/development-environment.md)   | Node.js、VS Code、.NET SDKのセットアップ |
| Sandbox      | [sandbox-guide.md](../docs/contributing/sandbox-guide.md)                       | デバッグ・動作確認用プロジェクトの使い方 |

> **重要**: `docs/contributing/` に新しいガイドラインを追加した場合は、上記テーブルにも追記すること。

## 変更時のルール

- ガイドラインの変更が必要な変更を行う場合は、関連するガイドライン（`docs/contributing/` 配下）も併せて変更すること
- コードを変更する際には、`docs/wiki/` 配下の関連ドキュメントも併せて変更すること

## ドキュメントの役割分担

| ドキュメント         | 対象読者 | 内容                                                     |
| -------------------- | -------- | -------------------------------------------------------- |
| `README.md`          | 利用者   | インストール方法、使用方法、ライセンス、セキュリティ     |
| `CONTRIBUTING.md`    | 開発者   | コントリビューション手順、ガイドライン一覧、コミット規約 |
| `docs/wiki/`         | 利用者   | APIリファレンス、使用例、共通機能の説明                   |
| `docs/contributing/` | 開発者   | 開発環境構築、コーディング規約、テスト方針、ブランチ戦略 |

### Wiki内リンクルール

`docs/wiki/` 配下のMarkdownファイル間のリンクは**相対パス**で記述すること。Wiki同期スクリプト（`docs/script/sync-docs-to-wiki.js`）が相対パスをWikiページタイトルに自動変換する。詳細は[ドキュメントガイドライン](../docs/contributing/documentation-guidelines.md#wiki内リンク形式)を参照。

## プリザンター本体コードの参照

プリザンター本体のコードを参照する必要がある場合は、以下の順序で参照すること：

1. **サブモジュール**: ワークスペース内の `Implem.Pleasanter/` ディレクトリ（Gitサブモジュールとして登録済み）
2. **公式GitHubリポジトリ**: [Implem/Implem.Pleasanter](https://github.com/Implem/Implem.Pleasanter)

### サブモジュールの取得

サブモジュールが未取得の場合は、以下のコマンドで初期化・取得する：

```bash
npm run submodule:init
# または
git submodule update --init --recursive
```

詳細は[開発環境構築ガイド](../docs/contributing/development-environment.md#プリザンター本体リポジトリ推奨)を参照。

## 出力ルール

- 優先順位や処理の都合上、指示されたタスクの一部を実行しない・できない場合は、その旨を明示的にPromptで出力すること
- 省略した内容と理由を簡潔に説明し、必要に応じて後続の対応を提案すること
