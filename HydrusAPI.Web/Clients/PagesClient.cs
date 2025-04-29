using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент для работы со страницами Hydrus.
/// </summary>
public class PagesClient : ApiClient, IPagesClient
{
    /// <inheritdoc />
    public PagesClient(IApiConnection apiConnection) : base(apiConnection)
    {
    }

    /// <inheritdoc />
    public async Task<Page> GetPages(CancellationToken cancel = default)
    {
        var response = await ApiConnection.Get<PagesResponse>(HydrusUrls.GetPages(), cancel);

        return response.Pages;
    }

    /// <inheritdoc/>
    public Task<PageInfoResponse> GetPage(string pageKey, bool simple = true, CancellationToken cancel = default)
    {
        return ApiConnection.Get<PageInfoResponse>(HydrusUrls.GetPage(pageKey, simple), cancel);
    }

    /// <inheritdoc />
    public Task AddFilesOnPage(string pageKey, string hash, CancellationToken cancel = default)
    {
        return AddFilesOnPage(new AddFilesOnPageRequest(pageKey, hash), cancel);
    }

    /// <inheritdoc />
    public Task AddFilesOnPage(string pageKey, IList<string> hashes)
    {
        return AddFilesOnPage(new AddFilesOnPageRequest(pageKey, hashes));
    }

    /// <inheritdoc />
    public Task AddFilesOnPage(string pageKey, ulong fileId, CancellationToken cancel = default)
    {
        return AddFilesOnPage(new AddFilesOnPageRequest(pageKey, fileId), cancel);
    }

    /// <inheritdoc />
    public Task AddFilesOnPage(string pageKey, IList<ulong> ids)
    {
        return AddFilesOnPage(new AddFilesOnPageRequest(pageKey, ids));
    }

    /// <inheritdoc />
    public Task AddFilesOnPage(AddFilesOnPageRequest request, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(request);

        return ApiConnection.Post(HydrusUrls.AddFilesOnPage(), null, request, cancel);
    }

    /// <inheritdoc />
    public Task FocusPage(string pageKey, CancellationToken cancel = default)
    {
        return ApiConnection.Post(
            HydrusUrls.FocusPage(),
            null,
            new PageKeyRequest(pageKey),
            cancel
        );
    }

    /// <inheritdoc />
    public Task RefreshPage(string pageKey, CancellationToken cancel = default)
    {
        return ApiConnection.Post(
            HydrusUrls.RefreshPage(),
            null,
            new PageKeyRequest(pageKey),
            cancel
        );
    }
}
