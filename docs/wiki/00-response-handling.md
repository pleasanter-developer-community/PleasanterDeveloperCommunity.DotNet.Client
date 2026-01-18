# レスポンスの処理

APIレスポンスの処理方法について説明します。

## 基本的なレスポンス処理

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

## レスポンスの構造

すべてのAPIレスポンスは`ApiResponse<T>`型で返されます。

### ApiResponseプロパティ

| プロパティ | 型 | 説明 |
|-----------|------|------|
| `StatusCode` | HttpStatusCode | HTTPステータスコード |
| `Message` | string | レスポンスメッセージ |
| `Response` | T | レスポンスデータ（APIの種類により異なる） |

### ステータスコードの確認

```csharp
var response = await client.GetRecordAsync(recordId: 123);

switch (response.StatusCode)
{
    case HttpStatusCode.OK:
        // 成功
        break;
    case HttpStatusCode.BadRequest:
        // リクエストエラー
        break;
    case HttpStatusCode.Unauthorized:
        // 認証エラー
        break;
    case HttpStatusCode.NotFound:
        // レコードが見つからない
        break;
    default:
        // その他のエラー
        break;
}
```
