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
	public Task SetRating(string hash, string ratingServiceKey, int? rating = null, CancellationToken cancel = default)
	{
		return SetRating(new SetRatingRequest(hash, ratingServiceKey)
		{
			Rating = rating
		}, cancel);
	}

	/// <inheritdoc />
	public Task SetRating(string hash, string ratingServiceKey, bool rating, CancellationToken cancel = default)
	{
		return SetRating(new SetRatingRequest(hash, ratingServiceKey)
		{
			Rating = rating
		}, cancel);
	}

	/// <inheritdoc />
	public Task SetRating(IList<string> hashes, string ratingServiceKey, int? rating = null, CancellationToken cancel = default)
	{
		return SetRating(new SetRatingRequest(hashes, ratingServiceKey)
		{
			Rating = rating
		}, cancel);
	}


	/// <inheritdoc />
	public Task SetRating(IList<string> hashes, string ratingServiceKey, bool rating, CancellationToken cancel = default)
	{
		return SetRating(new SetRatingRequest(hashes, ratingServiceKey)
		{
			Rating = rating
		}, cancel);
	}

	/// <inheritdoc />
	public Task SetRating(ulong id, string ratingServiceKey, int? rating = null, CancellationToken cancel = default)
	{
		return SetRating(new SetRatingRequest(id, ratingServiceKey)
		{
			Rating = rating
		}, cancel);
	}

	/// <inheritdoc />
	public Task SetRating(ulong id, string ratingServiceKey, bool rating, CancellationToken cancel = default)
	{
		return SetRating(new SetRatingRequest(id, ratingServiceKey)
		{
			Rating = rating
		}, cancel);
	}

	/// <inheritdoc />
	public Task SetRating(IList<ulong> ids, string ratingServiceKey, int? rating = null, CancellationToken cancel = default)
	{
		return SetRating(new SetRatingRequest(ids, ratingServiceKey)
		{
			Rating = rating
		}, cancel);
	}

	/// <inheritdoc />
	public Task SetRating(IList<ulong> ids, string ratingServiceKey, bool rating, CancellationToken cancel = default)
	{
		return SetRating(new SetRatingRequest(ids, ratingServiceKey)
		{
			Rating = rating
		}, cancel);
	}

	/// <inheritdoc />
	public Task SetRating(SetRatingRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post(HydrusUrls.SetRating(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task IncrementFileViewTime(string hash, CanvasTypes type, double viewTime, CancellationToken cancel = default)
	{
		return IncrementFileViewTime(new ViewTimeRequest(hash, type, viewTime), cancel);
	}

	/// <inheritdoc />
	public Task IncrementFileViewTime(IList<string>? hashes, CanvasTypes type, double viewTime, CancellationToken cancel = default)
	{
		return IncrementFileViewTime(new ViewTimeRequest(hashes, type, viewTime), cancel);
	}

	/// <inheritdoc />
	public Task IncrementFileViewTime(ulong id, CanvasTypes type, double viewTime, CancellationToken cancel = default)
	{
		return IncrementFileViewTime(new ViewTimeRequest(id, type, viewTime), cancel);
	}

	/// <inheritdoc />
	public Task IncrementFileViewTime(IList<ulong>? fileIds, CanvasTypes type, double viewTime, CancellationToken cancel = default)
	{
		return IncrementFileViewTime(new ViewTimeRequest(fileIds, type, viewTime), cancel);
	}

	/// <inheritdoc />
	public Task IncrementFileViewTime(ViewTimeRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post(HydrusUrls.IncrementFileViewTime(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task SetFileViewTime(string hash, CanvasTypes type, double viewTime, int views = 1, CancellationToken cancel = default)
	{
		return SetFileViewTime(new ViewTimeRequest(hash, type, viewTime) { Views = views }, cancel);
	}

	/// <inheritdoc />
	public Task SetFileViewTime(IList<string>? hashes, CanvasTypes type, double viewTime, int views = 1, CancellationToken cancel = default)
	{
		return SetFileViewTime(new ViewTimeRequest(hashes, type, viewTime) { Views = views }, cancel);
	}

	/// <inheritdoc />
	public Task SetFileViewTime(ulong id, CanvasTypes type, double viewTime, int views = 1, CancellationToken cancel = default)
	{
		return SetFileViewTime(new ViewTimeRequest(id, type, viewTime) { Views = views }, cancel);
	}

	/// <inheritdoc />
	public Task SetFileViewTime(IList<ulong>? fileIds, CanvasTypes type, double viewTime, int views = 1, CancellationToken cancel = default)
	{
		return SetFileViewTime(new ViewTimeRequest(fileIds, type, viewTime) { Views = views }, cancel);
	}

	/// <inheritdoc />
	public Task SetFileViewTime(ViewTimeRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post(HydrusUrls.SetFileViewTime(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task SetTime(SetTimeRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post(HydrusUrls.SetTime(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task<SetNotesResponse> SetNotes(SetNotesRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post<SetNotesResponse>(HydrusUrls.SetNotes(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task DeleteNotes(string hash, IList<string> names, CancellationToken cancel = default)
	{
		return DeleteNotes(new DeleteNotesRequest(hash, names), cancel);
	}

	/// <inheritdoc />
	public Task DeleteNotes(ulong id, IList<string> names, CancellationToken cancel = default)
	{
		return DeleteNotes(new DeleteNotesRequest(id, names), cancel);
	}

	/// <inheritdoc />
	public Task DeleteNotes(DeleteNotesRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post(HydrusUrls.DeleteNotes(), null, request, cancel);
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
		var response = await GetMetaData(new MetaDataRequest(hash)
		{
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
		IList<string> hashes,
		bool createNewFileIds = false,
		bool detailedUrlInformation = false,
		bool includeMilliseconds = false,
		bool includeNotes = false,
		CancellationToken cancel = default
	)
	{
		ThrowHelper.ArgumentNotNull(hashes);

		var response = await GetMetaData(new MetaDataRequest(hashes)
		{
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
		var response = await GetMetaData(new MetaDataRequest(fileId)
		{
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
		IList<ulong> fileIds,
		bool createNewFileIds = false,
		bool detailedUrlInformation = false,
		bool includeMilliseconds = false,
		bool includeNotes = false,
		CancellationToken cancel = default
	)
	{
		ThrowHelper.ArgumentNotNull(fileIds);

		var response = await GetMetaData(new MetaDataRequest(fileIds)
		{
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
		var request = HydrusUrls.GetMetadata(new MetaDataRequest(hash)
		{
			OnlyReturnIdentifiers = true,
			IncludeServicesObject = false
		});
		var response = await ApiConnection.Get<MetaDataResponse<MetaDataId>>(request, cancel);

		return response.Metadata;
	}

	/// <inheritdoc />
	public async Task<IEnumerable<MetaDataId>> GetId(IList<string> hashes, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(hashes);

		var request = HydrusUrls.GetMetadata(new MetaDataRequest(hashes)
		{
			OnlyReturnIdentifiers = true,
			IncludeServicesObject = false
		});
		var response = await ApiConnection.Get<MetaDataResponse<MetaDataId>>(request, cancel);

		return response.Metadata;
	}

	/// <inheritdoc />
	public async Task<IEnumerable<MetaDataId>> GetHash(ulong fileId, CancellationToken cancel = default)
	{
		var request = HydrusUrls.GetMetadata(new MetaDataRequest(fileId)
		{
			OnlyReturnIdentifiers = true,
			IncludeServicesObject = false
		});
		var response = await ApiConnection.Get<MetaDataResponse<MetaDataId>>(request, cancel);

		return response.Metadata;
	}

	/// <inheritdoc />
	public async Task<IEnumerable<MetaDataId>> GetHash(IList<ulong> fileIds, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(fileIds);

		var request = HydrusUrls.GetMetadata(new MetaDataRequest(fileIds)
		{
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

	/// <inheritdoc />
	public async Task<IEnumerable<StorageLocation>> GetLocalFileStorageLocations(CancellationToken cancel = default)
	{
		var response = await ApiConnection.Get<LocalFileStorageLocationsResponse>(HydrusUrls.GetLocalFileStorageLocations(), cancel);
		return response.Locations;
	}
}
