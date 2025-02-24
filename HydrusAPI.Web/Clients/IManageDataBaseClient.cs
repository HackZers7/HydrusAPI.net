namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы базой данных Hydrus.
/// </summary>
public interface IManageDataBaseClient
{
	/// <summary>
	///     Заставляет БД немедленно записать все ожидающие изменения
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManageDatabase" />.
	/// </remarks>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> ForceCommit(CancellationToken cancel = default);

	/// <summary>
	///     Приостанавливает работу БД клиента и отключает текущее соединение.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManageDatabase" />.
	/// </remarks>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> LockOn(CancellationToken cancel = default);

	/// <summary>
	///     Восстанавливает соединение с БД клиента.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManageDatabase" />.
	/// </remarks>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> LockOff(CancellationToken cancel = default);
}
