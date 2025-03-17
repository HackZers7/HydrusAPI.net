namespace HydrusAPI.Web;

/// <summary>
///     Возвращает найденные файлы.
/// </summary>
public class FilesSearchResponse : ApiVersionResponse
{
    /// <summary>
    ///     Коллекция хешей (SHA256) файлов.
    /// </summary>
    public List<string> Hashes { get; set; } = new List<string>();

    /// <summary>
    ///     Коллекция идентификаторов файлов.
    /// </summary>
    public List<ulong> FileIds { get; set; } = new List<ulong>();
}
