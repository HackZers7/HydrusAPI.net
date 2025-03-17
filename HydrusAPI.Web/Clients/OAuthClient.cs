using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент получения идентификационных данных для подключения.
/// </summary>
public class OAuthClient : ApiClient, IOAuthClient
{
    /// <summary>
    ///     Http заголовок токена доступа.
    /// </summary>
    public const string HydrusAccessHeader = "Hydrus-Client-API-Access-Key";

    /// <summary>
    ///     Http заголовок токена сессии.
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
    public Task<HydrusAccessTokenResponse> RequestAccessToken(string name, bool permitsEverything = false, CancellationToken cancel = default)
    {
        return RequestAccessToken(ApiConnection, new AccessTokenRequest(name, permitsEverything), cancel);
    }

    /// <inheritdoc />
    public Task<HydrusAccessTokenResponse> RequestAccessToken(string name, IList<Permissions> permissions, CancellationToken cancel = default)
    {
        return RequestAccessToken(ApiConnection, new AccessTokenRequest(name, permissions), cancel);
    }

    /// <inheritdoc />
    public Task<HydrusAccessTokenResponse> RequestAccessToken(AccessTokenRequest request, CancellationToken cancel = default)
    {
        return RequestAccessToken(ApiConnection, request, cancel);
    }

    /// <inheritdoc />
    public Task<HydrusSessionTokenResponse> RequestSessionToken(string accessToken, CancellationToken cancel = default)
    {
        return RequestSessionToken(ApiConnection, accessToken, cancel);
    }

    /// <inheritdoc />
    public Task<VerifyTokenResponse> VerifyAccessToken(string accessToken, CancellationToken cancel = default)
    {
        return VerifyAccessToken(ApiConnection, accessToken, cancel);
    }

    /// <inheritdoc />
    public Task<VerifyTokenResponse> VerifySessionToken(string sessionToken, CancellationToken cancel = default)
    {
        return VerifySessionToken(ApiConnection, sessionToken, cancel);
    }

    /// <summary>
    ///     Запрашивает токен доступа.
    /// </summary>
    /// <param name="apiConnection">Подключение к клиенту Hydrus.</param>
    /// <param name="request">Запрос получения токена доступа.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="HydrusAccessTokenResponse" /> с ключом доступа.</returns>
    public static Task<HydrusAccessTokenResponse> RequestAccessToken(IApiConnection apiConnection, AccessTokenRequest request, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(apiConnection);

        return apiConnection.Get<HydrusAccessTokenResponse>(HydrusUrls.RequestAccessToken(request), cancel);
    }

    /// <summary>
    ///     Запрашивает токен сессии.
    /// </summary>
    /// <param name="apiConnection">Подключение к клиенту Hydrus.</param>
    /// <param name="accessToken">токен доступа.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="HydrusAccessTokenResponse" /> с полученным ключом доступа.</returns>
    public static Task<HydrusSessionTokenResponse> RequestSessionToken(IApiConnection apiConnection, string accessToken, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(accessToken);
        ThrowHelper.ArgumentNotNull(apiConnection);

        var headers = new Dictionary<string, string>
        {
            { HydrusAccessHeader, accessToken }
        };
        return apiConnection.Get<HydrusSessionTokenResponse>(HydrusUrls.RequestSessionToken(), null, null, headers, cancel);
    }

    /// <summary>
    ///     Производит проверку токена доступа.
    /// </summary>
    /// <param name="apiConnection">Подключение к клиенту Hydrus.</param>
    /// <param name="accessToken">Токен доступа.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="VerifyTokenResponse" /> с информацией о ключе.</returns>
    public static Task<VerifyTokenResponse> VerifyAccessToken(IApiConnection apiConnection, string accessToken, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(apiConnection);
        ThrowHelper.ArgumentNotNull(accessToken);

        var headers = new Dictionary<string, string>
        {
            { HydrusAccessHeader, accessToken }
        };
        return apiConnection.Get<VerifyTokenResponse>(HydrusUrls.VerifyToken(), null, null, headers, cancel);
    }

    /// <summary>
    ///     Производит проверку токена сессии.
    /// </summary>
    /// <param name="apiConnection">Подключение к клиенту Hydrus.</param>
    /// <param name="sessionToken">Токен сессии</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="VerifyTokenResponse" /> с информацией о ключе.</returns>
    public static Task<VerifyTokenResponse> VerifySessionToken(IApiConnection apiConnection, string sessionToken, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(apiConnection);
        ThrowHelper.ArgumentNotNull(sessionToken);

        var headers = new Dictionary<string, string>
        {
            { HydrusSessionHeader, sessionToken }
        };
        return apiConnection.Get<VerifyTokenResponse>(HydrusUrls.VerifyToken(), null, null, headers, cancel);
    }

    private static IApiConnection BuildApi(HydrusClientConfig config)
    {
        ThrowHelper.ArgumentNotNull(config);

        return config.Build();
    }
}
