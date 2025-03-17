using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент для работы с url.
/// </summary>
public class UrlsClient : ApiClient, IUrlsClient
{
    /// <inheritdoc />
    public UrlsClient(IApiConnection apiConnection) : base(apiConnection)
    {
    }

    /// <inheritdoc />
    public Task<UrlFilesResponse> GetUrlFiles(string url, bool doubleCheckFileSystem = false, CancellationToken cancel = default)
    {
        return GetUrlFiles(new GetUrlFilesRequest(url, doubleCheckFileSystem), cancel);
    }

    /// <inheritdoc />
    public Task<UrlFilesResponse> GetUrlFiles(Uri url, bool doubleCheckFileSystem = false, CancellationToken cancel = default)
    {
        return GetUrlFiles(new GetUrlFilesRequest(url, doubleCheckFileSystem), cancel);
    }

    /// <inheritdoc />
    public Task<UrlFilesResponse> GetUrlFiles(GetUrlFilesRequest request, CancellationToken cancel = default)
    {
        return ApiConnection.Get<UrlFilesResponse>(HydrusUrls.GetUrlFiles(request), cancel);
    }

    /// <inheritdoc />
    public Task<UrlInfoResponse> GetUrlInfo(string url, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(url);

        return GetUrlInfo(new Uri(url));
    }

    /// <inheritdoc />
    public Task<UrlInfoResponse> GetUrlInfo(Uri url, CancellationToken cancel = default)
    {
        return ApiConnection.Get<UrlInfoResponse>(HydrusUrls.GetUrlInfo(url), cancel);
    }

    /// <inheritdoc />
    public Task<ImportUrlResult> ImportFromUrl(string url, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(url);

        return ImportFromUrl(new ImportFromUrlRequest(url), cancel);
    }

    /// <inheritdoc />
    public Task<ImportUrlResult> ImportFromUrl(Uri url, CancellationToken cancel = default)
    {

        return ImportFromUrl(new ImportFromUrlRequest(url), cancel);
    }

    /// <inheritdoc />
    public Task<ImportUrlResult> ImportFromUrl(ImportFromUrlRequest request, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(request);

        return ApiConnection.Post<ImportUrlResult>(HydrusUrls.AddUrl(), null, request, cancel);
    }

    /// <inheritdoc />
    public Task AddUrlToFile(string hash, string url, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(url);

        return AssociateUrl(new AssociateUrlRequest(hash)
        {
            UrlToAdd = new Uri(url)
        }, cancel);
    }

    /// <inheritdoc />
    public Task AddUrlToFile(string hash, Uri url, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(url);

        return AssociateUrl(new AssociateUrlRequest(hash)
        {
            UrlToAdd = url
        }, cancel);
    }

    /// <inheritdoc />
    public Task AddUrlToFile(string hash, IList<string> urls, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(urls);

        return AssociateUrl(new AssociateUrlRequest(hash)
        {
            UrlsToAdd = urls.Select(x => new Uri(x)).ToList()
        }, cancel);
    }

    /// <inheritdoc />
    public Task AddUrlToFile(string hash, IList<Uri> urls, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(urls);

        return AssociateUrl(new AssociateUrlRequest(hash)
        {
            UrlsToAdd = urls
        }, cancel);
    }

    /// <inheritdoc />
    public Task AddUrlToFile(ulong id, string url, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(url);

        return AssociateUrl(new AssociateUrlRequest(id)
        {
            UrlToAdd = new Uri(url)
        }, cancel);
    }

    /// <inheritdoc />
    public Task AddUrlToFile(ulong id, Uri url, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(url);

        return AssociateUrl(new AssociateUrlRequest(id)
        {
            UrlToAdd = url
        }, cancel);
    }

    /// <inheritdoc />
    public Task AddUrlToFile(ulong id, IList<string> urls, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(urls);

        return AssociateUrl(new AssociateUrlRequest(id)
        {
            UrlsToAdd = urls.Select(x => new Uri(x)).ToList()
        }, cancel);
    }

    /// <inheritdoc />
    public Task AddUrlToFile(ulong id, IList<Uri> urls, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(urls);

        return AssociateUrl(new AssociateUrlRequest(id)
        {
            UrlsToAdd = urls
        }, cancel);
    }

    /// <inheritdoc />
    public Task RemoveUrlFromFile(string hash, string url, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(url);

        return AssociateUrl(new AssociateUrlRequest(hash)
        {
            UrlToDelete = new Uri(url)
        }, cancel);
    }

    /// <inheritdoc />
    public Task RemoveUrlFromFile(string hash, Uri url, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(url);

        return AssociateUrl(new AssociateUrlRequest(hash)
        {
            UrlToDelete = url
        }, cancel);
    }

    /// <inheritdoc />
    public Task RemoveUrlFromFile(string hash, IList<string> urls, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(urls);

        return AssociateUrl(new AssociateUrlRequest(hash)
        {
            UrlsToDelete = urls.Select(x => new Uri(x)).ToList()
        }, cancel);
    }

    /// <inheritdoc />
    public Task RemoveUrlFromFile(string hash, IList<Uri> urls, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(urls);

        return AssociateUrl(new AssociateUrlRequest(hash)
        {
            UrlsToDelete = urls
        }, cancel);
    }

    /// <inheritdoc />
    public Task RemoveUrlFromFile(ulong id, string url, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(url);

        return AssociateUrl(new AssociateUrlRequest(id)
        {
            UrlToDelete = new Uri(url)
        }, cancel);
    }

    /// <inheritdoc />
    public Task RemoveUrlFromFile(ulong id, Uri url, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(url);

        return AssociateUrl(new AssociateUrlRequest(id)
        {
            UrlToDelete = url
        }, cancel);
    }

    /// <inheritdoc />
    public Task RemoveUrlFromFile(ulong id, IList<string> urls, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(urls);

        return AssociateUrl(new AssociateUrlRequest(id)
        {
            UrlsToDelete = urls.Select(x => new Uri(x)).ToList()
        }, cancel);
    }

    /// <inheritdoc />
    public Task RemoveUrlFromFile(ulong id, IList<Uri> urls, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(urls);

        return AssociateUrl(new AssociateUrlRequest(id)
        {
            UrlsToDelete = urls
        }, cancel);
    }

    /// <inheritdoc />
    public Task AssociateUrl(AssociateUrlRequest request, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(request);

        return ApiConnection.Post(HydrusUrls.AssociateUrl(), null, request, cancel);
    }
}
