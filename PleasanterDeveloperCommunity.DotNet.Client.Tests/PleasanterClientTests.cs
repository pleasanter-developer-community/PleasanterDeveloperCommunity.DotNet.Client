namespace PleasanterDeveloperCommunity.DotNet.Client.Tests;

/// <summary>
/// PleasanterClientのテストクラス
/// </summary>
public class PleasanterClientTests
{
    /// <summary>
    /// PleasanterClientが正しく初期化されることを確認
    /// </summary>
    [Fact]
    public void PleasanterClientConstructorShouldInitializeCorrectly()
    {
        // Arrange
        var baseUrl = "https://example.com/pleasanter";
        var apiKey = "test-api-key";

        // Act
        var client = new PleasanterClient(baseUrl, apiKey);

        // Assert
        Assert.NotNull(client);
    }

    /// <summary>
    /// baseUrlが空の場合は例外をスローすることを確認
    /// </summary>
    [Fact]
    public void PleasanterClientConstructorShouldThrowWhenBaseUrlIsEmpty()
    {
        // Arrange
        var baseUrl = "";
        var apiKey = "test-api-key";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new PleasanterClient(baseUrl, apiKey));
    }

    /// <summary>
    /// apiKeyが空の場合は例外をスローすることを確認
    /// </summary>
    [Fact]
    public void PleasanterClientConstructorShouldThrowWhenApiKeyIsEmpty()
    {
        // Arrange
        var baseUrl = "https://example.com/pleasanter";
        var apiKey = "";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => new PleasanterClient(baseUrl, apiKey));
    }

    /// <summary>
    /// PleasanterClientがIDisposableを実装していることを確認
    /// </summary>
    [Fact]
    public void PleasanterClientShouldImplementIDisposable()
    {
        // Arrange
        var baseUrl = "https://example.com/pleasanter";
        var apiKey = "test-api-key";

        // Act
        using var client = new PleasanterClient(baseUrl, apiKey);

        // Assert
        Assert.IsAssignableFrom<IDisposable>(client);
    }
}
