using System;
using System.IO;
using System.Threading.Tasks;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Requests.Binaries;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Binaries;
using PleasanterDeveloperCommunity.DotNet.Client.Models.Responses.Items;

namespace PleasanterDeveloperCommunity.DotNet.Client;
/// <summary>
/// PleasanterClient - 添付ファイルAPI
/// </summary>
public partial class PleasanterClient
{
    #region GetAttachment (添付ファイル取得)

    /// <summary>
    /// 添付ファイルを取得します（リクエストモデル版）
    /// </summary>
    public async Task<ApiResponse<AttachmentResponse>> GetAttachmentAsync(
        string guid,
        GetAttachmentRequest request,
        TimeSpan? timeout = null)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<AttachmentResponse>(
            $"/api/binaries/{guid}/get", request, timeout);
    }

    /// <summary>
    /// 添付ファイルを取得します
    /// </summary>
    public async Task<ApiResponse<AttachmentResponse>> GetAttachmentAsync(
        string guid,
        TimeSpan? timeout = null)
    {
        var request = new GetAttachmentRequest();
        return await GetAttachmentAsync(guid, request, timeout);
    }

    #endregion

    #region GetBinaryStream (バイナリストリーム取得)

    /// <summary>
    /// バイナリストリームを取得します（リクエストモデル版）
    /// </summary>
    /// <param name="guid">GUID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>バイナリストリーム取得レスポンス</returns>
    public async Task<ApiResponse<GetBinaryStreamResponse>> GetBinaryStreamAsync(
        string guid,
        GetBinaryStreamRequest request,
        TimeSpan? timeout = null)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<GetBinaryStreamResponse>(
            $"/api/binaries/{guid}/getstream", request, timeout);
    }

    /// <summary>
    /// バイナリストリームを取得します
    /// </summary>
    /// <param name="guid">GUID</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>バイナリストリーム取得レスポンス</returns>
    public async Task<ApiResponse<GetBinaryStreamResponse>> GetBinaryStreamAsync(
        string guid,
        TimeSpan? timeout = null)
    {
        var request = new GetBinaryStreamRequest();
        return await GetBinaryStreamAsync(guid, request, timeout);
    }

    #endregion

    #region UploadBinary (バイナリアップロード)

    /// <summary>
    /// バイナリをアップロードします（リクエストモデル版）
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="request">リクエストモデル</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>バイナリアップロードレスポンス</returns>
    public async Task<ApiResponse<UploadBinaryResponse>> UploadBinaryAsync(
        long siteId,
        UploadBinaryRequest request,
        TimeSpan? timeout = null)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        SetApiCredentials(request);
        return await SendRequestAsync<UploadBinaryResponse>(
            $"/api/binaries/{siteId}/upload", request, timeout);
    }

    /// <summary>
    /// バイナリをアップロードします
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="base64Data">Base64エンコードされたファイルデータ</param>
    /// <param name="contentType">コンテンツタイプ</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>バイナリアップロードレスポンス</returns>
    public async Task<ApiResponse<UploadBinaryResponse>> UploadBinaryAsync(
        long siteId,
        string fileName,
        string base64Data,
        string? contentType = null,
        TimeSpan? timeout = null)
    {
        var request = new UploadBinaryRequest
        {
            FileName = fileName ?? throw new ArgumentNullException(nameof(fileName)),
            Base64 = base64Data ?? throw new ArgumentNullException(nameof(base64Data)),
            ContentType = contentType
        };
        return await UploadBinaryAsync(siteId, request, timeout);
    }

    /// <summary>
    /// バイナリをアップロードします（バイト配列版）
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="fileData">ファイルデータ</param>
    /// <param name="contentType">コンテンツタイプ</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>バイナリアップロードレスポンス</returns>
    public async Task<ApiResponse<UploadBinaryResponse>> UploadBinaryAsync(
        long siteId,
        string fileName,
        byte[] fileData,
        string? contentType = null,
        TimeSpan? timeout = null)
    {
        if (fileData == null) throw new ArgumentNullException(nameof(fileData));
        var base64Data = Convert.ToBase64String(fileData);
        return await UploadBinaryAsync(siteId, fileName, base64Data, contentType, timeout);
    }

    #endregion

    #region UploadBinaryStream (ストリームアップロード - Bearer認証)

    /// <summary>
    /// ファイルをストリームでアップロードします（新規添付ファイル作成）
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="fileStream">ファイルストリーム</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="contentType">コンテンツタイプ</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>アップロードレスポンス</returns>
    /// <remarks>
    /// このメソッドはBearer認証を使用し、マルチパートフォームデータで直接ファイルをアップロードします。
    /// Base64エンコードが不要なため、大きなファイルのアップロードに適しています。
    /// </remarks>
    public async Task<ApiResponse<UploadBinaryResponse>> UploadBinaryStreamAsync(
        long siteId,
        Stream fileStream,
        string fileName,
        string? contentType = null,
        TimeSpan? timeout = null)
    {
        if (fileStream == null) throw new ArgumentNullException(nameof(fileStream));
        if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException(nameof(fileName));

        return await SendMultipartWithBearerAsync<UploadBinaryResponse>(
            $"/api/binaries/upload?id={siteId}",
            fileStream,
            fileName,
            contentType,
            rangeFrom: null,
            rangeTo: null,
            rangeTotal: null,
            fileHash: null,
            timeout);
    }

    /// <summary>
    /// ファイルをストリームでアップロードします（新規添付ファイル作成、byte[]版）
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="fileData">ファイルデータ</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="contentType">コンテンツタイプ</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>アップロードレスポンス</returns>
    /// <remarks>
    /// このメソッドはBearer認証を使用し、マルチパートフォームデータで直接ファイルをアップロードします。
    /// Base64エンコードが不要なため、大きなファイルのアップロードに適しています。
    /// </remarks>
    public async Task<ApiResponse<UploadBinaryResponse>> UploadBinaryStreamAsync(
        long siteId,
        byte[] fileData,
        string fileName,
        string? contentType = null,
        TimeSpan? timeout = null)
    {
        if (fileData == null) throw new ArgumentNullException(nameof(fileData));
        using var stream = new MemoryStream(fileData);
        return await UploadBinaryStreamAsync(siteId, stream, fileName, contentType, timeout);
    }

    /// <summary>
    /// ファイルパスを指定してストリームでアップロードします（新規添付ファイル作成）
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="filePath">ファイルパス</param>
    /// <param name="contentType">コンテンツタイプ（省略時は自動判定）</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>アップロードレスポンス</returns>
    /// <remarks>
    /// このメソッドはBearer認証を使用し、マルチパートフォームデータで直接ファイルをアップロードします。
    /// Base64エンコードが不要なため、大きなファイルのアップロードに適しています。
    /// </remarks>
    public async Task<ApiResponse<UploadBinaryResponse>> UploadBinaryStreamFromFileAsync(
        long siteId,
        string filePath,
        string? contentType = null,
        TimeSpan? timeout = null)
    {
        if (string.IsNullOrEmpty(filePath)) throw new ArgumentNullException(nameof(filePath));

        var fileName = Path.GetFileName(filePath);
        using var fileStream = File.OpenRead(filePath);
        return await UploadBinaryStreamAsync(siteId, fileStream, fileName, contentType, timeout);
    }

    /// <summary>
    /// 既存の添付ファイルを更新します（GUID指定）
    /// </summary>
    /// <param name="guid">更新対象のファイルGUID</param>
    /// <param name="fileStream">ファイルストリーム</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="contentType">コンテンツタイプ</param>
    /// <param name="overwrite">上書きモード（true: 同じGUIDで上書き、false: 新しいGUIDを生成）</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>アップロードレスポンス</returns>
    /// <remarks>
    /// このメソッドはBearer認証を使用し、マルチパートフォームデータで直接ファイルをアップロードします。
    /// 既存の添付ファイルを更新する場合に使用します。
    /// </remarks>
    public async Task<ApiResponse<UploadBinaryResponse>> UpdateBinaryStreamAsync(
        string guid,
        Stream fileStream,
        string fileName,
        string? contentType = null,
        bool overwrite = false,
        TimeSpan? timeout = null)
    {
        if (string.IsNullOrEmpty(guid)) throw new ArgumentNullException(nameof(guid));
        if (fileStream == null) throw new ArgumentNullException(nameof(fileStream));
        if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException(nameof(fileName));

        var endpoint = $"/api/binaries/{guid}/upload";
        if (overwrite)
        {
            endpoint += "?overwrite=true";
        }

        return await SendMultipartWithBearerAsync<UploadBinaryResponse>(
            endpoint,
            fileStream,
            fileName,
            contentType,
            rangeFrom: null,
            rangeTo: null,
            rangeTotal: null,
            fileHash: null,
            timeout);
    }

    /// <summary>
    /// 既存の添付ファイルを更新します（GUID指定、byte[]版）
    /// </summary>
    /// <param name="guid">更新対象のファイルGUID</param>
    /// <param name="fileData">ファイルデータ</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="contentType">コンテンツタイプ</param>
    /// <param name="overwrite">上書きモード（true: 同じGUIDで上書き、false: 新しいGUIDを生成）</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>アップロードレスポンス</returns>
    public async Task<ApiResponse<UploadBinaryResponse>> UpdateBinaryStreamAsync(
        string guid,
        byte[] fileData,
        string fileName,
        string? contentType = null,
        bool overwrite = false,
        TimeSpan? timeout = null)
    {
        if (fileData == null) throw new ArgumentNullException(nameof(fileData));
        using var stream = new MemoryStream(fileData);
        return await UpdateBinaryStreamAsync(guid, stream, fileName, contentType, overwrite, timeout);
    }

    #endregion

    #region UploadBinaryChunked (分割アップロード - Bearer認証)

    /// <summary>
    /// ファイルを分割（チャンク）でアップロードします
    /// </summary>
    /// <param name="siteId">サイトID</param>
    /// <param name="chunkData">チャンクデータ</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="rangeFrom">Content-Rangeの開始バイト位置</param>
    /// <param name="rangeTo">Content-Rangeの終了バイト位置</param>
    /// <param name="rangeTotal">ファイル全体のバイトサイズ</param>
    /// <param name="contentType">コンテンツタイプ</param>
    /// <param name="fileHash">ファイルハッシュ（最終チャンク時に検証用）</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>アップロードレスポンス</returns>
    /// <remarks>
    /// 大きなファイルを複数のチャンクに分割してアップロードする場合に使用します。
    /// Content-Rangeヘッダー（例: bytes 0-999999/5000000）を指定することで、サーバー側で分割受信が可能です。
    /// </remarks>
    public async Task<ApiResponse<UploadBinaryResponse>> UploadBinaryChunkAsync(
        long siteId,
        byte[] chunkData,
        string fileName,
        long rangeFrom,
        long rangeTo,
        long rangeTotal,
        string? contentType = null,
        string? fileHash = null,
        TimeSpan? timeout = null)
    {
        if (chunkData == null) throw new ArgumentNullException(nameof(chunkData));
        if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException(nameof(fileName));

        using var stream = new MemoryStream(chunkData);
        return await SendMultipartWithBearerAsync<UploadBinaryResponse>(
            $"/api/binaries/upload?id={siteId}",
            stream,
            fileName,
            contentType,
            rangeFrom,
            rangeTo,
            rangeTotal,
            fileHash,
            timeout);
    }

    /// <summary>
    /// 既存ファイルを分割（チャンク）で更新します
    /// </summary>
    /// <param name="guid">更新対象のファイルGUID</param>
    /// <param name="chunkData">チャンクデータ</param>
    /// <param name="fileName">ファイル名</param>
    /// <param name="rangeFrom">Content-Rangeの開始バイト位置</param>
    /// <param name="rangeTo">Content-Rangeの終了バイト位置</param>
    /// <param name="rangeTotal">ファイル全体のバイトサイズ</param>
    /// <param name="contentType">コンテンツタイプ</param>
    /// <param name="overwrite">上書きモード</param>
    /// <param name="fileHash">ファイルハッシュ（最終チャンク時に検証用）</param>
    /// <param name="timeout">タイムアウト</param>
    /// <returns>アップロードレスポンス</returns>
    /// <remarks>
    /// 既存の添付ファイルを分割アップロードで更新する場合に使用します。
    /// </remarks>
    public async Task<ApiResponse<UploadBinaryResponse>> UpdateBinaryChunkAsync(
        string guid,
        byte[] chunkData,
        string fileName,
        long rangeFrom,
        long rangeTo,
        long rangeTotal,
        string? contentType = null,
        bool overwrite = false,
        string? fileHash = null,
        TimeSpan? timeout = null)
    {
        if (string.IsNullOrEmpty(guid)) throw new ArgumentNullException(nameof(guid));
        if (chunkData == null) throw new ArgumentNullException(nameof(chunkData));
        if (string.IsNullOrEmpty(fileName)) throw new ArgumentNullException(nameof(fileName));

        var endpoint = $"/api/binaries/{guid}/upload";
        if (overwrite)
        {
            endpoint += "?overwrite=true";
        }

        using var stream = new MemoryStream(chunkData);
        return await SendMultipartWithBearerAsync<UploadBinaryResponse>(
            endpoint,
            stream,
            fileName,
            contentType,
            rangeFrom,
            rangeTo,
            rangeTotal,
            fileHash,
            timeout);
    }

    #endregion
}