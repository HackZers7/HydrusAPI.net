namespace HydrusAPI.Web;

/// <summary>
///     Запрос на установку заметки.
/// </summary>
public class SetNotesRequest : Files
{
	// TODO: Переделать на билдер

	/// <summary>
	///     Заметки.
	/// </summary>
	public Dictionary<string, string> Notes { get; } = new();

	/// <summary>
	///     Умное слияние.
	///     <remarks>
	///         По умолчанию - false.
	///     </remarks>
	/// </summary>
	public bool MergeCleverly { get; set; } = false;

	/// <summary>
	///     Расширить существующую заметку, если возможно.
	///     <remarks>
	///         По умолчанию - false.
	///     </remarks>
	/// </summary>
	public bool ExtendExistingNoteIfPossible { get; set; } = true;

	/// <summary>
	///     Как разрешать конфликты с существующей заметкой.
	///     <remarks>
	///         По умолчанию - <see cref="HydrusAPI.Web.СonflictResolutionType.Rename" />
	///         Для более удобной установки значения рекомендуется использовать <see cref="HydrusAPI.Web.СonflictResolutionType" />.
	///     </remarks>
	/// </summary>
	public int ConflictResolution { get; set; } = (int)СonflictResolutionType.Rename;
}
