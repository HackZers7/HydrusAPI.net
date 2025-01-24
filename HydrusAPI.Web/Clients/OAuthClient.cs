using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент получения идентификационных данных для подключения.
/// </summary>
public class OAuthClient : ApiClient, IOAuthClient
{
	/// <summary>
	///     Http заголовок ключа доступа.
	/// </summary>
	public const string HydrusAccessHeader = "Hydrus-Client-API-Access-Key";

	/// <summary>
	///     Http заголовок ключа сессии.
	/// </summary>
	public const string HydrusSessionHeader = "Hydrus-Client-API-Session-Key";

	/// <summary>
	///     Инициализирует новый экземпляр API клиента.
	/// </summary>
	/// <param name="baseAddress">Адрес клиента Hydrus.</param>
	public OAuthClient(Uri baseAddress) : this(HydrusClientConfig.CreateDefault(baseAddress))
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр API клиента.
	/// </summary>
	/// <param name="config">Настройки клиента Hydrus.</param>
	public OAuthClient(HydrusClientConfig config) : base(BuildApi(config))
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр API клиента.
	/// </summary>
	/// <param name="apiConnection">Подключение клиента.</param>
	public OAuthClient(IApiConnection apiConnection) : base(apiConnection)
	{
	}


	/// <inheritdoc />
	public Task<HydrusAccessToken> RequestAccessToken(string name, bool permitsEverything, params Permissions[] permissions)
	{
		return RequestAccessToken(ApiConnection, name, permitsEverything, permissions);
	}

	/// <inheritdoc />
	public Task<HydrusAccessToken> RequestAccessToken(string name, bool permitsEverything, Permissions[] permissions, CancellationToken cancel)
	{
		return RequestAccessToken(ApiConnection, name, permitsEverything, permissions, cancel);
	}

	/// <inheritdoc />
	public Task<HydrusSessionToken> RequestSessionToken(string accessToken, CancellationToken cancel)
	{
		return RequestSessionToken(ApiConnection, accessToken, cancel);
	}

	/// <summary>
	///     Запрашивает ключ доступа.
	/// </summary>
	/// <param name="apiConnection">Подключение к клиенту Hydrus.</param>
	/// <param name="name">Название ключа.</param>
	/// <param name="permitsEverything">selective, bool, whether to permit all tasks now and in future</param>
	/// <param name="permissions">Разрешения которые необходимы.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="HydrusAccessToken" /> с полученным ключом доступа.</returns>
	public static Task<HydrusAccessToken> RequestAccessToken(
		IApiConnection apiConnection,
		string name,
		bool permitsEverything,
		Permissions[] permissions,
		CancellationToken cancel = default
	)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(name);
		ThrowHelper.ArgumentNotNull(apiConnection);

		// TODO: Добавить получение доступных областей видимости
		return apiConnection.Get<HydrusAccessToken>(HydrusUrls.RequestAccessToken(name, permitsEverything, permissions), cancel);
	}

	/// <summary>
	///     Запрашивает ключ сессии.
	/// </summary>
	/// <param name="apiConnection">Подключение к клиенту Hydrus.</param>
	/// <param name="accessToken">Ключ доступа.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="HydrusAccessToken" /> с полученным ключом доступа.</returns>
	public static Task<HydrusSessionToken> RequestSessionToken(IApiConnection apiConnection, string accessToken, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(accessToken);
		ThrowHelper.ArgumentNotNull(apiConnection);

		var headers = new Dictionary<string, string>
		{
			{ HydrusAccessHeader, accessToken }
		};

		// TODO: Добавить получение доступных областей видимости
		return apiConnection.Get<HydrusSessionToken>(HydrusUrls.RequestSessionToken(), null, null, headers, cancel);
	}

	private static IApiConnection BuildApi(HydrusClientConfig config)
	{
		ThrowHelper.ArgumentNotNull(config);

		return config.BuildApiConnection();
	}
}
