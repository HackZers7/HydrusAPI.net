using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент для работы с файлами.
/// </summary>
public class FilesClient : ApiClient, IFilesClient
{
	/// <inheritdoc />
	public FilesClient(IApiConnection apiConnection) : base(apiConnection)
	{
	}

	/// <inheritdoc />
	public Task<ImportResult> SendLocalFile(string filePath, bool deleteAfterImport = false, string? fileDomain = null, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(filePath);

		return SendLocalFile(new ImportFileRequest(filePath, deleteAfterImport, fileDomain), cancel);
	}

	/// <inheritdoc />
	public Task<ImportResult> SendLocalFile(ImportFileRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post<ImportResult>(HydrusUrls.AddFile(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task<ImportResult> SendFile(Stream file, CancellationToken cancel = default)
	{
		return ApiConnection.Post<ImportResult>(HydrusUrls.AddFile(), null, file, cancel);
	}

	/// <inheritdoc />
	public Task<bool> DeleteFile(string hash, string? fileDomain = null, string? reason = null, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		return DeleteFile(new DeleteFilesByHashRequest(hash, fileDomain, reason), cancel);
	}

	/// <inheritdoc />
	public Task<bool> DeleteFile(params string[] hashes)
	{
		return DeleteFile(hashes, null);
	}

	/// <inheritdoc />
	public Task<bool> DeleteFile(IEnumerable<string> hashes, string? fileDomain = null, string? reason = null, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(hashes);

		return DeleteFile(new DeleteFilesByHashRequest(hashes, fileDomain, reason), cancel);
	}

	/// <inheritdoc />
	public async Task<bool> DeleteFile(DeleteFilesByHashRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.DeleteFile(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<bool> DeleteFile(ulong id, string? fileDomain = null, string? reason = null, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(id);

		return DeleteFile(new DeleteFilesByIdRequest(id, fileDomain, reason), cancel);
	}

	/// <inheritdoc />
	public Task<bool> DeleteFile(params ulong[] ids)
	{
		return DeleteFile(ids, null);
	}

	/// <inheritdoc />
	public Task<bool> DeleteFile(IEnumerable<ulong> ids, string? fileDomain = null, string? reason = null, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(ids);

		return DeleteFile(new DeleteFilesByIdRequest(ids, fileDomain, reason), cancel);
	}

	/// <inheritdoc />
	public async Task<bool> DeleteFile(DeleteFilesByIdRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.DeleteFile(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}
}
