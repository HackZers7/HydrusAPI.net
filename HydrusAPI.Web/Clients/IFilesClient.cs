namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы с файлами.
/// </summary>
public interface IFilesClient
{
	/// <summary>
	///     Отправляет файл, который находится на локальной машине с Hydrus. Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="filePath">Путь до файла на локальной машине.</param>
	/// <param name="deleteAfterImport">Удалить файл после импорта.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ServiceResponse" /> с информацией о сервисе.</returns>
	Task<ImportResult> SendLocalFile(string filePath, bool deleteAfterImport = false, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет файл, который находится на локальной машине с Hydrus. Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="request">Запрос на импорт файла по пути.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ServiceResponse" /> с информацией о сервисе.</returns>
	Task<ImportResult> SendLocalFile(AddFileRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет файл.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="file">Поток с файлом.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ServiceResponse" /> с информацией о сервисе.</returns>
	Task<ImportResult> SendFile(Stream file, CancellationToken cancel = default);
	
	/// <summary>
	///     Отправляет запрос удаления файлов по их хэшу (SHA256). Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFiles(params string[] hashes);

	/// <summary>
	///     Отправляет запрос удаления файлов по их хэшу (SHA256). Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <param name="reason">Не обязателен, причина удаления файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFiles(IEnumerable<string> hashes, string? reason = null, CancellationToken cancel = default);
	
	/// <summary>
	///     Отправляет запрос удаления файла по их идентификатору. Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFiles(params ulong[] ids);

	/// <summary>
	///     Отправляет запрос удаления файла по их идентификатору. Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <param name="reason">Не обязателен, причина удаления файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFiles(IEnumerable<ulong> ids, string? reason = null, CancellationToken cancel = default);
	
	/// <summary>
	///     Отправляет запрос удаления файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="request">Запрос на удаление файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFiles(DeleteFilesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет запрос для отмены удаления файлов по их хэшу (SHA256). Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> UndeleteFiles(params string[] hashes);
	
	/// <summary>
	///     Отправляет запрос для отмены удаления файлов по их идентификатору. Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> UndeleteFiles(params ulong[] ids);
	
	/// <summary>
	///     Отправляет запрос для отмены удаления файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="request">Запрос на отмену удаления файлов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> UndeleteFiles(UndeleteFilesRequest request, CancellationToken cancel = default);
}
