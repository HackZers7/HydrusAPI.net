using System.Security.Authentication;

namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы с файлами.
/// </summary>
public interface IFilesClient
{
	/// <summary>
	///     Импортирует файл, который находится на локальной машине с Hydrus. Используется файловый домен по умолчанию - "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="filePath">Путь до файла на локальной машине.</param>
	/// <param name="deleteAfterImport">Удалить файл после импорта.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ImportResultResponse" /> с информацией об импортированном файле.</returns>
	Task<ImportResultResponse> SendFile(string filePath, bool deleteAfterImport = false, CancellationToken cancel = default);

	/// <summary>
	///     Импортирует файл, который находится на локальной машине с Hydrus. Используется файловый домен по умолчанию - "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="request">Запрос на импорт файла по пути.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ImportResultResponse" /> с информацией об импортированном файле.</returns>
	Task<ImportResultResponse> SendFile(AddFileRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Импортирует файл из потока.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="file">Поток с файлом.</param>
	/// <param name="progressCallback">Функция обратного вызова для отображения процесса отправки.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ImportResultResponse" /> с информацией об импортированном файле.</returns>
	Task<ImportResultResponse> SendFile(Stream file, IProgress<int>? progressCallback = default, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет файл по хешу (SHA256). Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hash">Хеши (SHA256) файлов.</param>
	/// <param name="reason">Не обязателен, причина удаления файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task DeleteFiles(string hash, string? reason = null, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет файлы по их хешу (SHA256). Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	/// <param name="reason">Не обязателен, причина удаления файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task DeleteFiles(IList<string> hashes, string? reason = null, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет файл по идентификатору. Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="id">Идентификатор файла.</param>
	/// <param name="reason">Не обязателен, причина удаления файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task DeleteFiles(ulong id, string? reason = null, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет файлы по их идентификатору. Используется файловый домен по умолчанию "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="ids">Коллекция идентификаторов файлов.</param>
	/// <param name="reason">Не обязателен, причина удаления файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task DeleteFiles(IList<ulong> ids, string? reason = null, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет файлы.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task DeleteFiles(DeleteFilesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Отменяет удаление файла по хешу (SHA256). Используется файловый домен по умолчанию "all my files".
	///     Это обратная функция <see cref="DeleteFiles(DeleteFilesRequest, CancellationToken)"/> - восстанавливает файлы туда, откуда они были получены. 
	///		Если указана файловый домен, то файлы будут восстановлены только в нем. 
	/// 	Значение по умолчанию "all my files" восстанавливает во всех локальных доменах.
	///		Эта операция будет выполняться только с файлами, которые находятся в вашем хранилище файлов (т.е. во "all local files" и, возможно, но не обязательно, в "trash").
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task RestoreFiles(string hash);

	/// <summary>
	///     Отменяет удаление файлов по их хешу (SHA256). Используется файловый домен по умолчанию "all my files".
	///     Это обратная функция <see cref="DeleteFiles(DeleteFilesRequest, CancellationToken)"/> - восстанавливает файлы туда, откуда они были получены. 
	///		Если указана файловый домен, то файлы будут восстановлены только в нем. 
	/// 	Значение по умолчанию "all my files" восстанавливает во всех локальных доменах.
	///		Эта операция будет выполняться только с файлами, которые находятся в вашем хранилище файлов (т.е. во "all local files" и, возможно, но не обязательно, в "trash").
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task RestoreFiles(IList<string> hashes);

	/// <summary>
	///     Отменяет удаление файла по идентификатору. Используется файловый домен по умолчанию "all my files".
	///     Это обратная функция <see cref="DeleteFiles(DeleteFilesRequest, CancellationToken)"/> - восстанавливает файлы туда, откуда они были получены. 
	///		Если указана файловый домен, то файлы будут восстановлены только в нем. 
	/// 	Значение по умолчанию "all my files" восстанавливает во всех локальных доменах.
	///		Эта операция будет выполняться только с файлами, которые находятся в вашем хранилище файлов (т.е. во "all local files" и, возможно, но не обязательно, в "trash").
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="id">Идентификатор файлов.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task RestoreFiles(ulong id);

	/// <summary>
	///     Отменяет удаление файлов по их идентификатору. Используется файловый домен по умолчанию "all my files".
	///     Это обратная функция <see cref="DeleteFiles(DeleteFilesRequest, CancellationToken)"/> - восстанавливает файлы туда, откуда они были получены. 
	///		Если указана файловый домен, то файлы будут восстановлены только в нем. 
	/// 	Значение по умолчанию "all my files" восстанавливает во всех локальных доменах.
	///		Эта операция будет выполняться только с файлами, которые находятся в вашем хранилище файлов (т.е. во "all local files" и, возможно, но не обязательно, в "trash").
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task RestoreFiles(IList<ulong> ids);

	/// <summary>
	///     Отменяет удаление файлов.
	///     Это обратная функция <see cref="DeleteFiles(DeleteFilesRequest, CancellationToken)"/> - восстанавливает файлы туда, откуда они были получены. 
	///		Если указана файловый домен, то файлы будут восстановлены только в нем. 
	/// 	Значение по умолчанию "all my files" восстанавливает во всех локальных доменах.
	///		Эта операция будет выполняться только с файлами, которые находятся в вашем хранилище файлов (т.е. во "all local files" и, возможно, но не обязательно, в "trash").
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task RestoreFiles(FilesWithDomainRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Очищает информацию об удалении файла по хешу (SHA256). Поддерживается только файловый домен "all local files".
	///     Это то же самое, что и опция расширенного удаления с тем же основным именем.
	///     При этом удаляется запись о том, что файл был физически удален (т.е. это относится только к записям об удалении в домене "all local files").
	///     Файл, о котором больше нет записи об удалении из "all local files", пройдет проверку на "exclude previously deleted files" в параметрах импорта файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task ClearFilesDeletion(string hash);

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
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task ClearFilesDeletion(IList<string> hashes);

	/// <summary>
	///     Очищает информацию об удалении файла по идентификатору. Поддерживается только файловый домен "all local files".
	///     Это то же самое, что и опция расширенного удаления с тем же основным именем.
	///     При этом удаляется запись о том, что файл был физически удален (т.е. это относится только к записям об удалении в домене "all local files").
	///     Файл, о котором больше нет записи об удалении из "all local files", пройдет проверку на "exclude previously deleted files" в параметрах импорта файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="id">Идентификатор файла.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task ClearFilesDeletion(ulong id);

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
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task ClearFilesDeletion(IList<ulong> ids);

	/// <summary>
	///     Очищает информацию об удалении файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="request">Запрос с файлами.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task ClearFilesDeletion(FilesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Копирует (производит миграцию) файл в другой файловый домен по хешу (SHA256).
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
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task MigrateFiles(string toFileDomain, string hash);

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
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task MigrateFiles(string toFileDomain, IList<string> hashes);

	/// <summary>
	///     Копирует (производит миграцию) файл в другой файловый домен по идентификатору.
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
	/// <param name="id">Идентификатор файла.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task MigrateFiles(string toFileDomain, ulong id);

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
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task MigrateFiles(string toFileDomain, IList<ulong> ids);

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
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task MigrateFiles(FilesWithDomainRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Производит архивацию файла по хешу (SHA256). Поддерживается только файловый домены "my files" или "trash".
	///     Перемещает файлы в "archive", удаляя их из "inbox". 
	/// 	Имеет значение только для файлов, которые в данный момент находятся в "my files" или "trash". 
	///		Ошибки не выбрасываются, если файлы не существуют или уже находятся в архиве.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task ArchiveFiles(string hash);

	/// <summary>
	///     Производит архивацию файлов по их хешу (SHA256). Поддерживается только файловый домены "my files" или "trash".
	///     Перемещает файлы в "archive", удаляя их из "inbox". 
	/// 	Имеет значение только для файлов, которые в данный момент находятся в "my files" или "trash". 
	///		Ошибки не выбрасываются, если файлы не существуют или уже находятся в архиве.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task ArchiveFiles(IList<string> hashes);

	/// <summary>
	///     Производит архивацию файла по идентификатору. Поддерживается только файловый домены "my files" или "trash".
	///     Перемещает файлы в "archive", удаляя их из "inbox". 
	/// 	Имеет значение только для файлов, которые в данный момент находятся в "my files" или "trash". 
	///		Ошибки не выбрасываются, если файлы не существуют или уже находятся в архиве.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="id">Идентификатор файла.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task ArchiveFiles(ulong id);

	/// <summary>
	///     Производит архивацию файлов по их идентификатору. Поддерживается только файловый домены "my files" или "trash".
	///     Перемещает файлы в "archive", удаляя их из "inbox". 
	/// 	Имеет значение только для файлов, которые в данный момент находятся в "my files" или "trash". 
	///		Ошибки не выбрасываются, если файлы не существуют или уже находятся в архиве.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task ArchiveFiles(IList<ulong> ids);

	/// <summary>
	///     Производит архивацию файлов. Поддерживается только файловый домены "my files" или "trash".
	///     Перемещает файлы в "archive", удаляя их из "inbox". 
	/// 	Имеет значение только для файлов, которые в данный момент находятся в "my files" или "trash". 
	///		Ошибки не выбрасываются, если файлы не существуют или уже находятся в архиве.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="request">Запрос с файлами.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task ArchiveFiles(FilesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Разархивирует файл по хешу (SHA256). Поддерживается только файловый домен "my files" или "trash".
	///     Возвращает файлы обратно в "inbox", удалив их из "archive". 
	///		Имеет значение только для файлов, которые в данный момент находятся в "my files" или "trash".
	///		Ошибки не выбрасываются, если файлы не существуют или уже находятся во входящих.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task UnarchiveFiles(string hash);

	/// <summary>
	///     Разархивирует файлы по их хешу (SHA256). Поддерживается только файловый домен "my files" или "trash".
	///     Возвращает файлы обратно в "inbox", удалив их из "archive". 
	///		Имеет значение только для файлов, которые в данный момент находятся в "my files" или "trash".
	///		Ошибки не выбрасываются, если файлы не существуют или уже находятся во входящих.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task UnarchiveFiles(IList<string> hashes);

	/// <summary>
	///     Разархивирует файл по идентификатору. Поддерживается только файловый домен "my files" или "trash".
	///     Возвращает файлы обратно в "inbox", удалив их из "archive". 
	///		Имеет значение только для файлов, которые в данный момент находятся в "my files" или "trash".
	///		Ошибки не выбрасываются, если файлы не существуют или уже находятся во входящих.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="id">Идентификатор файла.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task UnarchiveFiles(ulong id);

	/// <summary>
	///     Разархивирует файлы по их идентификатору. Поддерживается только файловый домен "my files" или "trash".
	///     Возвращает файлы обратно в "inbox", удалив их из "archive". 
	///		Имеет значение только для файлов, которые в данный момент находятся в "my files" или "trash".
	///		Ошибки не выбрасываются, если файлы не существуют или уже находятся во входящих.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task UnarchiveFiles(IList<ulong> ids);

	/// <summary>
	///     Разархивирует файлы. Поддерживается только файловый домен "my files" или "trash".
	///     Возвращает файлы обратно в "inbox", удалив их из "archive". 
	///		Имеет значение только для файлов, которые в данный момент находятся в "my files" или "trash".
	///		Ошибки не выбрасываются, если файлы не существуют или уже находятся во входящих.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="request">Запрос с файлами.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task UnarchiveFiles(FilesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Генерирует хеши (SHA256), для файла, который находится на локальной машине с Hydrus.
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
	///     Генерирует хеши (SHA256), для файла, который находится на локальной машине с Hydrus.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="request">Запрос с файлами.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="GeneratedHashesResponse" /> с хешами (SHA256) файла.</returns>
	Task<GeneratedHashesResponse> GenerateHashes(LocalFileRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Генерирует хеши (SHA256), для файла из потока.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ImportDeleteFiles" />.
	/// </remarks>
	/// <param name="file">Поток с файлом.</param>
	/// <param name="progressCallback">Функция обратного вызова для отображения процесса отправки.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="GeneratedHashesResponse" /> с хешами (SHA256) файла.</returns>
	Task<GeneratedHashesResponse> GenerateHashes(Stream file, IProgress<int>? progressCallback = default, CancellationToken cancel = default);

	/// <summary>
	///     Производит поиск файлов по тегам.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="tags">Теги для поиска. Может содержать строковое значение или коллекцию с тегами.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="FilesSearchResponse" /> с идентификаторами файла.</returns>
	Task<FilesSearchResponse> SearchFiles(IList<object> tags, CancellationToken cancel = default);

	/// <summary>
	///     Производит поиск файлов по тегам.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="tags">Теги для поиска. Может содержать строковое значение или коллекцию с тегами.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="FilesSearchResponse" /> с идентификаторами файла.</returns>
	Task<FilesSearchResponse> SearchFiles(IList<string> tags, CancellationToken cancel = default);

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
	Task<FileHashesResponse> GetFileHashes(string hash, HashAlgorithmType desiredHashType, HashAlgorithmType sourceHashType = HashAlgorithmType.Sha256, CancellationToken cancel = default);

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
	Task<FileHashesResponse> GetFileHashes(IList<string> hashes, HashAlgorithmType desiredHashType, HashAlgorithmType sourceHashType = HashAlgorithmType.Sha256, CancellationToken cancel = default);

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
	Task<FileHashesResponse> GetFileHashes(FileHashesRequest request, CancellationToken cancel = default);

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
