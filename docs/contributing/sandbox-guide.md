# Sandbox ガイド

このドキュメントでは、Sandboxプロジェクトを使用したデバッグ・動作確認方法について説明します。

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [概要](#概要)
- [プロジェクト構成](#プロジェクト構成)
- [セットアップ](#セットアップ)
    - [1. 設定ファイルの作成](#1-設定ファイルの作成)
    - [2. 設定ファイルの編集](#2-設定ファイルの編集)
    - [設定項目](#設定項目)
- [実行モード](#実行モード)
- [実行方法](#実行方法)
    - [コマンドラインから実行](#コマンドラインから実行)
    - [VS Codeでデバッグ実行](#vs-codeでデバッグ実行)
- [テストメニュー](#テストメニュー)
- [カスタムテストの追加](#カスタムテストの追加)
    - [Program.cs の編集](#programcs-の編集)
    - [例: レコード作成テスト](#例-レコード作成テスト)
- [セキュリティに関する注意事項](#セキュリティに関する注意事項)
    - [.gitignore による除外](#gitignore-による除外)
    - [機密情報の取り扱い](#機密情報の取り扱い)
- [トラブルシューティング](#トラブルシューティング)
    - [設定ファイルが見つからない](#設定ファイルが見つからない)
    - [設定値がサンプルのまま](#設定値がサンプルのまま)
    - [接続エラー](#接続エラー)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

---

## 概要

Sandboxプロジェクトは、PleasanterClientライブラリの動作確認・デバッグを行うためのコンソールアプリケーションです。

| 特徴                 | 説明                                                |
| -------------------- | --------------------------------------------------- |
| Copilot併用対応      | 対話的にコードを生成・実行できる構造                |
| 対話式テストメニュー | 主要なAPI操作をメニューから選択して実行可能         |
| 設定ファイル分離     | 機密情報（APIキー等）をJSONファイルで管理           |
| .gitignore対応       | 機密情報を含むファイルは自動的にgit追跡から除外     |
| デバッグ対応         | VS Codeでブレークポイントを設定してステップ実行可能 |

---

## プロジェクト構成

```text
PleasanterDeveloperCommunity.DotNet.Client.Sandbox/
├── PleasanterDeveloperCommunity.DotNet.Client.Sandbox.csproj  # プロジェクトファイル
├── Program.cs                      # 実行コード（.gitignoreで除外）
├── Program.cs.example              # テンプレート（git追跡対象）
├── sandbox.settings.json           # 設定ファイル（.gitignoreで除外）
├── sandbox.settings.json.example   # 設定テンプレート（git追跡対象）
├── SandboxSettings.cs              # 設定モデルクラス
└── SettingsLoader.cs               # 設定読み込みヘルパー
```

---

## セットアップ

### 1. 設定ファイルの作成

Sandboxプロジェクトのディレクトリで、テンプレートファイルをコピーします。

```powershell
cd PleasanterDeveloperCommunity.DotNet.Client.Sandbox
copy sandbox.settings.json.example sandbox.settings.json
```

> **Note**: `Program.cs` は初回セットアップ時に自動生成されています。新しい環境では `Program.cs.example` からコピーしてください。

### 2. 設定ファイルの編集

`sandbox.settings.json` を開き、実際の接続情報を設定します。

```json
{
    "pleasanter": {
        "baseUrl": "https://your-pleasanter-server.example.com",
        "apiKey": "your-api-key-here",
        "apiVersion": 1.1
    },
    "testData": {
        "siteId": 12345,
        "recordId": 67890
    }
}
```

### 設定項目

| セクション   | プロパティ   | 説明                             | 必須 |
| ------------ | ------------ | -------------------------------- | :--: |
| `pleasanter` | `baseUrl`    | プリザンターのベースURL          | Yes  |
| `pleasanter` | `apiKey`     | APIキー                          | Yes  |
| `pleasanter` | `apiVersion` | APIバージョン（デフォルト: 1.1） |      |
| `testData`   | `siteId`     | テスト用サイトID                 |      |
| `testData`   | `recordId`   | テスト用レコードID               |      |

> **Note**: `testData` セクションは任意です。設定しない場合（0の場合）は、実行時に入力を求められます。

---

## 実行モード

Sandboxには2つの実行モードがあります。`Program.cs` 冒頭の `USE_MENU` 定数で切り替えます。

| モード         | `USE_MENU` | 用途                                |
| -------------- | :--------: | ----------------------------------- |
| ダイレクト     |  `false`   | Copilot併用でコードを直接編集・実行 |
| 対話式メニュー |   `true`   | 人間が手動でメニューから操作を選択  |

```csharp
// ダイレクトモード（Copilot併用向け）- デフォルト
const bool USE_MENU = false;

// 対話式メニューモード（人間操作向け）
const bool USE_MENU = true;
```

---

## 実行方法

### コマンドラインから実行

```powershell
# ソリューションのルートディレクトリから
dotnet run --project PleasanterDeveloperCommunity.DotNet.Client.Sandbox

# または、Sandboxディレクトリで
cd PleasanterDeveloperCommunity.DotNet.Client.Sandbox
dotnet run
```

### VS Codeでデバッグ実行

1. VS Codeでソリューションを開く
2. 以下のいずれかの方法でデバッグを開始:
    - **F5キー** を押す
    - サイドバーの「実行とデバッグ」から **「Sandbox: デバッグ実行」** を選択
3. ブレークポイントを設定してステップ実行が可能

---

## テストメニュー

`USE_MENU = true` の場合、対話式のテストメニューが表示されます。

```text
╔══════════════════════════════════════════════════════════════╗
║         Pleasanter Client Sandbox                           ║
╚══════════════════════════════════════════════════════════════╝

[OK] 設定を読み込みました
     BaseUrl: https://your-server.example.com
     ApiVersion: 1.1

[OK] クライアントを初期化しました

──────────────────────────────────────────────────────────────
テストメニュー:
  1. レコード取得 (単一)
  2. レコード一覧取得
  3. サイト情報取得
  4. ユーザ一覧取得
  0. 終了
──────────────────────────────────────────────────────────────
選択 >
```

| メニュー | 説明                                       | 使用するAPI       |
| :------: | ------------------------------------------ | ----------------- |
|    1     | 単一レコードを取得して詳細をJSON形式で表示 | `GetRecordAsync`  |
|    2     | サイト内のレコード一覧を取得               | `GetRecordsAsync` |
|    3     | サイト情報を取得                           | `GetSiteAsync`    |
|    4     | ユーザ一覧を取得                           | `GetUsersAsync`   |
|    0     | プログラムを終了                           | -                 |

---

## カスタムテストの追加

### Program.cs の編集

独自のテストコードを追加する場合は、`Program.cs` の `RunTestAsync()` メソッド内を編集します。

```csharp
async Task RunTestAsync()
{
    // ========================================
    // ここにテストコードを記述
    // ========================================

    var siteId = settings.TestData.SiteId;
    var recordId = settings.TestData.RecordId;

    // 例: レコード取得
    var response = await client.GetRecordAsync(recordId, new GetRecordRequest());
    PrintResponse(response);

    if (response.Response?.Response is not null)
    {
        PrintJson(response.Response.Response);
    }
}
```

利用可能な変数とヘルパー：

| 変数/メソッド                | 説明                                     |
| ---------------------------- | ---------------------------------------- |
| `client`                     | `PleasanterClient` インスタンス          |
| `settings.TestData.SiteId`   | 設定ファイルのサイトID                   |
| `settings.TestData.RecordId` | 設定ファイルのレコードID                 |
| `jsonOptions`                | JSON整形用オプション                     |
| `PrintJson(obj)`             | オブジェクトをJSON形式で出力             |
| `PrintResponse(response)`    | レスポンスの基本情報（StatusCode等）出力 |

### 例: レコード作成テスト

```csharp
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Items;

// レコード作成
var createRequest = new CreateRecordRequest
{
    Title = "テストレコード",
    Body = "Sandboxから作成したテストレコードです",
    ClassHash = new Dictionary<string, string>
    {
        ["ClassA"] = "分類A値"
    }
};

var createResponse = await client.CreateRecordAsync(
    settings.TestData.SiteId,
    createRequest);

if (createResponse.IsSuccess)
{
    Console.WriteLine($"レコードを作成しました: ID = {createResponse.Response?.Id}");
}
else
{
    Console.WriteLine($"作成失敗: {createResponse.Message}");
}
```

---

## セキュリティに関する注意事項

### .gitignore による除外

以下のファイルは `.gitignore` で自動的に除外されます。

| ファイル                | 除外理由                          |
| ----------------------- | --------------------------------- |
| `*.cs`（Sandbox配下）   | APIキーやテストデータを含む可能性 |
| `sandbox.settings.json` | 機密情報（APIキー等）を含む       |

### 機密情報の取り扱い

| やるべきこと                             | やってはいけないこと                 |
| ---------------------------------------- | ------------------------------------ |
| `sandbox.settings.json` に機密情報を記載 | `*.example` ファイルに実際の値を記載 |
| コミット前に `git status` で確認         | 除外設定を無効化してコミット         |
| 環境ごとに設定ファイルを作成             | 設定ファイルを他者と共有             |

---

## トラブルシューティング

### 設定ファイルが見つからない

```text
[ERROR] 設定の読み込みに失敗しました:
        設定ファイルが見つかりません: ...
```

**対処方法**:

1. `sandbox.settings.json.example` をコピーして `sandbox.settings.json` を作成
2. ファイルがSandboxプロジェクトのディレクトリに配置されていることを確認

### 設定値がサンプルのまま

```text
[ERROR] 設定の読み込みに失敗しました:
        設定ファイルの検証に失敗しました:
  - Pleasanter.BaseUrl が設定されていないか、サンプル値のままです
  - Pleasanter.ApiKey が設定されていないか、サンプル値のままです
```

**対処方法**:

`sandbox.settings.json` を開き、以下の値を実際の接続情報に変更してください。

- `baseUrl`: プリザンターサーバーの実際のURL
- `apiKey`: 有効なAPIキー

### 接続エラー

APIリクエストでエラーが発生する場合:

| エラー                  | 原因                   | 対処方法                                     |
| ----------------------- | ---------------------- | -------------------------------------------- |
| `401 Unauthorized`      | APIキーが無効          | APIキーを確認・再発行                        |
| `404 Not Found`         | URLまたはIDが不正      | baseUrl、siteId、recordIdを確認              |
| `Connection refused`    | サーバーに接続できない | URL、ネットワーク設定を確認                  |
| `SSL certificate error` | 証明書エラー           | 自己署名証明書の場合はクライアント設定を確認 |
