namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы с файлами.
/// </summary>
public interface IFilesClient
{
	/// <summary>
	///     Отправляет файл, который находится на локальной машине с Hydrus.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="filePath">Путь до файла на локальной машине.</param>
	/// <param name="deleteAfterImport">Удалить файл после импорта.</param>
	/// <param name="fileDomain">Не обязателен, локальный домен файла. По умолчанию "my files".</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ServiceResponse" /> с информацией о сервисе.</returns>
	Task<ImportResult> SendLocalFile(string filePath, bool deleteAfterImport = false, string? fileDomain = null, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет файл, который находится на локальной машине с Hydrus.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="request">Запрос на импорт файла по пути.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ServiceResponse" /> с информацией о сервисе.</returns>
	Task<ImportResult> SendLocalFile(ImportFileRequest request, CancellationToken cancel = default);

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
	///     Отправляет запрос удаления файла по его hash.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="hash">Хэш в формате SHA256.</param>
	/// <param name="fileDomain">Не обязателен, локальный домен файла. По умолчанию "my files".</param>
	/// <param name="reason">Не обязателен, причина удаления файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFile(string hash, string? fileDomain = null, string? reason = null, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет запрос удаления файла по его hash.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="hashes">Хэши в формате SHA256.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFile(params string[] hashes);

	/// <summary>
	///     Отправляет запрос удаления файла по его hash.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="hashes">Хэши в формате SHA256.</param>
	/// <param name="fileDomain">Не обязателен, локальный домен файла. По умолчанию "my files".</param>
	/// <param name="reason">Не обязателен, причина удаления файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFile(IEnumerable<string> hashes, string? fileDomain = null, string? reason = null, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет запрос удаления файла по его hash.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="request">Запрос на удаление файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFile(DeleteFilesByHashRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет запрос удаления файла по его hash.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="id">Идентификатор файла.</param>
	/// <param name="fileDomain">Не обязателен, локальный домен файла. По умолчанию "my files".</param>
	/// <param name="reason">Не обязателен, причина удаления файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFile(ulong id, string? fileDomain = null, string? reason = null, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет запрос удаления файла по его hash.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFile(params ulong[] ids);

	/// <summary>
	///     Отправляет запрос удаления файла по его hash.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <param name="fileDomain">Не обязателен, локальный домен файла. По умолчанию "my files".</param>
	/// <param name="reason">Не обязателен, причина удаления файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFile(IEnumerable<ulong> ids, string? fileDomain = null, string? reason = null, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет запрос удаления файла по его hash.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="request">Запрос на удаление файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFile(DeleteFilesByIdRequest request, CancellationToken cancel = default);
}
