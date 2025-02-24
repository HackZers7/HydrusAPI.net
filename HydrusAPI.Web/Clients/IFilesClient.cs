using System.Security.Authentication;

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
	///     Удаляет файлы по их хешу (SHA256). Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteFiles(params string[] hashes);

	/// <summary>
	///     Удаляет файлы по их хешу (SHA256). Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
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
	///     Отменяет удаление файлов по их хешу (SHA256). Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
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
	///     Очищает информацию об удалении файлов по их хешу (SHA256). Поддерживается только файловый домен "all local files".
	///     Это то же самое, что и опция расширенного удаления с тем же основным именем.
	///     При этом удаляется запись о том, что файл был физически удален (т.е. это относится только к записям об удалении в домене "all local files").
	///     Файл, о котором больше нет записи об удалении из "all local files", пройдет проверку на "exclude previously deleted files" в параметрах импорта файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
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
	///     Копирует (производит миграцию) файлы в другой файловый домен по их хешу (SHA256).
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
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
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
	///     Производит архивацию файлов по их хешу (SHA256). Поддерживается только файловый домены "my files" или "trash".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
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
	///     Разархивирует файлы по их хешу (SHA256). Поддерживается только файловый домен "my files" или "trash".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
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
	/// <returns>Возвращает <see cref="GeneratedHashesResponse" /> с хешами (SHA256) файла.</returns>
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
	/// <returns>Возвращает <see cref="GeneratedHashesResponse" /> с хешами (SHA256) файла.</returns>
	Task<GeneratedHashesResponse> GenerateHashes(Stream file, CancellationToken cancel = default);

	/// <summary>
	///     Производит поиск файлов по тегам.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="tags">Теги для поиска. Может содержать строковое значение или коллекцию с тегами.</param>
	/// <param name="tagServiceKey">Необязательно, шестнадцатеричный ключ домена, в котором выполняется поиск. По умолчанию - "all my files".</param>
	/// <param name="includeCurrentTags">Необязательно, выполнять поиск по "текущим" тегам. По умолчанию - true.</param>
	/// <param name="includePendingTags">Необязательно, выполнять поиск по "ожидающим" тегам. По умолчанию - true.</param>
	/// <param name="fileSortType">Необязательно, метод сортировки. По умолчанию - <see cref="SortingType.ImportTime" />.</param>
	/// <param name="fileSortAsc">Необязательно, тип сортировки. По умолчанию - true.</param>
	/// <param name="returnFileIds">Необязательно, получить идентификаторы файлов. По умолчанию - true.</param>
	/// <param name="returnHashes">Необязательно, получить хэши файлов. По умолчанию - true.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="FilesSearchResponse" /> с идентификаторами файла.</returns>
	Task<FilesSearchResponse> SearchFiles(
		IEnumerable<object> tags,
		string? tagServiceKey = null,
		bool includeCurrentTags = true,
		bool includePendingTags = true,
		SortingType fileSortType = SortingType.ImportTime,
		bool fileSortAsc = true,
		bool returnFileIds = true,
		bool returnHashes = true,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Производит поиск файлов по тегам.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="FilesSearchResponse" /> с идентификаторами файла.</returns>
	Task<FilesSearchResponse> SearchFiles(SearchFilesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает хэш по другому хешу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="hash">Хэш файла.</param>
	/// <param name="desiredHashType">Тип хеша, который необходимо получить.</param>
	/// <param name="sourceHashType">Тип отправленного хеша. По умолчанию - <see cref="HashAlgorithmType.Sha256" />.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает словарь с идентификаторами файла в нужном типе, где ключ - отправленный идентификатор.</returns>
	Task<IDictionary<string, string>> GetFileHashes(
		string hash,
		HashAlgorithmType desiredHashType,
		HashAlgorithmType sourceHashType = HashAlgorithmType.Sha256,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Запрашивает хэш по другому хешу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="hashes">Коллекция хешей файлов.</param>
	/// <param name="desiredHashType">Тип хеша, который необходимо получить.</param>
	/// <param name="sourceHashType">Тип отправленного хеша. По умолчанию - <see cref="HashAlgorithmType.Sha256" />.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает словарь с идентификаторами файла в нужном типе, где ключ - отправленный идентификатор.</returns>
	Task<IDictionary<string, string>> GetFileHashes(
		IEnumerable<string> hashes,
		HashAlgorithmType desiredHashType,
		HashAlgorithmType sourceHashType = HashAlgorithmType.Sha256,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Запрашивает хэш по другому хешу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает словарь с идентификаторами файла в нужном типе, где ключ - отправленный идентификатор.</returns>
	Task<IDictionary<string, string>> GetFileHashes(FileHashesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает файл.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файл.</param>
	/// <param name="download">Ставит Content-Disposition=attachment. По умолчанию - false.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает поток с файлом.</returns>
	Task<Stream> GetFile(string hash, bool download = false, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает файл.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="fileId">Идентификатор файл.</param>
	/// <param name="download">Ставит Content-Disposition=attachment. По умолчанию - false.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает поток с файлом.</returns>
	Task<Stream> GetFile(ulong fileId, bool download = false, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает эскиз.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файл.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает поток с файлом.</returns>
	Task<Stream> GetThumbnail(string hash, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает эскиз.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="fileId">Идентификатор файл.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает поток с файлом.</returns>
	Task<Stream> GetThumbnail(ulong fileId, CancellationToken cancel = default);

	/// <summary>
	///     Рендерит файл.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файл.</param>
	/// <param name="download">Ставит Content-Disposition=attachment. По умолчанию - false.</param>
	/// <param name="renderFormat">Выходной формат изображения. По умолчанию - <see cref="RenderOutputFormat.Png" />.</param>
	/// <param name="renderQuality">Качество выходного изображения. По умолчанию: PNG - 1; JPEG, WEBP - 80.</param>
	/// <param name="width">Ширина выходного изображения.</param>
	/// <param name="height">Высота выходного изображения.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает поток с файлом.</returns>
	Task<Stream> Render(
		string hash,
		bool download = false,
		RenderOutputFormat renderFormat = RenderOutputFormat.Png,
		ushort? renderQuality = null,
		ulong? width = null,
		ulong? height = null,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Рендер файл.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="fileId">Идентификатор файл.</param>
	/// <param name="download">Ставит Content-Disposition=attachment. По умолчанию - false.</param>
	/// <param name="renderFormat">Выходной формат изображения. По умолчанию - <see cref="RenderOutputFormat.Png" />.</param>
	/// <param name="renderQuality">Качество выходного изображения. По умолчанию: PNG - 1; JPEG, WEBP - 80.</param>
	/// <param name="width">Ширина выходного изображения.</param>
	/// <param name="height">Высота выходного изображения.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает поток с файлом.</returns>
	Task<Stream> Render(
		ulong fileId,
		bool download = false,
		RenderOutputFormat renderFormat = RenderOutputFormat.Png,
		ushort? renderQuality = null,
		ulong? width = null,
		ulong? height = null,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Рендер файл.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает поток с файлом.</returns>
	Task<Stream> Render(RenderRequest request, CancellationToken cancel = default);
}
