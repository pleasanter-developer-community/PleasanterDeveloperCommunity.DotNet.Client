namespace PleasanterDeveloperCommunity.DotNet.Client.Tests;

/// <summary>
/// PleasanterClientのテストクラス
/// </summary>
public class PleasanterClientTests
{
    /// <summary>
    /// Settingsが正しく初期化されることを確認
    /// </summary>
    [Fact]
    public void Settings_Constructor_ShouldInitializeCorrectly()
    {
        // Arrange
        var baseUrl = "https://example.com/pleasanter";
        var apiKey = "test-api-key";

        // Act
        var settings = new Settings(baseUrl, apiKey);

        // Assert
        Assert.Equal(baseUrl, settings.BaseUrl);
        Assert.Equal(apiKey, settings.ApiKey);
    }

    /// <summary>
    /// PleasanterClientがSettingsで初期化できることを確認
    /// </summary>
    [Fact]
    public void PleasanterClient_Constructor_ShouldAcceptSettings()
    {
        // Arrange
        var settings = new Settings("https://example.com/pleasanter", "test-api-key");

        // Act
        var client = new PleasanterClient(settings);

        // Assert
        Assert.NotNull(client);
    }
}
