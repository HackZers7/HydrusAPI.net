using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Основной клиент для работы с API.
/// </summary>
public class HydrusClient : IHydrusClient
{
	private readonly IApiConnection _apiConnection;

	/// <summary>
	///     Инициализирует новый экземпляр клиента.
	/// </summary>
	public HydrusClient()
	{
		// TODO: переделать, оставил так для тестов
		_apiConnection = new ApiConnection(
			HydrusUrls.DefaultLocalhost,
			new NewtonsoftJsonSerializer(),
			new NetHttpClient(),
			null
		);

		AccessClient = new AccessClient(_apiConnection);
	}

	/// <inheritdoc />
	public IAccessClient AccessClient { get; }

	/// <inheritdoc />
	public Task<ApiVersion> GetApiVersion(CancellationToken cancel = default)
	{
		return _apiConnection.Get<ApiVersion>(HydrusUrls.ApiVersion(), cancel);
	}
}
