using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент клиент для редактирования метаданных файла.
/// </summary>
public class MetaClient : ApiClient, IMetaClient
{
	/// <inheritdoc />
	public MetaClient(IApiConnection apiConnection) : base(apiConnection)
	{
	}

	/// <inheritdoc />
	public async Task<bool> SetRating(SetRatingRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.SetRating(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}
}
