# PleasanterDeveloperCommunity.DotNet.Client

<p>
  <a href="https://docs.microsoft.com/ja-jp/dotnet/standard/net-standard"><img src="https://img.shields.io/badge/.NET%20Standard-2.1-512BD4?logo=dotnet" alt=".NET Standard"></a>
  <a href="https://pleasanter.org/"><img src="https://img.shields.io/badge/Pleasanter-1.3.13.0%2B-00A0E9" alt="Pleasanter"></a>
  <a href="https://pleasanter.org/ja/manual/api"><img src="https://img.shields.io/badge/Pleasanter%20ApiVersion-1.1-00A0E9" alt="Pleasanter ApiVersion"></a>
  <a href="LICENSE"><img src="https://img.shields.io/badge/License-LGPL--2.1-blue.svg" alt="License"></a>
</p>

[プリザンター](https://pleasanter.org/)のAPIを.NETから簡単に利用するためのクライアントライブラリです。レコードのCRUD操作、一括処理、拡張SQL実行などを型安全に扱えます。

## インストール

### 方法1: NuGetパッケージ（推奨）

[Releasesページ](https://github.com/pleasanter-developer-community/PleasanterDeveloperCommunity.DotNet.Client/releases/latest)から`.nupkg`ファイルをダウンロードし、ローカルフィードとして追加します：

```bash
dotnet nuget add source /path/to/nupkg/folder --name LocalPackages
dotnet add package PleasanterDeveloperCommunity.DotNet.Client
```

### 方法2: DLLを直接参照

1. [Releasesページ](https://github.com/pleasanter-developer-community/PleasanterDeveloperCommunity.DotNet.Client/releases/latest)からzipファイルをダウンロードして展開するか、ソースからビルドします。

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

<p>
  <a href="https://www.nuget.org/packages/CsvHelper"><img src="https://img.shields.io/badge/CsvHelper-MS--PL%20%2F%20Apache--2.0-green" alt="CsvHelper"></a>
  <a href="https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Client"><img src="https://img.shields.io/badge/Microsoft.AspNet.WebApi.Client-MIT-green" alt="Microsoft.AspNet.WebApi.Client"></a>
  <a href="https://www.nuget.org/packages/Newtonsoft.Json"><img src="https://img.shields.io/badge/Newtonsoft.Json-MIT-green" alt="Newtonsoft.Json"></a>
  <a href="https://www.nuget.org/packages/System.ComponentModel.Annotations"><img src="https://img.shields.io/badge/System.ComponentModel.Annotations-MIT-green" alt="System.ComponentModel.Annotations"></a>
  <a href="https://www.nuget.org/packages/System.Threading.Channels"><img src="https://img.shields.io/badge/System.Threading.Channels-MIT-green" alt="System.Threading.Channels"></a>
  <a href="https://www.nuget.org/packages/UUIDNext"><img src="https://img.shields.io/badge/UUIDNext-MIT-green" alt="UUIDNext"></a>
</p>
