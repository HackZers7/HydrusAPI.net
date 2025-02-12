namespace HydrusAPI.Web;

/// <summary>
///     Представляет файлы Hydrus.
/// </summary>
public class FileRequest
{
	/// <summary>
	///     Хэш (SHA256) файла.
	/// </summary>
	public string? Hash { get; set; }

	/// <summary>
	///     Идентификатор файла.
	/// </summary>
	public ulong? FileId { get; set; }
}
