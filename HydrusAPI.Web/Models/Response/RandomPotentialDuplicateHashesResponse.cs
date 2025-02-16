namespace HydrusAPI.Web;

/// <summary>
///     Ответ со случайными потенциальными парами дубликатов.
/// </summary>
public class RandomPotentialDuplicateHashesResponse : ApiVersion
{
	/// <summary>
	///     Случайные потенциальные пары дубликатов.
	/// </summary>
	public List<string> RandomPotentialDuplicateHashes { get; set; } = new();
}
