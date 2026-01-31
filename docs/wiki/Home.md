# PleasanterDeveloperCommunity.DotNet.Client

## 動作要件

- プリザンター 1.3.13.0以降
  - 使用されている.NETスタックがサポート期間中であるバージョンの仕様を推奨
  - .NET Framework版は非対応
- プリザンター ApiVersion 1.1以降
  - Api.jsonの設定で1.0を指定した場合でも1.1以降のバージョンを強制指定
- .NET Standard 2.1対応環境（.NET Core 3.0以降、.NET 5以降、Xamarinなど）

## 基本的な使い方

```csharp
using PleasanterDeveloperCommunity.DotNet.Client;

// クライアントの初期化
using var client = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key"
);
```

## オプション設定

PleasanterClientでは、さまざまなオプション設定が可能です。

### パラメータ一覧

#### 標準コンストラクタ

| パラメータ名                       | 型               | 必須 | 説明                                                                           |
|:-----------------------------------|:-----------------|:----:|:-------------------------------------------------------------------------------|
| `baseUrl`                          | `string`         |  ✓   | プリザンターのベースURL（例: `https://example.com/pleasanter`）                |
| `apiKey`                           | `string`         |  ✓   | APIキー                                                                        |
| `apiVersion`                       | `float`          |      | APIバージョン（省略時: 1.1、最小値: 1.1）                                      |
| `defaultTimeout`                   | `TimeSpan?`      |      | デフォルトのリクエストタイムアウト（省略時：HttpClientのデフォルト値 100秒）   |
| `proxySettings`                    | `ProxySettings?` |      | プロキシ設定（省略時：OS設定に従う）                                           |
| `ignoreSslCertificateValidation`   | `bool`           |      | SSL証明書の検証を無効にするかどうか（省略時: false）。開発・テスト環境でのみ使用 |
| `debugSettings`                    | `DebugSettings?` |      | デバッグ設定（省略時：デバッグモード無効）                                     |

#### HttpClient指定コンストラクタ

| パラメータ名    | 型               | 必須 | 説明                                                            |
|:----------------|:-----------------|:----:|:----------------------------------------------------------------|
| `baseUrl`       | `string`         |  ✓   | プリザンターのベースURL（例: `https://example.com/pleasanter`） |
| `apiKey`        | `string`         |  ✓   | APIキー                                                         |
| `httpClient`    | `HttpClient`     |  ✓   | 外部から渡すHttpClientインスタンス                              |
| `apiVersion`    | `float`          |      | APIバージョン（省略時: 1.1、最小値: 1.1）                       |
| `debugSettings` | `DebugSettings?` |      | デバッグ設定（省略時：デバッグモード無効）                      |

##### 使用シチュエーション

- **DIコンテナとの統合**: ASP.NET CoreのIHttpClientFactoryなど、DIコンテナで管理されたHttpClientを使用する場合
- **共有HttpClient**: 複数のPleasanterClientインスタンスで同一のHttpClientを共有したい場合
- **カスタム設定**: 標準コンストラクタでサポートされていない高度なHttpClient設定（カスタムハンドラー、ポリシーなど）が必要な場合
- **テスト**: モックHttpClientを注入してユニットテストを行う場合

### APIバージョン

APIバージョンをコンストラクタで指定できます。

- **デフォルト値**: 1.1
- **最小値**: 1.1
- **形式**: リクエストJSON内では`"1.1"`のような文字列形式でシリアライズされます

```csharp
// APIバージョンを明示的に指定
using var client = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key",
    apiVersion: 1.1f
);
```

### リクエストモデルの使用

各APIメソッドには、パラメータを個別に指定するオーバーロードと、リクエストモデルを使用するオーバーロードの2種類があります。

#### パラメータ指定版

```csharp
// パラメータを個別に指定
var result = await client.CreateRecordAsync(
    siteId: 456,
    title: "タイトル",
    body: "内容",
    status: 100
);
```

#### リクエストモデル版

```csharp
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

// リクエストモデルを使用
var request = new CreateRecordRequest
{
    Title = "タイトル",
    Body = "内容",
    Status = 100
};

var result = await client.CreateRecordAsync(siteId: 456, request: request);
```

リクエストモデルは以下の名前空間で提供されます：

| 名前空間 | 説明 |
|:---------|:-----|
| `Models.Requests.Items` | テーブル・レコード操作のリクエストモデル |
| `Models.Requests.Sites` | サイト操作のリクエストモデル |
| `Models.Requests.Binaries` | 添付ファイル取得のリクエストモデル |
| `Models.Requests.Extended` | 拡張SQL実行のリクエストモデル |

### タイムアウト設定

```csharp
using var client = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key",
    defaultTimeout: TimeSpan.FromSeconds(30)
);
```

### プロキシ設定

```csharp
// OS設定のプロキシを使用（デフォルト動作、proxySettingsを省略した場合と同じ）
using var clientSystemProxy = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key",
    proxySettings: ProxySettings.UseSystemDefault
);

// カスタムプロキシ
using var clientWithProxy = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key",
    proxySettings: ProxySettings.Custom("http://proxy:8080")
);

// 認証付きプロキシ
using var clientWithAuthProxy = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key",
    proxySettings: ProxySettings.Custom(
        proxyAddress: "http://proxy:8080",
        username: "proxyuser",
        password: "proxypassword"
    )
);

// IWebProxyを直接指定（ドメイン認証など高度な設定が必要な場合）
var proxy = new WebProxy("http://proxy:8080")
{
    Credentials = new NetworkCredential("user", "password", "domain")
};
using var clientWithCustomProxy = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key",
    proxySettings: ProxySettings.Custom(proxy)
);

// プロキシなし（OS設定を無視してプロキシを使用しない）
using var clientNoProxy = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key",
    proxySettings: ProxySettings.NoProxy
);
```

### SSL証明書検証の無効化

開発・テスト環境でのみ使用してください。

```csharp
using var clientDevMode = new PleasanterClient(
    baseUrl: "https://localhost/pleasanter",
    apiKey: "your-api-key",
    ignoreSslCertificateValidation: true
);
```

### デバッグ設定

PleasanterClientにはAPIリクエストとレスポンスをログファイルに記録するデバッグ機能があります。問題のトラブルシューティングやAPI通信の確認に役立ちます。

#### 基本的な使い方

```csharp
using var client = new PleasanterClient(
    baseUrl: "https://example.com/pleasanter",
    apiKey: "your-api-key",
    debugSettings: new DebugSettings(
        logDirectory: @"C:\Logs\PleasanterDebug",
        maskApiKey: true
    )
);
```

#### DebugSettingsのオプション

| パラメータ     | 型         | 必須 | デフォルト値   | 説明                                   |
|:--------------|:-----------|:----:|:--------------|:---------------------------------------|
| `logDirectory` | `string`   |  ✓   | -             | ログファイルの出力先ディレクトリパス       |
| `encoding`     | `Encoding` |  -   | システム規定    | CSVファイルのエンコーディング             |
| `maskApiKey`   | `bool`     |  -   | `true`        | APIキーをマスクして出力するかどうか       |

#### ファクトリメソッド

```csharp
// システム規定のエンコーディングを使用
var settings = DebugSettings.WithSystemDefaultEncoding(@"C:\Logs");

// UTF-8エンコーディングを使用
var settings = DebugSettings.WithUtf8Encoding(@"C:\Logs");

// 任意のエンコーディングを指定
var settings = DebugSettings.WithEncoding(@"C:\Logs", Encoding.GetEncoding("Shift_JIS"));
```

#### 出力されるログ

デバッグ機能を有効にすると、以下の情報がCSVファイルに記録されます：

| フィールド | 説明                           | 備考                                                                     |
|:-----------|:-------------------------------|:-------------------------------------------------------------------------|
| Timestamp  | リクエスト/レスポンスの日時    |                                                                          |
| RequestId  | リクエストを識別するためのID   | UUID v7形式                                                              |
| Type       | ログの種類                     | `Request`、`Response`、または `Exception`                                |
| Url        | リクエストURL                  |                                                                          |
| StatusCode | HTTPステータスコード           | レスポンスのみ                                                           |
| IsJson     | レスポンスがJSON形式かどうか   | レスポンスのみ                                                           |
| Content    | リクエスト/レスポンスのボディ  | 例外の場合はスタックトレースを含む詳細情報                               |

#### 例外ハンドリング

API呼び出し中に例外が発生した場合、その詳細情報がログに記録されます：

- **Type**: `Exception` としてログに記録
- **Content**: 例外の型名、メッセージ、スタックトレースを含む
- **InnerException**: ネストされた内部例外も再帰的に展開
- **AggregateException**: 複数の内部例外がある場合はすべて展開

```
// ログ出力例
System.Net.Http.HttpRequestException: Connection refused
StackTrace:
  at System.Net.Http.HttpClient.SendAsync(...)
  at PleasanterDeveloperCommunity.DotNet.Client.PleasanterClient.SendRequestAsync(...)

  [InnerException] System.Net.Sockets.SocketException: Connection refused
  StackTrace:
    at System.Net.Sockets.Socket.Connect(...)
```

#### APIキーのマスク

セキュリティのため、デフォルトでAPIキーはマスクされて記録されます：

```csharp
// APIキーをマスク（デフォルト）
var settings = new DebugSettings(@"C:\Logs", maskApiKey: true);
// ログ出力: "ApiKey": "********"

// APIキーをマスクしない（デバッグ目的でのみ使用）
var settings = new DebugSettings(@"C:\Logs", maskApiKey: false);
// ログ出力: "ApiKey": "実際のAPIキー"
```

#### 非同期バックグラウンド処理

ログの書き込みは非同期でバックグラウンド処理されるため、アプリケーションのパフォーマンスへの影響を最小限に抑えます。ログの書き込みに失敗してもアプリケーションは停止しません。

#### 注意事項

- ログディレクトリが存在しない場合は自動的に作成されます
- ディレクトリへの書き込み権限がない場合は例外がスローされます
- クライアントを`Dispose`する際にログの書き込みが完了するまで待機します

## 対応API

これらの表の対応Verはプリザンターのバージョンを示します。

> **Note:** 各APIの詳細については、[プリザンター公式マニュアル](https://pleasanter.org/ja/manual)を参照してください。APIの洗い出しは[ソースコード](https://github.com/Implem/Implem.Pleasanter)からおこなっているためマニュアルにないものも網羅しています。マニュアルに存在しないものはコードを参照してください。

### 01.テーブル操作

| #  | 対応Ver  | 対象       | 操作               | エンドポイント                            |
|:--:|:--------:|:-----------|:-------------------|:------------------------------------------|
| 01 | 1.3.13.0 | レコード   | 作成               | /api/items/{siteId}/create                |
| 02 | 1.3.13.0 | テーブル   | インポート         | /api/items/{siteId}/import                |
| 03 | 1.3.13.0 | レコード   | 取得(単一)         | /api/items/{recordId}/get                 |
| 04 | 1.3.13.0 | テーブル   | 取得(複数)         | /api/items/{siteId}/get                   |
| 05 | 1.3.13.0 | レコード   | 取得(添付ファイル) | /api/items/{recordId}/binaries/{guid}/get |
| 06 | 1.3.13.0 | テーブル   | エクスポート       | /api/items/{siteId}/export                |
| 07 | 1.3.13.0 | レコード   | 更新               | /api/items/{recordId}/update              |
| 08 | 1.3.13.0 | テーブル   | 作成・更新         | /api/items/{siteId}/upsert                |
| 09 | 1.4.6.0  | テーブル   | 一括作成・更新     | /api/items/{siteId}/bulkupsert            |
| 10 | 1.3.13.0 | レコード   | 削除               | /api/items/{recordId}/delete              |
| 11 | 1.3.13.0 | テーブル   | 一括削除           | /api/items/{siteId}/bulkdelete            |

### 02.サイト操作

| #  | 対応Ver  | 対象     | 操作                                   | エンドポイント                           |
|:--:|:--------:|:---------|:---------------------------------------|:-----------------------------------------|
| 01 | 1.3.13.0 | サイト   | 作成                                   | /api/sites/{parentId}/create             |
| 02 | 1.3.13.0 | サイト   | コピー                                 | /api/sites/{siteId}/copy                 |
| 03 | 1.3.13.0 | サイト   | 取得                                   | /api/items/{siteId}/getsite              |
| 04 | 1.4.5.0  | サイト   | 検索で該当サイトに最も近いサイトID取得 | /api/items/{siteId}/getclosestsiteid     |
| 05 | 1.3.13.0 | サイト   | 更新                                   | /api/items/{siteId}/updatesite           |
| 06 |          | サイト   | 設定更新（部分追加/更新/削除）         | /api/sites/{siteId}/updatesitesettings   |
| 07 |          | サイト   | サマリ同期                             | /api/sites/{siteId}/synchronizesummaries |
| 08 |          | サイト   | 検索インデックス再構築                 | /api/sites/{siteId}/rebuildsearchindexes |
| 09 |          | サイト   | 削除                                   | /api/sites/{siteId}/delete               |

### 03.ユーザ操作

| #  | 対応Ver | 対象     | 操作       | エンドポイント             |
|:--:|:-------:|:---------|:-----------|:---------------------------|
| 01 |         | ユーザ   | 作成       | /api/users/create          |
| 02 |         | ユーザ   | インポート | /api/users/import          |
| 03 |         | ユーザ   | 取得(全て) | /api/users/get             |
| 04 |         | ユーザ   | 取得       | /api/users/{userId}/get    |
| 05 |         | ユーザ   | 更新       | /api/users/{userId}/update |
| 06 |         | ユーザ   | 削除       | /api/users/{userId}/delete |

### 04.グループ操作

| #  | 対応Ver | 対象       | 操作       | エンドポイント               |
|:--:|:-------:|:-----------|:-----------|:-----------------------------|
| 01 |         | グループ   | 作成       | /api/groups/create           |
| 02 |         | グループ   | インポート | /api/groups/import           |
| 03 |         | グループ   | 取得       | /api/groups/{groupId}/get    |
| 04 |         | グループ   | 更新       | /api/groups/{groupId}/update |
| 05 |         | グループ   | 削除       | /api/groups/{groupId}/delete |

### 05.組織操作

| #  | 対応Ver | 対象 | 操作       | エンドポイント             |
|:--:|:-------:|:-----|:-----------|:---------------------------|
| 01 |         | 組織 | 作成       | /api/depts/create          |
| 02 |         | 組織 | インポート | /api/depts/import          |
| 03 |         | 組織 | 取得       | /api/depts/{deptId}/get    |
| 04 |         | 組織 | 更新       | /api/depts/{deptId}/update |
| 05 |         | 組織 | 削除       | /api/depts/{deptId}/delete |

### 06.メール

| #  | 対応Ver | 対象     | 操作 | エンドポイント           |
|:--:|:-------:|:---------|:-----|:-------------------------|
| 01 |         | メール   | 送信 | /api/items/{siteId}/mail |

### 09.その他

| #  | 対応Ver  | 対象    | 操作       | エンドポイント      |
|:--:|:--------:|:--------|:-----------|:--------------------|
| 01 | 1.3.13.0 | 拡張SQL | 取得(実行) | /api/extended/sql   |

## Thanks

このWikiは[sync-docs-to-wiki](https://github.com/ShoWaka/sync-docs-to-wiki)をベースに、本体レポジトリのdocsがWikiに自動同期される仕組みを構築しています。
