namespace HydrusAPI.Web;

/// <summary>
///     Запрос на установку заметки.
/// </summary>
public class SetNotesRequest : FileRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	public SetNotesRequest(string hash) : base(hash)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	public SetNotesRequest(ulong id) : base(id)
	{
	}

	/// <summary>
	///     Словарь с заметками, где ключом является название заметки, а значение - заметка.
	/// </summary>
	public IDictionary<string, string> Notes { get; set; } = new Dictionary<string, string>();

	/// <summary>
	///     Умное слияние.
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - false.
	/// </remarks>
	public bool MergeCleverly { get; set; } = false;

	/// <summary>
	///     Расширить существующую заметку, если возможно.
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - false.
	/// </remarks>
	public bool ExtendExistingNoteIfPossible { get; set; } = true;

	/// <summary>
	///     Как разрешать конфликты с существующей заметкой.
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - <see cref="ConflictResolutionType.Rename" />
	/// </remarks>
	public ConflictResolutionType ConflictResolution { get; set; } = ConflictResolutionType.Rename;
}
