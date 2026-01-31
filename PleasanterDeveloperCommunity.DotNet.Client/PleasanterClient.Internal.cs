using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;

namespace PleasanterDeveloperCommunity.DotNet.Client
{
    /// <summary>
    /// PleasanterClient - 内部ヘルパーメソッド
    /// </summary>
    public partial class PleasanterClient
    {
        /// <summary>
        /// リクエストにAPI認証情報を設定します
        /// </summary>
        private void SetApiCredentials(ApiRequestBase request)
        {
            request.ApiVersion = _apiVersion.ToString("F1", CultureInfo.InvariantCulture);
            request.ApiKey = _apiKey;
        }

        private async Task<ApiResponse<T>> SendRequestAsync<T>(
            string endpoint,
            object request,
            TimeSpan? timeout)
        {
            var requestId = Guid.NewGuid().ToString();
            var url = _baseUrl + endpoint;
            var jsonContent = JsonSerializer.Serialize(request, JsonOptions);

            // デバッグログ（リクエスト）
            LogRequest(requestId, url, jsonContent);

            try
            {
                using var cts = timeout.HasValue
                    ? new CancellationTokenSource(timeout.Value)
                    : new CancellationTokenSource();

                using var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                using var response = await _httpClient.PostAsync(url, content, cts.Token);

                var responseContent = await response.Content.ReadAsStringAsync();

                // デバッグログ（レスポンス）
                LogResponse(requestId, url, (int)response.StatusCode, responseContent);

                var apiResponse = new ApiResponse<T>
                {
                    StatusCode = response.StatusCode
                };

                if (!string.IsNullOrEmpty(responseContent))
                {
                    try
                    {
                        using var doc = JsonDocument.Parse(responseContent);
                        var root = doc.RootElement;

                        if (root.TryGetProperty("Message", out var messageElement))
                            apiResponse.Message = messageElement.GetString();

                        if (root.TryGetProperty("Response", out var responseElement))
                        {
                            apiResponse.Response = JsonSerializer.Deserialize<T>(
                                responseElement.GetRawText(), JsonOptions);
                        }
                        else
                        {
                            // Responseプロパティがない場合、ルート全体をレスポンスとして扱う
                            apiResponse.Response = JsonSerializer.Deserialize<T>(responseContent, JsonOptions);
                        }
                    }
                    catch (JsonException)
                    {
                        apiResponse.Message = responseContent;
                    }
                }

                return apiResponse;
            }
            catch (Exception ex)
            {
                LogException(requestId, url, ex);
                throw;
            }
        }

        private async Task<ApiResponse<T>> SendMultipartRequestAsync<T>(
            string endpoint,
            Stream fileStream,
            string fileName,
            Dictionary<string, object> parameters,
            TimeSpan? timeout)
        {
            var requestId = Guid.NewGuid().ToString();
            var url = _baseUrl + endpoint;

            // デバッグログ（リクエスト）
            LogRequest(requestId, url, JsonSerializer.Serialize(parameters, JsonOptions));

            try
            {
                using var cts = timeout.HasValue
                    ? new CancellationTokenSource(timeout.Value)
                    : new CancellationTokenSource();

                using var content = new MultipartFormDataContent();
                content.Add(new StringContent(JsonSerializer.Serialize(parameters, JsonOptions)), "parameters");

                var streamContent = new StreamContent(fileStream);
                streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/csv");
                content.Add(streamContent, "file", fileName);

                using var response = await _httpClient.PostAsync(url, content, cts.Token);
                var responseContent = await response.Content.ReadAsStringAsync();

                // デバッグログ（レスポンス）
                LogResponse(requestId, url, (int)response.StatusCode, responseContent);

                var apiResponse = new ApiResponse<T>
                {
                    StatusCode = response.StatusCode
                };

                if (!string.IsNullOrEmpty(responseContent))
                {
                    try
                    {
                        using var doc = JsonDocument.Parse(responseContent);
                        var root = doc.RootElement;

                        if (root.TryGetProperty("Message", out var messageElement))
                            apiResponse.Message = messageElement.GetString();

                        if (root.TryGetProperty("Response", out var responseElement))
                        {
                            apiResponse.Response = JsonSerializer.Deserialize<T>(
                                responseElement.GetRawText(), JsonOptions);
                        }
                        else
                        {
                            apiResponse.Response = JsonSerializer.Deserialize<T>(responseContent, JsonOptions);
                        }
                    }
                    catch (JsonException)
                    {
                        apiResponse.Message = responseContent;
                    }
                }

                return apiResponse;
            }
            catch (Exception ex)
            {
                LogException(requestId, url, ex);
                throw;
            }
        }

        /// <summary>
        /// Bearer認証を使用してマルチパートフォームデータでファイルをアップロードします
        /// </summary>
        private async Task<ApiResponse<T>> SendMultipartWithBearerAsync<T>(
            string endpoint,
            Stream fileStream,
            string fileName,
            string? contentType,
            long? rangeFrom,
            long? rangeTo,
            long? rangeTotal,
            string? fileHash,
            TimeSpan? timeout)
        {
            var requestId = Guid.NewGuid().ToString();
            var url = _baseUrl + endpoint;

            // デバッグログ（リクエスト）
            LogRequest(requestId, url, $"[Multipart Upload] FileName: {fileName}, ContentType: {contentType}");

            try
            {
                using var cts = timeout.HasValue
                    ? new CancellationTokenSource(timeout.Value)
                    : new CancellationTokenSource();

                using var content = new MultipartFormDataContent();

                var streamContent = new StreamContent(fileStream);
                if (!string.IsNullOrEmpty(contentType))
                {
                    streamContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                }

                // Content-Rangeヘッダー（分割アップロード用）
                if (rangeFrom.HasValue && rangeTo.HasValue && rangeTotal.HasValue)
                {
                    streamContent.Headers.Add("Content-Range", $"bytes {rangeFrom.Value}-{rangeTo.Value}/{rangeTotal.Value}");
                }

                content.Add(streamContent, "file", fileName);

                // ファイルハッシュ（整合性検証用）
                if (!string.IsNullOrEmpty(fileHash))
                {
                    content.Add(new StringContent(fileHash), "FileHash");
                }

                using var request = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = content
                };

                // Bearer認証ヘッダーを追加
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

                using var response = await _httpClient.SendAsync(request, cts.Token);
                var responseContent = await response.Content.ReadAsStringAsync();

                // デバッグログ（レスポンス）
                LogResponse(requestId, url, (int)response.StatusCode, responseContent);

                var apiResponse = new ApiResponse<T>
                {
                    StatusCode = response.StatusCode
                };

                if (!string.IsNullOrEmpty(responseContent))
                {
                    try
                    {
                        using var doc = JsonDocument.Parse(responseContent);
                        var root = doc.RootElement;

                        if (root.TryGetProperty("Message", out var messageElement))
                            apiResponse.Message = messageElement.GetString();

                        if (root.TryGetProperty("Response", out var responseElement))
                        {
                            apiResponse.Response = JsonSerializer.Deserialize<T>(
                                responseElement.GetRawText(), JsonOptions);
                        }
                        else
                        {
                            apiResponse.Response = JsonSerializer.Deserialize<T>(responseContent, JsonOptions);
                        }
                    }
                    catch (JsonException)
                    {
                        apiResponse.Message = responseContent;
                    }
                }

                return apiResponse;
            }
            catch (Exception ex)
            {
                LogException(requestId, url, ex);
                throw;
            }
        }

        private static Encoding DetectFileEncoding(string filePath)
        {
            var bytes = File.ReadAllBytes(filePath);

            // UTF-8 BOM
            if (bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
                return Encoding.UTF8;

            // UTF-8パターン検出
            if (IsUtf8(bytes))
                return Encoding.UTF8;

            // Shift-JIS
            return Encoding.GetEncoding(932);
        }

        private static bool IsUtf8(byte[] bytes)
        {
            var i = 0;
            while (i < bytes.Length)
            {
                if (bytes[i] <= 0x7F)
                {
                    i++;
                }
                else if (bytes[i] >= 0xC2 && bytes[i] <= 0xDF)
                {
                    if (i + 1 >= bytes.Length || bytes[i + 1] < 0x80 || bytes[i + 1] > 0xBF)
                        return false;
                    i += 2;
                }
                else if (bytes[i] >= 0xE0 && bytes[i] <= 0xEF)
                {
                    if (i + 2 >= bytes.Length)
                        return false;
                    if (bytes[i + 1] < 0x80 || bytes[i + 1] > 0xBF ||
                        bytes[i + 2] < 0x80 || bytes[i + 2] > 0xBF)
                        return false;
                    i += 3;
                }
                else if (bytes[i] >= 0xF0 && bytes[i] <= 0xF4)
                {
                    if (i + 3 >= bytes.Length)
                        return false;
                    if (bytes[i + 1] < 0x80 || bytes[i + 1] > 0xBF ||
                        bytes[i + 2] < 0x80 || bytes[i + 2] > 0xBF ||
                        bytes[i + 3] < 0x80 || bytes[i + 3] > 0xBF)
                        return false;
                    i += 4;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        #region Debug Logging

        private void LogRequest(string requestId, string url, string content)
        {
            if (_debugSettings == null) return;

            var maskedContent = _debugSettings.MaskApiKey
                ? MaskApiKey(content)
                : content;

            var logEntry = FormatLogEntry(
                DateTime.UtcNow.ToString("o"),
                requestId,
                "Request",
                url,
                "",
                "",
                maskedContent);

            _logQueue.Enqueue(logEntry);
        }

        private void LogResponse(string requestId, string url, int statusCode, string content)
        {
            if (_debugSettings == null) return;

            var isJson = content.TrimStart().StartsWith("{") || content.TrimStart().StartsWith("[");

            var logEntry = FormatLogEntry(
                DateTime.UtcNow.ToString("o"),
                requestId,
                "Response",
                url,
                statusCode.ToString(),
                isJson.ToString(),
                content);

            _logQueue.Enqueue(logEntry);
        }

        private void LogException(string requestId, string url, Exception ex)
        {
            if (_debugSettings == null) return;

            var content = FormatException(ex);

            var logEntry = FormatLogEntry(
                DateTime.UtcNow.ToString("o"),
                requestId,
                "Exception",
                url,
                "",
                "",
                content);

            _logQueue.Enqueue(logEntry);
        }

        private static string FormatException(Exception ex, int depth = 0)
        {
            var sb = new StringBuilder();
            var indent = new string(' ', depth * 2);

            if (depth > 0)
                sb.AppendLine($"{indent}[InnerException] {ex.GetType().FullName}: {ex.Message}");
            else
                sb.AppendLine($"{ex.GetType().FullName}: {ex.Message}");

            sb.AppendLine($"{indent}StackTrace:");
            sb.AppendLine($"{indent}{ex.StackTrace}");

            if (ex is AggregateException aggEx)
            {
                foreach (var inner in aggEx.InnerExceptions)
                {
                    sb.AppendLine();
                    sb.Append(FormatException(inner, depth + 1));
                }
            }
            else if (ex.InnerException != null)
            {
                sb.AppendLine();
                sb.Append(FormatException(ex.InnerException, depth + 1));
            }

            return sb.ToString();
        }

        private string MaskApiKey(string content)
        {
            // JSON形式のApiKeyをマスク
            return System.Text.RegularExpressions.Regex.Replace(
                content,
                @"""ApiKey""\s*:\s*""[^""]+""",
                @"""ApiKey"": ""********""");
        }

        private static string FormatLogEntry(string timestamp, string requestId, string type,
            string url, string statusCode, string isJson, string content)
        {
            // CSV形式でエスケープ
            var escapedContent = content.Replace("\"", "\"\"");
            return $"\"{timestamp}\",\"{requestId}\",\"{type}\",\"{url}\",\"{statusCode}\",\"{isJson}\",\"{escapedContent}\"";
        }

        private async Task StartLogWriterAsync(CancellationToken cancellationToken)
        {
            if (_debugSettings == null) return;

            var logFilePath = Path.Combine(_debugSettings.LogDirectory,
                $"pleasanter-api-{DateTime.Now:yyyyMMdd}.csv");

            // ヘッダーを書き込み
            if (!File.Exists(logFilePath))
            {
                var header = "Timestamp,RequestId,Type,Url,StatusCode,IsJson,Content";
                await File.WriteAllTextAsync(logFilePath, header + Environment.NewLine, _debugSettings.Encoding);
            }

            while (!cancellationToken.IsCancellationRequested)
            {
                try
                {
                    if (_logQueue.TryDequeue(out var entry))
                    {
                        await File.AppendAllTextAsync(logFilePath, entry + Environment.NewLine, _debugSettings.Encoding);
                    }
                    else
                    {
                        await Task.Delay(100, cancellationToken);
                    }
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch
                {
                    // ログ書き込みの失敗は無視
                }
            }

            // 残りのログをフラッシュ
            while (_logQueue.TryDequeue(out var entry))
            {
                try
                {
                    await File.AppendAllTextAsync(logFilePath, entry + Environment.NewLine, _debugSettings.Encoding);
                }
                catch
                {
                    // 無視
                }
            }
        }

        #endregion
    }
}
