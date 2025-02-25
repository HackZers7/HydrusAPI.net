using HydrusAPI.Web.Http;
using HydrusAPI.Web.Models.Request;
using HydrusAPI.Web.Models.Response;

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
}
