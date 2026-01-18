# レコード作成・更新 - items/{siteId}/upsert

## 概要

キーに基づいてレコードを作成または更新します。キーに一致するレコードが存在する場合は更新、存在しない場合は新規作成します。

## メソッド

```csharp
Task<ApiResponse<UpsertRecordResponse>> UpsertRecordAsync(long siteId, UpsertRecordRequest request, TimeSpan? timeout = null)
```

## パラメータ

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

## 使用例

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
