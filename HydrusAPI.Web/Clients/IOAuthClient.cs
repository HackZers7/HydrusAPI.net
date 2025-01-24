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
	/// <param name="permitsEverything">selective, bool, whether to permit all tasks now and in future</param>
	/// <param name="permissions">Разрешения которые необходимы.</param>
	/// <returns>Возвращает <see cref="HydrusAccessToken" /> с полученным ключом доступа.</returns>
	Task<HydrusAccessToken> RequestAccessToken(string name, bool permitsEverything, params Permissions[] permissions);

	/// <summary>
	///     Запрашивает ключ доступа.
	/// </summary>
	/// <param name="name">Название ключа.</param>
	/// <param name="permitsEverything">selective, bool, whether to permit all tasks now and in future</param>
	/// <param name="permissions">Разрешения которые необходимы.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="HydrusAccessToken" /> с полученным ключом доступа.</returns>
	Task<HydrusAccessToken> RequestAccessToken(string name, bool permitsEverything, Permissions[] permissions, CancellationToken cancel);

	/// <summary>
	///     Запрашивает ключ сессии.
	/// </summary>
	/// <param name="accessToken">Ключ доступа.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="HydrusSessionToken" /> с полученным ключом сессии.</returns>
	Task<HydrusSessionToken> RequestSessionToken(string accessToken, CancellationToken cancel);
}
