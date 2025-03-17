
namespace HydrusAPI.Web;

/// <summary>
/// Запрос получения статистики.
/// </summary>
public class BonesRequest : FilesWithDomainRequest
{
    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="hash">Хеш (SHA256) файла.</param>
    public BonesRequest(string hash) : base(hash)
    {
    }

    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    public BonesRequest(ulong id) : base(id)
    {
    }

    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
    public BonesRequest(IList<string>? hashes) : base(hashes)
    {
    }

    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="fileIds">Коллекция идентификаторов файлов.</param>
    public BonesRequest(IList<ulong>? fileIds) : base(fileIds)
    {
    }

    /// <summary>
    /// 	Необязательно, шестнадцатеричный ключ домена тегов.
    /// </summary>
    public string? TagServiceKey { get; set; }
}
