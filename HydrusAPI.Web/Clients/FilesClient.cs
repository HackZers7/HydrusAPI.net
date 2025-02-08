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
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(HydrusUrls.DeleteFiles(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<bool> UndeleteFiles(params string[] hashes)
	{
		return UndeleteFiles(new FilesWithDomain(hashes));
	}

	/// <inheritdoc />
	public Task<bool> UndeleteFiles(params ulong[] ids)
	{
		return UndeleteFiles(new FilesWithDomain(ids));
	}

	/// <inheritdoc />
	public async Task<bool> UndeleteFiles(FilesWithDomain request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(HydrusUrls.UndeleteFiles(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<bool> ClearFilesDeletion(params string[] hashes)
	{
		return ClearFilesDeletion(new Files(hashes));
	}

	/// <inheritdoc />
	public Task<bool> ClearFilesDeletion(params ulong[] ids)
	{
		return ClearFilesDeletion(new Files(ids));
	}

	/// <inheritdoc />
	public async Task<bool> ClearFilesDeletion(Files request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(HydrusUrls.ClearFilesDeletion(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<bool> MigrateFiles(string toFileDomain, params string[] hashes)
	{
		var files = new FilesWithDomain(hashes);
		files.AddFileDomain(toFileDomain);
		return MigrateFiles(files);
	}

	/// <inheritdoc />
	public Task<bool> MigrateFiles(string toFileDomain, params ulong[] ids)
	{
		var files = new FilesWithDomain(ids);
		files.AddFileDomain(toFileDomain);
		return MigrateFiles(files);
	}

	/// <inheritdoc />
	public async Task<bool> MigrateFiles(FilesWithDomain request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(HydrusUrls.MigrateFiles(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<bool> ArchiveFiles(params string[] hashes)
	{
		return ArchiveFiles(new Files(hashes));
	}

	/// <inheritdoc />
	public Task<bool> ArchiveFiles(params ulong[] ids)
	{
		return ArchiveFiles(new Files(ids));
	}

	/// <inheritdoc />
	public async Task<bool> ArchiveFiles(Files request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(HydrusUrls.ArchiveFiles(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<bool> UnarchiveFiles(params string[] hashes)
	{
		return UnarchiveFiles(new Files(hashes));
	}

	/// <inheritdoc />
	public Task<bool> UnarchiveFiles(params ulong[] ids)
	{
		return UnarchiveFiles(new Files(ids));
	}

	/// <inheritdoc />
	public async Task<bool> UnarchiveFiles(Files request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(HydrusUrls.UnarchiveFiles(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<GeneratedHashesResponse> GenerateHashes(string filePath, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(filePath);

		return ApiConnection.Post<GeneratedHashesResponse>(HydrusUrls.GenerateHashes(), null, new LocalFile(filePath), cancel);
	}

	/// <inheritdoc />
	public Task<GeneratedHashesResponse> GenerateHashes(Stream file, CancellationToken cancel = default)
	{
		return ApiConnection.Post<GeneratedHashesResponse>(HydrusUrls.GenerateHashes(), null, file, cancel);
	}
}
