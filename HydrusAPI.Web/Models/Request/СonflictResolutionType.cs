namespace HydrusAPI.Web;

/// <summary>
///     Типы разрешения конфликтов.
/// </summary>
public enum СonflictResolutionType
{
	/// <summary>
	///     Overwrite the existing conflicting note.
	/// </summary>
	Replace = 0,

	/// <summary>
	///     Make no changes.
	/// </summary>
	Ignore = 1,

	/// <summary>
	///     Append the new text to the existing text.
	/// </summary>
	Append = 2,

	/// <summary>
	///     Add the new text under a 'name (x)'-style rename.
	/// </summary>
	Rename = 3
}
