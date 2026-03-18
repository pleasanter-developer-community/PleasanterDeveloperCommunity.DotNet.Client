# VehicleVision.Pleasanter.DotNet.Client

<!-- markdownlint-disable MD013 -->

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/) [![Pleasanter](https://img.shields.io/badge/Pleasanter-1.3.13.0%2B-00A0E9)](https://pleasanter.org/) [![Pleasanter ApiVersion](https://img.shields.io/badge/Pleasanter%20ApiVersion-1.1%2B-00A0E9)](https://pleasanter.org/ja/manual/api) [![License](https://img.shields.io/badge/License-LGPL--2.1-blue.svg)](LICENSE)

<!-- markdownlint-enable MD013 -->

[プリザンター](https://pleasanter.org/)のAPIを.NETから簡単に利用するためのクライアントライブラリです。レコードのCRUD操作、一括処理、拡張SQL実行などを型安全に扱えます。

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [インストール](#インストール)
    - [方法1: NuGetパッケージ（推奨）](#方法1-nugetパッケージ推奨)
    - [方法2: GitHub Packages](#方法2-github-packages)
    - [方法3: オフライン環境でのNuGetパッケージ](#方法3-オフライン環境でのnugetパッケージ)
    - [方法4: DLLを直接参照](#方法4-dllを直接参照)
- [使用方法](#使用方法)
- [サードパーティライセンス](#サードパーティライセンス)
- [コントリビューション](#コントリビューション)
- [セキュリティ](#セキュリティ)
- [謝辞](#謝辞)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## インストール

### 方法1: NuGetパッケージ（推奨）

[![NuGet](https://img.shields.io/nuget/v/VehicleVision.Pleasanter.DotNet.Client)](https://www.nuget.org/packages/VehicleVision.Pleasanter.DotNet.Client)

#### .NET CLI

```bash
dotnet add package VehicleVision.Pleasanter.DotNet.Client
```

#### Visual Studio

1. **ソリューションエクスプローラー**でプロジェクトを右クリック
2. **NuGet パッケージの管理**を選択
3. **参照**タブで `VehicleVision.Pleasanter.DotNet.Client` を検索
4. パッケージを選択して**インストール**をクリック

または、**パッケージマネージャーコンソール**（ツール → NuGet パッケージ マネージャー → パッケージ マネージャー コンソール）から：

```powershell
Install-Package VehicleVision.Pleasanter.DotNet.Client
```

#### Visual Studio Code

1. **コマンドパレット**（`Ctrl+Shift+P`）を開く
2. `NuGet: Add NuGet Package` を入力して実行
3. `VehicleVision.Pleasanter.DotNet.Client` を検索してインストール

または、**ターミナル**から：

```bash
dotnet add package VehicleVision.Pleasanter.DotNet.Client
```

<!-- markdownlint-disable MD013 -->

> **Note**: VS Codeで NuGet パッケージマネージャーを使用するには、[C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) 拡張機能のインストールを推奨します。

<!-- markdownlint-enable MD013 -->

#### JetBrains Rider

1. **ソリューションエクスプローラー**でプロジェクトを右クリック
2. **Manage NuGet Packages**を選択
3. **Packages**タブで `VehicleVision.Pleasanter.DotNet.Client` を検索
4. パッケージを選択して**+**ボタン（Install）をクリック

または、**ターミナル**から：

```bash
dotnet add package VehicleVision.Pleasanter.DotNet.Client
```

### 方法2: GitHub Packages

[![GitHub Packages](https://img.shields.io/badge/GitHub%20Packages-VehicleVision.Pleasanter.DotNet.Client-blue?logo=github)](https://github.com/pleasanter-developer-community/VehicleVision.Pleasanter.DotNet.Client/pkgs/nuget/VehicleVision.Pleasanter.DotNet.Client)

> **Note**: GitHub PackagesのNuGetレジストリはパブリックパッケージでも認証が必要です（GitHubの仕様）。認証不要でインストールしたい場合は[方法1: NuGetパッケージ](#方法1-nugetパッケージ推奨)をご利用ください。

#### 1. 認証の設定

GitHub Packagesを利用するには、GitHub Personal Access Token（PAT）が必要です。[GitHub Settings](https://github.com/settings/tokens)で`read:packages`スコープを持つトークンを作成してください。

#### 2. NuGetソースの追加

プロジェクトのルートに`nuget.config`ファイルを作成します：

```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
    <add key="github" value="https://nuget.pkg.github.com/pleasanter-developer-community/index.json" />
  </packageSources>
  <packageSourceCredentials>
    <github>
      <add key="Username" value="YOUR_GITHUB_USERNAME" />
      <add key="ClearTextPassword" value="YOUR_GITHUB_PAT" />
    </github>
  </packageSourceCredentials>
</configuration>
```

> **Note**: `YOUR_GITHUB_USERNAME`と`YOUR_GITHUB_PAT`を実際の値に置き換えてください。

#### 3. パッケージのインストール

```bash
dotnet add package VehicleVision.Pleasanter.DotNet.Client --source github
```

### 方法3: オフライン環境でのNuGetパッケージ

#### 1. パッケージのダウンロード

[最新リリース](https://github.com/pleasanter-developer-community/VehicleVision.Pleasanter.DotNet.Client/releases/latest)から`.nupkg`ファイルをダウンロードします。

#### 2. ローカルフィードの追加

ダウンロードした`.nupkg`ファイルを配置したフォルダをローカルフィードとして追加します：

```bash
dotnet nuget add source /path/to/nupkg/folder --name LocalPackages
```

> **Note**: `/path/to/nupkg/folder`は実際の`.nupkg`ファイルの配置場所に合わせて変更してください。

#### 3. パッケージのインストール（オフライン）

```bash
dotnet add package VehicleVision.Pleasanter.DotNet.Client
```

### 方法4: DLLを直接参照

#### 1. DLLの取得

以下のいずれかの方法でDLLを取得します：

- **リリースからダウンロード**: [最新リリース](https://github.com/pleasanter-developer-community/VehicleVision.Pleasanter.DotNet.Client/releases/latest)から`.zip`ファイルをダウンロードして展開
- **ソースからビルド**: リポジトリをクローンしてビルド

#### 2. プロジェクトへの参照追加

プロジェクトファイル（`.csproj`）に以下を追加します：

```xml
<ItemGroup>
  <Reference Include="VehicleVision.Pleasanter.DotNet.Client">
    <HintPath>path\to\VehicleVision.Pleasanter.DotNet.Client.dll</HintPath>
  </Reference>
</ItemGroup>
```

> **Note**: `HintPath`は実際のDLLの配置場所に合わせて変更してください。

#### 3. 依存パッケージのインストール

以下のコマンドで必要な依存パッケージをインストールします：

```bash
dotnet add package Microsoft.AspNetCore.StaticFiles
```

## 使用方法

[Wiki](https://github.com/pleasanter-developer-community/VehicleVision.Pleasanter.DotNet.Client/wiki)を参照してください。

## サードパーティライセンス

このプロジェクトは以下のサードパーティライブラリを使用しています：

| ライブラリ                       | ライセンス | 著作権                                         |
| -------------------------------- | ---------- | ---------------------------------------------- |
| Microsoft.AspNetCore.StaticFiles | MIT        | Copyright (c) .NET Foundation and Contributors |

ライセンスファイルの全文は [LICENSES](./LICENSES/) フォルダを参照してください。

## コントリビューション

バグ報告、機能要望、プルリクエストを歓迎しています。詳細は [CONTRIBUTING.md](CONTRIBUTING.md) を参照してください。

## セキュリティ

セキュリティ上の脆弱性を発見された場合は、[セキュリティポリシー](.github/SECURITY.md)をご確認の上、ご報告ください。

## 謝辞

セキュリティ脆弱性の報告やプロジェクトへの貢献をしてくださった方々に感謝いたします。

<!-- 貢献者・報告者はこちらに追記 -->
