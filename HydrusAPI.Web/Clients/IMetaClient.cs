namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для редактирования метаданных файла.
/// </summary>
public interface IMetaClient
{
	/// <summary>
	///     Устанавливает рейтинг файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRatings" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetRating(SetRatingRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Добавляет время в статистику просмотра.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> IncrementFileViewtime(ViewtimeRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает статичное время просмотра в статистике.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetFileViewtime(ViewtimeRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает время для файла.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetTime(SetTimeRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает заметки файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileNotes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="NotesResponse" /> с текущими заметками.</returns>
	Task<NotesResponse> SetNotes(SetNotesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Производит удаление заметок.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileNotes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteNotes(DeleteNotesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает метаданные по настроенному запросу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файла.</param>
	/// <param name="createNewFileIds">Создает физическую запись об хэше, который не был найден. По умолчанию - false.</param>
	/// <param name="detailedUrlInformation">Необязательно, вернуть детальную информацию об URL. Может быть очень тяжелым процессом. По умолчанию - false.</param>
	/// <param name="includeMilliseconds">Необязательно, включить в ответ миллисекунды. По умолчанию - false.</param>
	/// <param name="includeNotes">Необязательно, включить в ответ заметки. По умолчанию - false.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию <see cref="MetaData" /> с мета данными.</returns>
	Task<IEnumerable<MetaData>> GetMetaData(
		string hash,
		bool createNewFileIds = false,
		bool detailedUrlInformation = false,
		bool includeMilliseconds = false,
		bool includeNotes = false,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Запрашивает метаданные по настроенному запросу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <param name="createNewFileIds">Создает физическую запись об хэше, который не был найден. По умолчанию - false.</param>
	/// <param name="detailedUrlInformation">Необязательно, вернуть детальную информацию об URL. Может быть очень тяжелым процессом. По умолчанию - false.</param>
	/// <param name="includeMilliseconds">Необязательно, включить в ответ миллисекунды. По умолчанию - false.</param>
	/// <param name="includeNotes">Необязательно, включить в ответ заметки. По умолчанию - false.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию <see cref="MetaData" /> с мета данными.</returns>
	Task<IEnumerable<MetaData>> GetMetaData(
		IEnumerable<string> hashes,
		bool createNewFileIds = false,
		bool detailedUrlInformation = false,
		bool includeMilliseconds = false,
		bool includeNotes = false,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Запрашивает метаданные по настроенному запросу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="fileId">Идентификатор файла.</param>
	/// <param name="createNewFileIds">Создает физическую запись об хэше, который не был найден. По умолчанию - false.</param>
	/// <param name="detailedUrlInformation">Необязательно, вернуть детальную информацию об URL. Может быть очень тяжелым процессом. По умолчанию - false.</param>
	/// <param name="includeMilliseconds">Необязательно, включить в ответ миллисекунды. По умолчанию - false.</param>
	/// <param name="includeNotes">Необязательно, включить в ответ заметки. По умолчанию - false.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию <see cref="MetaData" /> с мета данными.</returns>
	Task<IEnumerable<MetaData>> GetMetaData(
		ulong fileId,
		bool createNewFileIds = false,
		bool detailedUrlInformation = false,
		bool includeMilliseconds = false,
		bool includeNotes = false,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Запрашивает метаданные по настроенному запросу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="fileIds">Идентификаторы файлов.</param>
	/// <param name="createNewFileIds">Создает физическую запись об хэше, который не был найден. По умолчанию - false.</param>
	/// <param name="detailedUrlInformation">Необязательно, вернуть детальную информацию об URL. Может быть очень тяжелым процессом. По умолчанию - false.</param>
	/// <param name="includeMilliseconds">Необязательно, включить в ответ миллисекунды. По умолчанию - false.</param>
	/// <param name="includeNotes">Необязательно, включить в ответ заметки. По умолчанию - false.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию <see cref="MetaData" /> с мета данными.</returns>
	Task<IEnumerable<MetaData>> GetMetaData(
		IEnumerable<ulong> fileIds,
		bool createNewFileIds = false,
		bool detailedUrlInformation = false,
		bool includeMilliseconds = false,
		bool includeNotes = false,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Запрашивает метаданные по настроенному запросу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="MetaDataResponse" /> с мета данными.</returns>
	Task<MetaDataResponse<MetaData>> GetMetaData(MetaDataRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает идентификатор файла.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию с идентификаторами.</returns>
	Task<IEnumerable<MetaDataId>> GetId(
		string hash,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Запрашивает идентификаторы файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию с идентификаторами.</returns>
	Task<IEnumerable<MetaDataId>> GetId(
		IEnumerable<string> hashes,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Запрашивает хэш (SHA256) файла.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="fileId">Идентификатор файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию с идентификаторами.</returns>
	Task<IEnumerable<MetaDataId>> GetHash(
		ulong fileId,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Запрашивает хэши (SHA256) файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="fileIds">Идентификаторы файлов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию с идентификаторами.</returns>
	Task<IEnumerable<MetaDataId>> GetHash(
		IEnumerable<ulong> fileIds,
		CancellationToken cancel = default
	);
	
	/// <summary>
	///     Запрашивает локальный путь к файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется области видимости (разрешения):
	///     <see cref="Permissions.SearchFetchFiles" />,
	///     <see cref="Permissions.SeeLocalPaths" />.
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="FilePathResponse" />.</returns>
	Task<FilePathResponse> GetFilePath(
		string hash,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Запрашивает локальный путь к эскизу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется области видимости (разрешения):
	///     <see cref="Permissions.SearchFetchFiles" />,
	///     <see cref="Permissions.SeeLocalPaths" />.
	/// </remarks>
	/// <param name="fileId">Идентификатор файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="FilePathResponse" />.</returns>
	Task<FilePathResponse> GetFilePath(
		ulong fileId,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Запрашивает локальный путь к эскизу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется области видимости (разрешения):
	///     <see cref="Permissions.SearchFetchFiles" />,
	///     <see cref="Permissions.SeeLocalPaths" />.
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файла.</param>
	/// <param name="includeThumbnailFiletype">Добавить в ответ тип файла. По умолчанию - false.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ThumbnailFilePathResponse" />.</returns>
	Task<ThumbnailFilePathResponse> GetThumbnailFilePath(
		string hash,
		bool includeThumbnailFiletype = false,
		CancellationToken cancel = default
	);

	/// <summary>
	///     Запрашивает локальный путь к файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется области видимости (разрешения):
	///     <see cref="Permissions.SearchFetchFiles" />,
	///     <see cref="Permissions.SeeLocalPaths" />.
	/// </remarks>
	/// <param name="fileId">Идентификатор файла.</param>
	/// <param name="includeThumbnailFiletype">Добавить в ответ тип файла. По умолчанию - false.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ThumbnailFilePathResponse" />.</returns>
	Task<ThumbnailFilePathResponse> GetThumbnailFilePath(
		ulong fileId,
		bool includeThumbnailFiletype = false,
		CancellationToken cancel = default
	);
}
