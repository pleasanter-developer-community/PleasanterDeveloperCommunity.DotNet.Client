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

これらの表の対応Verはプリザンターのバージョンを示します。対応Verに記載ありのものがクライエントライブラリに実装済みです。

> **Note:** 各APIの詳細については、[Pleasanter公式マニュアル](https://pleasanter.org/ja/manual)を参照してください。

### 01.テーブル操作

| #  | 対応Ver  | 対象       | 操作               | エンドポイント                            |
|:--:|:--------:|:-----------|:-------------------|:------------------------------------------|
| 01 | 1.3.13.0 | レコード   | 作成               | /api/items/{siteId}/create                |
| 02 | 1.3.13.0 | テーブル   | インポート         | /api/items/{siteId}/import                |
| 03 | 1.3.13.0 | レコード   | 取得(単一)         | /api/items/{recordId}/get                 |
| 04 | 1.3.13.0 | テーブル   | 取得(複数)         | /api/items/{siteId}/get                   |
| 05 | 1.3.13.0 | レコード   | 取得(添付ファイル) | /api/items/{recordId}/binaries/{guid}/get |
| 06 | 1.3.13.0 | テーブル   | エクスポート       | /api/items/{siteId}/export                |
| 07 | 1.3.13.0 | レコード   | 更新               | /api/items/{recordId}/update              |
| 08 | 1.3.13.0 | テーブル   | 作成・更新         | /api/items/{siteId}/upsert                |
| 09 | 1.4.6.0  | テーブル   | 一括作成・更新     | /api/items/{siteId}/bulkupsert            |
| 10 | 1.3.13.0 | レコード   | 削除               | /api/items/{recordId}/delete              |
| 11 | 1.3.13.0 | テーブル   | 一括削除           | /api/items/{siteId}/bulkdelete            |

### 02.サイト操作

| #  | 対応Ver  | 対象     | 操作                                   | エンドポイント                           |
|:--:|:--------:|:---------|:---------------------------------------|:-----------------------------------------|
| 01 | 1.3.13.0 | サイト   | 作成                                   | /api/sites/{parentId}/create             |
| 02 | 1.3.13.0 | サイト   | コピー                                 | /api/sites/{siteId}/copy                 |
| 03 | 1.3.13.0 | サイト   | 取得                                   | /api/items/{siteId}/getsite              |
| 04 | 1.4.5.0  | サイト   | 検索で該当サイトに最も近いサイトID取得 | /api/items/{siteId}/getclosestsiteid     |
| 05 |          | サイト   | 更新                                   | /api/sites/{siteId}/update               |
| 06 |          | サイト   | 設定更新（部分追加/更新/削除）         | /api/sites/{siteId}/updatesitesettings   |
| 07 |          | サイト   | サマリ同期                             | /api/sites/{siteId}/synchronizesummaries |
| 08 |          | サイト   | 検索インデックス再構築                 | /api/sites/{siteId}/rebuildsearchindexes |
| 09 |          | サイト   | 削除                                   | /api/sites/{siteId}/delete               |

### 03.ユーザ操作

| #  | 対応Ver | 対象     | 操作       | エンドポイント             |
|:--:|:-------:|:---------|:-----------|:---------------------------|
| 01 |         | ユーザ   | 作成       | /api/users/create          |
| 02 |         | ユーザ   | インポート | /api/users/import          |
| 03 |         | ユーザ   | 取得(全て) | /api/users/get             |
| 04 |         | ユーザ   | 取得       | /api/users/{userId}/get    |
| 05 |         | ユーザ   | 更新       | /api/users/{userId}/update |
| 06 |         | ユーザ   | 削除       | /api/users/{userId}/delete |

### 04.グループ操作

| #  | 対応Ver | 対象       | 操作       | エンドポイント               |
|:--:|:-------:|:-----------|:-----------|:-----------------------------|
| 01 |         | グループ   | 作成       | /api/groups/create           |
| 02 |         | グループ   | インポート | /api/groups/import           |
| 03 |         | グループ   | 取得       | /api/groups/{groupId}/get    |
| 04 |         | グループ   | 更新       | /api/groups/{groupId}/update |
| 05 |         | グループ   | 削除       | /api/groups/{groupId}/delete |

### 05.組織操作

| #  | 対応Ver | 対象 | 操作       | エンドポイント             |
|:--:|:-------:|:-----|:-----------|:---------------------------|
| 01 |         | 組織 | 作成       | /api/depts/create          |
| 02 |         | 組織 | インポート | /api/depts/import          |
| 03 |         | 組織 | 取得       | /api/depts/{deptId}/get    |
| 04 |         | 組織 | 更新       | /api/depts/{deptId}/update |
| 05 |         | 組織 | 削除       | /api/depts/{deptId}/delete |

### 06.メール

| #  | 対応Ver | 対象     | 操作 | エンドポイント           |
|:--:|:-------:|:---------|:-----|:-------------------------|
| 01 |         | メール   | 送信 | /api/items/{siteId}/mail |

### 09.その他

| #  | 対応Ver  | 対象    | 操作       | エンドポイント      |
|:--:|:--------:|:--------|:-----------|:--------------------|
| 01 | 1.3.13.0 | 拡張SQL | 取得(実行) | /api/extended/sql   |

## Thanks

このWikiは[sync-docs-to-wiki](https://github.com/ShoWaka/sync-docs-to-wiki)をベースに、本体レポジトリのdocsがWikiに自動同期される仕組みを構築しています。
