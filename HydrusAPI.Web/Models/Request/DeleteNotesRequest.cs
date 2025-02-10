namespace HydrusAPI.Web;

/// <summary>
///     Запрос на удаление заметки.
/// </summary>
public class DeleteNotesRequest : Files
{
	// TODO: Переделать на билдер

	/// <summary>
	///     Заметки.
	/// </summary>
	public List<string> NotesNames { get; } = new();
}
