# Pleasanter API 実装状況

このドキュメントは `Implem.Pleasanter/Controllers/Api/` 配下のコントローラーから確認した、Pleasanter APIの実装状況をまとめたものです。

## 概要

| # | カテゴリ | コントローラー | API数 | 対応 | 未対応 |
|:-:|:---------|:---------------|:-----:|:----:|:------:|
| 01 | テーブル操作 | ItemsController | 9 | 9 | 0 |
| 02 | サイト操作 | ItemsController | 8 | 8 | 0 |
| 03 | ユーザ操作 | UsersController | 5 | 4 | 1 |
| 04 | グループ操作 | GroupsController | 5 | 4 | 1 |
| 05 | 組織操作 | DeptsController | 5 | 4 | 1 |
| 06 | セッション操作 | SessionsController | 3 | 3 | 0 |
| 07 | メール操作 | OutgoingMailsController | 1 | 1 | 0 |
| 08 | バイナリ操作 | BinariesController | 3 | 3 | 0 |
| 09 | 拡張SQL | ExtendedController | 1 | 1 | 0 |
| 10 | 拡張機能操作 | ExtensionsController | 4 | 4 | 0 |
| 11 | ユーティリティ | UtilityController | 1 | 1 | 0 |
| 12 | バックグラウンドタスク | BackgroundTasksController | 1 | 1 | 0 |
| 13 | デモ | DemoController | 1 | 0 | 1 |
| | **合計** | | **47** | **43** | **4** |

---

## 01. テーブル操作 (ItemsController)

`Route: api/items`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/items/{id}/get` | 取得 | レコードまたはテーブルのレコード一覧を取得 | ✓ |
| 2 | `/api/items/{id}/create` | 作成 | 新しいレコードを作成 | ✓ |
| 3 | `/api/items/{id}/update` | 更新 | 既存レコードを更新 | ✓ |
| 4 | `/api/items/{id}/upsert` | 作成・更新 | キーに基づいてレコードを作成または更新 | ✓ |
| 5 | `/api/items/{id}/delete` | 削除 | レコードを削除 | ✓ |
| 6 | `/api/items/{id}/bulkdelete` | 一括削除 | 複数レコードを一括削除 | ✓ |
| 7 | `/api/items/{id}/bulkupsert` | 一括作成・更新 | 複数レコードを一括で作成または更新 | ✓ |
| 8 | `/api/items/{id}/import` | インポート | CSVファイルをインポート | ✓ |
| 9 | `/api/items/{id}/export` | エクスポート | テーブルをCSV/JSON形式でエクスポート | ✓ |

---

## 02. サイト操作 (ItemsController)

`Route: api/items`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/items/{id}/getsite` | サイト取得 | サイト情報を取得 | ✓ |
| 2 | `/api/items/{id}/createsite` | サイト作成 | 新しいサイトを作成 | ✓ |
| 3 | `/api/items/{id}/updatesite` | サイト更新 | サイト情報を更新 | ✓ |
| 4 | `/api/items/{id}/deletesite` | サイト削除 | サイトを削除 | ✓ |
| 5 | `/api/items/{id}/copysitepackage` | サイトコピー | サイトパッケージをコピー | ✓ |
| 6 | `/api/items/{id}/synchronizesummaries` | 集計同期 | 集計を同期 | ✓ |
| 7 | `/api/items/{id}/updatesitesettings` | サイト設定更新 | サイト設定を部分更新 | ✓ |
| 8 | `/api/items/{id}/getclosestsiteid` | サイトID取得 | サイト名検索で最も近いサイトIDを取得 | ✓ |
| 9 | `/api/backgroundtasks/{id}/rebuildsearchindexes` | 検索インデックス再構築 | 検索インデックスを再構築 | ✓ |

---

## 03. ユーザ操作 (UsersController)

`Route: api/users`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/users/get`<br>`/api/users/{id}/get` | 取得 | ユーザ情報を取得（全体または個別） | ✓ |
| 2 | `/api/users/create` | 作成 | 新しいユーザを作成 | ✓ |
| 3 | `/api/users/{id}/update` | 更新 | ユーザ情報を更新 | ✓ |
| 4 | `/api/users/{id}/delete` | 削除 | ユーザを削除 | ✓ |
| 5 | `/api/users/import` | インポート | ユーザをCSVインポート | |

---

## 04. グループ操作 (GroupsController)

`Route: api/groups`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/groups/get`<br>`/api/groups/{id}/get` | 取得 | グループ情報を取得（全体または個別） | ✓ |
| 2 | `/api/groups/create` | 作成 | 新しいグループを作成 | ✓ |
| 3 | `/api/groups/{id}/update` | 更新 | グループ情報を更新 | ✓ |
| 4 | `/api/groups/{id}/delete` | 削除 | グループを削除 | ✓ |
| 5 | `/api/groups/import` | インポート | グループをCSVインポート | |

---

## 05. 組織操作 (DeptsController)

`Route: api/depts`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/depts/get`<br>`/api/depts/{id}/get` | 取得 | 組織情報を取得（全体または個別） | ✓ |
| 2 | `/api/depts/create` | 作成 | 新しい組織を作成 | ✓ |
| 3 | `/api/depts/{id}/update` | 更新 | 組織情報を更新 | ✓ |
| 4 | `/api/depts/{id}/delete` | 削除 | 組織を削除 | ✓ |
| 5 | `/api/depts/import` | インポート | 組織をCSVインポート | |

---

## 06. セッション操作 (SessionsController)

`Route: api/sessions`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/sessions/get` | 取得 | セッション情報を取得 | ✓ |
| 2 | `/api/sessions/set` | 設定 | セッション情報を設定 | ✓ |
| 3 | `/api/sessions/delete` | 削除 | セッション情報を削除 | ✓ |

---

## 07. メール操作 (OutgoingMailsController)

`Route: api`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/items/{id}/outgoingmails/send` | 送信 | メールを送信 | ✓ |

---

## 08. バイナリ操作 (BinariesController)

`Route: api/binaries`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/binaries/{guid}/get` | 取得 | 添付ファイル情報をBase64形式で取得 | ✓ |
| 2 | `/api/binaries/{guid}/getstream` | ストリーム取得 | 添付ファイルをストリームとして取得 | ✓ |
| 3 | `/api/binaries/{siteId}/upload` | アップロード | ファイルをアップロード | ✓ |

---

## 09. 拡張SQL (ExtendedController)

`Route: api/extended`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/extended/sql` | 実行 | 事前定義された拡張SQLを実行 | ✓ |

---

## 10. 拡張機能操作 (ExtensionsController)

`Route: api/extensions`

> **注意:** この機能には `AllowExtensionsApi` の有効化と特権が必要です。

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/extensions/get`<br>`/api/extensions/{id}/get` | 取得 | 拡張機能情報を取得 | ✓ |
| 2 | `/api/extensions/create` | 作成 | 新しい拡張機能を作成 | ✓ |
| 3 | `/api/extensions/{id}/update` | 更新 | 拡張機能を更新 | ✓ |
| 4 | `/api/extensions/{id}/delete` | 削除 | 拡張機能を削除 | ✓ |

---

## 11. ユーティリティ (UtilityController)

`Route: api/utility`

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/utility/getlicenseinfo` | ライセンス情報取得 | ライセンス情報を取得 | ✓ |

---

## 12. バックグラウンドタスク (BackgroundTasksController)

`Route: api/backgroundtasks`

> **注意:** この機能には `BackgroundTask.Enabled` パラメータの有効化が必要です。
> 
> ※ クライアントライブラリでは「02. サイト操作」に含めて実装しています。

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/backgroundtasks/rebuildsearchindexes`<br>`/api/backgroundtasks/{id}/rebuildsearchindexes` | 検索インデックス再構築 | 検索インデックスを再構築 | ✓ |

---

## 13. デモ (DemoController)

`Route: api/demo`

> **注意:** この機能には `Service.DemoApi` パラメータの有効化が必要です。

| # | エンドポイント | 操作 | 説明 | 対応 |
|:-:|:---------------|:-----|:-----|:----:|
| 1 | `/api/demo/register` | 登録 | デモ環境を登録 | |

---

## 備考

- すべてのAPIは `POST` メソッドで実装されています
- 認証は `ApiKey` をリクエストボディに含めて行います
- 詳細なAPIの仕様については [プリザンター公式マニュアル](https://pleasanter.org/ja/manual) を参照してください
- 対応列: ✓ = 対応済み、空欄 = 未対応
