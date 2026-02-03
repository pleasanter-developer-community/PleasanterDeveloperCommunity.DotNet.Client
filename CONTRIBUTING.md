# コントリビューションガイド

PleasanterDeveloperCommunity.DotNet.Client へのコントリビューションに感謝します。
このドキュメントでは、プロジェクトへの貢献方法について説明します。

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [はじめに](#はじめに)
- [ガイドライン一覧](#ガイドライン一覧)
- [クイックスタート](#クイックスタート)
    - [1. リポジトリをフォーク・クローン](#1-リポジトリをフォーククローン)
    - [2. ブランチを作成](#2-ブランチを作成)
    - [3. 変更を実装](#3-変更を実装)
    - [4. コミット・プッシュ](#4-コミットプッシュ)
    - [5. プルリクエストを作成](#5-プルリクエストを作成)
- [コミットメッセージ](#コミットメッセージ)
- [Issue報告](#issue報告)
- [ライセンス](#ライセンス)
- [質問・サポート](#質問サポート)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## はじめに

このプロジェクトは、プリザンターAPIの.NETクライアントライブラリです。コントリビューションを行う前に、以下のガイドラインをご確認ください。

## ガイドライン一覧

| ガイドライン                                                              | 内容                                     |
| ------------------------------------------------------------------------- | ---------------------------------------- |
| [開発環境構築](docs/contributing/development-environment.md)              | Node.js、VS Code、.NET SDKのセットアップ |
| [コーディングガイドライン](docs/contributing/coding-guidelines.md)        | 命名規則、フォーマット、コードスタイル   |
| [テストガイドライン](docs/contributing/testing-guidelines.md)             | テストの書き方、実行方法、カバレッジ     |
| [ドキュメントガイドライン](docs/contributing/documentation-guidelines.md) | Markdown記法、ファイル構成、同期ルール   |
| [ブランチ戦略](docs/contributing/branch-strategy.md)                      | ブランチ命名、マージ方針                 |
| [CI/CDワークフロー](docs/contributing/ci-workflow.md)                     | 自動テスト、リリースプロセス             |

## クイックスタート

### 1. リポジトリをフォーク・クローン

```bash
git clone https://github.com/your-username/PleasanterDeveloperCommunity.DotNet.Client.git
cd PleasanterDeveloperCommunity.DotNet.Client
```

### 2. ブランチを作成

```bash
git checkout -b feature/your-feature-name
```

ブランチ命名規則については[ブランチ戦略](docs/contributing/branch-strategy.md)を参照してください。

### 3. 変更を実装

- [コーディングガイドライン](docs/contributing/coding-guidelines.md)に従ってコードを記述
- テストを追加（[テストガイドライン](docs/contributing/testing-guidelines.md)参照）
- ドキュメントを更新（[ドキュメントガイドライン](docs/contributing/documentation-guidelines.md)参照）

### 4. コミット・プッシュ

```bash
git add .
git commit -m "feat: 機能の説明"
git push origin feature/your-feature-name
```

### 5. プルリクエストを作成

GitHub上でプルリクエストを作成してください。

## コミットメッセージ

以下のプレフィックスを使用：

| プレフィックス | 用途               |
| -------------- | ------------------ |
| `feat:`        | 新機能             |
| `fix:`         | バグ修正           |
| `docs:`        | ドキュメント更新   |
| `refactor:`    | リファクタリング   |
| `test:`        | テスト追加・修正   |
| `chore:`       | その他（ビルド等） |

## Issue報告

バグ報告や機能要望は、GitHubのIssueで受け付けています。

- **バグ報告**: 再現手順、期待される動作、実際の動作を記載
- **機能要望**: ユースケースと期待される動作を記載

## ライセンス

このプロジェクトは LGPL-2.1 ライセンスの下で公開されています。コントリビューションは同じライセンスの下で提供されます。

## 質問・サポート

質問がある場合は、GitHubのDiscussionsまたはIssueでお気軽にお問い合わせください。
