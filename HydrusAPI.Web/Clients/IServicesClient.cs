namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы с сервисами Hydrus.
/// </summary>
public interface IServicesClient
{
	/// <summary>
	///     Запрашивает данные о сервисе по имени.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для получения информации о сервисе требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	///     <see cref="Permissions.EditFileTags" />,
	///     <see cref="Permissions.ManagePages" />,
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="name">Название сервиса.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ServiceResponse" /> с информацией о сервисе.</returns>
	Task<ServiceResponse> GetServiceByName(string name, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает данные о сервисе по ключу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для получения информации о сервисе требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	///     <see cref="Permissions.EditFileTags" />,
	///     <see cref="Permissions.ManagePages" />,
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="key">Ключ сервиса.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ServiceResponse" /> с информацией о сервисе.</returns>
	Task<ServiceResponse> GetServiceByKey(string key, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает данные о всех доступных сервисах.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для получения информации о сервисе требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	///     <see cref="Permissions.EditFileTags" />,
	///     <see cref="Permissions.ManagePages" />,
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ServicesResponse" /> с информацией о всех сервисах.</returns>
	Task<ServicesResponse> GetServices(CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает ожидающие загрузки материалы для каждого сервиса.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.CommitPending" />.
	/// </remarks>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="PendingCountsResponse" />.</returns>
	Task<PendingCountsResponse> GetPendingCounts(CancellationToken cancel = default);

	/// <summary>
	///     Запускает загрузку ожидающего сервиса.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.CommitPending" />.
	/// </remarks>
	/// <param name="serviceKey">Ключ сервиса.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> CommitPending(string serviceKey, CancellationToken cancel = default);

	/// <summary>
	///     Отменяет загрузку ожидающего сервиса.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.CommitPending" />.
	/// </remarks>
	/// <param name="serviceKey">Ключ сервиса.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> ForgetPending(string serviceKey, CancellationToken cancel = default);
}
