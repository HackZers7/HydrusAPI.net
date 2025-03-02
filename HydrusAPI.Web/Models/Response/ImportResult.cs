namespace HydrusAPI.Web;

/// <summary>
///     Результат импорта.
/// </summary>
public class ImportResultResponse : HashResponse
{
	/// <summary>
	///     Статус импорта.
	/// </summary>
	public FileStatus Status { get; set; } = default!;

	/// <summary>
	///     Заметка.
	/// </summary>
	public string Note { get; set; } = default!;
}
