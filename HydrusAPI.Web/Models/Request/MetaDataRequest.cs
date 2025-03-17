
namespace HydrusAPI.Web;

/// <summary>
///     Запрос мета данных файла.
/// </summary>
public class MetaDataRequest : FilesRequest
{
    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="hash">Хеш (SHA256) файла.</param>
    public MetaDataRequest(string hash) : base(hash)
    {
    }

    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    public MetaDataRequest(ulong id) : base(id)
    {
    }

    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
    public MetaDataRequest(IList<string>? hashes) : base(hashes)
    {
    }

    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="fileIds">Коллекция идентификаторов файлов.</param>
    public MetaDataRequest(IList<ulong>? fileIds) : base(fileIds)
    {
    }

    /// <summary>
    ///     Создает физическую запись об хеше, который не был найден.
    /// </summary>
    /// <remarks>
    ///     По умолчанию - false.
    /// </remarks>
    public bool CreateNewFileIds { get; set; } = false;

    /// <summary>
    ///     Необязательно, вернуть только идентификаторы.
    /// </summary>
    /// <remarks>
    ///     По умолчанию - false.
    /// </remarks>
    public bool OnlyReturnIdentifiers { get; set; } = false;

    /// <summary>
    ///     Необязательно, вернуть только базовую информацию.
    /// </summary>
    /// <remarks>
    ///     По умолчанию - false.
    /// </remarks>
    public bool OnlyReturnBasicInformation { get; set; } = false;

    /// <summary>
    ///     Необязательно, вернуть детальную информацию об URL. Может быть очень тяжелым процессом.
    /// </summary>
    /// <remarks>
    ///     По умолчанию - false.
    /// </remarks>
    public bool DetailedUrlInformation { get; set; } = false;

    /// <summary>
    ///     Необязательно, включить в ответ Blur Hash. Работает только если <see cref="OnlyReturnBasicInformation" /> - true.
    /// </summary>
    /// <remarks>
    ///     По умолчанию - false.
    /// </remarks>
    public bool IncludeBlurHash { get; set; } = false;

    /// <summary>
    ///     Необязательно, включить в ответ миллисекунды.
    /// </summary>
    /// <remarks>
    ///     По умолчанию - false.
    /// </remarks>
    public bool IncludeMilliseconds { get; set; } = false;

    /// <summary>
    ///     Необязательно, включить в ответ заметки.
    /// </summary>
    /// <remarks>
    ///     По умолчанию - false.
    /// </remarks>
    public bool IncludeNotes { get; set; } = false;

    /// <summary>
    ///     Необязательно, включить в ответ сервисы.
    /// </summary>
    /// <remarks>
    ///     По умолчанию - true.
    /// </remarks>
    public bool IncludeServicesObject { get; set; } = true;

    /// <summary>
    ///     Необязательно, скрыть сервисные теги. Упразднено, скоро будет убрано.
    /// </summary>
    /// <remarks>
    ///     По умолчанию - true.
    /// </remarks>
    [Obsolete("Устарел, скоро будет удален!")]
    public bool HideServiceKeysTags { get; set; } = true;
}
