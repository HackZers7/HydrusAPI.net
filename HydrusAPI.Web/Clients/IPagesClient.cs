namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы со страницами Hydrus.
/// </summary>
public interface IPagesClient
{
	/// <summary>
	///     Запрашивает все страницы открытие в клиенте Hydrus.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePages" />.
	/// </remarks>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает "главную" станицу, которая содержит другие страницы.</returns>
	Task<Page> GetPages(CancellationToken cancel = default);

	/// <summary>
	///     Добавляет файлы на страницу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePages" />.
	/// </remarks>
	/// <param name="pageKey">Уникальный ключ страницы.</param>
	/// <param name="hash">Хэш (SHA256) файл.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> AddFilesOnPage(string pageKey, string hash, CancellationToken cancel = default);

	/// <summary>
	///     Добавляет файлы на страницу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePages" />.
	/// </remarks>
	/// <param name="pageKey">Уникальный ключ страницы.</param>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> AddFilesOnPage(string pageKey, params string[] hashes);

	/// <summary>
	///     Добавляет файлы на страницу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePages" />.
	/// </remarks>
	/// <param name="pageKey">Уникальный ключ страницы.</param>
	/// <param name="fileId">Идентификатор файл.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> AddFilesOnPage(string pageKey, ulong fileId, CancellationToken cancel = default);

	/// <summary>
	///     Добавляет файлы на страницу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePages" />.
	/// </remarks>
	/// <param name="pageKey">Уникальный ключ страницы.</param>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> AddFilesOnPage(string pageKey, params ulong[] ids);

	/// <summary>
	///     Добавляет файлы на страницу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePages" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> AddFilesOnPage(AddFilesOnPageRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Фокусирует страницу в клиенте Hydrus.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePages" />.
	/// </remarks>
	/// <param name="pageKey">Уникальный ключ страницы.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> FocusPage(string pageKey, CancellationToken cancel = default);

	/// <summary>
	///     Обновляет страницу в клиенте Hydrus.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePages" />.
	/// </remarks>
	/// <param name="pageKey">Уникальный ключ страницы.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> RefreshPage(string pageKey, CancellationToken cancel = default);
}
