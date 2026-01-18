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

### 方法2: オフライン環境でのNuGetパッケージ

[![GitHub Release](https://img.shields.io/github/v/release/pleasanter-developer-community/PleasanterDeveloperCommunity.DotNet.Client)](https://github.com/pleasanter-developer-community/PleasanterDeveloperCommunity.DotNet.Client/releases/latest)

Releasesページから`.nupkg`ファイルをダウンロードし、ローカルフィードとして追加します：

```bash
dotnet nuget add source /path/to/nupkg/folder --name LocalPackages
dotnet add package PleasanterDeveloperCommunity.DotNet.Client
```

### 方法3: DLLを直接参照

1. [![GitHub Release](https://img.shields.io/github/v/release/pleasanter-developer-community/PleasanterDeveloperCommunity.DotNet.Client)](https://github.com/pleasanter-developer-community/PleasanterDeveloperCommunity.DotNet.Client/releases/latest) からzipファイルをダウンロードして展開するか、ソースからビルドします。

2. プロジェクトファイル（.csproj）に参照を追加します：

```xml
<ItemGroup>
  <Reference Include="PleasanterDeveloperCommunity.DotNet.Client">
    <HintPath>path\to\PleasanterDeveloperCommunity.DotNet.Client.dll</HintPath>
  </Reference>
</ItemGroup>
```

3. 依存パッケージをプロジェクトに追加します：

```bash
dotnet add package CsvHelper
dotnet add package Microsoft.AspNet.WebApi.Client
dotnet add package Newtonsoft.Json
dotnet add package System.ComponentModel.Annotations
dotnet add package System.Threading.Channels
dotnet add package UUIDNext
```

## 使用方法

[Wiki](https://github.com/pleasanter-developer-community/PleasanterDeveloperCommunity.DotNet.Client/wiki)を参照してください。

## サードパーティライセンス

このプロジェクトは以下のサードパーティライブラリを使用しています：

[![CsvHelper](https://img.shields.io/badge/CsvHelper-MS--PL%20%2F%20Apache--2.0-green)](https://www.nuget.org/packages/CsvHelper) [![Microsoft.AspNet.WebApi.Client](https://img.shields.io/badge/Microsoft.AspNet.WebApi.Client-MIT-green)](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Client) [![Newtonsoft.Json](https://img.shields.io/badge/Newtonsoft.Json-MIT-green)](https://www.nuget.org/packages/Newtonsoft.Json) [![System.ComponentModel.Annotations](https://img.shields.io/badge/System.ComponentModel.Annotations-MIT-green)](https://www.nuget.org/packages/System.ComponentModel.Annotations) [![System.Threading.Channels](https://img.shields.io/badge/System.Threading.Channels-MIT-green)](https://www.nuget.org/packages/System.Threading.Channels) [![UUIDNext](https://img.shields.io/badge/UUIDNext-MIT-green)](https://www.nuget.org/packages/UUIDNext)
