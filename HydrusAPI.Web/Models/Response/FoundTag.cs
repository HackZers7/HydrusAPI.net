namespace HydrusAPI.Web;

/// <summary>
///     Найденный тег.
/// </summary>
public class FoundTag
{
	/// <summary>
	///     Найденный тег.
	/// </summary>
	public string Value { get; set; } = default!;

	/// <summary>
	///     Количество использований.
	/// </summary>
	public int Count { get; set; } = 0;
}
