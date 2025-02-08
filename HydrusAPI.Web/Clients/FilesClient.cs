using HydrusAPI.Web.Http;

// ReSharper disable PossibleMultipleEnumeration

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
	public Task<ImportResult> SendLocalFile(string filePath, bool deleteAfterImport = false, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(filePath);

		return SendLocalFile(new AddFileRequest(filePath, deleteAfterImport), cancel);
	}

	/// <inheritdoc />
	public Task<ImportResult> SendLocalFile(AddFileRequest request, CancellationToken cancel = default)
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
	public Task<bool> DeleteFiles(params string[] hashes)
	{
		return DeleteFiles(hashes, null);
	}

	/// <inheritdoc />
	public Task<bool> DeleteFiles(IEnumerable<string> hashes, string? reason = null, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(hashes);

		return DeleteFiles(new DeleteFilesRequest(hashes, reason), cancel);
	}

	/// <inheritdoc />
	public Task<bool> DeleteFiles(params ulong[] ids)
	{
		return DeleteFiles(ids, null);
	}

	/// <inheritdoc />
	public Task<bool> DeleteFiles(IEnumerable<ulong> ids, string? reason = null, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(ids);

		return DeleteFiles(new DeleteFilesRequest(ids, reason), cancel);
	}

	/// <inheritdoc />
	public async Task<bool> DeleteFiles(DeleteFilesRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.DeleteFile(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}
}
