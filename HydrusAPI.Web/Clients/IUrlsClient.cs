namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы с url.
/// </summary>
public interface IUrlsClient
{
    /// <summary>
    ///     Производит поиск статусов файлов по URL.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="url">URL.</param>
    /// <param name="doubleCheckFileSystem">
    ///     Если true – то любой результат, который <see cref="FileStatus.AlreadyExists" /> (2), будет дважды сверен с фактической файловой системой.
    ///     Эта проверка выполняется в любом обычном процессе импорта файлов, для проверки и исправления отсутствующих файлов (если файл отсутствует, статус становится <see cref="FileStatus.FileNotExists" /> (0)).
    /// </param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="UrlFilesResponse" /> с информацией об привязанных к URL файлах.</returns>
    Task<UrlFilesResponse> GetUrlFiles(string url, bool doubleCheckFileSystem = false, CancellationToken cancel = default);

    /// <summary>
    ///     Производит поиск статусов файлов по URL.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="url">URL.</param>
    /// <param name="doubleCheckFileSystem">
    ///     Если true – то любой результат, который <see cref="FileStatus.AlreadyExists" /> (2), будет дважды сверен с фактической файловой системой.
    ///     Эта проверка выполняется в любом обычном процессе импорта файлов, для проверки и исправления отсутствующих файлов (если файл отсутствует, статус становится <see cref="FileStatus.FileNotExists" /> (0)).
    /// </param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="UrlFilesResponse" /> с информацией об привязанных к URL файлах.</returns>
    Task<UrlFilesResponse> GetUrlFiles(Uri url, bool doubleCheckFileSystem = false, CancellationToken cancel = default);

    /// <summary>
    ///     Производит поиск статусов файлов по URL.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="request">Запрос.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="UrlFilesResponse" /> с информацией об привязанных к URL файлах.</returns>
    Task<UrlFilesResponse> GetUrlFiles(GetUrlFilesRequest request, CancellationToken cancel = default);

    /// <summary>
    ///     Запрашивает информацию об URL.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="url">URl.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="UrlInfoResponse" /> с информацией об URL.</returns>
    Task<UrlInfoResponse> GetUrlInfo(string url, CancellationToken cancel = default);

    /// <summary>
    ///     Запрашивает информацию об URL.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="url">URl.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="UrlInfoResponse" /> с информацией об URL.</returns>
    Task<UrlInfoResponse> GetUrlInfo(Uri url, CancellationToken cancel = default);

    /// <summary>
    ///     Производит импорт файла или файлов по URL.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="url">URL с файлом или файлами для импорта.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="ImportUrlResult" /> с результатом импорта.</returns>
    Task<ImportUrlResult> ImportFromUrl(string url, CancellationToken cancel = default);

    /// <summary>
    ///     Производит импорт файла или файлов по URL.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="url">URL с файлом или файлами для импорта.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="ImportUrlResult" /> с результатом импорта.</returns>
    Task<ImportUrlResult> ImportFromUrl(Uri url, CancellationToken cancel = default);

    /// <summary>
    ///     Производит импорт файла или файлов по URL.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="request">Запрос импорта.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="ImportUrlResult" /> с результатом импорта.</returns>
    Task<ImportUrlResult> ImportFromUrl(ImportFromUrlRequest request, CancellationToken cancel = default);

    /// <summary>
    ///     Добавляет новые URL для файла по его хешу (SHA256).
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="hash">Хэш (SHA256) файла к которому нужно добавить ссылки.</param>
    /// <param name="url">Ссылка для добавления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task AddUrlToFile(string hash, string url, CancellationToken cancel = default);

    /// <summary>
    ///     Добавляет новые URL для файла по его хешу (SHA256).
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="hash">Хэш (SHA256) файла к которому нужно добавить ссылки.</param>
    /// <param name="url">Ссылка для добавления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task AddUrlToFile(string hash, Uri url, CancellationToken cancel = default);

    /// <summary>
    ///     Добавляет новые URL для файла по его хешу (SHA256).
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="hash">Хэш (SHA256) файла к которому нужно добавить ссылки.</param>
    /// <param name="urls">Ссылки для добавления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task AddUrlToFile(string hash, IList<string> urls, CancellationToken cancel = default);

    /// <summary>
    ///     Добавляет новые URL для файла по его хешу (SHA256).
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="hash">Хэш (SHA256) файла к которому нужно добавить ссылки.</param>
    /// <param name="urls">Ссылки для добавления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task AddUrlToFile(string hash, IList<Uri> urls, CancellationToken cancel = default);

    /// <summary>
    ///     Добавляет новые URL для файла по его идентификатору.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="id">Идентификатор файла к которому нужно добавить ссылки.</param>
    /// <param name="url">Ссылка для добавления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task AddUrlToFile(ulong id, string url, CancellationToken cancel = default);

    /// <summary>
    ///     Добавляет новые URL для файла по его идентификатору.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="id">Идентификатор файла к которому нужно добавить ссылки.</param>
    /// <param name="url">Ссылка для добавления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task AddUrlToFile(ulong id, Uri url, CancellationToken cancel = default);

    /// <summary>
    ///     Добавляет новые URL для файла по его идентификатору.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="id">Идентификатор файла к которому нужно добавить ссылки.</param>
    /// <param name="urls">Ссылки для добавления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task AddUrlToFile(ulong id, IList<string> urls, CancellationToken cancel = default);

    /// <summary>
    ///     Добавляет новые URL для файла по его идентификатору.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="id">Идентификатор файла к которому нужно добавить ссылки.</param>
    /// <param name="urls">Ссылки для добавления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task AddUrlToFile(ulong id, IList<Uri> urls, CancellationToken cancel = default);

    /// <summary>
    ///     Удаляет URL из файла по его хешу (SHA256).
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="hash">Хэш (SHA256) файла к которому нужно добавить ссылки.</param>
    /// <param name="url">Ссылка для удаления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task RemoveUrlFromFile(string hash, string url, CancellationToken cancel = default);

    /// <summary>
    ///     Удаляет URL из файла по его хешу (SHA256).
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="hash">Хэш (SHA256) файла к которому нужно добавить ссылки.</param>
    /// <param name="url">Ссылка для удаления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task RemoveUrlFromFile(string hash, Uri url, CancellationToken cancel = default);

    /// <summary>
    ///     Удаляет URL из файла по его хешу (SHA256).
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="hash">Хэш (SHA256) файла к которому нужно добавить ссылки.</param>
    /// <param name="urls">Ссылки для удаления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task RemoveUrlFromFile(string hash, IList<string> urls, CancellationToken cancel = default);

    /// <summary>
    ///     Удаляет URL из файла по его хешу (SHA256).
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="hash">Хэш (SHA256) файла к которому нужно добавить ссылки.</param>
    /// <param name="urls">Ссылки для удаления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task RemoveUrlFromFile(string hash, IList<Uri> urls, CancellationToken cancel = default);

    /// <summary>
    ///     Удаляет URL из файла по его идентификатору.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="id">Идентификатор файла к которому нужно добавить ссылки.</param>
    /// <param name="url">Ссылка для удаления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task RemoveUrlFromFile(ulong id, string url, CancellationToken cancel = default);

    /// <summary>
    ///     Удаляет URL из файла по его идентификатору.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="id">Идентификатор файла к которому нужно добавить ссылки.</param>
    /// <param name="url">Ссылка для удаления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task RemoveUrlFromFile(ulong id, Uri url, CancellationToken cancel = default);

    /// <summary>
    ///     Удаляет URL из файла по его идентификатору.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="id">Идентификатор файла к которому нужно добавить ссылки.</param>
    /// <param name="urls">Ссылки для удаления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task RemoveUrlFromFile(ulong id, IList<string> urls, CancellationToken cancel = default);

    /// <summary>
    ///     Удаляет URL из файла по его идентификатору.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="id">Идентификатор файла к которому нужно добавить ссылки.</param>
    /// <param name="urls">Ссылки для удаления.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="Task"/>.</returns>
    Task RemoveUrlFromFile(ulong id, IList<Uri> urls, CancellationToken cancel = default);

    /// <summary>
    ///     Производит ассоциацию или диссоциацию URL с файлом.
    /// </summary>
    /// <remarks>
    ///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
    ///     <see cref="Permissions.ImportEditUrls" />.
    /// </remarks>
    /// <param name="request">Запрос.</param>
    /// <param name="cancel">Токен отмены запроса.</param>
    /// <returns>Возвращает <see cref="ImportUrlResult" /> с результатом импорта.</returns>
    Task AssociateUrl(AssociateUrlRequest request, CancellationToken cancel = default);
}
