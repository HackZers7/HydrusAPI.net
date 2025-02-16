using HydrusAPI.Web.Http;
using System.Security.Authentication;

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
	public Task<ImportResult> SendFile(string filePath, bool deleteAfterImport = false, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(filePath);

		return SendFile(
			new AddFileRequest
			{
				Path = filePath,
				DeleteAfterSuccessfulImport = deleteAfterImport
			}, cancel
		);
	}

	/// <inheritdoc />
	public Task<ImportResult> SendFile(AddFileRequest request, CancellationToken cancel = default)
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
		return UndeleteFiles(new FilesWithDomainRequest(hashes));
	}

	/// <inheritdoc />
	public Task<bool> UndeleteFiles(params ulong[] ids)
	{
		return UndeleteFiles(new FilesWithDomainRequest(ids));
	}

	/// <inheritdoc />
	public async Task<bool> UndeleteFiles(FilesWithDomainRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(HydrusUrls.UndeleteFiles(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<bool> ClearFilesDeletion(params string[] hashes)
	{
		return ClearFilesDeletion(new FilesRequest(hashes));
	}

	/// <inheritdoc />
	public Task<bool> ClearFilesDeletion(params ulong[] ids)
	{
		return ClearFilesDeletion(new FilesRequest(ids));
	}

	/// <inheritdoc />
	public async Task<bool> ClearFilesDeletion(FilesRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(HydrusUrls.ClearFilesDeletion(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<bool> MigrateFiles(string toFileDomain, params string[] hashes)
	{
		return MigrateFiles(new FilesWithDomainRequest(hashes)
		{
			FileServiceKey = toFileDomain
		});
	}

	/// <inheritdoc />
	public Task<bool> MigrateFiles(string toFileDomain, params ulong[] ids)
	{
		return MigrateFiles(new FilesWithDomainRequest(ids)
		{
			FileServiceKey = toFileDomain
		});
	}

	/// <inheritdoc />
	public async Task<bool> MigrateFiles(FilesWithDomainRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(HydrusUrls.MigrateFiles(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<bool> ArchiveFiles(params string[] hashes)
	{
		return ArchiveFiles(new FilesRequest(hashes));
	}

	/// <inheritdoc />
	public Task<bool> ArchiveFiles(params ulong[] ids)
	{
		return ArchiveFiles(new FilesRequest(ids));
	}

	/// <inheritdoc />
	public async Task<bool> ArchiveFiles(FilesRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(HydrusUrls.ArchiveFiles(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<bool> UnarchiveFiles(params string[] hashes)
	{
		return UnarchiveFiles(new FilesRequest(hashes));
	}

	/// <inheritdoc />
	public Task<bool> UnarchiveFiles(params ulong[] ids)
	{
		return UnarchiveFiles(new FilesRequest(ids));
	}

	/// <inheritdoc />
	public async Task<bool> UnarchiveFiles(FilesRequest request, CancellationToken cancel = default)
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
		ThrowHelper.ArgumentNotNull(file);

		return ApiConnection.Post<GeneratedHashesResponse>(HydrusUrls.GenerateHashes(), null, file, cancel);
	}

	/// <inheritdoc />
	public Task<FilesSearchResponse> SearchFiles(
		IEnumerable<object> tags,
		string? tagServiceKey = null,
		bool includeCurrentTags = true,
		bool includePendingTags = true,
		SortingType fileSortType = SortingType.ImportTime,
		bool fileSortAsc = true,
		bool returnFileIds = true,
		bool returnHashes = true,
		CancellationToken cancel = default
	)
	{
		return SearchFiles(new SearchFilesRequest
		{
			Tags = new List<object>(tags),
			TagServiceKey = tagServiceKey,
			IncludeCurrentTags = includeCurrentTags,
			IncludePendingTags = includePendingTags,
			FileSortType = (int)fileSortType,
			FileSortAsc = fileSortAsc,
			ReturnFileIds = returnFileIds,
			ReturnHashes = returnHashes
		}, cancel);
	}

	/// <inheritdoc />
	public Task<FilesSearchResponse> SearchFiles(SearchFilesRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Get<FilesSearchResponse>(HydrusUrls.SearchFiles(request), cancel);
	}

	/// <inheritdoc />
	public Task<IDictionary<string, string>> GetFileHashes(string hash, HashAlgorithmType desiredHashType, HashAlgorithmType sourceHashType = HashAlgorithmType.Sha256, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		return GetFileHashes(new FileHashesRequest
		{
			Hash = hash,
			DesiredHashType = desiredHashType.ToString().ToLower(),
			SourceHashType = sourceHashType.ToString().ToLower()
		}, cancel);
	}

	/// <inheritdoc />
	public Task<IDictionary<string, string>> GetFileHashes(IEnumerable<string> hashes, HashAlgorithmType desiredHashType, HashAlgorithmType sourceHashType = HashAlgorithmType.Sha256, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(hashes);

		return GetFileHashes(new FileHashesRequest
		{
			Hashes = new List<string>(hashes),
			DesiredHashType = desiredHashType.ToString().ToLower(),
			SourceHashType = sourceHashType.ToString().ToLower()
		}, cancel);
	}

	/// <inheritdoc />
	public async Task<IDictionary<string, string>> GetFileHashes(FileHashesRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Get<FileHashesResponse>(HydrusUrls.GetFileHashes(request), cancel);
		return response.Hashes;
	}

	/// <inheritdoc />
	public async Task<Stream> GetFile(string hash, bool download = false, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		var response = await ApiConnection.GetRawStream(HydrusUrls.GetFile(hash, download), cancel);

		return response.Body!;
	}

	/// <inheritdoc />
	public async Task<Stream> GetFile(ulong fileId, bool download = false, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentOutOfRange(fileId, (ulong)1, ulong.MaxValue);

		var response = await ApiConnection.GetRawStream(HydrusUrls.GetFile(fileId, download), cancel);

		return response.Body!;
	}

	/// <inheritdoc />
	public async Task<Stream> GetThumbnail(string hash, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		var response = await ApiConnection.GetRawStream(HydrusUrls.GetThumbnail(hash), cancel);

		return response.Body!;
	}

	/// <inheritdoc />
	public async Task<Stream> GetThumbnail(ulong fileId, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentOutOfRange(fileId, (ulong)1, ulong.MaxValue);

		var response = await ApiConnection.GetRawStream(HydrusUrls.GetThumbnail(fileId), cancel);

		return response.Body!;
	}

	/// <inheritdoc />
	public Task<Stream> Render(
		string hash,
		bool download = false,
		RenderOutputFormat renderFormat = RenderOutputFormat.Png,
		ushort? renderQuality = null,
		ulong? width = null,
		ulong? height = null,
		CancellationToken cancel = default
	)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		return Render(new RenderRequest
		{
			Hash = hash,
			Download = download,
			RenderFormat = (int)renderFormat,
			RenderQuality = renderQuality,
			Width = width,
			Height = height
		}, cancel);
	}

	public Task<Stream> Render(
		ulong fileId,
		bool download = false,
		RenderOutputFormat renderFormat = RenderOutputFormat.Png,
		ushort? renderQuality = null,
		ulong? width = null,
		ulong? height = null,
		CancellationToken cancel = default
	)
	{
		ThrowHelper.ArgumentOutOfRange(fileId, (ulong)1, ulong.MaxValue);

		return Render(new RenderRequest
		{
			FileId = fileId,
			Download = download,
			RenderFormat = (int)renderFormat,
			RenderQuality = renderQuality,
			Width = width,
			Height = height
		}, cancel);
	}

	/// <inheritdoc />
	public async Task<Stream> Render(RenderRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.GetRawStream(HydrusUrls.Render(request), cancel);

		return response.Body!;
	}
}
