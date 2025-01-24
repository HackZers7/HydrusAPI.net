namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для получения ключа доступа.
/// </summary>
public interface IOAuthClient
{
	/// <summary>
	///     Запрашивает ключ доступа.
	/// </summary>
	/// <param name="name">Название ключа.</param>
	/// <param name="permitsEverything">Разрешить доступ ко всем областям (разрешениям).</param>
	/// <param name="permissions">Области видимости (разрешения).</param>
	/// <returns>Возвращает <see cref="HydrusAccessToken" /> с полученным ключом доступа.</returns>
	Task<HydrusAccessToken> RequestAccessToken(string name, bool permitsEverything, params Permissions[] permissions);

	/// <summary>
	///     Запрашивает ключ доступа.
	/// </summary>
	/// <param name="name">Название ключа.</param>
	/// <param name="permitsEverything">Разрешить доступ ко всем областям (разрешениям).</param>
	/// <param name="permissions">Области видимости (разрешения).</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="HydrusAccessToken" /> с полученным ключом доступа.</returns>
	Task<HydrusAccessToken> RequestAccessToken(string name, bool permitsEverything, Permissions[] permissions, CancellationToken cancel);

	/// <summary>
	///     Запрашивает ключ сессии.
	/// </summary>
	/// <param name="accessToken">Ключ доступа.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="HydrusSessionToken" /> с полученным ключом сессии.</returns>
	Task<HydrusSessionToken> RequestSessionToken(string accessToken, CancellationToken cancel = default);

	/// <summary>
	///     Производит проверку токена доступа.
	/// </summary>
	/// <param name="accessToken">Токен доступа.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="VerifyToken" /> с информацией о ключе.</returns>
	Task<VerifyToken> VerifyAccessToken(string accessToken, CancellationToken cancel = default);

	/// <summary>
	///     Производит проверку токена сессии.
	/// </summary>
	/// <param name="sessionToken">Токен сессии</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="VerifyToken" /> с информацией о ключе.</returns>
	Task<VerifyToken> VerifySessionToken(string sessionToken, CancellationToken cancel = default);
}
