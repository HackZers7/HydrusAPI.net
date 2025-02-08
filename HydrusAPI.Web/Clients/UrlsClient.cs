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
	public Task<UrlFilesResponse> GetUrlFiles(string url, bool doublecheckFileSystem = false, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(url);

		return ApiConnection.Get<UrlFilesResponse>(HydrusUrls.GetUrlFiles(url, doublecheckFileSystem), cancel);
	}

	/// <inheritdoc />
	public Task<UrlInfoResponse> GetUrlInfo(string url, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(url);

		return ApiConnection.Get<UrlInfoResponse>(HydrusUrls.GetUrlInfo(url), cancel);
	}

	/// <inheritdoc />
	public Task<ImportUrlResult> ImportUrl(string url, CancellationToken cancel = default)
	{
		return ImportUrl(new AddUrlRequest(url), cancel);
	}

	/// <inheritdoc />
	public Task<ImportUrlResult> ImportUrl(AddUrlRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post<ImportUrlResult>(HydrusUrls.AddUrl(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task<bool> AddUrlToFile(string hash, params string[] urls)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		var request = new AssociateUrlRequest([hash]);
		request.AddRangeAssociateUrl(urls);

		return AssociateUrl(request);
	}

	/// <inheritdoc />
	public Task<bool> AddUrlToFile(ulong id, params string[] urls)
	{
		var request = new AssociateUrlRequest([id]);
		request.AddRangeAssociateUrl(urls);

		return AssociateUrl(request);
	}

	/// <inheritdoc />
	public Task<bool> RemoveUrlFromFile(string hash, params string[] urls)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		var request = new AssociateUrlRequest([hash]);
		request.AddDisassociateUrl(urls);

		return AssociateUrl(request);
	}

	/// <inheritdoc />
	public Task<bool> RemoveUrlFromFile(ulong id, params string[] urls)
	{
		var request = new AssociateUrlRequest([id]);
		request.AddDisassociateUrl(urls);

		return AssociateUrl(request);
	}

	/// <inheritdoc />
	public async Task<bool> AssociateUrl(AssociateUrlRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(HydrusUrls.AssociateUrl(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}
}
