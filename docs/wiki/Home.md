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

詳細な使用方法については、各エンドポイントのドキュメントを参照してください。

## 関連ドキュメント

- [レスポンスの処理](00-レスポンスの処理) - APIレスポンスの処理方法
- [オプション設定](99-オプション設定) - タイムアウト、プロキシ、SSL証明書検証などの設定
- [デバッグ機能](99-デバッグ機能) - リクエスト・レスポンスのログ記録

## 対応API

> **Note:** 各APIの詳細なパラメータや使用方法については、[Pleasanter公式マニュアル](https://pleasanter.org/ja/manual)を参照してください。

### 01.テーブル操作

| 実装済み | API名 | エンドポイント |
|:--------:|------|---------------|
| ✓ | 単一レコード取得 | items/{recordId}/get |
| ✓ | 複数レコード取得 | items/{siteId}/get |
| ✓ | レコード作成 | items/{siteId}/create |
| ✓ | レコード一括作成・更新 | items/{siteId}/bulkupsert |
| ✓ | レコード作成・更新 | items/{siteId}/upsert |
| ✓ | レコード更新 | items/{recordId}/update |
| ✓ | レコード削除 | items/{recordId}/delete |
| ✓ | レコード一括削除 | items/{siteId}/bulkdelete |
| ✓ | 添付ファイル取得 | items/{recordId}/binaries/{guid}/get |
| ✓ | テーブルのエクスポート | items/{siteId}/export |
| ✓ | レコードのインポート | items/{siteId}/import |

### 02.サイト操作

| 実装済み | API名 | エンドポイント |
|:--------:|------|---------------|
| ✓ | サイトコピー | sites/{siteId}/copy |
| ✓ | サイト作成 | sites/{parentId}/create |
| | サイト削除 | sites/{siteId}/delete |
| | サイト取得 | sites/{siteId}/get |
| | サイト名検索で該当サイトに最も近いサイトID取得 | sites/get |
| | サイト更新 | sites/{siteId}/update |
| | サイト設定の更新（部分追加/更新/削除） | sites/{siteId}/updatesitesettings |
| | サマリ同期 | sites/{siteId}/synchronizesummaries |
| | 検索インデックス再構築 | sites/{siteId}/rebuildsearchindexes |

### 03.ユーザ操作

| 実装済み | API名 | エンドポイント |
|:--------:|------|---------------|
| | ユーザ作成 | users/create |
| | ユーザ削除 | users/{userId}/delete |
| | ユーザ取得(全て) | users/get |
| | ユーザ取得(選択) | users/{userId}/get |
| | ユーザ更新 | users/{userId}/update |
| | インポート | users/import |

### 04.グループ操作

| 実装済み | API名 | エンドポイント |
|:--------:|------|---------------|
| | グループ作成 | groups/create |
| | グループ削除 | groups/{groupId}/delete |
| | グループ取得 | groups/{groupId}/get |
| | グループ更新 | groups/{groupId}/update |
| | インポート | groups/import |

### 05.組織操作

| 実装済み | API名 | エンドポイント |
|:--------:|------|---------------|
| | 組織取得 | depts/{deptId}/get |
| | 組織作成 | depts/create |
| | 組織削除 | depts/{deptId}/delete |
| | 組織更新 | depts/{deptId}/update |
| | インポート | depts/import |

### 06.メール

| 実装済み | API名 | エンドポイント |
|:--------:|------|---------------|
| | メール送信 | items/{siteId}/mail |

### 09.その他

| 実装済み | API名 | エンドポイント |
|:--------:|------|---------------|
| ✓ | 拡張SQL実行 | extended/sql |
| | ヘルスチェック | healthz |

## Thanks
このWikiは[sync-docs-to-wiki](https://github.com/ShoWaka/sync-docs-to-wiki)をベースに、本体レポジトリのdocsがWikiに自動同期される仕組みを構築しています。
