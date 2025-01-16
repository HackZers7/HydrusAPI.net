namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для получения ключа доступа.
/// </summary>
public interface IAccessClient
{
	/// <summary>
	///     Запрашивает ключ идентификации API.
	/// </summary>
	/// <param name="name">Название ключа.</param>
	/// <param name="permitsEverything">selective, bool, whether to permit all tasks now and in future</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="AuthAccessKey" /> с полученным ключом доступа.</returns>
	Task<AuthAccessKey> GetAccessKey(string name, bool permitsEverything = true, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает ключ идентификации API.
	/// </summary>
	/// <param name="name">Название ключа.</param>
	/// <param name="permissions">Разрешения которые необходимы.</param>
	/// <returns>Возвращает <see cref="AuthAccessKey" /> с полученным ключом доступа.</returns>
	Task<AuthAccessKey> GetAccessKey(string name, params Permissions[] permissions);

	/// <summary>
	///     Запрашивает ключ идентификации API.
	/// </summary>
	/// <param name="name">Название ключа.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <param name="permissions">Разрешения которые необходимы.</param>
	/// <returns>Возвращает <see cref="AuthAccessKey" /> с полученным ключом доступа.</returns>
	Task<AuthAccessKey> GetAccessKey(string name, CancellationToken cancel, params Permissions[] permissions);
}
