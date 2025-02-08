namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы с url.
/// </summary>
public interface IUrlsClient
{
	/// <summary>
	///     Отправляет запрос поиска файлов по URL.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportEditUrls" />,
	/// </remarks>
	/// <param name="url">URL файла.</param>
	/// <param name="doublecheckFileSystem">
	///     Если true – то любой результат, который <see cref="FileStatus.AlreadyExists" /> (2), будет дважды сверен с фактической файловой системой.
	///     Эта проверка выполняется в любом обычном процессе импорта файлов, для проверки и исправления отсутствующих файлов (если файл отсутствует, статус становится <see cref="FileStatus.FileNotExists" /> (0)).
	/// </param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="UrlFilesResponse" /> с информацией об привязанных к URL файлах.</returns>
	Task<UrlFilesResponse> GetUrlFiles(string url, bool doublecheckFileSystem = false, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет запрос на получении информации о URL.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportEditUrls" />,
	/// </remarks>
	/// <param name="url">URl файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="UrlInfoResponse" /> с информацией об URL.</returns>
	Task<UrlInfoResponse> GetUrlInfo(string url, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет запрос на импорт файлов по URL.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportEditUrls" />,
	/// </remarks>
	/// <param name="url">URL с файлом или файлами для импорта.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ImportUrlResult" /> с результатом импорта.</returns>
	Task<ImportUrlResult> ImportUrl(string url, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет запрос на импорт файлов по URL.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportEditUrls" />,
	/// </remarks>
	/// <param name="request">Запрос для отправки.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ImportUrlResult" /> с результатом импорта.</returns>
	Task<ImportUrlResult> ImportUrl(AddUrlRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет запрос для ассоциации (добавления).
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportEditUrls" />,
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файла к которому нужно добавить ссылки.</param>
	/// <param name="urls">Ссылки для добавления.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> AddUrlToFile(string hash, params string[] urls);

	/// <summary>
	///     Отправляет запрос для ассоциации (добавления).
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportEditUrls" />,
	/// </remarks>
	/// <param name="id">Идентификатор файла к которому нужно добавить ссылки.</param>
	/// <param name="urls">Ссылки для добавления.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> AddUrlToFile(ulong id, params string[] urls);

	/// <summary>
	///     Отправляет запрос для диссоциации (удаления).
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportEditUrls" />,
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файла к которому нужно добавить ссылки.</param>
	/// <param name="urls">Ссылки для добавления.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> RemoveUrlFromFile(string hash, params string[] urls);

	/// <summary>
	///     Отправляет запрос для диссоциации (удаления).
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportEditUrls" />,
	/// </remarks>
	/// <param name="id">Идентификатор файла к которому нужно добавить ссылки.</param>
	/// <param name="urls">Ссылки для добавления.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> RemoveUrlFromFile(ulong id, params string[] urls);

	/// <summary>
	///     Отправляет запрос для ассоциации или диссоциации.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportEditUrls" />,
	/// </remarks>
	/// <param name="request">Запрос для отправки.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ImportUrlResult" /> с результатом импорта.</returns>
	Task<bool> AssociateUrl(AssociateUrlRequest request, CancellationToken cancel = default);
}
