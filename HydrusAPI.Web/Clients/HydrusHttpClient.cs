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
	public async Task<List<List<object?>>> GetCookies(string domain, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Get<CookiesResponse>(HydrusUrls.GetCookies(domain), cancel);

		return response.Cookies;
	}

	/// <inheritdoc/>
	public async Task<bool> SetCookies(SetCookiesRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.SetCookies(), null, request, cancel);
		return response.IsSuccessStatusCode();
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
	public async Task<bool> SetHeaders(SetHeadersRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.SetHeaders(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}
}
