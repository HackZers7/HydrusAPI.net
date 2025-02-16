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

	/// <inheritdoc />
	public Task<bool> AddFilesOnPage(string pageKey, string hash, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(pageKey);
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		return AddFilesOnPage(
			new AddFilesOnPageRequest
			{
				PageKey = pageKey,
				Hash = hash
			}, cancel
		);
	}

	/// <inheritdoc />
	public Task<bool> AddFilesOnPage(string pageKey, params string[] hashes)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(pageKey);
		ThrowHelper.ArgumentNotNull(hashes);

		return AddFilesOnPage(
			new AddFilesOnPageRequest
			{
				PageKey = pageKey,
				Hashes = new List<string>(hashes)
			}
		);
	}

	/// <inheritdoc />
	public Task<bool> AddFilesOnPage(string pageKey, ulong fileId, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(pageKey);
		ThrowHelper.ArgumentOutOfRange(fileId, (ulong)1, ulong.MaxValue);

		return AddFilesOnPage(
			new AddFilesOnPageRequest
			{
				PageKey = pageKey,
				FileId = fileId
			}, cancel
		);
	}

	/// <inheritdoc />
	public Task<bool> AddFilesOnPage(string pageKey, params ulong[] ids)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(pageKey);
		ThrowHelper.ArgumentNotNull(ids);

		return AddFilesOnPage(
			new AddFilesOnPageRequest
			{
				PageKey = pageKey,
				FileIds = new List<ulong>(ids)
			}
		);
	}

	/// <inheritdoc />
	public async Task<bool> AddFilesOnPage(AddFilesOnPageRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);

		var response = await ApiConnection.Post(HydrusUrls.AddFilesOnPage(), null, request, cancel);

		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public async Task<bool> FocusPage(string pageKey, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(pageKey);

		var response = await ApiConnection.Post(
			HydrusUrls.AddFilesOnPage(),
			null,
			new PageKeyRequest(pageKey),
			cancel
		);

		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public async Task<bool> RefreshPage(string pageKey, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(pageKey);

		var response = await ApiConnection.Post(
			HydrusUrls.AddFilesOnPage(),
			null,
			new PageKeyRequest(pageKey),
			cancel
		);

		return response.IsSuccessStatusCode();
	}
}
