namespace HydrusAPI.Web;

/// <summary>
///     Тег.
/// </summary>
public class Tag
{
	/// <summary>
	///     Обычное отображение тега.
	/// </summary>
	public string IdealTag { get; set; } = default!;

	/// <summary>
	///     Коллекция тегов, которые будут отображаться как <see cref="IdealTag" />, в том числе сам <see cref="IdealTag" />.
	/// </summary>
	public List<string> Siblings { get; set; } = default!;

	/// <summary>
	///     Коллекция дочерних тегов (в том числе внучек и правнучек).
	/// </summary>
	public List<string> Descendants { get; set; } = default!;

	/// <summary>
	///     Коллекция родителей (в том числе прародителей, бабушек и прабабушек).
	/// </summary>
	public List<string> Ancestors { get; set; } = default!;
}
