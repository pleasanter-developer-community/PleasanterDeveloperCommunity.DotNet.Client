# プリザンター Sessions API セッション有効期間調査

このドキュメントでは、プリザンター本体の Sessions API におけるセッション有効期間について調査した内容をまとめます。

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [調査情報](#調査情報)
- [調査目的](#調査目的)
- [エンドポイント](#エンドポイント)
- [結論](#結論)
    - [セッション有効期間](#セッション有効期間)
    - [有効期間の挙動](#有効期間の挙動)
- [実装の詳細](#実装の詳細)
    - [Session.json パラメータ](#sessionjson-パラメータ)
    - [パラメータクラス](#パラメータクラス)
    - [セッション期限の適用箇所](#セッション期限の適用箇所)
- [SavePerUser オプションの影響](#saveperuser-オプションの影響)
    - [リクエスト例](#リクエスト例)
    - [sessionGuid の決定ロジック](#sessionguid-の決定ロジック)
    - [重要な違い](#重要な違い)
- [削除タイミング](#削除タイミング)
    - [削除条件](#削除条件)
- [保存先](#保存先)
    - [RDB保存時（デフォルト）](#rdb保存時デフォルト)
    - [Redis使用時](#redis使用時)
- [まとめ](#まとめ)
    - [注意事項](#注意事項)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

## 調査情報

| 調査日       | リポジトリ | ブランチ | タグ/バージョン | コミット                                 | 備考     |
| ------------ | ---------- | -------- | --------------- | ---------------------------------------- | -------- |
| 2026年2月3日 | Pleasanter | main     |                 | 調査時点の最新（コミットハッシュ未取得） | 初回調査 |

## 調査目的

Sessions API を使用して保存したセッションデータの有効期間（保持期間）を明確にする。

---

## エンドポイント

| エンドポイント              | 説明               |
| --------------------------- | ------------------ |
| `POST /api/sessions/get`    | セッション値の取得 |
| `POST /api/sessions/set`    | セッション値の設定 |
| `POST /api/sessions/delete` | セッション値の削除 |

---

## 結論

### セッション有効期間

| 項目               | 値                                 |
| ------------------ | ---------------------------------- |
| デフォルト有効期間 | **1440分（24時間）**               |
| 設定ファイル       | `App_Data/Parameters/Session.json` |
| パラメータ名       | `RetentionPeriod`                  |

```json
{
    "RetentionPeriod": 1440,
    "UseKeyValueStore": false
}
```

### 有効期間の挙動

| 保存モード                          | sessionGuid形式         | 期限切れ処理                  |
| ----------------------------------- | ----------------------- | ----------------------------- |
| 通常（`SavePerUser: false`）        | リクエストのSessionGuid | `DeleteOldSessions`で日次削除 |
| ユーザー単位（`SavePerUser: true`） | `@{UserId}`             | 削除対象外（永続化）          |

---

## 実装の詳細

### Session.json パラメータ

**ファイル**: `Implem.Pleasanter/App_Data/Parameters/Session.json`

```json
{
    "RetentionPeriod": 1440,
    "UseKeyValueStore": false
}
```

| パラメータ         | 型     | 説明                                                |
| ------------------ | ------ | --------------------------------------------------- |
| `RetentionPeriod`  | `int`  | セッション保持期間（分）。デフォルト1440分 = 24時間 |
| `UseKeyValueStore` | `bool` | Redis等のKVSを使用するかどうか                      |

### パラメータクラス

**ファイル**: `Implem.ParameterAccessor/Parts/Session.cs`

```csharp
public class Session
{
    public int RetentionPeriod;
    public bool UseKeyValueStore;
}
```

### セッション期限の適用箇所

#### 1. ASP.NET Core セッションのIdleTimeout

**ファイル**: `Implem.Pleasanter/Startup.cs`

```csharp
services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(Parameters.Session.RetentionPeriod);
});
```

#### 2. Cookie認証の有効期限（SAML認証時）

```csharp
.AddCookie(o =>
{
    o.LoginPath = new PathString("/users/login");
    o.ExpireTimeSpan = TimeSpan.FromMinutes(Parameters.Session.RetentionPeriod);
})
```

#### 3. Redis使用時のキー有効期限

**ファイル**: `Implem.Pleasanter/Models/Sessions/SessionUtilities.cs`

```csharp
if (Parameters.Session.UseKeyValueStore && !userArea)
{
    // ... Redisへの保存処理 ...
    iDatabase.KeyExpire(sessionGuid, TimeSpan.FromMinutes(Parameters.Session.RetentionPeriod));
}
```

#### 4. RDB保存時の古いセッション削除

**ファイル**: `Implem.Pleasanter/Models/Sessions/SessionUtilities.cs`

```csharp
public static void DeleteOldSessions(Context context)
{
    var before = SiteInfo.SessionCleanedUpDate.ToLocal(context: context).ToString("yyyy/MM/dd");
    var now = DateTime.Now.ToLocal(context: context).ToString("yyyy/MM/dd");
    if (before != now)
    {
        SiteInfo.SessionCleanedUpDate = DateTime.Now;
        Rds.ExecuteNonQuery(
            context: context,
            statements: Rds.PhysicalDeleteSessions(
                where: Rds.SessionsWhere()
                    .UpdatedTime(
                        DateTime.Now.AddMinutes(Parameters.Session.RetentionPeriod * -1),
                        _operator: "<")
                    .Add(raw: "( \"SessionGuid\" not like '@%' )")));
    }
}
```

---

## SavePerUser オプションの影響

Sessions API では `SavePerUser` パラメータにより保存先が変わる。

### リクエスト例

```json
{
    "ApiKey": "...",
    "SessionKey": "myKey",
    "SessionValue": "myValue",
    "SavePerUser": true
}
```

### sessionGuid の決定ロジック

**ファイル**: `Implem.Pleasanter/Models/Sessions/SessionUtilities.cs`

```csharp
public static ContentResultInheritance SetByApi(Context context)
{
    // ...
    var sessionGuid = api.SavePerUser ? "@" + context.UserId : context.SessionGuid;
    // ...
}
```

| SavePerUser           | sessionGuid           | 説明                         |
| --------------------- | --------------------- | ---------------------------- |
| `false`（デフォルト） | `context.SessionGuid` | ブラウザセッション単位で保存 |
| `true`                | `@{UserId}`           | ユーザー単位で保存（永続化） |

### 重要な違い

`DeleteOldSessions` は `@` で始まるセッションGUIDを**削除対象から除外**している：

```csharp
.Add(raw: "( \"SessionGuid\" not like '@%' )")
```

これにより：

| SavePerUser | 有効期間                                          |
| ----------- | ------------------------------------------------- |
| `false`     | `RetentionPeriod`（デフォルト24時間）後に削除対象 |
| `true`      | 削除されない（永続化）。明示的な削除が必要        |

---

## 削除タイミング

`DeleteOldSessions` は以下のタイミングで呼び出される：

1. **Webリクエスト処理時**（`Context.cs`のセッション初期化時）
2. **1日1回のみ実行**（`SiteInfo.SessionCleanedUpDate`で制御）

```csharp
// Context.cs
SessionData = SessionUtilities.Get(context: this, includeUserArea: Controller == "sessions");
// ...
SessionUtilities.DeleteOldSessions(context: this);
```

### 削除条件

- `UpdatedTime` が `RetentionPeriod` 分より古い
- `SessionGuid` が `@` で始まらない（ユーザー固定セッションは除外）

---

## 保存先

### RDB保存時（デフォルト）

`Sessions` テーブルに保存される。

| カラム        | 説明                                         |
| ------------- | -------------------------------------------- |
| `SessionGuid` | セッション識別子                             |
| `Key`         | セッションキー（`User_` プレフィックス付き） |
| `Value`       | セッション値                                 |
| `Page`        | ページ単位保存時のページ名                   |
| `ReadOnce`    | 1回読み取りで削除するか                      |
| `UserArea`    | ユーザーエリアフラグ                         |
| `UpdatedTime` | 更新日時                                     |

### Redis使用時

`Parameters.Session.UseKeyValueStore = true` の場合、Redisに保存。
キーの有効期限は `RetentionPeriod` で自動設定される。

---

## まとめ

| 項目                 | 値                                                      |
| -------------------- | ------------------------------------------------------- |
| デフォルト有効期間   | 1440分（24時間）                                        |
| 設定箇所             | `App_Data/Parameters/Session.json` の `RetentionPeriod` |
| 削除タイミング       | 1日1回、古いセッションを物理削除                        |
| `SavePerUser: false` | セッションGUID単位で保存、有効期限後に削除              |
| `SavePerUser: true`  | ユーザーID単位で保存、**削除対象外**（永続化）          |

### 注意事項

1. **`SavePerUser: true` のセッションは自動削除されない**
    - 明示的に `/api/sessions/delete` で削除する必要がある
    - 不要なデータが蓄積する可能性がある

2. **`RetentionPeriod` の変更**
    - サーバー管理者が `Session.json` を編集することで変更可能
    - 変更後はアプリケーションの再起動が必要

3. **削除処理は1日1回**
    - 日付が変わったタイミングで初めてリクエストがあった際に実行
    - 即時削除ではない点に注意
