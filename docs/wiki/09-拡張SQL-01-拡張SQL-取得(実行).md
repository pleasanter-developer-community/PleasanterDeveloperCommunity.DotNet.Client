# 拡張SQL実行 - extended/sql

## 概要

事前に定義した拡張SQLを実行します。

## 対応バージョン

- プリザンター 1.3.13.0以降

## メソッド

```csharp
// パラメータ指定版
Task<ApiResponse<ExtendedSqlResponse>> ExecuteExtendedSqlAsync(string name, Dictionary<string, object>? parameters = null, TimeSpan? timeout = null)

// リクエストモデル版
Task<ApiResponse<ExtendedSqlResponse>> ExecuteExtendedSqlAsync(ExtendedSqlRequest request, TimeSpan? timeout = null)
```

## パラメータ

| 引数         | 型                           | 必須 | 説明                                     |
|--------------|------------------------------|:----:|------------------------------------------|
| `name`       | string                       | Yes  | 拡張SQLの名前（JSONファイルで定義したName） |
| `parameters` | Dictionary\<string, object\> |      | SQLに渡すパラメータ                      |
| `timeout`    | TimeSpan?                    |      | リクエストタイムアウト                   |

## 使用例

### パラメータ指定版

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

### リクエストモデル版

```csharp
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Extended;

// リクエストモデルを使用した拡張SQL実行
var request = new ExtendedSqlRequest
{
    Name = "MyExtendedSql",
    Parameters = new Dictionary<string, object>
    {
        { "Param1", "値" },
        { "Param2", 123 }
    }
};

var result = await client.ExecuteExtendedSqlAsync(request: request);
```

## 関連ドキュメント

- [レスポンスの処理](00-レスポンスの処理) - APIレスポンスの処理方法
