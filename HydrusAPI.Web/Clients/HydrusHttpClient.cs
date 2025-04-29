using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент для работы с http запросами Hydrus.
/// </summary>
public class HydrusHttpClient : ApiClient, IHydrusHttpClient
{
    /// <inheritdoc />
    public HydrusHttpClient(IApiConnection apiConnection) : base(apiConnection)
    {
    }

    /// <inheritdoc/>
    public Task<CookiesResponse> GetCookies(string domain, CancellationToken cancel = default)
    {
        return ApiConnection.Get<CookiesResponse>(HydrusUrls.GetCookies(domain), cancel);
    }

    /// <inheritdoc/>
    public Task SetCookies(SetCookiesRequest request, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(request);

        return ApiConnection.Post(HydrusUrls.SetCookies(), null, request, cancel);
    }

    /// <inheritdoc/>
    public Task<HeadersResponse> GetHeaders(CancellationToken cancel = default)
    {
        return ApiConnection.Get<HeadersResponse>(HydrusUrls.GetHeaders(), cancel);
    }

    /// <inheritdoc/>
    public Task<HeadersResponse> GetHeaders(string domain, CancellationToken cancel = default)
    {
        return ApiConnection.Get<HeadersResponse>(HydrusUrls.GetHeaders(domain), cancel);
    }

    /// <inheritdoc/>
    public Task SetHeaders(SetHeadersRequest request, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(request);

        return ApiConnection.Post(HydrusUrls.SetHeaders(), null, request, cancel);
    }
}
