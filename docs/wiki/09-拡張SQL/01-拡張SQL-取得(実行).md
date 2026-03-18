# 拡張SQL実行 - extended/sql

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [概要](#概要)
- [対応バージョン](#対応バージョン)
- [ExecuteExtendedSqlAsync](#executeextendedsqlasync)
    - [パラメータ](#パラメータ)
    - [レスポンス](#レスポンス)
- [使用例](#使用例)
    - [拡張SQLを実行](#拡張sqlを実行)
- [関連ドキュメント](#関連ドキュメント)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## 概要

事前に定義した拡張SQLを実行します。

## 対応バージョン

- プリザンター 1.3.13.0以降

## ExecuteExtendedSqlAsync

```csharp
Task<ApiResponse<ExtendedSqlResponse>> ExecuteExtendedSqlAsync(
    ExtendedSqlRequest request,
    TimeSpan? timeout = null,
    CancellationToken cancellationToken = default)
```

### パラメータ

| プロパティ#1        | #2                     | 型                            | 必須 | 説明                                           |
| ------------------- | ---------------------- | ----------------------------- | :--: | ---------------------------------------------- |
| `request`           |                        | `ExtendedSqlRequest`          | Yes  | リクエストモデル                               |
|                     | `Name`                 | `string?`                     |      | 拡張SQL名                                      |
|                     | `AdditionalParameters` | `Dictionary<string, object>?` |      | 追加パラメータ（動的に追加されるプロパティ用） |
| `timeout`           |                        | `TimeSpan?`                   |      | リクエストタイムアウト                         |
| `cancellationToken` |                        | `CancellationToken`           |      | キャンセルトークン                             |

### レスポンス

| プロパティ#1 | 型                                  | 説明                  |
| ------------ | ----------------------------------- | --------------------- |
| `Data`       | `List<Dictionary<string, object>>?` | 拡張SQL実行結果データ |

## 使用例

### 拡張SQLを実行

```csharp
using VehicleVision.Pleasanter.DotNet.Client.Models.Requests.Extended;

var request = new ExtendedSqlRequest
{
    Name = "MyExtendedSql",
    AdditionalParameters = new Dictionary<string, object>
    {
        { "Param1", "値" },
        { "Param2", 123 }
    }
};

var result = await client.ExecuteExtendedSqlAsync(request: request);
```

## 関連ドキュメント

- [タイムアウトとキャンセル](../00-共通/タイムアウトとキャンセル.md) - タイムアウトとキャンセルトークンの使い方
- [レスポンスの処理](../00-共通/レスポンスの処理.md) - APIレスポンスの処理方法
