namespace HydrusAPI.Web;

/// <summary>
///     Потенциальное количество дубликатов.
/// </summary>
public class PotentialDuplicatesCountResponse : ApiVersion
{
	/// <summary>
	///     Потенциальное количество дубликатов.
	/// </summary>
	public int PotentialDuplicatesCount { get; set; }
}
