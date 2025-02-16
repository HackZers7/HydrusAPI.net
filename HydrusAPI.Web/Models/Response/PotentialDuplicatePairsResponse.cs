namespace HydrusAPI.Web;

/// <summary>
///     Ответ с потенциальными парами дубликатов.
/// </summary>
public class PotentialDuplicatePairsResponse : ApiVersion
{
	/// <summary>
	///     Потенциальные пары дубликатов.
	/// </summary>
	public List<List<string>>? PotentialDuplicatePairs { get; set; }
}
