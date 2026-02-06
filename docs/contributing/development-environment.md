# 開発環境構築ガイド

このドキュメントでは、PleasanterDeveloperCommunity.DotNet.Client プロジェクトの開発環境セットアップについて説明します。

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [必要なツール](#必要なツール)
- [プリザンター本体リポジトリ（推奨）](#プリザンター本体リポジトリ推奨)
    - [サブモジュールのクローン](#サブモジュールのクローン)
    - [サブモジュールの更新](#サブモジュールの更新)
    - [サブモジュール管理コマンド](#サブモジュール管理コマンド)
    - [ディレクトリ構成](#ディレクトリ構成)
    - [参考リンク](#参考リンク)
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
    - [ビルドタスク](#ビルドタスク)
- [その他のIDE](#その他のide)
    - [Visual Studio](#visual-studio)
    - [JetBrains Rider](#jetbrains-rider)
- [セットアップ確認](#セットアップ確認)
- [参考リンク](#参考リンク-1)

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

## プリザンター本体リポジトリ（推奨）

プリザンター本体のソースコードを参照しながら開発することで、APIの動作やモデル構造をより深く理解できる。本リポジトリでは、プリザンター本体をGitサブモジュールとして登録しているため、以下のコマンドで取得できる。

### サブモジュールのクローン

リポジトリを初めてクローンする場合は、`--recurse-submodules` オプションを使用する：

```bash
git clone --recurse-submodules https://github.com/pleasanter-developer-community/PleasanterDeveloperCommunity.DotNet.Client.git
```

既にクローン済みの場合は、以下のコマンドでサブモジュールを初期化・取得する：

```bash
npm run submodule:init
# または
git submodule update --init --recursive
```

### サブモジュールの更新

サブモジュールを最新のコミットに更新する場合：

```bash
npm run submodule:update
# または
git submodule update --remote --merge
```

### サブモジュール管理コマンド

npmスクリプトとVS Codeタスクでサブモジュールを管理できる。

| コマンド                   | VS Codeタスク       | 説明                         |
| -------------------------- | ------------------- | ---------------------------- |
| `npm run submodule:init`   | `submodule: init`   | サブモジュールを初期化・取得 |
| `npm run submodule:update` | `submodule: update` | サブモジュールを最新に更新   |
| `npm run submodule:status` | `submodule: status` | サブモジュールの状態を確認   |

VS Codeでは、コマンドパレット（`Ctrl+Shift+P`）から「Tasks: Run Task」を選択し、上記タスクを実行できる。

### ディレクトリ構成

サブモジュールは `Implem.Pleasanter/` ディレクトリに配置される：

```text
PleasanterDeveloperCommunity.DotNet.Client/
├── Implem.Pleasanter/        ← サブモジュール（プリザンター本体）
├── PleasanterDeveloperCommunity.DotNet.Client/
├── PleasanterDeveloperCommunity.DotNet.Client.Tests/
└── ...
```

### 参考リンク

- [Implem.Pleasanter（GitHub）](https://github.com/Implem/Implem.Pleasanter)
- [プリザンター公式サイト](https://pleasanter.org/)

---

## .NET環境

### .NET SDKのインストール

本プロジェクトは .NET 10 をターゲットとしているため、.NET 10 SDK が必要。

> **Note**: ターゲットフレームワークはPleasanter本体に合わせて変更される。Pleasanterは.NET LTS版のリリースタイミングでターゲットフレームワークを変更するため、本プロジェクトもそれに追従する。詳細は[コーディングガイドライン](coding-guidelines.md#ターゲットフレームワーク変更ポリシー)を参照。

#### Windows（winget）

```powershell
winget install Microsoft.DotNet.SDK.10
```

#### Windows / macOS / Linux（インストーラー）

1. [.NET ダウンロードページ](https://dotnet.microsoft.com/download/dotnet/10.0) にアクセス
2. .NET 10 SDK をダウンロード
3. インストーラーを実行

#### macOS（Homebrew）

```bash
brew install dotnet@10
```

#### Linux（apt）

```bash
# Microsoft パッケージリポジトリの追加
wget https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb

# .NET 10 SDK のインストール
sudo apt-get update
sudo apt-get install -y dotnet-sdk-10.0
```

### インストール確認

```bash
dotnet --version
```

`10.x.xxx` 形式のバージョン番号が表示されればインストール完了。

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

| パッケージ        | 用途                                |
| ----------------- | ----------------------------------- |
| markdownlint      | Markdown構文チェック                |
| markdownlint-cli2 | markdownlintのCLIツール             |
| prettier          | コードフォーマッター                |
| doctoc            | 目次（TOC）の自動生成               |
| glob              | ファイルパターンマッチ（PDF生成用） |
| md-to-pdf         | Markdown→PDF変換エンジン            |

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

本プロジェクトでは以下の拡張機能を推奨している（`.vscode/extensions.json` に定義済み）。

| 拡張機能ID                       | 名称         | 用途                       |
| -------------------------------- | ------------ | -------------------------- |
| `ms-dotnettools.csharp`          | C#           | C#言語サポート             |
| `ms-dotnettools.csdevkit`        | C# Dev Kit   | .NET開発の統合支援         |
| `esbenp.prettier-vscode`         | Prettier     | コードフォーマッター       |
| `editorconfig.editorconfig`      | EditorConfig | エディタ設定の統一         |
| `davidanson.vscode-markdownlint` | markdownlint | Markdownのリアルタイムlint |

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
```

### ワークスペース設定

プロジェクトには `.vscode/settings.json` が含まれており、以下の設定が自動的に適用される：

| 設定                                  | 値                       | 説明                               |
| ------------------------------------- | ------------------------ | ---------------------------------- |
| `[markdown].editor.defaultFormatter`  | `esbenp.prettier-vscode` | MarkdownのフォーマッターにPrettier |
| `[markdown].editor.formatOnSave`      | `true`                   | 保存時に自動フォーマット           |
| `[markdown].editor.codeActionsOnSave` | markdownlint fixAll      | 保存時にlintエラーを自動修正       |
| `[json].editor.defaultFormatter`      | `esbenp.prettier-vscode` | JSONのフォーマッターにPrettier     |
| `[csharp].editor.formatOnSave`        | `true`                   | C#保存時に自動フォーマット         |
| `editor.formatOnSave`                 | `true`                   | 全体で保存時フォーマット有効       |
| `files.eol`                           | `\n`                     | 改行コードをLFに統一               |

### ビルドタスク

プロジェクトには `.vscode/tasks.json` が含まれており、VS Code のタスク機能でビルドやドキュメント操作を実行できる。

#### ビルドタスク

以下のタスクが `.vscode/tasks.json` に定義されています。

| タスク            | 説明                      | 備考                          |
| ----------------- | ------------------------- | ----------------------------- |
| `build`           | NuGet復元→ビルド          | デフォルトビルドタスク        |
| `build (Release)` | リリース構成でビルド      | 最適化有効、警告をエラー扱い  |
| `restore`         | NuGetパッケージの復元のみ | 依存パッケージのダウンロード  |
| `clean`           | ビルド成果物のクリーン    | bin/obj フォルダを削除        |
| `rebuild`         | クリーン→復元→ビルド      | フルリビルド                  |
| `format`          | C#コードのフォーマット    | using整理・コードスタイル適用 |

#### テストタスク

テストの実行方法については[テストガイドライン](testing-guidelines.md)を参照。

| コマンド                                      | 説明                   | 備考                   |
| --------------------------------------------- | ---------------------- | ---------------------- |
| `dotnet test`                                 | 全テストを実行         | ソリューション全体     |
| `dotnet test --filter "ClassName"`            | 特定のテストクラス実行 | フィルタで絞り込み     |
| `dotnet test --collect:"XPlat Code Coverage"` | カバレッジ収集付き実行 | coverlet.collector使用 |

#### ドキュメントタスク（npm）

以下のnpmスクリプトが VS Code タスクとして利用可能です（`package.json` に定義）。

| タスク              | 説明                            | 対応するnpmスクリプト  |
| ------------------- | ------------------------------- | ---------------------- |
| `npm: lint:md`      | Markdownファイルの構文チェック  | `npm run lint:md`      |
| `npm: lint:md:fix`  | lintエラーを自動修正            | `npm run lint:md:fix`  |
| `npm: format`       | Prettierでフォーマット          | `npm run format`       |
| `npm: format:check` | フォーマットのチェック          | `npm run format:check` |
| `npm: toc`          | doctocでTOCを更新               | `npm run toc`          |
| `npm: toc:all`      | TOC更新 + フォーマットを一括    | `npm run toc:all`      |
| `npm: pdf`          | 全MarkdownをPDFに変換           | `npm run pdf`          |
| `npm: pdf:wiki`     | WikiドキュメントをPDFに変換     | `npm run pdf:wiki`     |
| `npm: pdf:research` | リサーチドキュメントをPDFに変換 | `npm run pdf:research` |

#### タスクの実行方法

**キーボードショートカット（推奨）**

- `Ctrl+Shift+B`（Windows/Linux）または `Cmd+Shift+B`（macOS）でデフォルトのビルドタスクを実行

**コマンドパレットから実行**

1. `Ctrl+Shift+P`（Windows/Linux）または `Cmd+Shift+P`（macOS）でコマンドパレットを開く
2. `Tasks: Run Task` と入力
3. 実行したいタスクを選択

**ターミナルメニューから実行**

1. メニューバーから「ターミナル」→「タスクの実行」を選択
2. 実行したいタスクを選択

#### 自動NuGet復元

`build` タスクは `restore` タスクに依存しているため、ビルド実行時に自動的にNuGetパッケージが復元される。手動で `dotnet restore` を実行する必要はない。

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
