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
	public Task<IEnumerable<string>> CleanTags(params string[] tags)
	{
		return CleanTags(tags, default);
	}

	/// <inheritdoc />
	public async Task<IEnumerable<string>> CleanTags(IEnumerable<string> tags, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Get<TagsResponse>(HydrusUrls.CleanTags(tags), cancel);
		return response.Tags;
	}

	/// <inheritdoc />
	public Task<SiblingsAndParentsResponse> GetSiblingsAndParents(params string[] tags)
	{
		return GetSiblingsAndParents(tags, default);
	}

	/// <inheritdoc />
	public Task<SiblingsAndParentsResponse> GetSiblingsAndParents(IEnumerable<string> tags, CancellationToken cancel = default)
	{
		return ApiConnection.Get<SiblingsAndParentsResponse>(HydrusUrls.GetSiblingsAndParents(tags), cancel);
	}
}
