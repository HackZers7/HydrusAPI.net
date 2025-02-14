namespace HydrusAPI.Web;

/// <summary>
///     Возвращает найденные файлы.
/// </summary>
public class FilesSearchResponse : ApiVersion
{
	/// <summary>
	///     Коллекция хэшей (SHA256) файлов.
	/// </summary>
	public List<string>? Hashes { get; set; }

	/// <summary>
	///     Коллекция идентификаторов файлов.
	/// </summary>
	public List<ulong>? FileIds { get; set; }
}
