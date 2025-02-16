using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент для работы со связями файлов.
/// </summary>
public class RelationshipsClient : ApiClient, IRelationshipsClient
{
	/// <inheritdoc />
	public RelationshipsClient(IApiConnection apiConnection) : base(apiConnection)
	{
	}

	/// <inheritdoc />
	public Task<FileRelationshipsResponse> GetFileRelationships(FilesWithDomainRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Get<FileRelationshipsResponse>(HydrusUrls.GetFileRelationships(request), cancel);
	}

	/// <inheritdoc />
	public async Task<int> GetPotentialsCount(GetPotentialsRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Get<PotentialDuplicatesCountResponse>(HydrusUrls.GetPotentialsCount(request), cancel);

		return response.PotentialDuplicatesCount;
	}

	/// <inheritdoc />
	public Task<PotentialDuplicatePairsResponse> GetPotentialsPairs(GetPotentialsPairsRequest request, CancellationToken cancel = default)
	{
		return ApiConnection.Get<PotentialDuplicatePairsResponse>(HydrusUrls.GetPotentialsPairs(request), cancel);
	}

	/// <inheritdoc />
	public async Task<List<string>> GetRandomPotentials(GetPotentialsRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Get<RandomPotentialDuplicateHashesResponse>(HydrusUrls.GetRandomPotentials(request), cancel);

		return response.RandomPotentialDuplicateHashes;
	}

	/// <inheritdoc />
	public Task<bool> RemovePotentials(string hash, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		return RemovePotentials(new FilesRequest
		{
			Hash = hash
		}, cancel);
	}

	/// <inheritdoc />
	public Task<bool> RemovePotentials(params string[] hashes)
	{
		ThrowHelper.ArgumentNotNull(hashes);

		return RemovePotentials(new FilesRequest
		{
			Hashes = new List<string>(hashes)
		});
	}

	/// <inheritdoc />
	public Task<bool> RemovePotentials(ulong fileId, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentOutOfRange(fileId, (ulong)1, ulong.MaxValue);

		return RemovePotentials(new FilesRequest
		{
			FileId = fileId
		}, cancel);
	}

	/// <inheritdoc />
	public Task<bool> RemovePotentials(params ulong[] ids)
	{
		ThrowHelper.ArgumentNotNull(ids);

		return RemovePotentials(new FilesRequest
		{
			FileIds = new List<ulong>(ids)
		});
	}

	/// <inheritdoc />
	public async Task<bool> RemovePotentials(FilesRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(HydrusUrls.RemovePotentials(), null, request, cancel);

		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public async Task<bool> SetFileRelationships(IEnumerable<Relationships> request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(
			HydrusUrls.SetFileRelationships(),
			null,
			new SetFileRelationshipsRequest
			{
				Relationships = new List<Relationships>(request)
			},
			cancel
		);

		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<bool> SetKings(string hash, CancellationToken cancel = default)
	{
		return SetKings(new FilesRequest
		{
			Hash = hash
		}, cancel);
	}

	/// <inheritdoc />
	public Task<bool> SetKings(params string[] hashes)
	{
		return SetKings(new FilesRequest
		{
			Hashes = new List<string>(hashes)
		});
	}

	/// <inheritdoc />
	public Task<bool> SetKings(ulong fileId, CancellationToken cancel = default)
	{
		return SetKings(new FilesRequest
		{
			FileId = fileId
		}, cancel);
	}

	/// <inheritdoc />
	public Task<bool> SetKings(params ulong[] ids)
	{
		return SetKings(new FilesRequest
		{
			FileIds = new List<ulong>(ids)
		});
	}

	/// <inheritdoc />
	public async Task<bool> SetKings(FilesRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(
			HydrusUrls.SetFileRelationships(),
			null,
			request,
			cancel
		);

		return response.IsSuccessStatusCode();
	}
}
