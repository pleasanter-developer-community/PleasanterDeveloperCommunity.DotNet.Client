# PleasanterDeveloperCommunity.DotNet.Client

PleasanterDeveloperCommunity.DotNet.Clientは、オープンソースのWebデータベース「プリザンター」のAPIを.NETアプリケーションから簡単に利用するためのクライアントライブラリです。レコードの取得・作成・更新・一括処理や拡張SQLの実行など、プリザンターAPIの主要な機能を型安全かつ直感的に操作できます。非同期処理に対応し、プロキシ設定やデバッグログ出力などの柔軟なオプションも備えています。.NET Standard 2.1に対応しているため、.NET Core、.NET 5以降、Xamarinなど幅広いプラットフォームで利用可能です。

## ライセンス

このプロジェクトは [LGPL-2.1](LICENSE) でライセンスされています。

## サードパーティライセンス

このプロジェクトは以下のサードパーティライブラリを使用しています：

| ライブラリ | バージョン | ライセンス | 説明 |
|---------|---------|---------|-----|
| [CsvHelper](https://www.nuget.org/packages/CsvHelper) | 33.1.0 | [MS-PL / Apache-2.0](https://www.nuget.org/packages/CsvHelper/33.1.0/license) | CSVファイルの読み書きを行うためのライブラリ |
| [Microsoft.AspNet.WebApi.Client](https://www.nuget.org/packages/Microsoft.AspNet.WebApi.Client) | 6.0.0 | [MIT](https://licenses.nuget.org/MIT) | HTTP通信とWeb APIクライアント機能を提供 |
| [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json) | 13.0.4 | [MIT](https://licenses.nuget.org/MIT) | JSONのシリアライズ・デシリアライズを行うライブラリ |
| [System.ComponentModel.Annotations](https://www.nuget.org/packages/System.ComponentModel.Annotations) | 5.0.0 | [MIT](https://licenses.nuget.org/MIT) | データ検証用の属性を提供 |
| [System.Threading.Channels](https://www.nuget.org/packages/System.Threading.Channels) | 10.0.2 | [MIT](https://licenses.nuget.org/MIT) | 非同期データストリーム処理のためのチャネル機能を提供 |
| [UUIDNext](https://www.nuget.org/packages/UUIDNext) | 4.2.3 | [MIT](https://licenses.nuget.org/MIT) | UUID v7などの新しいUUID形式を生成するライブラリ |

## インストール

1. `dist`フォルダから以下のファイルをプロジェクトにコピーします：
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

### 基本的な使い方

```csharp
using PleasanterDeveloperCommunity.DotNet.Client;

// クライアントの初期化
using var client = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key"
);
```

### レコードの取得

```csharp
// 単一レコードの取得
var record = await client.GetRecordAsync(recordId: 123);

// 複数レコードの取得
var records = await client.GetRecordsAsync(siteId: 456);

// ページングを自動処理して全レコードを取得
var allRecords = await client.GetAllRecordsAsync(siteId: 456);
```

#### GetRecordAsync - 単一レコードの取得

| 引数 | 型 | 必須 | 説明 |
|------|------|:----:|------|
| `recordId` | long | ✓ | レコードID（IssueIdまたはResultId） |
| `view` | View | | ビュー設定（取得する列の指定など） |
| `timeout` | TimeSpan? | | リクエストタイムアウト |

#### GetRecordsAsync - 複数レコードの取得

| 引数 | 型 | 必須 | 説明 |
|------|------|:----:|------|
| `siteId` | long | ✓ | サイトID |
| `offset` | int? | | 取得開始位置（ページネーション用） |
| `view` | View | | ビュー設定（フィルタや並び替えなど） |
| `timeout` | TimeSpan? | | リクエストタイムアウト |

#### GetAllRecordsAsync - 全レコードの取得

| 引数 | 型 | 必須 | 説明 |
|------|------|:----:|------|
| `siteId` | long | ✓ | サイトID |
| `view` | View | | ビュー設定（フィルタや並び替えなど） |
| `timeout` | TimeSpan? | | リクエストタイムアウト |

### ビュー設定を使用した取得

```csharp
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;

var view = new View
{
    ColumnFilterHash = new Dictionary<string, string>
    {
        { "ClassA", "検索値" }
    },
    ColumnSorterHash = new Dictionary<string, SortOrderType>
    {
        { "CreatedTime", SortOrderType.Desc }
    }
};

var records = await client.GetRecordsAsync(siteId: 456, view: view);
```

#### Viewクラスのプロパティ

| プロパティ | 型 | 説明 |
|-----------|------|------|
| `Incomplete` | bool? | 未完了のレコードのみ取得 |
| `Own` | bool? | 自分が担当のレコードのみ取得 |
| `NearCompletionTime` | bool? | 期限が近いレコードのみ取得 |
| `Delay` | bool? | 遅延しているレコードのみ取得 |
| `Overdue` | bool? | 期限超過のレコードのみ取得 |
| `Search` | string | 全文検索キーワード |
| `ColumnFilterHash` | Dictionary\<string, string\> | 列フィルタ設定（キー: 列名、値: フィルタ値） |
| `ColumnFilterSearchTypes` | Dictionary\<string, ColumnFilterSearchType\> | 列フィルタ検索タイプ |
| `ColumnFilterNegatives` | List\<string\> | 否定フィルタ対象の列名 |
| `ColumnSorterHash` | Dictionary\<string, SortOrderType\> | ソート設定（キー: 列名、値: Asc/Desc） |
| `ApiDataType` | ApiDataType? | APIデータタイプ |
| `ApiColumnKeyDisplayType` | ApiColumnKeyDisplayType? | APIカラムキー表示タイプ（KeyValues時のみ） |
| `ApiColumnValueDisplayType` | ApiColumnValueDisplayType? | APIカラム値表示タイプ（KeyValues時のみ） |
| `ApiColumnHash` | Dictionary\<string, ApiColumnSetting\> | 項目単位のKey/Value表示形式設定 |
| `GridColumns` | List\<string\> | 返却される項目を制御する配列 |
| `MergeSessionViewFilters` | bool? | セッションのフィルタ条件とマージするか |
| `MergeSessionViewSorters` | bool? | セッションのソート条件とマージするか |

#### 列挙体

##### SortOrderType - ソート順タイプ

| 値 | 説明 |
|------|------|
| `Asc` | 昇順 |
| `Desc` | 降順 |

##### ColumnFilterSearchType - 列フィルタ検索タイプ

| 値 | 説明 |
|------|------|
| `PartialMatch` | 部分一致 |
| `ExactMatch` | 完全一致 |
| `ForwardMatch` | 前方一致 |
| `PartialMatchMultiple` | 部分一致（複数） |
| `ExactMatchMultiple` | 完全一致（複数） |
| `ForwardMatchMultiple` | 前方一致（複数） |

##### ApiDataType - APIデータタイプ

| 値 | 説明 |
|------|------|
| `Default` | デフォルト（Keyはカラム名、Valueは値） |
| `KeyValues` | KeyValues形式（Keyは表示名、Valueは表示値） |

##### ApiColumnKeyDisplayType - APIカラムキー表示タイプ

| 値 | 説明 |
|------|------|
| `LabelText` | 表示名 |
| `ColumnName` | カラム名 |

##### ApiColumnValueDisplayType - APIカラム値表示タイプ

| 値 | 説明 |
|------|------|
| `DisplayValue` | 表示名 |
| `Value` | 値（データベース上に登録されている値） |
| `Text` | 書式や単位等も含めた値 |

### レコードの作成

#### CreateRecordAsync

| 引数 | 型 | 必須 | 説明 |
|------|------|:----:|------|
| `siteId` | long | ✓ | サイトID |
| `title` | string | | タイトル |
| `body` | string | | 内容 |
| `status` | int? | | 状況 |
| `manager` | int? | | 管理者 |
| `owner` | int? | | 担当者 |
| `completionTime` | string | | 完了日時 |
| `classHash` | Dictionary\<string, string\> | | 分類項目 |
| `numHash` | Dictionary\<string, decimal\> | | 数値項目 |
| `dateHash` | Dictionary\<string, string\> | | 日付項目 |
| `descriptionHash` | Dictionary\<string, string\> | | 説明項目 |
| `checkHash` | Dictionary\<string, bool\> | | チェック項目 |
| `attachmentsHash` | Dictionary\<string, List\<AttachmentData\>\> | | 添付ファイル項目 |
| `processId` | int? | | プロセスID |
| `processIds` | List\<int\> | | 複数のプロセスID |
| `imageHash` | Dictionary\<string, ImageSettings\> | | 画像挿入設定 |
| `timeout` | TimeSpan? | | リクエストタイムアウト |

```csharp
// 基本的な作成
var result = await client.CreateRecordAsync(
    siteId: 456,
    title: "タイトル",
    body: "内容",
    status: 100,
    classHash: new Dictionary<string, string>
    {
        { "ClassA", "分類A" }
    },
    numHash: new Dictionary<string, decimal>
    {
        { "NumA", 123.45m }
    }
);
```

### レコードの作成または更新（Upsert）

#### UpsertRecordAsync

| 引数 | 型 | 必須 | 説明 |
|------|------|:----:|------|
| `siteId` | long | ✓ | サイトID |
| `keys` | List\<string\> | ✓ | キーとなる項目名の配列 |
| `title` | string | | タイトル |
| `body` | string | | 内容 |
| `status` | int? | | 状況 |
| `manager` | int? | | 管理者 |
| `owner` | int? | | 担当者 |
| `completionTime` | string | | 完了日時 |
| `classHash` | Dictionary\<string, string\> | | 分類項目 |
| `numHash` | Dictionary\<string, decimal\> | | 数値項目 |
| `dateHash` | Dictionary\<string, string\> | | 日付項目 |
| `descriptionHash` | Dictionary\<string, string\> | | 説明項目 |
| `checkHash` | Dictionary\<string, bool\> | | チェック項目 |
| `processId` | int? | | プロセスID |
| `processIds` | List\<int\> | | 複数のプロセスID |
| `imageHash` | Dictionary\<string, ImageSettings\> | | 画像挿入設定 |
| `timeout` | TimeSpan? | | リクエストタイムアウト |

```csharp
// キーに基づいて作成または更新
var result = await client.UpsertRecordAsync(
    siteId: 456,
    keys: new List<string> { "ClassA" },
    title: "タイトル",
    classHash: new Dictionary<string, string>
    {
        { "ClassA", "キー値" }
    }
);
```

### 一括作成・更新（BulkUpsert）

```csharp
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

var data = new List<BulkUpsertRecordData>
{
    new BulkUpsertRecordData
    {
        Title = "レコード1",
        ClassHash = new Dictionary<string, string> { { "ClassA", "値1" } }
    },
    new BulkUpsertRecordData
    {
        Title = "レコード2",
        ClassHash = new Dictionary<string, string> { { "ClassA", "値2" } }
    }
};

var result = await client.BulkUpsertRecordAsync(
    siteId: 456,
    data: data,
    keys: new List<string> { "ClassA" }
);
```

#### BulkUpsertRecordAsync

| 引数 | 型 | 必須 | 説明 |
|------|------|:----:|------|
| `siteId` | long | ✓ | サイトID |
| `data` | List\<BulkUpsertRecordData\> | ✓ | レコードデータの配列 |
| `keys` | List\<string\> | | キーとなる項目名の配列（省略時：全てのレコードを新規作成） |
| `keyNotFoundCreate` | bool? | | キーと一致するレコードが無い場合に新規作成するかどうか（省略時：true） |
| `timeout` | TimeSpan? | | リクエストタイムアウト |

### 拡張SQLの実行

```csharp
var result = await client.ExecuteExtendedSqlAsync(
    name: "MyExtendedSql",
    parameters: new Dictionary<string, object>
    {
        { "Param1", "値" },
        { "Param2", 123 }
    }
);
```

#### ExecuteExtendedSqlAsync

| 引数 | 型 | 必須 | 説明 |
|------|------|:----:|------|
| `name` | string | ✓ | 拡張SQLの名前（JSONファイルで定義したName） |
| `parameters` | Dictionary\<string, object\> | | SQLに渡すパラメータ |
| `timeout` | TimeSpan? | | リクエストタイムアウト |



### オプション設定

```csharp
// タイムアウト設定
using var client = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key",
    defaultTimeout: TimeSpan.FromSeconds(30)
);

// プロキシ設定
using var clientWithProxy = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key",
    proxySettings: ProxySettings.WithCustomProxy(new WebProxy("http://proxy:8080"))
);

// プロキシなし
using var clientNoProxy = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key",
    proxySettings: ProxySettings.NoProxy
);

// SSL証明書検証の無効化（開発・テスト環境でのみ使用）
using var clientDevMode = new PleasanterClient(
    baseUrl: "https://localhost/pleasanter",
    apiKey: "your-api-key",
    ignoreSslCertificateValidation: true
);

// デバッグ設定（リクエスト・レスポンスをログ出力）
using var clientDebug = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key",
    debugSettings: new DebugSettings(
        logDirectory: @"C:\Logs",
        maskApiKey: true
    )
);
```

### レスポンスの処理

```csharp
var response = await client.GetRecordsAsync(siteId: 456);

if (response.StatusCode == System.Net.HttpStatusCode.OK)
{
    Console.WriteLine($"取得件数: {response.Response?.Data?.Count}");
    Console.WriteLine($"総件数: {response.Response?.TotalCount}");
    
    foreach (var record in response.Response?.Data ?? new List<RecordData>())
    {
        Console.WriteLine($"ID: {record.IssueId ?? record.ResultId}");
        Console.WriteLine($"タイトル: {record.Title}");
    }
}
else
{
    Console.WriteLine($"エラー: {response.Message}");
}
```

## デバッグ機能

PleasanterClientにはAPIリクエストとレスポンスをログファイルに記録するデバッグ機能があります。問題のトラブルシューティングやAPI通信の確認に役立ちます。

### デバッグ機能の有効化

```csharp
// 基本的なデバッグ設定
using var client = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key",
    debugSettings: new DebugSettings(
        logDirectory: @"C:\Logs\PleasanterDebug"
    )
);
```

### DebugSettingsのオプション

| パラメータ | 型 | 必須 | デフォルト値 | 説明 |
|-----------|------|:----:|-------------|------|
| `logDirectory` | string | ✓ | - | ログファイルの出力先ディレクトリパス |
| `encoding` | Encoding | | システム規定 | CSVファイルのエンコーディング |
| `maskApiKey` | bool | | true | APIキーをマスクして出力するかどうか |

### ファクトリメソッド

```csharp
// システム規定のエンコーディングを使用
var settings = DebugSettings.WithSystemDefaultEncoding(@"C:\Logs");

// UTF-8エンコーディングを使用
var settings = DebugSettings.WithUtf8Encoding(@"C:\Logs");

// 任意のエンコーディングを指定
var settings = DebugSettings.WithEncoding(@"C:\Logs", Encoding.GetEncoding("Shift_JIS"));
```

### 出力されるログ

デバッグ機能を有効にすると、以下の情報がCSVファイルに記録されます：

| フィールド | 説明 | 備考 |
|-----------|------|------|
| Timestamp | リクエスト/レスポンスの日時 | |
| RequestId | リクエストを識別するためのID | UUID v7形式をハイフンなしの32文字の16進数文字列で表現（例: `0194d1f0a1b2c3d4e5f6789012345678`）。タイムスタンプベースのため生成順にソート可能でログ分析に便利 |
| Type | `Request` または `Response` | |
| Url | リクエストURL | |
| StatusCode | HTTPステータスコード | レスポンスのみ |
| IsJson | レスポンスがJSON形式かどうか | レスポンスのみ |
| Content | リクエスト/レスポンスのボディ内容 | |

### APIキーのマスク

セキュリティのため、デフォルトでAPIキーはマスクされて記録されます：

```csharp
// APIキーをマスク（デフォルト）
var settings = new DebugSettings(@"C:\Logs", maskApiKey: true);
// ログ出力: "ApiKey": "********"

// APIキーをマスクしない（デバッグ目的でのみ使用）
var settings = new DebugSettings(@"C:\Logs", maskApiKey: false);
// ログ出力: "ApiKey": "実際のAPIキー"
```

### 非同期バックグラウンド処理

ログの書き込みは非同期でバックグラウンド処理されるため、アプリケーションのパフォーマンスへの影響を最小限に抑えます。ログの書き込みに失敗してもアプリケーションは停止しません。

### 注意事項

- ログディレクトリが存在しない場合は自動的に作成されます
- ディレクトリへの書き込み権限がない場合は例外がスローされます
- クライアントを`Dispose`する際にログの書き込みが完了するまで待機します

