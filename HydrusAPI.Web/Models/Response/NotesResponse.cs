namespace HydrusAPI.Web;

/// <summary>
///     Ответ с заметками.
/// </summary>
public class NotesResponse : ApiVersion
{
	/// <summary>
	///     Словарь с заметками, где ключ название заметки.
	/// </summary>
	public Dictionary<string, string> Notes { get; set; } = default!;

	/// <summary>
	///     Хэш файла.
	/// </summary>
	public string Hash { get; set; } = default!;
}
