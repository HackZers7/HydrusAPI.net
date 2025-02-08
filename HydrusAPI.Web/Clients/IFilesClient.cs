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
	/// <param name="request">Запрос с файлами и доменом.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> UndeleteFiles(FilesWithDomain request, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет запрос для очистки информации об удалении файлов по их хэшу (SHA256). Поддерживается только файловый домен "all local files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> ClearFilesDeletion(params string[] hashes);

	/// <summary>
	///     Отправляет запрос для очистки информации об удалении файлов по их идентификатору. Поддерживается только файловый домен "all local files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> ClearFilesDeletion(params ulong[] ids);

	/// <summary>
	///     Отправляет запрос для очистки информации об удалении файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="request">Запрос с файлами.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> ClearFilesDeletion(Files request, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет запрос для копирования (миграции) файлов в другой файловый домен по их хэшу (SHA256).
	///     Это уместно только в том случае, если у пользователя несколько локальных файловых сервисов.
	///     Действие выполняется аналогично действию в меню media files->add to->domain menu action.
	///     Если файлы изначально находятся в локальном файловом домене A, а вы говорите "добавить в B", то впоследствии они будут и в A, и в B.
	///     Действие является идемпотентным и не приводит к перезаписи файлов, которые "уже есть", новыми временными метками или чем-либо еще.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="toFileDomain">Шестнадцатеричный домен, в который необходимо скопировать файл.</param>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> MigrateFiles(string toFileDomain, params string[] hashes);

	/// <summary>
	///     Отправляет запрос для копирования (миграции) файлов в другой файловый домен по их идентификатору.
	///     Это уместно только в том случае, если у пользователя несколько локальных файловых сервисов.
	///     Действие выполняется аналогично действию в меню media files->add to->domain menu action.
	///     Если файлы изначально находятся в локальном файловом домене A, а вы говорите "добавить в B", то впоследствии они будут и в A, и в B.
	///     Действие является идемпотентным и не приводит к перезаписи файлов, которые "уже есть", новыми временными метками или чем-либо еще.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="toFileDomain">Шестнадцатеричный домен, в который необходимо скопировать файл.</param>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> MigrateFiles(string toFileDomain, params ulong[] ids);

	/// <summary>
	///     Отправляет запрос для копирования (миграции) файлов в другой файловый домен.
	///     Это уместно только в том случае, если у пользователя несколько локальных файловых сервисов.
	///     Действие выполняется аналогично действию в меню media files->add to->domain menu action.
	///     Если файлы изначально находятся в локальном файловом домене A, а вы говорите "добавить в B", то впоследствии они будут и в A, и в B.
	///     Действие является идемпотентным и не приводит к перезаписи файлов, которые "уже есть", новыми временными метками или чем-либо еще.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="request">Запрос с файлами и доменом.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> MigrateFiles(FilesWithDomain request, CancellationToken cancel = default);
	
	/// <summary>
	///     Отправляет запрос для архивации отправленных файлов по их хэшу (SHA256). Поддерживается только файловый домен "my files" или "trash".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> ArchiveFiles(params string[] hashes);

	/// <summary>
	///     Отправляет запрос для архивации отправленных файлов по их идентификатору. Поддерживается только файловый домен "my files" или "trash".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> ArchiveFiles(params ulong[] ids);

	/// <summary>
	///     Отправляет запрос для архивации отправленных файлов. Поддерживается только файловый домен "my files" или "trash".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="request">Запрос с файлами.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> ArchiveFiles(Files request, CancellationToken cancel = default);
	
	/// <summary>
	///     Отправляет запрос для разархивации отправленных файлов по их хэшу (SHA256). Поддерживается только файловый домен "my files" или "trash".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> UnarchiveFiles(params string[] hashes);

	/// <summary>
	///     Отправляет запрос для разархивации отправленных файлов по их идентификатору. Поддерживается только файловый домен "my files" или "trash".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> UnarchiveFiles(params ulong[] ids);

	/// <summary>
	///     Отправляет запрос для разархивации отправленных файлов. Поддерживается только файловый домен "my files" или "trash".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.ImportDeleteFiles" />,
	/// </remarks>
	/// <param name="request">Запрос с файлами.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> UnarchiveFiles(Files request, CancellationToken cancel = default);
}
