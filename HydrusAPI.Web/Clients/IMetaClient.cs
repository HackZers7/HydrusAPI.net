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
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	/// <param name="rating">Рейтинг.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetRating(string hash, string ratingServiceKey, int? rating = null, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает рейтинг файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRatings" />.
	/// </remarks>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	/// <param name="rating">Рейтинг.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetRating(string hash, string ratingServiceKey, bool rating, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает рейтинг файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRatings" />.
	/// </remarks>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	/// <param name="rating">Рейтинг.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetRating(IList<string> hashes, string ratingServiceKey, int? rating = null, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает рейтинг файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRatings" />.
	/// </remarks>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	/// <param name="rating">Рейтинг.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetRating(IList<string> hashes, string ratingServiceKey, bool rating, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает рейтинг файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRatings" />.
	/// </remarks>
	/// <param name="id">Идентификатор файла.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	/// <param name="rating">Рейтинг.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetRating(ulong id, string ratingServiceKey, int? rating = null, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает рейтинг файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRatings" />.
	/// </remarks>
	/// <param name="id">Идентификатор файла.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	/// <param name="rating">Рейтинг.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetRating(ulong id, string ratingServiceKey, bool rating, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает рейтинг файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRatings" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	/// <param name="rating">Рейтинг.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetRating(IList<ulong> ids, string ratingServiceKey, int? rating = null, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает рейтинг файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRatings" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	/// <param name="rating">Рейтинг.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetRating(IList<ulong> ids, string ratingServiceKey, bool rating, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает рейтинг файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRatings" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetRating(SetRatingRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Добавляет время в статистику просмотра.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <param name="type">Тип холста.</param>
	/// <param name="viewTime">Как долго пользователь просматривал файл. Unix-формат.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task IncrementFileViewTime(string hash, CanvasTypes type, double viewTime, CancellationToken cancel = default);

	/// <summary>
	///     Добавляет время в статистику просмотра.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	/// <param name="type">Тип холста.</param>
	/// <param name="viewTime">Как долго пользователь просматривал файл. Unix-формат.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task IncrementFileViewTime(IList<string>? hashes, CanvasTypes type, double viewTime, CancellationToken cancel = default);

	/// <summary>
	///     Добавляет время в статистику просмотра.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="id">Идентификатор файла.</param>
	/// <param name="type">Тип холста.</param>
	/// <param name="viewTime">Как долго пользователь просматривал файл. Unix-формат.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task IncrementFileViewTime(ulong id, CanvasTypes type, double viewTime, CancellationToken cancel = default);

	/// <summary>
	///     Добавляет время в статистику просмотра.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="fileIds">Коллекция идентификаторов файлов.</param>
	/// <param name="type">Тип холста.</param>
	/// <param name="viewTime">Как долго пользователь просматривал файл. Unix-формат.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task IncrementFileViewTime(IList<ulong>? fileIds, CanvasTypes type, double viewTime, CancellationToken cancel = default);

	/// <summary>
	///     Добавляет время в статистику просмотра.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task IncrementFileViewTime(ViewTimeRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает статичное время просмотра в статистике.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <param name="type">Тип холста.</param>
	/// <param name="viewTime">Как долго пользователь просматривал файл. Unix-формат.</param>
	/// <param name="views">Необязательно, количество добавляемых просмотров. По умолчанию - 1.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetFileViewTime(string hash, CanvasTypes type, double viewTime, int views = 1, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает статичное время просмотра в статистике.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	/// <param name="type">Тип холста.</param>
	/// <param name="viewTime">Как долго пользователь просматривал файл. Unix-формат.</param>
	/// <param name="views">Необязательно, количество добавляемых просмотров. По умолчанию - 1.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetFileViewTime(IList<string>? hashes, CanvasTypes type, double viewTime, int views = 1, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает статичное время просмотра в статистике.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="id">Идентификатор файла.</param>
	/// <param name="type">Тип холста.</param>
	/// <param name="viewTime">Как долго пользователь просматривал файл. Unix-формат.</param>
	/// <param name="views">Необязательно, количество добавляемых просмотров. По умолчанию - 1.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetFileViewTime(ulong id, CanvasTypes type, double viewTime, int views = 1, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает статичное время просмотра в статистике.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="fileIds">Коллекция идентификаторов файлов.</param>
	/// <param name="type">Тип холста.</param>
	/// <param name="viewTime">Как долго пользователь просматривал файл. Unix-формат.</param>
	/// <param name="views">Необязательно, количество добавляемых просмотров. По умолчанию - 1.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetFileViewTime(IList<ulong>? fileIds, CanvasTypes type, double viewTime, int views = 1, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает статичное время просмотра в статистике.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetFileViewTime(ViewTimeRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает время для файла.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetTime(SetTimeRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает заметки файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileNotes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="SetNotesResponse" /> с текущими заметками.</returns>
	Task<SetNotesResponse> SetNotes(SetNotesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Производит удаление заметок.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileNotes" />.
	/// </remarks>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <param name="names">Коллекция наименований заметок.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task DeleteNotes(string hash, IList<string> names, CancellationToken cancel = default);

	/// <summary>
	///     Производит удаление заметок.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileNotes" />.
	/// </remarks>
	/// <param name="id">Идентификатор файла.</param>
	/// <param name="names">Коллекция наименований заметок.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task DeleteNotes(ulong id, IList<string> names, CancellationToken cancel = default);

	/// <summary>
	///     Производит удаление заметок.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileNotes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task DeleteNotes(DeleteNotesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает метаданные по настроенному запросу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файла.</param>
	/// <param name="createNewFileIds">Создает физическую запись об хеше, который не был найден. По умолчанию - false.</param>
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
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	/// <param name="createNewFileIds">Создает физическую запись об хеше, который не был найден. По умолчанию - false.</param>
	/// <param name="detailedUrlInformation">Необязательно, вернуть детальную информацию об URL. Может быть очень тяжелым процессом. По умолчанию - false.</param>
	/// <param name="includeMilliseconds">Необязательно, включить в ответ миллисекунды. По умолчанию - false.</param>
	/// <param name="includeNotes">Необязательно, включить в ответ заметки. По умолчанию - false.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию <see cref="MetaData" /> с мета данными.</returns>
	Task<IEnumerable<MetaData>> GetMetaData(
		IList<string> hashes,
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
	/// <param name="createNewFileIds">Создает физическую запись об хеше, который не был найден. По умолчанию - false.</param>
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
	/// <param name="createNewFileIds">Создает физическую запись об хеше, который не был найден. По умолчанию - false.</param>
	/// <param name="detailedUrlInformation">Необязательно, вернуть детальную информацию об URL. Может быть очень тяжелым процессом. По умолчанию - false.</param>
	/// <param name="includeMilliseconds">Необязательно, включить в ответ миллисекунды. По умолчанию - false.</param>
	/// <param name="includeNotes">Необязательно, включить в ответ заметки. По умолчанию - false.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию <see cref="MetaData" /> с мета данными.</returns>
	Task<IEnumerable<MetaData>> GetMetaData(
		IList<ulong> fileIds,
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
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию с идентификаторами.</returns>
	Task<IEnumerable<MetaDataId>> GetId(
		IList<string> hashes,
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
	///     Запрашивает хеши (SHA256) файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="fileIds">Идентификаторы файлов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию с идентификаторами.</returns>
	Task<IEnumerable<MetaDataId>> GetHash(
		IList<ulong> fileIds,
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

	/// <summary>
	///     Запрашивает локальные хранилища.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется области видимости (разрешения):
	///     <see cref="Permissions.SearchFetchFiles" />,
	///     <see cref="Permissions.SeeLocalPaths" />.
	/// </remarks>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекция с хранилищами.</returns>
	Task<IEnumerable<StorageLocation>> GetLocalFileStorageLocations(
		CancellationToken cancel = default
	);
}
