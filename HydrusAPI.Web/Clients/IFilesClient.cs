namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы с файлами.
/// </summary>
public interface IFilesClient
{
	/// <summary>
	///     Импортирует файл, который находится на локальной машине с Hydrus. Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="filePath">Путь до файла на локальной машине.</param>
	/// <param name="deleteAfterImport">Удалить файл после импорта.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ImportResult" /> с информацией об импортированном файле.</returns>
	Task<ImportResult> SendFile(string filePath, bool deleteAfterImport = false, CancellationToken cancel = default);

	/// <summary>
	///     Импортирует файл, который находится на локальной машине с Hydrus. Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="request">Запрос на импорт файла по пути.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ImportResult" /> с информацией об импортированном файле.</returns>
	Task<ImportResult> SendFile(AddFileRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Импортирует файл из потока.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="file">Поток с файлом.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ImportResult" /> с информацией об импортированном файле.</returns>
	Task<ImportResult> SendFile(Stream file, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет файлы по их хэшу (SHA256). Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFiles(params string[] hashes);

	/// <summary>
	///     Удаляет файлы по их хэшу (SHA256). Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <param name="reason">Не обязателен, причина удаления файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFiles(IEnumerable<string> hashes, string? reason = null, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет файлы по их идентификатору. Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFiles(params ulong[] ids);

	/// <summary>
	///     Удаляет файлы по их идентификатору. Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <param name="reason">Не обязателен, причина удаления файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFiles(IEnumerable<ulong> ids, string? reason = null, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет файлы.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFiles(DeleteFilesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Отменяет удаление файлов по их хэшу (SHA256). Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> UndeleteFiles(params string[] hashes);

	/// <summary>
	///     Отменяет удаление файлов по их идентификатору. Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> UndeleteFiles(params ulong[] ids);

	/// <summary>
	///     Отменяет удаление файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> UndeleteFiles(FilesWithDomainRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Очищает информацию об удалении файлов по их хэшу (SHA256). Поддерживается только файловый домен "all local files".
	///     Это то же самое, что и опция расширенного удаления с тем же основным именем.
	///     При этом удаляется запись о том, что файл был физически удален (т.е. это относится только к записям об удалении в домене "all local files").
	///     Файл, о котором больше нет записи об удалении из "all local files", пройдет проверку на "exclude previously deleted files" в параметрах импорта файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> ClearFilesDeletion(params string[] hashes);

	/// <summary>
	///     Очищает информацию об удалении файлов по их идентификатору. Поддерживается только файловый домен "all local files".
	///     Это то же самое, что и опция расширенного удаления с тем же основным именем.
	///     При этом удаляется запись о том, что файл был физически удален (т.е. это относится только к записям об удалении в домене "all local files").
	///     Файл, о котором больше нет записи об удалении из "all local files", пройдет проверку на "exclude previously deleted files" в параметрах импорта файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> ClearFilesDeletion(params ulong[] ids);

	/// <summary>
	///     Очищает информацию об удалении файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="request">Запрос с файлами.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> ClearFilesDeletion(FilesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Копирует (производит миграцию) файлы в другой файловый домен по их хэшу (SHA256).
	///     Это уместно только в том случае, если у пользователя несколько локальных файловых сервисов.
	///     Действие выполняется аналогично действию в меню media files->add to->domain menu action.
	///     Если файлы изначально находятся в локальном файловом домене A, а вы говорите "добавить в B", то впоследствии они будут и в A, и в B.
	///     Действие является идемпотентным и не приводит к перезаписи файлов, которые "уже есть", новыми временными метками или чем-либо еще.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="toFileDomain">Шестнадцатеричный домен, в который необходимо скопировать файл.</param>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> MigrateFiles(string toFileDomain, params string[] hashes);

	/// <summary>
	///     Копирует (производит миграцию) файлы в другой файловый домен по их идентификатору.
	///     Это уместно только в том случае, если у пользователя несколько локальных файловых сервисов.
	///     Действие выполняется аналогично действию в меню media files->add to->domain menu action.
	///     Если файлы изначально находятся в локальном файловом домене A, а вы говорите "добавить в B", то впоследствии они будут и в A, и в B.
	///     Действие является идемпотентным и не приводит к перезаписи файлов, которые "уже есть", новыми временными метками или чем-либо еще.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="toFileDomain">Шестнадцатеричный домен, в который необходимо скопировать файл.</param>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> MigrateFiles(string toFileDomain, params ulong[] ids);

	/// <summary>
	///     Копирует (производит миграцию) файлы в другой файловый домен.
	///     Это уместно только в том случае, если у пользователя несколько локальных файловых сервисов.
	///     Действие выполняется аналогично действию в меню media files->add to->domain menu action.
	///     Если файлы изначально находятся в локальном файловом домене A, а вы говорите "добавить в B", то впоследствии они будут и в A, и в B.
	///     Действие является идемпотентным и не приводит к перезаписи файлов, которые "уже есть", новыми временными метками или чем-либо еще.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="request">Запрос с файлами и доменом.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> MigrateFiles(FilesWithDomainRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Производит архивацию файлов по их хэшу (SHA256). Поддерживается только файловый домены "my files" или "trash".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> ArchiveFiles(params string[] hashes);

	/// <summary>
	///     Производит архивацию файлов по их идентификатору. Поддерживается только файловый домены "my files" или "trash".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> ArchiveFiles(params ulong[] ids);

	/// <summary>
	///     Производит архивацию файлов. Поддерживается только файловый домены "my files" или "trash".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="request">Запрос с файлами.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> ArchiveFiles(FilesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Разархивирует файлы по их хэшу (SHA256). Поддерживается только файловый домен "my files" или "trash".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> UnarchiveFiles(params string[] hashes);

	/// <summary>
	///     Разархивирует файлы по их идентификатору. Поддерживается только файловый домен "my files" или "trash".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> UnarchiveFiles(params ulong[] ids);

	/// <summary>
	///     Разархивирует файлы. Поддерживается только файловый домен "my files" или "trash".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="request">Запрос с файлами.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> UnarchiveFiles(FilesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Генерирует хэши (SHA256), для файла, который находится на локальной машине с Hydrus.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="filePath">Путь до файла на локальной машине.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="GeneratedHashesResponse" /> с хэшами (SHA256) файла.</returns>
	Task<GeneratedHashesResponse> GenerateHashes(string filePath, CancellationToken cancel = default);

	/// <summary>
	///     Генерирует хэши (SHA256), для файла из потока.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="file">Поток с файлом.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="GeneratedHashesResponse" /> с хэшами (SHA256) файла.</returns>
	Task<GeneratedHashesResponse> GenerateHashes(Stream file, CancellationToken cancel = default);
}
