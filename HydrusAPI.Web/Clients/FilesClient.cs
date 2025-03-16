using HydrusAPI.Web.Http;
using System.Security.Authentication;

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
	public Task<ImportResultResponse> SendFile(string filePath, bool deleteAfterImport = false, CancellationToken cancel = default)
	{
		return SendFile(new AddFileRequest(filePath, deleteAfterImport), cancel);
	}

	/// <inheritdoc />
	public Task<ImportResultResponse> SendFile(AddFileRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post<ImportResultResponse>(HydrusUrls.AddFile(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task<ImportResultResponse> SendFile(Stream file, CancellationToken cancel = default)
	{
		return ApiConnection.Post<ImportResultResponse>(HydrusUrls.AddFile(), null, file, cancel);
	}

	/// <inheritdoc />
	public Task DeleteFiles(string hash, string? reason = null, CancellationToken cancel = default)
	{
		return DeleteFiles(new DeleteFilesRequest(hash, reason), cancel);
	}

	/// <inheritdoc />
	public Task DeleteFiles(ulong id, string? reason = null, CancellationToken cancel = default)
	{
		return DeleteFiles(new DeleteFilesRequest(id, reason), cancel);
	}

	/// <inheritdoc />
	public Task DeleteFiles(IList<string> hashes, string? reason = null, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(hashes);

		return DeleteFiles(new DeleteFilesRequest(hashes, reason), cancel);
	}

	/// <inheritdoc />
	public Task DeleteFiles(IList<ulong> ids, string? reason = null, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(ids);

		return DeleteFiles(new DeleteFilesRequest(ids, reason), cancel);
	}

	/// <inheritdoc />
	public Task DeleteFiles(DeleteFilesRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post(HydrusUrls.DeleteFiles(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task RestoreFiles(string hash)
	{
		return RestoreFiles(new FilesWithDomainRequest(hash));
	}

	/// <inheritdoc />
	public Task RestoreFiles(IList<string> hashes)
	{
		ThrowHelper.ArgumentNotNull(hashes);

		return RestoreFiles(new FilesWithDomainRequest(hashes));
	}

	/// <inheritdoc />
	public Task RestoreFiles(ulong id)
	{
		return RestoreFiles(new FilesWithDomainRequest(id));
	}

	/// <inheritdoc />
	public Task RestoreFiles(IList<ulong> ids)
	{
		ThrowHelper.ArgumentNotNull(ids);

		return RestoreFiles(new FilesWithDomainRequest(ids));
	}

	/// <inheritdoc />
	public Task RestoreFiles(FilesWithDomainRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post(HydrusUrls.RestoreFiles(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task ClearFilesDeletion(string hash)
	{
		return ClearFilesDeletion(new FilesRequest(hash));
	}

	/// <inheritdoc />
	public Task ClearFilesDeletion(IList<string> hashes)
	{
		ThrowHelper.ArgumentNotNull(hashes);

		return ClearFilesDeletion(new FilesRequest(hashes));
	}

	/// <inheritdoc />
	public Task ClearFilesDeletion(ulong id)
	{
		return ClearFilesDeletion(new FilesRequest(id));
	}

	/// <inheritdoc />
	public Task ClearFilesDeletion(IList<ulong> ids)
	{
		ThrowHelper.ArgumentNotNull(ids);

		return ClearFilesDeletion(new FilesRequest(ids));
	}

	/// <inheritdoc />
	public Task ClearFilesDeletion(FilesRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post(HydrusUrls.ClearFilesDeletion(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task MigrateFiles(string toFileDomain, string hash)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(toFileDomain);

		return MigrateFiles(new FilesWithDomainRequest(hash)
		{
			FileServiceKey = toFileDomain
		});
	}

	/// <inheritdoc />
	public Task MigrateFiles(string toFileDomain, IList<string> hashes)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(toFileDomain);
		ThrowHelper.ArgumentNotNull(hashes);

		return MigrateFiles(new FilesWithDomainRequest(hashes)
		{
			FileServiceKey = toFileDomain
		});
	}

	/// <inheritdoc />
	public Task MigrateFiles(string toFileDomain, ulong id)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(toFileDomain);

		return MigrateFiles(new FilesWithDomainRequest(id)
		{
			FileServiceKey = toFileDomain
		});
	}

	/// <inheritdoc />
	public Task MigrateFiles(string toFileDomain, IList<ulong> ids)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(toFileDomain);
		ThrowHelper.ArgumentNotNull(ids);

		return MigrateFiles(new FilesWithDomainRequest(ids)
		{
			FileServiceKey = toFileDomain
		});
	}

	/// <inheritdoc />
	public Task MigrateFiles(FilesWithDomainRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post(HydrusUrls.MigrateFiles(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task ArchiveFiles(string hash)
	{
		return ArchiveFiles(new FilesRequest(hash));
	}

	/// <inheritdoc />
	public Task ArchiveFiles(IList<string> hashes)
	{
		ThrowHelper.ArgumentNotNull(hashes);

		return ArchiveFiles(new FilesRequest(hashes));
	}

	/// <inheritdoc />
	public Task ArchiveFiles(ulong id)
	{
		return ArchiveFiles(new FilesRequest(id));
	}

	/// <inheritdoc />
	public Task ArchiveFiles(IList<ulong> ids)
	{
		ThrowHelper.ArgumentNotNull(ids);

		return ArchiveFiles(new FilesRequest(ids));
	}

	/// <inheritdoc />
	public Task ArchiveFiles(FilesRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post(HydrusUrls.ArchiveFiles(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task UnarchiveFiles(string hash)
	{
		return UnarchiveFiles(new FilesRequest(hash));
	}

	/// <inheritdoc />
	public Task UnarchiveFiles(IList<string> hashes)
	{
		ThrowHelper.ArgumentNotNull(hashes);

		return UnarchiveFiles(new FilesRequest(hashes));
	}

	/// <inheritdoc />
	public Task UnarchiveFiles(ulong id)
	{
		return UnarchiveFiles(new FilesRequest(id));
	}

	/// <inheritdoc />
	public Task UnarchiveFiles(IList<ulong> ids)
	{
		ThrowHelper.ArgumentNotNull(ids);

		return UnarchiveFiles(new FilesRequest(ids));
	}

	/// <inheritdoc />
	public Task UnarchiveFiles(FilesRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post(HydrusUrls.UnarchiveFiles(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task<GeneratedHashesResponse> GenerateHashes(string filePath, CancellationToken cancel = default)
	{
		return GenerateHashes(new LocalFileRequest(filePath), cancel);
	}

	/// <inheritdoc />
	public Task<GeneratedHashesResponse> GenerateHashes(LocalFileRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post<GeneratedHashesResponse>(HydrusUrls.GenerateHashes(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task<GeneratedHashesResponse> GenerateHashes(Stream file, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(file);

		return ApiConnection.Post<GeneratedHashesResponse>(HydrusUrls.GenerateHashes(), null, file, cancel);
	}

	/// <inheritdoc />
	public Task<FilesSearchResponse> SearchFiles(IList<object> tags, CancellationToken cancel = default)
	{
		return SearchFiles(new SearchFilesRequest(tags), cancel);
	}

	/// <inheritdoc />
	public Task<FilesSearchResponse> SearchFiles(IList<string> tags, CancellationToken cancel = default)
	{
		return SearchFiles(new SearchFilesRequest(tags), cancel);
	}

	/// <inheritdoc />
	public Task<FilesSearchResponse> SearchFiles(SearchFilesRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Get<FilesSearchResponse>(HydrusUrls.SearchFiles(request), cancel);
	}

	/// <inheritdoc />
	public Task<FileHashesResponse> GetFileHashes(string hash, HashAlgorithmType desiredHashType, HashAlgorithmType sourceHashType = HashAlgorithmType.Sha256, CancellationToken cancel = default)
	{
		return GetFileHashes(new FileHashesRequest(hash, desiredHashType, sourceHashType), cancel);
	}

	/// <inheritdoc />
	public Task<FileHashesResponse> GetFileHashes(IList<string> hashes, HashAlgorithmType desiredHashType, HashAlgorithmType sourceHashType = HashAlgorithmType.Sha256, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(hashes);

		return GetFileHashes(new FileHashesRequest(hashes, desiredHashType, sourceHashType), cancel);
	}

	/// <inheritdoc />
	public Task<FileHashesResponse> GetFileHashes(FileHashesRequest request, CancellationToken cancel = default)
	{
		return ApiConnection.Get<FileHashesResponse>(HydrusUrls.GetFileHashes(request), cancel);
	}

	/// <inheritdoc />
	public async Task<StreamWithContentType> GetFile(string hash, bool download = false, CancellationToken cancel = default)
	{
		var response = await ApiConnection.GetRawStream(HydrusUrls.GetFile(hash, download), cancel);

		return new StreamWithContentType(response.Body!, response.Response.ContentType!);
	}

	/// <inheritdoc />
	public async Task<StreamWithContentType> GetFile(ulong fileId, bool download = false, CancellationToken cancel = default)
	{
		var response = await ApiConnection.GetRawStream(HydrusUrls.GetFile(fileId, download), cancel);

		return new StreamWithContentType(response.Body!, response.Response.ContentType!);
	}

	/// <inheritdoc />
	public async Task<StreamWithContentType> GetThumbnail(string hash, CancellationToken cancel = default)
	{
		var response = await ApiConnection.GetRawStream(HydrusUrls.GetThumbnail(hash), cancel);

		return new StreamWithContentType(response.Body!, response.Response.ContentType!);
	}

	/// <inheritdoc />
	public async Task<StreamWithContentType> GetThumbnail(ulong fileId, CancellationToken cancel = default)
	{
		var response = await ApiConnection.GetRawStream(HydrusUrls.GetThumbnail(fileId), cancel);

		return new StreamWithContentType(response.Body!, response.Response.ContentType!);
	}

	/// <inheritdoc />
	public Task<Stream> Render(string hash, CancellationToken cancel = default
	)
	{
		return Render(new RenderRequest(hash), cancel);
	}

	/// <inheritdoc />
	public Task<Stream> Render(ulong fileId, CancellationToken cancel = default)
	{
		return Render(new RenderRequest(fileId), cancel);
	}

	/// <inheritdoc />
	public async Task<Stream> Render(RenderRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.GetRawStream(HydrusUrls.Render(request), cancel);

		return response.Body!;
	}
}
