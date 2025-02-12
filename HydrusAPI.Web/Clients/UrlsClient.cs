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
	public Task<ImportUrlResult> ImportFromUrl(string url, CancellationToken cancel = default)
	{
		return ImportFromUrl(new ImportFromUrlRequest
		{
			Url = new Uri(url)
		}, cancel);
	}

	/// <inheritdoc />
	public Task<ImportUrlResult> ImportFromUrl(ImportFromUrlRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		return ApiConnection.Post<ImportUrlResult>(HydrusUrls.AddUrl(), null, request, cancel);
	}

	/// <inheritdoc />
	public Task<bool> AddUrlToFile(string hash, params string[] urls)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		return AssociateUrl(new AssociateUrlRequest([hash])
		{
			UrlsToAdd = new List<string>(urls)
		});
	}

	/// <inheritdoc />
	public Task<bool> AddUrlToFile(ulong id, params string[] urls)
	{
		ThrowHelper.ArgumentOutOfRange(id, (ulong)1, ulong.MaxValue);

		return AssociateUrl(new AssociateUrlRequest([id])
		{
			UrlsToAdd = new List<string>(urls)
		});
	}

	/// <inheritdoc />
	public Task<bool> RemoveUrlFromFile(string hash, params string[] urls)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		return AssociateUrl(new AssociateUrlRequest([hash])
		{
			UrlsToDelete = new List<string>(urls)
		});
	}

	/// <inheritdoc />
	public Task<bool> RemoveUrlFromFile(ulong id, params string[] urls)
	{
		ThrowHelper.ArgumentOutOfRange(id, (ulong)1, ulong.MaxValue);

		return AssociateUrl(new AssociateUrlRequest([id])
		{
			UrlsToDelete = new List<string>(urls)
		});
	}

	/// <inheritdoc />
	public async Task<bool> AssociateUrl(AssociateUrlRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(HydrusUrls.AssociateUrl(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}
}
