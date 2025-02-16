using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент для редактирования метаданных файла.
/// </summary>
public class MetaClient : ApiClient, IMetaClient
{
	/// <inheritdoc />
	public MetaClient(IApiConnection apiConnection) : base(apiConnection)
	{
	}

	/// <inheritdoc />
	public async Task<bool> SetRating(SetRatingRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.SetRating(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public async Task<bool> IncrementFileViewtime(ViewtimeRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.IncrementFileViewtime(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public async Task<bool> SetFileViewtime(ViewtimeRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.SetFileViewtime(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public async Task<bool> SetTime(SetTimeRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.SetTime(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<NotesResponse> SetNotes(SetNotesRequest request, CancellationToken cancel = default)
	{
		return ApiConnection.Post<NotesResponse>(HydrusUrls.SetNotes(), null, request, cancel);
	}

	/// <inheritdoc />
	public async Task<bool> DeleteNotes(DeleteNotesRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.DeleteNotes(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public async Task<IEnumerable<MetaData>> GetMetaData(
		string hash,
		bool createNewFileIds = false,
		bool detailedUrlInformation = false,
		bool includeMilliseconds = false,
		bool includeNotes = false,
		CancellationToken cancel = default
	)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		var response = await GetMetaData(new MetaDataRequest
		{
			Hash = hash,
			CreateNewFileIds = createNewFileIds,
			OnlyReturnIdentifiers = false,
			OnlyReturnBasicInformation = false,
			DetailedUrlInformation = detailedUrlInformation,
			IncludeBlurHash = false,
			IncludeMilliseconds = includeMilliseconds,
			IncludeNotes = includeNotes,
			IncludeServicesObject = false
		}, cancel);

		return response.Metadata;
	}

	/// <inheritdoc />
	public async Task<IEnumerable<MetaData>> GetMetaData(
		IEnumerable<string> hashes,
		bool createNewFileIds = false,
		bool detailedUrlInformation = false,
		bool includeMilliseconds = false,
		bool includeNotes = false,
		CancellationToken cancel = default
	)
	{
		ThrowHelper.ArgumentNotNull(hashes);

		var response = await GetMetaData(new MetaDataRequest
		{
			Hashes = new List<string>(hashes),
			CreateNewFileIds = createNewFileIds,
			OnlyReturnIdentifiers = false,
			OnlyReturnBasicInformation = false,
			DetailedUrlInformation = detailedUrlInformation,
			IncludeBlurHash = false,
			IncludeMilliseconds = includeMilliseconds,
			IncludeNotes = includeNotes,
			IncludeServicesObject = false
		}, cancel);

		return response.Metadata;
	}

	/// <inheritdoc />
	public async Task<IEnumerable<MetaData>> GetMetaData(
		ulong fileId,
		bool createNewFileIds = false,
		bool detailedUrlInformation = false,
		bool includeMilliseconds = false,
		bool includeNotes = false,
		CancellationToken cancel = default
	)
	{
		ThrowHelper.ArgumentOutOfRange(fileId, (ulong)1, ulong.MaxValue);

		var response = await GetMetaData(new MetaDataRequest
		{
			FileId = fileId,
			CreateNewFileIds = createNewFileIds,
			OnlyReturnIdentifiers = false,
			OnlyReturnBasicInformation = false,
			DetailedUrlInformation = detailedUrlInformation,
			IncludeBlurHash = false,
			IncludeMilliseconds = includeMilliseconds,
			IncludeNotes = includeNotes,
			IncludeServicesObject = false
		}, cancel);

		return response.Metadata;
	}

	/// <inheritdoc />
	public async Task<IEnumerable<MetaData>> GetMetaData(
		IEnumerable<ulong> fileIds,
		bool createNewFileIds = false,
		bool detailedUrlInformation = false,
		bool includeMilliseconds = false,
		bool includeNotes = false,
		CancellationToken cancel = default
	)
	{
		ThrowHelper.ArgumentNotNull(fileIds);

		var response = await GetMetaData(new MetaDataRequest
		{
			FileIds = new List<ulong>(fileIds),
			CreateNewFileIds = createNewFileIds,
			OnlyReturnIdentifiers = false,
			OnlyReturnBasicInformation = false,
			DetailedUrlInformation = detailedUrlInformation,
			IncludeBlurHash = false,
			IncludeMilliseconds = includeMilliseconds,
			IncludeNotes = includeNotes,
			IncludeServicesObject = false
		}, cancel);

		return response.Metadata;
	}
	
	/// <inheritdoc />
	public Task<MetaDataResponse<MetaData>> GetMetaData(MetaDataRequest request, CancellationToken cancel = default)
	{
		return ApiConnection.Get<MetaDataResponse<MetaData>>(HydrusUrls.GetMetadata(request), cancel);
	}

	/// <inheritdoc />
	public async Task<IEnumerable<MetaDataId>> GetId(string hash, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		var request = HydrusUrls.GetMetadata(new MetaDataRequest
		{
			Hash = hash,
			OnlyReturnIdentifiers = true,
			IncludeServicesObject = false
		});
		var response = await ApiConnection.Get<MetaDataResponse<MetaDataId>>(request, cancel);

		return response.Metadata;
	}

	/// <inheritdoc />
	public async Task<IEnumerable<MetaDataId>> GetId(IEnumerable<string> hashes, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(hashes);

		var request = HydrusUrls.GetMetadata(new MetaDataRequest
		{
			Hashes = new List<string>(hashes),
			OnlyReturnIdentifiers = true,
			IncludeServicesObject = false
		});
		var response = await ApiConnection.Get<MetaDataResponse<MetaDataId>>(request, cancel);

		return response.Metadata;
	}

	/// <inheritdoc />
	public async Task<IEnumerable<MetaDataId>> GetHash(ulong fileId, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentOutOfRange(fileId, (ulong)1, ulong.MaxValue);

		var request = HydrusUrls.GetMetadata(new MetaDataRequest
		{
			FileId = fileId,
			OnlyReturnIdentifiers = true,
			IncludeServicesObject = false
		});
		var response = await ApiConnection.Get<MetaDataResponse<MetaDataId>>(request, cancel);

		return response.Metadata;
	}

	/// <inheritdoc />
	public async Task<IEnumerable<MetaDataId>> GetHash(IEnumerable<ulong> fileIds, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(fileIds);

		var request = HydrusUrls.GetMetadata(new MetaDataRequest
		{
			FileIds = new List<ulong>(fileIds),
			OnlyReturnIdentifiers = true,
			IncludeServicesObject = false
		});
		var response = await ApiConnection.Get<MetaDataResponse<MetaDataId>>(request, cancel);

		return response.Metadata;
	}

	/// <inheritdoc />
	public Task<FilePathResponse> GetFilePath(string hash, CancellationToken cancel = default)
	{
		return ApiConnection.Get<FilePathResponse>(HydrusUrls.GetFilePath(hash), cancel);
	}

	/// <inheritdoc />
	public Task<FilePathResponse> GetFilePath(ulong fileId, CancellationToken cancel = default)
	{
		return ApiConnection.Get<FilePathResponse>(HydrusUrls.GetFilePath(fileId), cancel);
	}

	/// <inheritdoc />
	public Task<ThumbnailFilePathResponse> GetThumbnailFilePath(string hash, bool includeThumbnailFiletype = false, CancellationToken cancel = default)
	{
		return ApiConnection.Get<ThumbnailFilePathResponse>(HydrusUrls.GetThumbnailFilePath(hash, includeThumbnailFiletype), cancel);
	}

	/// <inheritdoc />
	public Task<ThumbnailFilePathResponse> GetThumbnailFilePath(ulong fileId, bool includeThumbnailFiletype = false, CancellationToken cancel = default)
	{
		return ApiConnection.Get<ThumbnailFilePathResponse>(HydrusUrls.GetThumbnailFilePath(fileId, includeThumbnailFiletype), cancel);
	}
}
