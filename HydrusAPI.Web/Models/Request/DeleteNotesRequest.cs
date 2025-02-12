namespace HydrusAPI.Web;

/// <summary>
///     Запрос на удаление заметки.
/// </summary>
public class DeleteNotesRequest : FileRequest
{
	/// <summary>
	///     Коллекция заметок.
	/// </summary>
	public List<string> NotesNames { get; } = new();
}
