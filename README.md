# PleasanterDeveloperCommunity.DotNet.Client

[![.NET Standard](https://img.shields.io/badge/.NET%20Standard-2.1-512BD4?logo=dotnet)](https://docs.microsoft.com/ja-jp/dotnet/standard/net-standard) [![Pleasanter](https://img.shields.io/badge/Pleasanter-1.3.13.0%2B-00A0E9)](https://pleasanter.org/) [![Pleasanter ApiVersion](https://img.shields.io/badge/Pleasanter%20ApiVersion-1.1%2B-00A0E9)](https://pleasanter.org/ja/manual/api) [![License](https://img.shields.io/badge/License-LGPL--2.1-blue.svg)](LICENSE)

[プリザンター](https://pleasanter.org/)のAPIを.NETから簡単に利用するためのクライアントライブラリです。レコードのCRUD操作、一括処理、拡張SQL実行などを型安全に扱えます。

## インストール

### 方法1: NuGetパッケージ（推奨）

[![NuGet](https://img.shields.io/nuget/v/PleasanterDeveloperCommunity.DotNet.Client)](https://www.nuget.org/packages/PleasanterDeveloperCommunity.DotNet.Client)

```bash
dotnet add package PleasanterDeveloperCommunity.DotNet.Client
```

または、Visual Studioのパッケージマネージャーコンソールから：

```powershell
Install-Package PleasanterDeveloperCommunity.DotNet.Client
```

### 方法2: GitHub Packages

[![GitHub Packages](https://img.shields.io/badge/GitHub%20Packages-PleasanterDeveloperCommunity.DotNet.Client-blue?logo=github)](https://github.com/pleasanter-developer-community/PleasanterDeveloperCommunity.DotNet.Client/pkgs/nuget/PleasanterDeveloperCommunity.DotNet.Client)

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
dotnet add package PleasanterDeveloperCommunity.DotNet.Client --source github
```

### 方法3: オフライン環境でのNuGetパッケージ

#### 1. パッケージのダウンロード

[最新リリース](https://github.com/pleasanter-developer-community/PleasanterDeveloperCommunity.DotNet.Client/releases/latest)から`.nupkg`ファイルをダウンロードします。

#### 2. ローカルフィードの追加

ダウンロードした`.nupkg`ファイルを配置したフォルダをローカルフィードとして追加します：

```bash
dotnet nuget add source /path/to/nupkg/folder --name LocalPackages
```

> **Note**: `/path/to/nupkg/folder`は実際の`.nupkg`ファイルの配置場所に合わせて変更してください。

#### 3. パッケージのインストール

```bash
dotnet add package PleasanterDeveloperCommunity.DotNet.Client
```

### 方法4: DLLを直接参照

#### 1. DLLの取得

以下のいずれかの方法でDLLを取得します：

- **リリースからダウンロード**: [最新リリース](https://github.com/pleasanter-developer-community/PleasanterDeveloperCommunity.DotNet.Client/releases/latest)から`.zip`ファイルをダウンロードして展開
- **ソースからビルド**: リポジトリをクローンしてビルド

#### 2. プロジェクトへの参照追加

プロジェクトファイル（`.csproj`）に以下を追加します：

```xml
<ItemGroup>
  <Reference Include="PleasanterDeveloperCommunity.DotNet.Client">
    <HintPath>path\to\PleasanterDeveloperCommunity.DotNet.Client.dll</HintPath>
  </Reference>
</ItemGroup>
```

> **Note**: `HintPath`は実際のDLLの配置場所に合わせて変更してください。

#### 3. 依存パッケージのインストール

以下のコマンドで必要な依存パッケージをインストールします：

```bash
dotnet add package Newtonsoft.Json
```

## 使用方法

[Wiki](https://github.com/pleasanter-developer-community/PleasanterDeveloperCommunity.DotNet.Client/wiki)を参照してください。

## サードパーティライセンス

このプロジェクトは以下のサードパーティライブラリを使用しています：

| ライブラリ      | ライセンス | 著作権                               |
| --------------- | ---------- | ------------------------------------ |
| Newtonsoft.Json | MIT        | Copyright (c) 2007 James Newton-King |

ライセンスファイルの全文は [LICENSES](./LICENSES/) フォルダを参照してください。
