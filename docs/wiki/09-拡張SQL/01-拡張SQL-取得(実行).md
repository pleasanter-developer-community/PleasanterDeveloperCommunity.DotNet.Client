# 拡張SQL実行 - extended/sql

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [概要](#%E6%A6%82%E8%A6%81)
- [対応バージョン](#%E5%AF%BE%E5%BF%9C%E3%83%90%E3%83%BC%E3%82%B8%E3%83%A7%E3%83%B3)
- [ExecuteExtendedSqlAsync](#executeextendedsqlasync)
    - [パラメータ](#%E3%83%91%E3%83%A9%E3%83%A1%E3%83%BC%E3%82%BF)
    - [レスポンス](#%E3%83%AC%E3%82%B9%E3%83%9D%E3%83%B3%E3%82%B9)
- [使用例](#%E4%BD%BF%E7%94%A8%E4%BE%8B)
    - [拡張SQLを実行](#%E6%8B%A1%E5%BC%B5sql%E3%82%92%E5%AE%9F%E8%A1%8C)
- [関連ドキュメント](#%E9%96%A2%E9%80%A3%E3%83%89%E3%82%AD%E3%83%A5%E3%83%A1%E3%83%B3%E3%83%88)

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
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Extended;

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

- [タイムアウトとキャンセル](00-タイムアウトとキャンセル) - タイムアウトとキャンセルトークンの使い方
- [レスポンスの処理](00-レスポンスの処理) - APIレスポンスの処理方法
