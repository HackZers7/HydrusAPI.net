namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для получения ключа доступа.
/// </summary>
public interface IOAuthClient
{
    /// <summary>
    ///     Запрашивает токен доступа.
    /// </summary>
    /// <param name="name">Наименование токена.</param>
    /// <param name="permitsEverything">Разрешить доступ ко всем областям (разрешениям), в том числе и тем что появятся в будущем. По умолчанию - false.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="HydrusAccessTokenResponse" /> с ключом доступа.</returns>
    Task<HydrusAccessTokenResponse> RequestAccessToken(string name, bool permitsEverything = false, CancellationToken cancel = default);

    /// <summary>
    ///     Запрашивает токен доступа.
    /// </summary>
    /// <param name="name">Название ключа.</param>
    /// <param name="permissions">Коллекция областей (разрешений).</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="HydrusAccessTokenResponse" /> с ключом доступа.</returns>
    Task<HydrusAccessTokenResponse> RequestAccessToken(string name, IList<Permissions> permissions, CancellationToken cancel = default);

    /// <summary>
    ///     Запрашивает токен доступа.
    /// </summary>
    /// <param name="request">Запрос получения токена доступа.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="HydrusAccessTokenResponse" /> с ключом доступа.</returns>
    Task<HydrusAccessTokenResponse> RequestAccessToken(AccessTokenRequest request, CancellationToken cancel = default);

    /// <summary>
    ///     Запрашивает токен сессии.
    /// </summary>
    /// <param name="accessToken">Токен доступа.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="HydrusSessionTokenResponse" /> с полученным ключом сессии.</returns>
    Task<HydrusSessionTokenResponse> RequestSessionToken(string accessToken, CancellationToken cancel = default);

    /// <summary>
    ///     Производит проверку токена доступа.
    /// </summary>
    /// <param name="accessToken">Токен доступа.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="VerifyTokenResponse" /> с информацией о ключе.</returns>
    Task<VerifyTokenResponse> VerifyAccessToken(string accessToken, CancellationToken cancel = default);

    /// <summary>
    ///     Производит проверку токена сессии.
    /// </summary>
    /// <param name="sessionToken">Токен сессии</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="VerifyTokenResponse" /> с информацией о ключе.</returns>
    Task<VerifyTokenResponse> VerifySessionToken(string sessionToken, CancellationToken cancel = default);
}
