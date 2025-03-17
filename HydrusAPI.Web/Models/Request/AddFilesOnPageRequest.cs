
namespace HydrusAPI.Web;

/// <summary>
///     Запрос добавления файлов на страницу.
/// </summary>
public class AddFilesOnPageRequest : FilesRequest
{
    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="pageKey">Уникальный ключ страницы.</param>
    /// <param name="hash">Хеш (SHA256) файла.</param>
    public AddFilesOnPageRequest(string pageKey, string hash) : base(hash)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(pageKey);

        PageKey = pageKey;
    }

    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="pageKey">Уникальный ключ страницы.</param>
    /// <param name="id">Идентификатор файла.</param>
    public AddFilesOnPageRequest(string pageKey, ulong id) : base(id)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(pageKey);

        PageKey = pageKey;
    }

    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="pageKey">Уникальный ключ страницы.</param>
    /// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
    public AddFilesOnPageRequest(string pageKey, IList<string>? hashes) : base(hashes)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(pageKey);

        PageKey = pageKey;
    }

    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="pageKey">Уникальный ключ страницы.</param>
    /// <param name="fileIds">Коллекция идентификаторов файлов.</param>
    public AddFilesOnPageRequest(string pageKey, IList<ulong>? fileIds) : base(fileIds)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(pageKey);

        PageKey = pageKey;
    }

    /// <summary>
    ///     Уникальный ключ страницы.
    /// </summary>
    public string PageKey { get; set; } = default!;
}
