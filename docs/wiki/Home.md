# PleasanterDeveloperCommunity.DotNet.Client

## 動作要件

- プリザンター 1.3.13.0以降
  - 使用されている.NETスタックがサポート期間中であるバージョンの仕様を推奨
  - .NET Framework版は非対応
  - このクライアントは**プリザンター 1.5.0.0 のソースコードを参考に実装**
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

このライブラリが対応しているPleasanter APIの一覧です。

> **Note:** 各APIの詳細については、[プリザンター公式マニュアル](https://pleasanter.org/ja/manual)を参照してください。APIの洗い出しは[ソースコード](https://github.com/Implem/Implem.Pleasanter)からおこなっているためマニュアルにないものも網羅しています。マニュアルに存在しないものはコードを参照してください。

### 概要

| # | カテゴリ | コントローラー | API数 | 対応 | 未対応 |
|:-:|:---------|:---------------|:-----:|:----:|:------:|
| 01 | テーブル操作 | ItemsController | 9 | 9 | 0 |
| 02 | サイト操作 | ItemsController | 8 | 8 | 0 |
| 03 | ユーザ操作 | UsersController | 5 | 5 | 0 |
| 04 | グループ操作 | GroupsController | 5 | 5 | 0 |
| 05 | 組織操作 | DeptsController | 5 | 5 | 0 |
| 06 | セッション操作 | SessionsController | 3 | 3 | 0 |
| 07 | メール操作 | OutgoingMailsController | 1 | 1 | 0 |
| 08 | バイナリ操作 | BinariesController | 4 | 4 | 0 |
| 09 | 拡張SQL | ExtendedController | 1 | 1 | 0 |
| 10 | 拡張機能操作 | ExtensionsController | 4 | 4 | 0 |
| 11 | ユーティリティ | UtilityController | 1 | 1 | 0 |
| 12 | バックグラウンドタスク | BackgroundTasksController | 2 | 2 | 0 |
| 13 | デモ | DemoController | 1 | 1 | 0 |
| | **合計** | | **49** | **49** | **0** |

### 01. テーブル操作

`Route: api/items`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/items/{id}/get` | 取得 | レコードまたはテーブルのレコード一覧を取得 | ✓ |
| 2 | `/api/items/{id}/create` | 作成 | 新しいレコードを作成 | ✓ |
| 3 | `/api/items/{id}/update` | 更新 | 既存レコードを更新 | ✓ |
| 4 | `/api/items/{id}/upsert` | 作成・更新 | キーに基づいてレコードを作成または更新 | ✓ |
| 5 | `/api/items/{id}/delete` | 削除 | レコードを削除 | ✓ |
| 6 | `/api/items/{id}/bulkdelete` | 一括削除 | 複数レコードを一括削除 | ✓ |
| 7 | `/api/items/{id}/bulkupsert` | 一括作成・更新 | 複数レコードを一括で作成または更新 | ✓ |
| 8 | `/api/items/{id}/import` | インポート | CSVファイルをインポート | ✓ |
| 9 | `/api/items/{id}/export` | エクスポート | テーブルをCSV/JSON形式でエクスポート | ✓ |

### 02. サイト操作

`Route: api/items`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/items/{id}/getsite` | サイト取得 | サイト情報を取得 | ✓ |
| 2 | `/api/items/{id}/createsite` | サイト作成 | 新しいサイトを作成 | ✓ |
| 3 | `/api/items/{id}/updatesite` | サイト更新 | サイト情報を更新 | ✓ |
| 4 | `/api/items/{id}/deletesite` | サイト削除 | サイトを削除 | ✓ |
| 5 | `/api/items/{id}/copysitepackage` | サイトコピー | サイトパッケージをコピー | ✓ |
| 6 | `/api/items/{id}/synchronizesummaries` | 集計同期 | 集計を同期 | ✓ |
| 7 | `/api/items/{id}/updatesitesettings` | サイト設定更新 | サイト設定を部分更新 | ✓ |
| 8 | `/api/items/{id}/getclosestsiteid` | サイトID取得 | サイト名検索で最も近いサイトIDを取得 | ✓ |

### 03. ユーザ操作

`Route: api/users`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/users/get`<br>`/api/users/{id}/get` | 取得 | ユーザ情報を取得（全体または個別） | ✓ |
| 2 | `/api/users/create` | 作成 | 新しいユーザを作成 | ✓ |
| 3 | `/api/users/{id}/update` | 更新 | ユーザ情報を更新 | ✓ |
| 4 | `/api/users/{id}/delete` | 削除 | ユーザを削除 | ✓ |
| 5 | `/api/users/import` | インポート | ユーザをCSVインポート | ✓ |

### 04. グループ操作

`Route: api/groups`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/groups/get`<br>`/api/groups/{id}/get` | 取得 | グループ情報を取得（全体または個別） | ✓ |
| 2 | `/api/groups/create` | 作成 | 新しいグループを作成 | ✓ |
| 3 | `/api/groups/{id}/update` | 更新 | グループ情報を更新 | ✓ |
| 4 | `/api/groups/{id}/delete` | 削除 | グループを削除 | ✓ |
| 5 | `/api/groups/import` | インポート | グループをCSVインポート | ✓ |

### 05. 組織操作

`Route: api/depts`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/depts/get`<br>`/api/depts/{id}/get` | 取得 | 組織情報を取得（全体または個別） | ✓ |
| 2 | `/api/depts/create` | 作成 | 新しい組織を作成 | ✓ |
| 3 | `/api/depts/{id}/update` | 更新 | 組織情報を更新 | ✓ |
| 4 | `/api/depts/{id}/delete` | 削除 | 組織を削除 | ✓ |
| 5 | `/api/depts/import` | インポート | 組織をCSVインポート | ✓ |

### 06. セッション操作

`Route: api/sessions`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/sessions/get` | 取得 | セッション情報を取得 | ✓ |
| 2 | `/api/sessions/set` | 設定 | セッション情報を設定 | ✓ |
| 3 | `/api/sessions/delete` | 削除 | セッション情報を削除 | ✓ |

### 07. メール操作

`Route: api`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/items/{id}/outgoingmails/send` | 送信 | メールを送信 | ✓ |

### 08. バイナリ操作

`Route: api/binaries`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/binaries/{guid}/get` | 取得 | 添付ファイル情報をBase64形式で取得 | ✓ |
| 2 | `/api/binaries/{guid}/getstream` | ストリーム取得 | 添付ファイルをストリームとして取得 | ✓ |
| 3 | `/api/binaries/{siteId}/upload` | アップロード | ファイルをアップロード（Base64） | ✓ |
| 4 | `/api/binaries/upload` | ストリームアップロード | ファイルをストリームでアップロード（Bearer認証） | ✓ |

### 09. 拡張SQL

`Route: api/extended`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/extended/sql` | 実行 | 事前定義された拡張SQLを実行 | ✓ |

### 10. 拡張機能操作

`Route: api/extensions`

> **注意:** この機能には `AllowExtensionsApi` の有効化と特権が必要です。

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/extensions/get`<br>`/api/extensions/{id}/get` | 取得 | 拡張機能情報を取得 | ✓ |
| 2 | `/api/extensions/create` | 作成 | 新しい拡張機能を作成 | ✓ |
| 3 | `/api/extensions/{id}/update` | 更新 | 拡張機能を更新 | ✓ |
| 4 | `/api/extensions/{id}/delete` | 削除 | 拡張機能を削除 | ✓ |

### 11. ユーティリティ

`Route: api/utility`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/utility/getlicenseinfo` | ライセンス情報取得 | ライセンス情報を取得 | ✓ |

### 12. バックグラウンドタスク

`Route: api/backgroundtasks`

> **注意:** この機能には `BackgroundTask.Enabled` パラメータの有効化が必要です。

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/backgroundtasks/rebuildsearchindexes` | 全サイト検索インデックス再構築 | 全サイトの検索インデックスを再構築 | ✓ |
| 2 | `/api/backgroundtasks/{id}/rebuildsearchindexes` | 検索インデックス再構築 | 特定サイトの検索インデックスを再構築 | ✓ |

### 13. デモ

`Route: api/demo`

> **注意:** この機能には `Service.DemoApi` パラメータの有効化が必要です。

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/demo/register` | 登録 | デモ環境を登録 | ✓ |

## Thanks

このWikiは[sync-docs-to-wiki](https://github.com/ShoWaka/sync-docs-to-wiki)をベースに、本体レポジトリのdocsがWikiに自動同期される仕組みを構築しています。
