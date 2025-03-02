namespace HydrusAPI.Web;

/// <summary>
///     Результат импорта.
/// </summary>
public class ImportResultResponse : ApiVersionResponse
{
	/// <summary>
	///     Хэш (SHA256).
	/// </summary>
	public string Hash { get; set; } = default!;

	/// <summary>
	///     Статус импорта.
	/// </summary>
	public FileStatus Status { get; set; } = default!;

	/// <summary>
	///     Заметка.
	/// </summary>
	public string Note { get; set; } = default!;
}
