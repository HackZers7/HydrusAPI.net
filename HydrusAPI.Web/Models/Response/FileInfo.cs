namespace HydrusAPI.Web;

/// <summary>
///     Информация о файле.
/// </summary>
public class FileInfo
{
	/// <summary>
	///     Статус файла.
	/// </summary>
	public FileStatus Status { get; set; } = default!;

	/// <summary>
	///     Заметка.
	/// </summary>
	public string Note { get; set; } = default!;

	/// <summary>
	///     Хэш (SHA256).
	/// </summary>
	public string Hash { get; set; } = default!;
}
