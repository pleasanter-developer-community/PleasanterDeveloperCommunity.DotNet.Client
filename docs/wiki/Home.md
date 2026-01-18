# PleasanterDeveloperCommunity.DotNet.Client

## 対応API

### テーブル操作

| 実装済み | API名 | エンドポイント | 公式マニュアル | Wiki |
|:--------:|------|---------------|-----------|------------|
| ✓ | 単一レコード取得 | items/{recordId}/get | [マニュアル](https://pleasanter.org/ja/manual/api-record-get) | [詳細](01-items-recordId-get.md) |
| ✓ | 複数レコード取得 | items/{siteId}/get | [マニュアル](https://pleasanter.org/ja/manual/api-record-get-multi) | [詳細](01-items-siteId-get.md) |
| ✓ | レコード作成 | items/{siteId}/create | [マニュアル](https://pleasanter.org/ja/manual/api-record-create) | [詳細](01-items-siteId-create.md) |
| ✓ | レコード一括作成・更新 | items/{siteId}/bulkupsert | [マニュアル](https://pleasanter.org/ja/manual/api-record-bulkupsert) | [詳細](01-items-siteId-bulkupsert.md) |
| ✓ | レコード作成・更新 | items/{siteId}/upsert | [マニュアル](https://pleasanter.org/ja/manual/api-record-upsert) | [詳細](01-items-siteId-upsert.md) |
| | レコード更新 | items/{recordId}/update | [マニュアル](https://pleasanter.org/ja/manual/api-record-update) | |
| | レコード削除 | items/{recordId}/delete | [マニュアル](https://pleasanter.org/ja/manual/api-record-delete) | |
| | レコード一括削除 | items/{siteId}/bulkdelete | [マニュアル](https://pleasanter.org/ja/manual/api-table-bulk-delete) | |
| | 添付ファイル取得 | items/{recordId}/binaries/{guid}/get | [マニュアル](https://pleasanter.org/ja/manual/api-attachment-get) | |
| | テーブルのエクスポート | items/{siteId}/export | [マニュアル](https://pleasanter.org/ja/manual/api-export) | |
| | レコードのインポート | items/{siteId}/import | [マニュアル](https://pleasanter.org/ja/manual/api-import) | |

### サイト操作

| 実装済み | API名 | エンドポイント | 公式マニュアル | Wiki |
|:--------:|------|---------------|-----------|------------|
| | サイトコピー | sites/{siteId}/copy | [マニュアル](https://pleasanter.org/ja/manual/api-site-copy) | |
| | サイト作成 | sites/{parentId}/create | [マニュアル](https://pleasanter.org/ja/manual/api-site-create) | |
| | サイト削除 | sites/{siteId}/delete | [マニュアル](https://pleasanter.org/ja/manual/api-site-delete) | |
| | サイト取得 | sites/{siteId}/get | [マニュアル](https://pleasanter.org/ja/manual/api-site-get) | |
| | サイト名検索で該当サイトに最も近いサイトID取得 | sites/get | [マニュアル](https://pleasanter.org/ja/manual/api-site-get-closest-siteid) | |
| | サイト更新 | sites/{siteId}/update | [マニュアル](https://pleasanter.org/ja/manual/api-site-update) | |
| | サイト設定の更新（部分追加/更新/削除） | sites/{siteId}/updatesitesettings | [マニュアル](https://pleasanter.org/ja/manual/api-update-sitesettings) | |
| | サマリ同期 | sites/{siteId}/synchronizesummaries | [マニュアル](https://pleasanter.org/ja/manual/api-synchronize-summaries) | |
| | 検索インデックス再構築 | sites/{siteId}/rebuildsearchindexes | [マニュアル](https://pleasanter.org/ja/manual/api-rebuild-search-indexes) | |

### ユーザ操作

| 実装済み | API名 | エンドポイント | 公式マニュアル | Wiki |
|:--------:|------|---------------|-----------|------------|
| | ユーザ作成 | users/create | [マニュアル](https://pleasanter.org/ja/manual/api-user-create) | |
| | ユーザ削除 | users/{userId}/delete | [マニュアル](https://pleasanter.org/ja/manual/api-user-delete) | |
| | ユーザ取得（全て） | users/get | [マニュアル](https://pleasanter.org/ja/manual/api-user-get-all) | |
| | ユーザ取得（選択） | users/{userId}/get | [マニュアル](https://pleasanter.org/ja/manual/api-user-get) | |
| | ユーザ更新 | users/{userId}/update | [マニュアル](https://pleasanter.org/ja/manual/api-user-update) | |
| | インポート | users/import | [マニュアル](https://pleasanter.org/ja/manual/api-user-import) | |

### グループ操作

| 実装済み | API名 | エンドポイント | 公式マニュアル | Wiki |
|:--------:|------|---------------|-----------|------------|
| | グループ作成 | groups/create | [マニュアル](https://pleasanter.org/ja/manual/api-group-create) | |
| | グループ削除 | groups/{groupId}/delete | [マニュアル](https://pleasanter.org/ja/manual/api-group-delete) | |
| | グループ取得 | groups/{groupId}/get | [マニュアル](https://pleasanter.org/ja/manual/api-group-get) | |
| | グループ更新 | groups/{groupId}/update | [マニュアル](https://pleasanter.org/ja/manual/api-group-update) | |
| | インポート | groups/import | [マニュアル](https://pleasanter.org/ja/manual/api-group-import) | |

### 組織操作

| 実装済み | API名 | エンドポイント | 公式マニュアル | Wiki |
|:--------:|------|---------------|-----------|------------|
| | 組織取得 | depts/{deptId}/get | [マニュアル](https://pleasanter.org/ja/manual/api-dept-get) | |
| | 組織作成 | depts/create | [マニュアル](https://pleasanter.org/ja/manual/api-dept-create) | |
| | 組織削除 | depts/{deptId}/delete | [マニュアル](https://pleasanter.org/ja/manual/api-dept-delete) | |
| | 組織更新 | depts/{deptId}/update | [マニュアル](https://pleasanter.org/ja/manual/api-dept-update) | |
| | インポート | depts/import | [マニュアル](https://pleasanter.org/ja/manual/api-dept-import) | |

### メール

| 実装済み | API名 | エンドポイント | 公式マニュアル | Wiki |
|:--------:|------|---------------|-----------|------------|
| | メール送信 | items/{siteId}/mail | [マニュアル](https://pleasanter.org/ja/manual/api-mail) | |

### その他

| 実装済み | API名 | エンドポイント | 公式マニュアル | Wiki |
|:--------:|------|---------------|-----------|----------|
| ✓ | 拡張SQL実行 | extended/sql | [マニュアル](https://pleasanter.org/ja/manual/extended-sql-api) | [詳細](01-extended-sql.md) |
| | ヘルスチェック | healthz | [マニュアル](https://pleasanter.org/ja/manual/enable-health-check) | |

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

- [レスポンスの処理](00-response-handling.md) - APIレスポンスの処理方法
- [オプション設定](09-options.md) - タイムアウト、プロキシ、SSL証明書検証などの設定
- [デバッグ機能](09-debug.md) - リクエスト・レスポンスのログ記録

## Thanks
このWikiは[sync-docs-to-wiki](https://github.com/ShoWaka/sync-docs-to-wiki)をベースに、単体レポジトリのdocsがWikiに自動同期される仕組みを構築しています。
