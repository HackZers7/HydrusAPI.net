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
}
