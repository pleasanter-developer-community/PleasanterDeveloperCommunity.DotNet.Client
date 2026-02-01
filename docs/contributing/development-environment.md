# 開発環境構築ガイド

このドキュメントでは、PleasanterDeveloperCommunity.DotNet.Client プロジェクトの開発環境セットアップについて説明します。

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [必要なツール](#必要なツール)
- [.NET環境](#net環境)
    - [.NET SDKのインストール](#net-sdkのインストール)
    - [インストール確認](#インストール確認)
- [Node.js環境](#nodejs環境)
    - [Node.jsのインストール](#nodejsのインストール)
    - [インストール確認](#インストール確認-1)
    - [パッケージのインストール](#パッケージのインストール)
- [IDE（Visual Studio Code）](#idevisual-studio-code)
    - [VS Codeのインストール](#vs-codeのインストール)
    - [推奨拡張機能](#推奨拡張機能)
    - [拡張機能の一括インストール](#拡張機能の一括インストール)
    - [ワークスペース設定](#ワークスペース設定)
- [その他のIDE](#その他のide)
    - [Visual Studio](#visual-studio)
    - [JetBrains Rider](#jetbrains-rider)
- [セットアップ確認](#セットアップ確認)
- [参考リンク](#参考リンク)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

---

## 必要なツール

| ツール   | 用途                             | 必須 |
| -------- | -------------------------------- | ---- |
| .NET SDK | ライブラリのビルド・テスト       | 必須 |
| Node.js  | ドキュメントのlint・フォーマット | 推奨 |
| VS Code  | 推奨エディタ                     | 推奨 |
| Git      | バージョン管理                   | 必須 |

---

## .NET環境

### .NET SDKのインストール

本プロジェクトは .NET Standard 2.1 をターゲットとしているため、.NET 6.0 SDK 以上が必要。

1. [.NET ダウンロードページ](https://dotnet.microsoft.com/download) にアクセス
2. 最新の .NET SDK（LTS推奨）をダウンロード
3. インストーラーを実行

### インストール確認

```bash
dotnet --version
```

バージョン番号が表示されればインストール完了。

---

## Node.js環境

ドキュメントのlintやフォーマットにはNode.jsが必要。

### Node.jsのインストール

#### Windows（winget）

```powershell
winget install OpenJS.NodeJS.LTS
```

#### Windows（インストーラー）

1. [Node.js公式サイト](https://nodejs.org/) にアクセス
2. LTS版をダウンロード
3. インストーラーを実行

#### macOS（Homebrew）

```bash
brew install node
```

#### Linux（apt）

```bash
curl -fsSL https://deb.nodesource.com/setup_lts.x | sudo -E bash -
sudo apt-get install -y nodejs
```

### インストール確認

```bash
node --version
npm --version
```

両方のバージョン番号が表示されればインストール完了。

### パッケージのインストール

リポジトリのルートディレクトリで以下を実行：

```bash
npm install
```

これにより、以下のツールがインストールされる：

| パッケージ        | 用途                    |
| ----------------- | ----------------------- |
| markdownlint      | Markdown構文チェック    |
| markdownlint-cli2 | markdownlintのCLIツール |
| prettier          | コードフォーマッター    |

---

## IDE（Visual Studio Code）

本プロジェクトでは **Visual Studio Code** を推奨エディタとしている。

### VS Codeのインストール

1. [Visual Studio Code公式サイト](https://code.visualstudio.com/) にアクセス
2. OSに応じたインストーラーをダウンロード
3. インストーラーを実行

#### Windows（winget）

```powershell
winget install Microsoft.VisualStudioCode
```

#### macOS（Homebrew）

```bash
brew install --cask visual-studio-code
```

### 推奨拡張機能

本プロジェクトでは以下の拡張機能を推奨している。

| 拡張機能ID                       | 名称                | 用途                         |
| -------------------------------- | ------------------- | ---------------------------- |
| `ms-dotnettools.csharp`          | C#                  | C#言語サポート               |
| `ms-dotnettools.csdevkit`        | C# Dev Kit          | .NET開発の統合支援           |
| `esbenp.prettier-vscode`         | Prettier            | コードフォーマッター         |
| `editorconfig.editorconfig`      | EditorConfig        | エディタ設定の統一           |
| `davidanson.vscode-markdownlint` | markdownlint        | Markdownのリアルタイムlint   |
| `yzhang.markdown-all-in-one`     | Markdown All in One | 目次自動生成、プレビュー強化 |

### 拡張機能の一括インストール

プロジェクトを VS Code で開くと、推奨拡張機能のインストールを促すダイアログが表示される。
「Install All」をクリックすることで一括インストールが可能。

手動でインストールする場合は、以下のコマンドを実行：

```bash
code --install-extension ms-dotnettools.csharp
code --install-extension ms-dotnettools.csdevkit
code --install-extension esbenp.prettier-vscode
code --install-extension editorconfig.editorconfig
code --install-extension davidanson.vscode-markdownlint
code --install-extension yzhang.markdown-all-in-one
```

### ワークスペース設定

プロジェクトには `.vscode/settings.json` が含まれており、以下の設定が自動的に適用される：

| 設定                                  | 値                       | 説明                               |
| ------------------------------------- | ------------------------ | ---------------------------------- |
| `[markdown].editor.defaultFormatter`  | `esbenp.prettier-vscode` | MarkdownのフォーマッターにPrettier |
| `[markdown].editor.formatOnSave`      | `true`                   | 保存時に自動フォーマット           |
| `[markdown].editor.codeActionsOnSave` | markdownlint fixAll      | 保存時にlintエラーを自動修正       |
| `markdown.extension.toc.updateOnSave` | `true`                   | 保存時に目次を自動更新             |
| `files.eol`                           | `\n`                     | 改行コードをLFに統一               |

---

## その他のIDE

### Visual Studio

Visual Studio 2022 以降を使用する場合：

1. [Visual Studio ダウンロードページ](https://visualstudio.microsoft.com/) からインストール
2. ワークロード「.NET デスクトップ開発」を選択
3. EditorConfigサポートは標準で有効

**注意**: ドキュメントのlint・フォーマットには別途 Node.js 環境が必要。

### JetBrains Rider

JetBrains Rider を使用する場合：

1. [Rider ダウンロードページ](https://www.jetbrains.com/rider/) からインストール
2. EditorConfigサポートは標準で有効
3. Prettier プラグインをインストール（任意）

**注意**: ドキュメントのlint・フォーマットには別途 Node.js 環境が必要。

---

## セットアップ確認

すべてのセットアップが完了したら、以下のコマンドで確認：

```bash
# .NET SDKの確認
dotnet --version

# Node.jsの確認
node --version
npm --version

# プロジェクトのビルド
dotnet build

# ドキュメントのlint
npm run lint:md

# ドキュメントのフォーマットチェック
npm run format:check
```

すべてのコマンドがエラーなく完了すれば、開発環境のセットアップは完了。

---

## 参考リンク

- [.NET ドキュメント](https://learn.microsoft.com/ja-jp/dotnet/)
- [Node.js 公式サイト](https://nodejs.org/ja/)
- [Visual Studio Code ドキュメント](https://code.visualstudio.com/docs)
