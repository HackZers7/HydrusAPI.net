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
	public Task<HydrusSessionToken> RequestSessionToken(string accessToken, CancellationToken cancel = default)
	{
		return RequestSessionToken(ApiConnection, accessToken, cancel);
	}

	/// <inheritdoc />
	public Task<VerifyToken> VerifyAccessToken(string accessToken, CancellationToken cancel = default)
	{
		return VerifyAccessToken(ApiConnection, accessToken, cancel);
	}

	/// <inheritdoc />
	public Task<VerifyToken> VerifySessionToken(string sessionToken, CancellationToken cancel = default)
	{
		return VerifySessionToken(ApiConnection, sessionToken, cancel);
	}

	/// <summary>
	///     Запрашивает ключ доступа.
	/// </summary>
	/// <param name="apiConnection">Подключение к клиенту Hydrus.</param>
	/// <param name="name">Название ключа.</param>
	/// <param name="permitsEverything">Разрешить доступ ко всем областям (разрешениям).</param>
	/// <param name="permissions">Области видимости (разрешения).</param>
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

	/// <summary>
	///     Производит проверку токена доступа.
	/// </summary>
	/// <param name="apiConnection">Подключение к клиенту Hydrus.</param>
	/// <param name="accessToken">Токен доступа.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="VerifyToken" /> с информацией о ключе.</returns>
	public static Task<VerifyToken> VerifyAccessToken(IApiConnection apiConnection, string accessToken, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(apiConnection);
		ThrowHelper.ArgumentNotNull(accessToken);

		var headers = new Dictionary<string, string>
		{
			{ HydrusAccessHeader, accessToken }
		};
		return apiConnection.Get<VerifyToken>(HydrusUrls.VerifyToken(), null, null, headers, cancel);
	}

	/// <summary>
	///     Производит проверку токена сессии.
	/// </summary>
	/// <param name="apiConnection">Подключение к клиенту Hydrus.</param>
	/// <param name="sessionToken">Токен сессии</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="VerifyToken" /> с информацией о ключе.</returns>
	public static Task<VerifyToken> VerifySessionToken(IApiConnection apiConnection, string sessionToken, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(apiConnection);
		ThrowHelper.ArgumentNotNull(sessionToken);

		var headers = new Dictionary<string, string>
		{
			{ HydrusSessionHeader, sessionToken }
		};
		return apiConnection.Get<VerifyToken>(HydrusUrls.VerifyToken(), null, null, headers, cancel);
	}

	private static IApiConnection BuildApi(HydrusClientConfig config)
	{
		ThrowHelper.ArgumentNotNull(config);

		return config.BuildApiConnection();
	}
}
