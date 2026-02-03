# テストガイドライン

このドキュメントでは、PleasanterDeveloperCommunity.DotNet.Client プロジェクトのテスト規約について説明します。

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->

- [テストガイドライン](#テストガイドライン)
    - [基本情報](#基本情報)
        - [テストプロジェクト構成](#テストプロジェクト構成)
        - [ディレクトリ構造](#ディレクトリ構造)
    - [テスト実行](#テスト実行)
        - [コマンドライン](#コマンドライン)
        - [Visual Studio / VS Code](#visual-studio--vs-code)
    - [カバレッジ](#カバレッジ)
        - [カバレッジの収集](#カバレッジの収集)
        - [レポート生成（ReportGenerator使用）](#レポート生成reportgenerator使用)
    - [テストの書き方](#テストの書き方)
        - [命名規則](#命名規則)
        - [テスト構造（AAA パターン）](#テスト構造aaa-パターン)
        - [XMLドキュメントコメント](#xmlドキュメントコメント)
    - [テストの種類](#テストの種類)
        - [単体テスト（Unit Tests）](#単体テストunit-tests)
        - [パラメータ化テスト（Theory）](#パラメータ化テストtheory)
        - [非同期テスト](#非同期テスト)
    - [モック化](#モック化)
        - [HttpMessageHandler のモック](#httpmessagehandler-のモック)
        - [使用例](#使用例)
    - [テストのベストプラクティス](#テストのベストプラクティス)
        - [推奨事項](#推奨事項)
        - [避けるべきこと](#避けるべきこと)
    - [CI/CD統合](#cicd統合)
        - [GitHub Actions での実行](#github-actions-での実行)
    - [参考リンク](#参考リンク)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->

---

## 基本情報

### テストプロジェクト構成

| 項目                     | 内容                                               |
| ------------------------ | -------------------------------------------------- |
| プロジェクト名           | `PleasanterDeveloperCommunity.DotNet.Client.Tests` |
| テストフレームワーク     | xUnit                                              |
| ターゲットフレームワーク | .NET 10                                            |
| カバレッジツール         | coverlet.collector                                 |

### ディレクトリ構造

```text
PleasanterDeveloperCommunity.DotNet.Client.Tests/
├── PleasanterDeveloperCommunity.DotNet.Client.Tests.csproj
├── PleasanterClientTests.cs          # PleasanterClientの単体テスト
├── Models/                           # モデルクラスのテスト
│   └── (将来追加予定)
└── Helpers/                          # ヘルパークラスのテスト
    └── (将来追加予定)
```

---

## テスト実行

### コマンドライン

```bash
# 全テストを実行
dotnet test

# 特定のプロジェクトのテストを実行
dotnet test PleasanterDeveloperCommunity.DotNet.Client.Tests

# 詳細なログを出力
dotnet test --logger "console;verbosity=detailed"

# 特定のテストのみ実行（フィルタ）
dotnet test --filter "FullyQualifiedName~PleasanterClientTests"

# 特定のテストメソッドのみ実行
dotnet test --filter "FullyQualifiedName=PleasanterDeveloperCommunity.DotNet.Client.Tests.PleasanterClientTests.PleasanterClientConstructorShouldInitializeCorrectly"
```

### Visual Studio / VS Code

- **Visual Studio**: テストエクスプローラー（`Ctrl+E, T`）からテストを実行
- **VS Code**: C# Dev Kitの「Testing」パネルからテストを実行

---

## カバレッジ

### カバレッジの収集

```bash
# カバレッジを収集
dotnet test --collect:"XPlat Code Coverage"

# 結果の出力先
# TestResults/{GUID}/coverage.cobertura.xml
```

### レポート生成（ReportGenerator使用）

```bash
# ReportGeneratorのインストール（初回のみ）
dotnet tool install -g dotnet-reportgenerator-globaltool

# レポート生成
reportgenerator -reports:"**/coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html
```

---

## テストの書き方

### 命名規則

テストメソッド名はPascalCaseで、以下のパターンを推奨：

| パターン                                  | 例                                                         |
| ----------------------------------------- | ---------------------------------------------------------- |
| `{メソッド名}{条件}{期待結果}`            | `PleasanterClientConstructorShouldInitializeCorrectly`     |
| `{メソッド名}ShouldThrowWhen{条件}`       | `PleasanterClientConstructorShouldThrowWhenBaseUrlIsEmpty` |
| `{メソッド名}Returns{期待結果}When{条件}` | `GetRecordAsyncReturnsNullWhenNotFound`                    |

### テスト構造（AAA パターン）

すべてのテストは **Arrange-Act-Assert** パターンに従う：

```csharp
[Fact]
public void PleasanterClientConstructorShouldInitializeCorrectly()
{
    // Arrange（準備）
    var baseUrl = "https://example.com/pleasanter";
    var apiKey = "test-api-key";

    // Act（実行）
    var client = new PleasanterClient(baseUrl, apiKey);

    // Assert（検証）
    Assert.NotNull(client);
}
```

### XMLドキュメントコメント

テストメソッドにもXMLドキュメントコメントを記述：

```csharp
/// <summary>
/// PleasanterClientが正しく初期化されることを確認
/// </summary>
[Fact]
public void PleasanterClientConstructorShouldInitializeCorrectly()
{
    // ...
}
```

---

## テストの種類

### 単体テスト（Unit Tests）

- 個々のクラス・メソッドを独立してテスト
- 外部依存（HTTP通信など）はモック化

```csharp
[Fact]
public void PleasanterClientConstructorShouldThrowWhenBaseUrlIsEmpty()
{
    // Arrange
    var baseUrl = "";
    var apiKey = "test-api-key";

    // Act & Assert
    Assert.Throws<ArgumentException>(() => new PleasanterClient(baseUrl, apiKey));
}
```

### パラメータ化テスト（Theory）

複数のテストケースを1つのメソッドで実行：

```csharp
[Theory]
[InlineData("")]
[InlineData(null)]
[InlineData("   ")]
public void PleasanterClientConstructorShouldThrowWhenBaseUrlIsInvalid(string? baseUrl)
{
    // Arrange
    var apiKey = "test-api-key";

    // Act & Assert
    Assert.ThrowsAny<ArgumentException>(() => new PleasanterClient(baseUrl!, apiKey));
}
```

### 非同期テスト

非同期メソッドのテストは `async Task` を使用：

```csharp
[Fact]
public async Task GetRecordAsyncShouldReturnRecord()
{
    // Arrange
    using var client = CreateMockClient();

    // Act
    var result = await client.GetRecordAsync(siteId: 123, recordId: 456);

    // Assert
    Assert.NotNull(result);
    Assert.Equal(200, result.StatusCode);
}
```

---

## モック化

### HttpMessageHandler のモック

HTTP通信をモック化する場合：

```csharp
public class MockHttpMessageHandler : HttpMessageHandler
{
    private readonly Func<HttpRequestMessage, HttpResponseMessage> _responseFactory;

    public MockHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> responseFactory)
    {
        _responseFactory = responseFactory;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(_responseFactory(request));
    }
}
```

### 使用例

```csharp
[Fact]
public async Task GetRecordAsyncShouldParseResponse()
{
    // Arrange
    var handler = new MockHttpMessageHandler(request =>
    {
        return new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent("""{"Id":123,"StatusCode":200}""")
        };
    });

    using var httpClient = new HttpClient(handler);
    // テスト対象のクライアントを作成...
}
```

---

## テストのベストプラクティス

### 推奨事項

| 項目               | 説明                                                  |
| ------------------ | ----------------------------------------------------- |
| 独立性             | 各テストは他のテストに依存しない                      |
| 再現性             | 何度実行しても同じ結果になる                          |
| 高速性             | 単体テストは高速に実行できるようにする                |
| 明確なアサーション | 1つのテストで1つの概念を検証                          |
| リソース解放       | `IDisposable` を実装するオブジェクトは `using` で管理 |

### 避けるべきこと

| 項目              | 説明                                       |
| ----------------- | ------------------------------------------ |
| テスト間の依存    | テストの実行順序に依存しない               |
| 実際のAPI呼び出し | 単体テストで実際のAPIを呼び出さない        |
| 静的状態の共有    | 静的フィールドでテスト間の状態を共有しない |
| 過度なモック化    | 必要最小限のモック化に留める               |

---

## CI/CD統合

### GitHub Actions での実行

テストはプルリクエスト時に自動実行される。詳細は [ci-workflow.md](ci-workflow.md) を参照。

```yaml
- name: Test
  run: dotnet test --no-build --verbosity normal
```

---

## 参考リンク

- [xUnit.net 公式ドキュメント](https://xunit.net/)
- [.NET テストのベストプラクティス](https://learn.microsoft.com/ja-jp/dotnet/core/testing/unit-testing-best-practices)
- [Coverlet - コードカバレッジ](https://github.com/coverlet-coverage/coverlet)
