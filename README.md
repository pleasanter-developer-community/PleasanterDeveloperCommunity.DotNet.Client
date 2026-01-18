# PleasanterDeveloperCommunity.DotNet.Client

PleasanterDeveloperCommunity.DotNet.Clientは、オープンソースのWebデータベース「プリザンター」のAPIを.NETアプリケーションから簡単に利用するためのクライアントライブラリです。レコードの取得・作成・更新・一括処理や拡張SQLの実行など、プリザンターAPIの主要な機能を型安全かつ直感的に操作できます。非同期処理に対応し、プロキシ設定やデバッグログ出力などの柔軟なオプションも備えています。.NET Standard 2.1に対応しているため、.NET Core、.NET 5以降、Xamarinなど幅広いプラットフォームで利用可能です。

## インストール

1. Releasesページから[最新のアーカイブ](https://github.com/pleasanter-developer-community/PleasanterDeveloperCommunity.DotNet.Client/releases/latest)を取得するか下記のソースからビルドし、下記のファイルをプロジェクトにコピーします：
   - `PleasanterDeveloperCommunity.DotNet.Client.dll`

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

## ライセンス

このプロジェクトは [LGPL-2.1](LICENSE) でライセンスされています。

## サードパーティライセンス

このプロジェクトは以下のサードパーティライブラリを使用しています：

| ライブラリ | ライセンス |
|---------|---------|
| [CsvHelper](https://www.nuget.org/packages/CsvHelper) | [MS-PL / Apache-2.0](https://www.nuget.org/packages/CsvHelper/33.1.0/license) |
| [Microsoft.AspNet.WebApi.Client](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Client) | [MIT](https://licenses.nuget.org/MIT) |
| [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) | [MIT](https://licenses.nuget.org/MIT) |
| [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) | [MIT](https://licenses.nuget.org/MIT) |
| [System.Threading.Channels](https://www.nuget.org/packages/System.Threading.Channels) | [MIT](https://licenses.nuget.org/MIT) |
| [UUIDNext](https://www.nuget.org/packages/UUIDNext) | [MIT](https://licenses.nuget.org/MIT) |
