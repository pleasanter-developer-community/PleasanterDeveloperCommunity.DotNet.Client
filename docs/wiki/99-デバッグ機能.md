# デバッグ機能

PleasanterClientにはAPIリクエストとレスポンスをログファイルに記録するデバッグ機能があります。問題のトラブルシューティングやAPI通信の確認に役立ちます。

## デバッグ機能の有効化

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

## DebugSettingsのオプション

| パラメータ | 型 | 必須 | デフォルト値 | 説明 |
|-----------|------|:----:|-------------|------|
| `logDirectory` | string | ✓ | - | ログファイルの出力先ディレクトリパス |
| `encoding` | Encoding | | システム規定 | CSVファイルのエンコーディング |
| `maskApiKey` | bool | | true | APIキーをマスクして出力するかどうか |

## ファクトリメソッド

```csharp
// システム規定のエンコーディングを使用
var settings = DebugSettings.WithSystemDefaultEncoding(@"C:\Logs");

// UTF-8エンコーディングを使用
var settings = DebugSettings.WithUtf8Encoding(@"C:\Logs");

// 任意のエンコーディングを指定
var settings = DebugSettings.WithEncoding(@"C:\Logs", Encoding.GetEncoding("Shift_JIS"));
```

## 出力されるログ

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

## APIキーのマスク

セキュリティのため、デフォルトでAPIキーはマスクされて記録されます：

```csharp
// APIキーをマスク（デフォルト）
var settings = new DebugSettings(@"C:\Logs", maskApiKey: true);
// ログ出力: "ApiKey": "********"

// APIキーをマスクしない（デバッグ目的でのみ使用）
var settings = new DebugSettings(@"C:\Logs", maskApiKey: false);
// ログ出力: "ApiKey": "実際のAPIキー"
```

## 非同期バックグラウンド処理

ログの書き込みは非同期でバックグラウンド処理されるため、アプリケーションのパフォーマンスへの影響を最小限に抑えます。ログの書き込みに失敗してもアプリケーションは停止しません。

## 注意事項

- ログディレクトリが存在しない場合は自動的に作成されます
- ディレクトリへの書き込み権限がない場合は例外がスローされます
- クライアントを`Dispose`する際にログの書き込みが完了するまで待機します
