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
    public Task<FileRelationshipsResponse> GetFileRelationships(string hash, CancellationToken cancel = default)
    {
        return GetFileRelationships(new FilesWithDomainRequest(hash));
    }

    /// <inheritdoc />
    public Task<FileRelationshipsResponse> GetFileRelationships(IList<string> hashes,
        CancellationToken cancel = default)
    {
        return GetFileRelationships(new FilesWithDomainRequest(hashes));
    }

    /// <inheritdoc />
    public Task<FileRelationshipsResponse> GetFileRelationships(ulong fileId, CancellationToken cancel = default)
    {
        return GetFileRelationships(new FilesWithDomainRequest(fileId));
    }

    /// <inheritdoc />
    public Task<FileRelationshipsResponse> GetFileRelationships(IList<ulong> fileIds,
        CancellationToken cancel = default)
    {
        return GetFileRelationships(new FilesWithDomainRequest(fileIds));
    }

    /// <inheritdoc />
    public Task<FileRelationshipsResponse> GetFileRelationships(FilesWithDomainRequest request,
        CancellationToken cancel = default)
    {
        return ApiConnection.Get<FileRelationshipsResponse>(HydrusUrls.GetFileRelationships(request), cancel);
    }

    /// <inheritdoc />
    public async Task<int> GetPotentialsCount(CancellationToken cancel = default)
    {
        var response =
            await ApiConnection.Get<PotentialDuplicatesCountResponse>(HydrusUrls.GetPotentialsCount(), cancel);

        return response.PotentialDuplicatesCount;
    }

    /// <inheritdoc />
    public async Task<int> GetPotentialsCount(GetPotentialsRequest request, CancellationToken cancel = default)
    {
        var response =
            await ApiConnection.Get<PotentialDuplicatesCountResponse>(HydrusUrls.GetPotentialsCount(request), cancel);

        return response.PotentialDuplicatesCount;
    }

    /// <inheritdoc />
    public Task<PotentialDuplicatePairsResponse> GetPotentialsPairs(CancellationToken cancel = default)
    {
        return ApiConnection.Get<PotentialDuplicatePairsResponse>(HydrusUrls.GetPotentialsPairs(), cancel);
    }

    /// <inheritdoc />
    public Task<PotentialDuplicatePairsResponse> GetPotentialsPairs(GetPotentialsPairsRequest request,
        CancellationToken cancel = default)
    {
        return ApiConnection.Get<PotentialDuplicatePairsResponse>(HydrusUrls.GetPotentialsPairs(request), cancel);
    }

    /// <inheritdoc />
    public Task<RandomPotentialDuplicateHashesResponse> GetRandomPotentials(CancellationToken cancel = default)
    {
        return ApiConnection.Get<RandomPotentialDuplicateHashesResponse>(HydrusUrls.GetRandomPotentials(), cancel);
    }

    /// <inheritdoc />
    public Task<RandomPotentialDuplicateHashesResponse> GetRandomPotentials(GetPotentialsRequest request,
        CancellationToken cancel = default)
    {
        return ApiConnection.Get<RandomPotentialDuplicateHashesResponse>(HydrusUrls.GetRandomPotentials(request),
            cancel);
    }

    /// <inheritdoc />
    public Task RemovePotentials(string hash, CancellationToken cancel = default)
    {
        return RemovePotentials(new FilesRequest(hash), cancel);
    }

    /// <inheritdoc />
    public Task RemovePotentials(IList<string> hashes, CancellationToken cancel = default)
    {
        return RemovePotentials(new FilesRequest(hashes), cancel);
    }

    /// <inheritdoc />
    public Task RemovePotentials(ulong fileId, CancellationToken cancel = default)
    {
        return RemovePotentials(new FilesRequest(fileId), cancel);
    }

    /// <inheritdoc />
    public Task RemovePotentials(IList<ulong> ids, CancellationToken cancel = default)
    {
        return RemovePotentials(new FilesRequest(ids), cancel);
    }

    /// <inheritdoc />
    public Task RemovePotentials(FilesRequest request, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(request);

        return ApiConnection.Post(HydrusUrls.RemovePotentials(), null, request, cancel);
    }

    /// <inheritdoc />
    public Task SetFileRelationships(IList<Relationships> request, CancellationToken cancel = default)
    {
        return SetFileRelationships(new SetFileRelationshipsRequest(request), cancel);
    }

    /// <inheritdoc />
    public Task SetFileRelationships(SetFileRelationshipsRequest request, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(request);

        return ApiConnection.Post(HydrusUrls.SetFileRelationships(), null, request, cancel);
    }

    /// <inheritdoc />
    public Task SetKings(string hash, CancellationToken cancel = default)
    {
        return SetKings(new FilesRequest(hash), cancel);
    }

    /// <inheritdoc />
    public Task SetKings(IList<string> hashes, CancellationToken cancel = default)
    {
        return SetKings(new FilesRequest(hashes), cancel);
    }

    /// <inheritdoc />
    public Task SetKings(ulong fileId, CancellationToken cancel = default)
    {
        return SetKings(new FilesRequest(fileId), cancel);
    }

    /// <inheritdoc />
    public Task SetKings(IList<ulong> ids, CancellationToken cancel = default)
    {
        return SetKings(new FilesRequest(ids), cancel);
    }

    /// <inheritdoc />
    public Task SetKings(FilesRequest request, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(request);

        return ApiConnection.Post(HydrusUrls.SetFileRelationships(), null, request, cancel);
    }
}
