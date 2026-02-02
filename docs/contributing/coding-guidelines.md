# コーディングガイドライン

このドキュメントでは、PleasanterDeveloperCommunity.DotNet.Client プロジェクトのコーディング規約について詳細に説明します。

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [基本原則](#基本原則)
    - [プロジェクト設定](#プロジェクト設定)
    - [重要な方針](#重要な方針)
- [API設計方針](#api設計方針)
    - [基本方針](#基本方針)
    - [メソッド設計](#メソッド設計)
    - [レスポンス設計](#レスポンス設計)
    - [依存関係](#依存関係)
    - [JSONシリアライゼーション](#jsonシリアライゼーション)
    - [サードパーティライセンス管理](#サードパーティライセンス管理)
- [命名規則](#命名規則)
    - [一覧表](#一覧表)
    - [詳細ルール](#詳細ルール)
- [フォーマット規則](#フォーマット規則)
    - [インデント](#インデント)
    - [中括弧](#中括弧)
    - [中括弧の配置](#中括弧の配置)
    - [スペース](#スペース)
- [コードスタイル](#コードスタイル)
    - [var の使用](#var-の使用)
    - [式形式メンバー](#式形式メンバー)
    - [パターンマッチング](#パターンマッチング)
    - [ターゲット型new式](#ターゲット型new式)
    - [using宣言](#using宣言)
    - [Index/Range演算子](#indexrange演算子)
    - [静的ローカル関数](#静的ローカル関数)
    - [非同期ストリーム](#非同期ストリーム)
    - [文字列補間（埋め込みリテラル）](#文字列補間埋め込みリテラル)
- [コメントとドキュメント](#コメントとドキュメント)
    - [XMLドキュメントコメント](#xmlドキュメントコメント)
    - [Wikiドキュメントへのリンク（seealso）](#wikiドキュメントへのリンクseealso)
    - [コメント言語](#コメント言語)
    - [TODOコメント](#todoコメント)
- [非同期プログラミング](#非同期プログラミング)
    - [基本ルール](#基本ルール)
    - [ConfigureAwait](#configureawait)
    - [同期メソッドの提供](#同期メソッドの提供)
- [エラーハンドリング](#エラーハンドリング)
    - [例外の使用](#例外の使用)
    - [例外のキャッチ](#例外のキャッチ)
- [Null安全](#null安全)
    - [Nullable参照型の活用](#nullable参照型の活用)
    - [Null結合演算子](#null結合演算子)
- [LINQ](#linq)
    - [積極的に活用](#積極的に活用)
    - [クエリ構文 vs メソッド構文](#クエリ構文-vs-メソッド構文)
- [正規表現](#正規表現)
    - [基本ルール](#基本ルール-1)
    - [コンパイル済み正規表現の再利用](#コンパイル済み正規表現の再利用)
    - [タイムアウトの設定（ReDoS対策）](#タイムアウトの設定redos対策)
    - [単純な文字列操作での代替](#単純な文字列操作での代替)
    - [非キャプチャグループの使用](#非キャプチャグループの使用)
    - [バックトラッキングの回避](#バックトラッキングの回避)
    - [パフォーマンス比較](#パフォーマンス比較)
- [ファイル構成](#ファイル構成)
    - [ディレクトリ構造](#ディレクトリ構造)
    - [usingディレクティブ](#usingディレクティブ)
    - [ファイル内の順序](#ファイル内の順序)
- [ツール設定](#ツール設定)
    - [EditorConfig](#editorconfig)
    - [Directory.Build.props](#directorybuildprops)
    - [IDE設定](#ide設定)
- [参考リンク](#参考リンク)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

---

## 基本原則

### プロジェクト設定

| 項目           | 値                |
| -------------- | ----------------- |
| ターゲット     | .NET Standard 2.1 |
| 言語バージョン | C# latest         |
| Nullable参照型 | 有効              |
| コメント言語   | 日本語            |

### 重要な方針

- **可読性を最優先**：コードは書く時間より読む時間の方が長い
- **一貫性を保つ**：既存のコードスタイルに従う
- **シンプルに保つ**：過度な抽象化を避ける
- **テスト可能な設計**：依存性の注入を考慮する

---

## API設計方針

### 基本方針

- Pleasanter APIのエンドポイントに対応するメソッドを提供
- レスポンスは型安全なモデルクラスで返却
- エラーハンドリングは例外またはResult型で統一

### メソッド設計

```csharp
// 非同期メソッドを主要APIとして提供
public async Task<ApiResponse<RecordResponse>> GetRecordAsync(
    long siteId,
    long recordId,
    CancellationToken cancellationToken = default);

// 必要に応じて同期版も提供
public ApiResponse<RecordResponse> GetRecord(long siteId, long recordId);
```

### レスポンス設計

```csharp
// 共通APIResponse<T>ラッパーで返却
public class ApiResponse<T>
{
    public int StatusCode { get; set; }
    public T? Data { get; set; }
    public string? Message { get; set; }
    public bool IsSuccess => StatusCode >= 200 && StatusCode < 300;
}
```

### 依存関係

- JSONに関する操作はNewtonsoft.Json（JSON.NET）を使用すること

### JSONシリアライゼーション

#### JsonProperty属性のルール

| ルール                                 | 説明                                                            |
| -------------------------------------- | --------------------------------------------------------------- |
| プロパティ名がJSON名と一致する場合     | `[JsonProperty]` は省略する                                     |
| プロパティ名がJSON名と異なる場合       | `[JsonProperty("JsonName")]` を明示する                         |
| CA1720（識別子に型名を含む）への対応時 | プロパティ名を変更し、`[JsonProperty("元のJSON名")]` を付与する |

#### 記述例

```csharp
// Good - プロパティ名がJSON名と一致する場合は省略
public class AttachmentBase
{
    /// <summary>ファイル名</summary>
    public string? Name { get; set; }

    /// <summary>サイズ（バイト）</summary>
    public long? Size { get; set; }
}

// Good - CA1720対応でプロパティ名を変更した場合
public class AttachmentBase
{
    /// <summary>添付ファイルのGUID</summary>
    [JsonProperty("Guid")]
    public string? AttachmentGuid { get; set; }  // "Guid" → "AttachmentGuid" に変更
}

// Bad - 名前が一致するのにJsonPropertyを付けている
public class AttachmentBase
{
    [JsonProperty("Name")]  // 不要
    public string? Name { get; set; }
}
```

#### CA1720への対応方針

`Guid` など型名と同じプロパティ名はCA1720警告の対象となる。以下の方針で対応する：

| 対応方法         | 説明                                                  |
| ---------------- | ----------------------------------------------------- |
| プロパティ名変更 | 文脈を含む名前に変更（例: `Guid` → `AttachmentGuid`） |
| JsonProperty追加 | 元のJSON名を `[JsonProperty("Guid")]` で指定          |
| 抑制は使用しない | `#pragma warning disable` や `NoWarn` での抑制は禁止  |

### サードパーティライセンス管理

新しい依存パッケージを追加する際は、以下を実施すること：

| 手順 | 内容                                                                               |
| ---- | ---------------------------------------------------------------------------------- |
| 1    | `LICENSES/` にライセンスファイルを追加（`{PackageName}.txt` 形式）                 |
| 2    | `README.md` のサードパーティライセンスセクションに著作権表示を追加                 |
| 3    | `.github/workflows/release.yml` でリリースZIPに `LICENSES/` が同梱されることを確認 |

**重要**: MIT、Apache-2.0、BSD系などのライセンスはライセンス文と著作権表示の同梱が必須。

---

## 命名規則

### 一覧表

| 要素                   | スタイル        | 例                  |
| ---------------------- | --------------- | ------------------- |
| クラス                 | PascalCase      | `PleasanterClient`  |
| インターフェース       | IPascalCase     | `IApiClient`        |
| メソッド               | PascalCase      | `GetRecordAsync`    |
| 非同期メソッド         | PascalCaseAsync | `CreateRecordAsync` |
| プロパティ             | PascalCase      | `BaseUrl`           |
| パブリックフィールド   | PascalCase      | `DefaultTimeout`    |
| プライベートフィールド | \_camelCase     | `_httpClient`       |
| パラメータ             | camelCase       | `siteId`            |
| ローカル変数           | camelCase       | `response`          |
| 定数                   | PascalCase      | `MaxRetryCount`     |
| 型パラメータ           | TPascalCase     | `TResponse`         |

### 詳細ルール

#### クラス・構造体

```csharp
// Good
public class PleasanterClient { }
public struct ApiEndpoint { }
public record CreateRecordRequest { }

// Bad
public class pleasanterClient { }  // 小文字始まり
public class Pleasanter_Client { } // アンダースコア
```

#### インターフェース

```csharp
// Good
public interface IApiClient { }
public interface IRecordRepository { }

// Bad
public interface ApiClient { }     // Iプレフィックスなし
public interface IapiClient { }    // 小文字
```

#### メソッド

```csharp
// Good
public RecordResponse GetRecord(long id) { }
public async Task<RecordResponse> GetRecordAsync(long id) { }

// Bad
public RecordResponse getRecord(long id) { }      // 小文字始まり
public async Task<RecordResponse> GetRecord(long id) { } // Asyncサフィックスなし
```

#### ヘルパーメソッド（変換系）

入力を別の形式に変換するヘルパーメソッドは `To{Output}` パターンを使用する：

```csharp
// Good - To{Output} パターン
public static string ToBase64(string filePath) { }           // File → Base64
public static byte[] ToBytes(string base64) { }              // Base64 → Bytes
public static MailAttachment ToMailAttachment(string filePath) { }  // File → MailAttachment
public static AttachmentData ToAttachmentData(string filePath) { }  // File → AttachmentData

// Bad - 命名規則の揺れ
public static byte[] FromBase64ToBytes(string base64) { }    // From...To... は使わない
public static MailAttachment CreateMailAttachment(string filePath) { }  // Create... は使わない
```

#### フィールド

```csharp
public class PleasanterClient
{
    // プライベートフィールド: アンダースコア + camelCase
    private readonly HttpClient _httpClient;
    private string _baseUrl;

    // パブリックフィールド（通常はプロパティを推奨）: PascalCase
    public static readonly int DefaultTimeout = 30;
}
```

---

## フォーマット規則

### インデント

- **スペース4つ**を使用（タブは使用しない）
- 継続行は適切にインデントする

```csharp
// Good
public async Task<ApiResponse<T>> SendRequestAsync<T>(
    string endpoint,
    HttpMethod method,
    object? body = null,
    CancellationToken cancellationToken = default)
{
    // ...
}
```

### 中括弧

**すべての制御文で中括弧を使用する**（単文でも省略しない）

```csharp
// Good
if (condition)
{
    DoSomething();
}

foreach (var item in items)
{
    Process(item);
}

// Bad
if (condition)
    DoSomething();

foreach (var item in items)
    Process(item);
```

### 中括弧の配置

Allmanスタイル（中括弧を新しい行に配置）を使用：

```csharp
// Good
public class MyClass
{
    public void MyMethod()
    {
        if (condition)
        {
            // ...
        }
        else
        {
            // ...
        }
    }
}

// Bad（K&Rスタイル）
public class MyClass {
    public void MyMethod() {
        if (condition) {
            // ...
        }
    }
}
```

### スペース

```csharp
// 制御文のキーワードと括弧の間にスペース
if (condition)
for (var i = 0; i < 10; i++)
while (running)

// メソッド名と括弧の間にスペースなし
DoSomething();
var result = Calculate(x, y);

// 二項演算子の前後にスペース
var sum = a + b;
var isValid = x > 0 && y < 100;

// カンマの後にスペース
Method(arg1, arg2, arg3);
```

---

## コードスタイル

### var の使用

型が明確な場合は `var` を使用：

```csharp
// Good
var client = new PleasanterClient();
var response = await client.GetRecordAsync(123);
var items = new List<string>();

// 型が不明確な場合は明示的に記述
IEnumerable<Record> records = GetRecords();
```

### 式形式メンバー

単一式の場合は式形式を使用：

```csharp
// Good
public string FullName => $"{FirstName} {LastName}";

public override string ToString() => $"Record({Id})";

// 複数行の場合はブロック形式
public async Task<Record> GetRecordAsync(long id)
{
    var response = await _client.GetAsync($"records/{id}");
    return await response.Content.ReadAsAsync<Record>();
}
```

### パターンマッチング

積極的に活用：

```csharp
// Good
if (obj is string text)
{
    Console.WriteLine(text.Length);
}

var message = status switch
{
    200 => "成功",
    404 => "見つかりません",
    500 => "サーバーエラー",
    _ => "不明なステータス"
};

// nullチェック
if (value is not null)
{
    Process(value);
}
```

### ターゲット型new式

型が明確な場合に使用：

```csharp
// Good
List<string> items = new();
Dictionary<string, int> map = new();
PleasanterClient client = new(settings);

// 型が不明確な場合は従来の形式
var items = new List<string>();
```

### using宣言

シンプルなusing宣言を使用：

```csharp
// Good
using var stream = new FileStream(path, FileMode.Open);
var content = await ReadAllTextAsync(stream);
// streamはスコープ終了時に自動的にDispose

// 複数のusingが必要な場合も有効
using var reader = new StreamReader(path);
using var writer = new StreamWriter(outputPath);
```

### Index/Range演算子

配列やコレクションへのアクセスに `^`（末尾から）と `..`（範囲）演算子を活用：

```csharp
var items = new[] { "a", "b", "c", "d", "e" };

// Good - Index演算子（末尾からのアクセス）
var last = items[^1];           // "e"（最後の要素）
var secondLast = items[^2];     // "d"（最後から2番目）

// Good - Range演算子（スライス）
var firstTwo = items[..2];      // ["a", "b"]
var lastTwo = items[^2..];      // ["d", "e"]
var middle = items[1..^1];      // ["b", "c", "d"]
var copy = items[..];           // 全体のコピー

// Bad - 従来の方式
var last = items[items.Length - 1];
var slice = items.Skip(1).Take(3).ToArray();
```

### 静的ローカル関数

キャプチャが不要な場合は `static` を付けてパフォーマンスを向上：

```csharp
// Good - staticローカル関数（変数をキャプチャしない）
public int Calculate(int[] values)
{
    return values.Sum(static x => x * 2);
}

public void Process(IEnumerable<string> items)
{
    var results = items.Where(static s => !string.IsNullOrEmpty(s));
    // ...
}

// Good - ヘルパー関数として
public async Task<T> ExecuteWithRetryAsync<T>(Func<Task<T>> action)
{
    static bool IsTransient(Exception ex) =>
        ex is HttpRequestException or TimeoutException;

    // ...
}

// Bad - 不要なキャプチャが発生
public int Calculate(int[] values)
{
    int multiplier = 2;  // キャプチャされる
    return values.Sum(x => x * multiplier);
}
```

### 非同期ストリーム

大量データの逐次処理には `IAsyncEnumerable<T>` を活用：

```csharp
// Good - 非同期ストリームで逐次処理
public async IAsyncEnumerable<Record> GetRecordsAsync(
    [EnumeratorCancellation] CancellationToken cancellationToken = default)
{
    var offset = 0;
    while (true)
    {
        var batch = await FetchBatchAsync(offset, cancellationToken);
        if (batch.Count == 0)
            yield break;

        foreach (var record in batch)
        {
            yield return record;
        }
        offset += batch.Count;
    }
}

// 呼び出し側
await foreach (var record in client.GetRecordsAsync(cancellationToken))
{
    Process(record);
}

// Bad - 全件をメモリに読み込む
public async Task<List<Record>> GetAllRecordsAsync()
{
    var allRecords = new List<Record>();
    // 大量データをすべてメモリに保持...
}
```

### 文字列補間（埋め込みリテラル）

**文字列結合には必ず文字列補間（`$""`）を使用する**：

```csharp
// Good - 文字列補間を使用
var message = $"ユーザー {userName} がログインしました";
var url = $"{baseUrl}/api/items/{itemId}";
var log = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {level}: {message}";

// Good - 複数行の場合
var query = $"""
    SELECT *
    FROM {tableName}
    WHERE Id = {id}
    """;

// Bad - 文字列連結演算子の使用
var message = "ユーザー " + userName + " がログインしました";  // 避ける
var url = baseUrl + "/api/items/" + itemId.ToString();          // 避ける

// Bad - string.Format の使用
var message = string.Format("ユーザー {0} がログインしました", userName);  // 避ける

// Bad - string.Concat の使用
var message = string.Concat("ユーザー ", userName, " がログインしました");  // 避ける
```

#### 文字列補間のメリット

- **可読性が高い**：変数が文字列内のどこに挿入されるか一目でわかる
- **型安全**：コンパイル時に型チェックが行われる
- **書式指定が容易**：`{value:format}` 形式で書式を指定できる
- **パフォーマンス**：コンパイラが最適化を行う

#### 書式指定の例

```csharp
// 数値の書式
var price = $"価格: {amount:N0}円";           // 3桁区切り: "価格: 1,234円"
var rate = $"割合: {percentage:P1}";          // パーセント: "割合: 12.3%"
var hex = $"コード: 0x{code:X4}";             // 16進数: "コード: 0x00FF"

// 日時の書式
var date = $"日付: {now:yyyy/MM/dd}";
var time = $"時刻: {now:HH:mm:ss}";

// 幅指定（パディング）
var padded = $"|{name,10}|{value,-10}|";      // 右寄せ・左寄せ
```

---

## コメントとドキュメント

### XMLドキュメントコメント

**すべての公開APIに必須**。CS1591警告を抑制せず、XMLドキュメントコメントを記述すること。

#### 対象範囲

| 対象                       | 必須/任意 | 説明                                      |
| -------------------------- | --------- | ----------------------------------------- |
| 公開クラス・構造体         | 必須      | すべての `public class` / `public struct` |
| 公開メソッド               | 必須      | すべての `public` メソッド                |
| 公開プロパティ             | 必須      | すべての `public` プロパティ              |
| 公開フィールド             | 必須      | すべての `public` フィールド              |
| 公開イベント               | 必須      | すべての `public` イベント                |
| 内部・プライベートメンバー | 任意      | 複雑な場合は推奨                          |

#### プロパティのXMLコメント

シンプルなプロパティでも必ず `<summary>` を記述する。

```csharp
// Good - すべてのプロパティにXMLコメントあり
public class CreateRecordResponse
{
    /// <summary>作成されたレコードのID</summary>
    public long Id { get; set; }

    /// <summary>ステータスコード</summary>
    public int StatusCode { get; set; }

    /// <summary>メッセージ</summary>
    public string? Message { get; set; }
}

// Bad - XMLコメントなし（CS1591警告）
public class CreateRecordResponse
{
    public long Id { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
}
```

#### CS1591への対応方針

| 対応方法         | 説明                                                  |
| ---------------- | ----------------------------------------------------- |
| XMLコメント追加  | すべての公開メンバーに `/// <summary>` を追加         |
| 抑制は使用しない | `#pragma warning disable` や `NoWarn` での抑制は禁止  |
| 継承時も必須     | 継承したプロパティにもXMLコメントを記述（または継承） |

#### 必須/任意ルール

| タグ          | 条件                                   | 必須/任意 |
| ------------- | -------------------------------------- | --------- |
| `<summary>`   | すべての公開API                        | 必須      |
| `<seealso>`   | 対応するWikiドキュメントが存在する場合 | 必須      |
| `<param>`     | 引数がある場合                         | 必須      |
| `<returns>`   | 戻り値がある場合（`void`/`Task`以外）  | 必須      |
| `<exception>` | 例外をスローする可能性がある場合       | 必須      |
| `<remarks>`   | 補足説明が必要な場合                   | 任意      |
| `<example>`   | 使用例を示す場合                       | 任意      |

#### 記述例

```csharp
/// <summary>
/// 指定されたサイトからレコードを取得
/// </summary>
/// <param name="siteId">取得対象のサイトID</param>
/// <param name="recordId">取得対象のレコードID</param>
/// <param name="cancellationToken">キャンセルトークン</param>
/// <returns>レコード情報を含むレスポンス</returns>
/// <exception cref="ArgumentException">
/// <paramref name="siteId"/> または <paramref name="recordId"/> が0以下の場合
/// </exception>
/// <exception cref="PleasanterApiException">API呼び出しに失敗した場合</exception>
 public async Task<ApiResponse<RecordResponse>> GetRecordAsync(
    long siteId,
    long recordId,
    CancellationToken cancellationToken = default)
{
    // 実装
}
```

### Wikiドキュメントへのリンク（seealso）

PleasanterClientの公開メソッドには、対応するWikiドキュメントへのリンクを `<seealso>` タグで記述する。

#### 基本ルール

| 項目           | 内容                                         |
| -------------- | -------------------------------------------- |
| 対象           | PleasanterClientの全公開メソッド             |
| タグ           | `<seealso href="...">`                       |
| リンク形式     | 内部リンク（`../docs/wiki/{ファイル名}.md`） |
| 配置位置       | `<summary>` タグの直後、`<param>` タグの前   |
| リンクテキスト | `Wiki: {Wikiページ名}`                       |

#### 記述例

```csharp
/// <summary>
/// レコードを作成（リクエストモデル版）
/// </summary>
/// <seealso href="../docs/wiki/01-テーブル操作-01-レコード-作成.md">Wiki: 01-テーブル操作-01-レコード-作成</seealso>
/// <param name="siteId">サイトID</param>
/// <param name="request">リクエストモデル</param>
public async Task<ApiResponse<CreateRecordResponse>> CreateRecordAsync(
    long siteId,
    CreateRecordRequest request,
    TimeSpan? timeout = null,
    CancellationToken cancellationToken = default)
{
    // 実装
}
```

#### Wikiドキュメントとメソッドの対応

| カテゴリ番号 | カテゴリ名             | 対応ファイル                        |
| ------------ | ---------------------- | ----------------------------------- |
| 01           | テーブル操作           | PleasanterClient.Items.cs           |
| 01           | テーブル操作（Import） | PleasanterClient.ImportExport.cs    |
| 02           | サイト操作             | PleasanterClient.Sites.cs           |
| 03           | ユーザ操作             | PleasanterClient.Users.cs           |
| 04           | グループ操作           | PleasanterClient.Groups.cs          |
| 05           | 組織操作               | PleasanterClient.Depts.cs           |
| 06           | セッション操作         | PleasanterClient.Sessions.cs        |
| 07           | メール操作             | PleasanterClient.Mails.cs           |
| 08           | バイナリ操作           | PleasanterClient.Binaries.cs        |
| 09           | 拡張SQL                | PleasanterClient.Extended.cs        |
| 10           | 拡張機能操作           | PleasanterClient.Extensions.cs      |
| 11           | ユーティリティ         | PleasanterClient.Utility.cs         |
| 12           | バックグラウンドタスク | PleasanterClient.BackgroundTasks.cs |
| 13           | デモ                   | PleasanterClient.Demo.cs            |

#### 注意事項

- URLエンコードは不要（内部リンクのため日本語のまま記述）
- 同一メソッドのオーバーロード（リクエストモデル版/簡易版）は同じWikiページを参照
- 新しいメソッドを追加する際は、対応するWikiドキュメントも作成すること

### コメント言語

コメントは**日本語**で記述：

```csharp
// リトライ回数を超えた場合は例外をスロー
if (retryCount > MaxRetryCount)
{
    throw new PleasanterApiException("最大リトライ回数を超えました");
}

/*
 * 複数行コメントの例
 * APIレスポンスのパースと変換を行う
 */
```

### TODOコメント

```csharp
// TODO: キャッシュ機能を実装する
// HACK: 一時的な回避策、後で修正が必要
// FIXME: バグがあるため修正が必要
```

---

## 非同期プログラミング

### 基本ルール

1. 非同期メソッドには `Async` サフィックスを付ける
2. `async void` は避ける（イベントハンドラ以外）
3. `CancellationToken` を受け入れる

```csharp
// Good
public async Task<Record> GetRecordAsync(
    long id,
    CancellationToken cancellationToken = default)
{
    var response = await _httpClient.GetAsync(
        $"records/{id}",
        cancellationToken);

    return await response.Content.ReadAsAsync<Record>(cancellationToken);
}

// Bad
public async void GetRecord(long id) // async voidは避ける
{
    // ...
}
```

### ConfigureAwait

ライブラリコードでは `ConfigureAwait(false)` を使用：

```csharp
public async Task<T> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default)
{
    var response = await _httpClient.GetAsync(endpoint, cancellationToken)
        .ConfigureAwait(false);

    var content = await response.Content.ReadAsStringAsync()
        .ConfigureAwait(false);

    return JsonConvert.DeserializeObject<T>(content);
}
```

### 同期メソッドの提供

必要に応じて同期版も提供：

```csharp
// 非同期版（主要なAPI）
public async Task<Record> GetRecordAsync(long id, CancellationToken cancellationToken = default)
{
    // 非同期実装
}

// 同期版（互換性のため）
public Record GetRecord(long id)
{
    return GetRecordAsync(id).GetAwaiter().GetResult();
}
```

---

## エラーハンドリング

### 例外の使用

```csharp
// 引数検証
public void SetTimeout(int seconds)
{
    if (seconds <= 0)
    {
        throw new ArgumentOutOfRangeException(
            nameof(seconds),
            seconds,
            "タイムアウトは正の値である必要があります");
    }

    _timeout = TimeSpan.FromSeconds(seconds);
}

// カスタム例外
public class PleasanterApiException : Exception
{
    public int StatusCode { get; }

    public PleasanterApiException(string message, int statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }
}
```

### 例外のキャッチ

```csharp
try
{
    var response = await client.GetRecordAsync(id);
}
catch (PleasanterApiException ex) when (ex.StatusCode == 404)
{
    // レコードが見つからない場合の処理
    return null;
}
catch (HttpRequestException ex)
{
    // ネットワークエラーの処理
    _logger.LogError(ex, "APIリクエストに失敗しました");
    throw;
}
```

---

## Null安全

### Nullable参照型の活用

```csharp
// Nullを許容する場合は ? を付ける
public string? OptionalDescription { get; set; }

// Nullを許容しない場合はそのまま
public string RequiredName { get; set; }

// メソッドパラメータ
public void Process(string requiredParam, string? optionalParam = null)
{
    // requiredParamはnullでないことが保証される
    Console.WriteLine(requiredParam.Length);

    // optionalParamはnullチェックが必要
    if (optionalParam is not null)
    {
        Console.WriteLine(optionalParam.Length);
    }
}
```

### Null結合演算子

```csharp
// Null結合演算子
var name = user?.Name ?? "Unknown";

// Null結合代入演算子
_cache ??= new Dictionary<string, object>();

// Null条件演算子
var length = items?.Count ?? 0;
```

---

## LINQ

### 積極的に活用

```csharp
// Good
var activeUsers = users
    .Where(u => u.IsActive)
    .OrderBy(u => u.Name)
    .Select(u => new UserDto(u.Id, u.Name))
    .ToList();

// メソッドチェーンが長い場合は適切に改行
var result = records
    .Where(r => r.Status == RecordStatus.Active)
    .Where(r => r.CreatedAt >= startDate)
    .GroupBy(r => r.Category)
    .Select(g => new
    {
        Category = g.Key,
        Count = g.Count(),
        TotalValue = g.Sum(r => r.Value)
    })
    .OrderByDescending(x => x.Count)
    .Take(10)
    .ToList();
```

### クエリ構文 vs メソッド構文

メソッド構文を優先：

```csharp
// 推奨（メソッド構文）
var result = items.Where(x => x.IsValid).Select(x => x.Name);

// 複雑なjoinの場合はクエリ構文も可
var result = from order in orders
             join customer in customers on order.CustomerId equals customer.Id
             where order.Total > 1000
             select new { customer.Name, order.Total };
```

---

## 正規表現

### 基本ルール

正規表現を使用する際は、パフォーマンスとセキュリティを考慮すること。

| ルール                     | 説明                                           |
| -------------------------- | ---------------------------------------------- |
| コンパイル済みを再利用     | `static readonly` フィールドで定義し再利用する |
| `RegexOptions.Compiled`    | 多数回使用する場合は指定する                   |
| タイムアウトを設定         | ReDoS対策として必ずタイムアウトを指定する      |
| 単純な操作は文字列メソッド | `StartsWith`、`Contains` 等で代替可能なら使う  |
| 非キャプチャグループ       | キャプチャ不要な場合は `(?:...)` を使用する    |

### コンパイル済み正規表現の再利用

```csharp
// Good - 静的フィールドで一度だけコンパイル、再利用
public class Validator
{
    private static readonly Regex EmailPattern = new Regex(
        @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        RegexOptions.Compiled,
        TimeSpan.FromSeconds(1));

    public bool IsValidEmail(string email)
    {
        return EmailPattern.IsMatch(email);
    }
}

// Bad - 毎回コンパイルされる
public bool IsValidEmail(string email)
{
    return Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
}
```

### タイムアウトの設定（ReDoS対策）

悪意のある入力による正規表現サービス拒否攻撃（ReDoS）を防ぐため、タイムアウトを必ず設定する：

```csharp
// Good - タイムアウト指定あり
private static readonly Regex Pattern = new Regex(
    @"pattern",
    RegexOptions.Compiled,
    TimeSpan.FromSeconds(1));

// Bad - タイムアウトなし（DoS攻撃に脆弱）
private static readonly Regex Pattern = new Regex(@"pattern", RegexOptions.Compiled);
```

### 単純な文字列操作での代替

正規表現が不要な場合は、より高速な文字列メソッドを使用する：

```csharp
// Good - 単純なメソッドを使用
if (text.StartsWith("prefix"))
if (text.Contains("substring"))
if (text.EndsWith("suffix"))

// Bad - 正規表現が不要な場合に使用
if (Regex.IsMatch(text, @"^prefix"))
if (Regex.IsMatch(text, @"substring"))
if (Regex.IsMatch(text, @"suffix$"))
```

### 非キャプチャグループの使用

キャプチャが不要な場合は非キャプチャグループを使用してパフォーマンスを向上：

```csharp
// Good - 非キャプチャグループ
var regex = new Regex(@"(?:abc|def)", RegexOptions.Compiled, TimeSpan.FromSeconds(1));

// Bad - 不要なキャプチャ
var regex = new Regex(@"(abc|def)", RegexOptions.Compiled, TimeSpan.FromSeconds(1));
```

### バックトラッキングの回避

カタストロフィックバックトラッキングを引き起こすパターンを避ける：

```csharp
// Good - 原子グループを使用
var regex = new Regex(@"(?>a+)b", RegexOptions.Compiled, TimeSpan.FromSeconds(1));

// Bad - カタストロフィックバックトラッキングの可能性
var regex = new Regex(@"(a+)+b", RegexOptions.Compiled, TimeSpan.FromSeconds(1));
```

### パフォーマンス比較

| 手法                               | 相対速度 | 用途                   |
| ---------------------------------- | -------- | ---------------------- |
| `string.Contains` 等               | 最速     | 単純なパターン         |
| `Regex` (Compiled + 再利用)        | 速い     | 複雑なパターン、多数回 |
| `Regex` (インスタンス再利用)       | 中程度   | 複雑なパターン、少数回 |
| `Regex.IsMatch` (静的メソッド毎回) | 遅い     | 避けるべき             |

---

## ファイル構成

### ディレクトリ構造

```text
PleasanterDeveloperCommunity.DotNet.Client/
├── PleasanterClient.Core.cs
├── PleasanterClient.Items.cs
├── PleasanterClient.Sites.cs
├── PleasanterClient.Users.cs
├── Settings.cs
└── Models/
    ├── Request/
    │   ├── CreateRecordRequest.cs
    │   └── UpdateRecordRequest.cs
    ├── Response/
    │   ├── RecordResponse.cs
    │   └── ApiResponse.cs
    └── Shared/
        └── RecordField.cs
```

### usingディレクティブ

#### 配置と並び順

| ルール            | 説明                                        |
| ----------------- | ------------------------------------------- |
| 配置位置          | 名前空間の外側（ファイル先頭）              |
| System系を先頭    | `System.*` 名前空間を最初にグループ化       |
| アルファベット順  | 各グループ内でアルファベット順にソート      |
| 不要なusingは削除 | 使用していないusingディレクティブは削除する |

#### 記述例

```csharp
// Good - System系が先頭、アルファベット順
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PleasanterDeveloperCommunity.DotNet.Client.Models;

// Bad - 順序が不適切
using PleasanterDeveloperCommunity.DotNet.Client.Models;
using System;  // System系は先頭に
using Newtonsoft.Json;
```

#### 自動整理

VS Codeでは保存時に自動整理される（`.vscode/settings.json` で設定済み）。

手動で実行する場合は `dotnet format` コマンドを使用：

```bash
dotnet format --include-generated
```

### ファイル内の順序

```csharp
// 1. usingディレクティブ（System系を先頭に）
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PleasanterDeveloperCommunity.DotNet.Client.Models;

// 2. 名前空間
namespace PleasanterDeveloperCommunity.DotNet.Client
{
    // 3. クラス定義
    public partial class PleasanterClient
    {
        // 4. 定数・静的フィールド
        private const int DefaultTimeout = 30;

        // 5. フィールド
        private readonly HttpClient _httpClient;
        private string _baseUrl;

        // 6. コンストラクタ

        // 7. プロパティ

        // 8. パブリックメソッド

        // 9. プライベートメソッド
    }
}
```

---

## ツール設定

### EditorConfig

プロジェクトルートの `.editorconfig` で自動フォーマットを設定。

#### 基本設定

| 項目                       | 値          | 説明                     |
| -------------------------- | ----------- | ------------------------ |
| `indent_style`             | `space`     | スペースでインデント     |
| `indent_size`              | `4`         | インデント幅（C#）       |
| `end_of_line`              | `lf`        | 改行コード               |
| `charset`                  | `utf-8-bom` | 文字コード（C#ファイル） |
| `trim_trailing_whitespace` | `true`      | 行末空白を削除           |
| `insert_final_newline`     | `true`      | ファイル末尾に改行       |

#### 警告レベルで強制されるルール

以下のルールは `warning` レベルで設定されており、違反すると警告が表示される：

| ルール                                     | 設定値    | 説明                   |
| ------------------------------------------ | --------- | ---------------------- |
| `csharp_prefer_braces`                     | `true`    | 制御文の中括弧を必須   |
| `dotnet_style_prefer_string_interpolation` | `true`    | 文字列補間を優先       |
| `dotnet_sort_system_directives_first`      | `true`    | System系を先頭にソート |
| `IDE0055`                                  | `warning` | フォーマット違反       |
| `IDE0005`                                  | `warning` | 不要なusing            |
| `CS8600-CS8605`                            | `warning` | Nullable参照型関連     |

#### 命名規則（EditorConfigで強制）

| 対象                    | スタイル             | 例                   |
| ----------------------- | -------------------- | -------------------- |
| インターフェース        | `I` + PascalCase     | `IApiClient`         |
| 型パラメータ            | `T` + PascalCase     | `TResponse`          |
| 非同期メソッド          | PascalCase + `Async` | `GetRecordAsync`     |
| プライベートフィールド  | `_` + camelCase      | `_httpClient`        |
| パラメータ/ローカル変数 | camelCase            | `siteId`, `response` |

### Directory.Build.props

コード分析とビルド設定を `Directory.Build.props` で一元管理。

#### 設定内容

```xml
<Project>
  <PropertyGroup>
    <!-- コード分析の有効化 -->
    <EnableNETAnalyzers>true</EnableNETAnalyzers>
    <AnalysisLevel>latest-recommended</AnalysisLevel>
    <EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>

    <!-- Nullable参照型 -->
    <Nullable>enable</Nullable>

    <!-- 警告をエラーとして扱う（リリースビルド時） -->
    <TreatWarningsAsErrors Condition="'$(Configuration)' == 'Release'">true</TreatWarningsAsErrors>

    <!-- ドキュメントXML生成 -->
    <GenerateDocumentationFile>true</GenerateDocumentationFile>

    <!-- コンパイラ警告レベル -->
    <WarningLevel>5</WarningLevel>
  </PropertyGroup>
</Project>
```

#### 主要な設定項目

| 項目                        | 値                   | 説明                           |
| --------------------------- | -------------------- | ------------------------------ |
| `EnableNETAnalyzers`        | `true`               | .NETアナライザーを有効化       |
| `AnalysisLevel`             | `latest-recommended` | 最新の推奨分析ルールを使用     |
| `EnforceCodeStyleInBuild`   | `true`               | ビルド時にコードスタイルを強制 |
| `Nullable`                  | `enable`             | Nullable参照型を有効化         |
| `TreatWarningsAsErrors`     | `true`（Release時）  | リリースビルドで警告をエラー化 |
| `GenerateDocumentationFile` | `true`               | XMLドキュメントファイルを生成  |
| `WarningLevel`              | `5`                  | 最高レベルの警告を有効化       |

### IDE設定

Visual Studio / VS Code で EditorConfig を有効化し、保存時にフォーマットを適用することを推奨。

#### Visual Studio Code

1. C# Dev Kit 拡張機能をインストール
2. 設定で `editor.formatOnSave` を `true` に設定
3. EditorConfig for VS Code 拡張機能をインストール（推奨）

#### Visual Studio

1. ツール → オプション → テキストエディター → C# → コードスタイル
2. 「EditorConfigの設定を使用する」を有効化
3. 保存時にフォーマットを適用する設定を有効化

---

## 参考リンク

- [C# コーディング規則 (Microsoft)](https://learn.microsoft.com/ja-jp/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- [.NET API設計ガイドライン](https://learn.microsoft.com/ja-jp/dotnet/standard/design-guidelines/)
- [非同期プログラミングのベストプラクティス](https://learn.microsoft.com/ja-jp/dotnet/csharp/asynchronous-programming/)
