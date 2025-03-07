using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент для работы с тегами.
/// </summary>
public class TagsClient : ApiClient, ITagsClient
{
	/// <inheritdoc />
	public TagsClient(IApiConnection apiConnection) : base(apiConnection)
	{
	}

	/// <inheritdoc />
	public Task<TagsResponse> CleanTags(IList<string> tags, CancellationToken cancel = default)
	{
		return ApiConnection.Get<TagsResponse>(HydrusUrls.CleanTags(tags), cancel);
	}

	/// <inheritdoc />
	public Task<SiblingsAndParentsResponse> GetSiblingsAndParents(IList<string> tags, CancellationToken cancel = default)
	{
		return ApiConnection.Get<SiblingsAndParentsResponse>(HydrusUrls.GetSiblingsAndParents(tags), cancel);
	}

	/// <inheritdoc />
	public Task<TagsSearchResponse> SearchTags(string search, CancellationToken cancel = default)
	{
		return SearchTags(new SearchTagsRequest(search), cancel);
	}

	/// <inheritdoc />
	public Task<TagsSearchResponse> SearchTags(SearchTagsRequest request, CancellationToken cancel = default)
	{
		return ApiConnection.Get<TagsSearchResponse>(HydrusUrls.SearchTags(request), cancel);
	}

	/// <inheritdoc />
	public Task AddTags(AddTagsRequest request, CancellationToken cancel = default)
	{
		return ApiConnection.Post(HydrusUrls.AddTags(), null, request, cancel);
	}
}
