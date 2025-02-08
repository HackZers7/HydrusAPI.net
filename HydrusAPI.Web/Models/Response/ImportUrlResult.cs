namespace HydrusAPI.Web;

/// <summary>
///     Результат импорта URL.
/// </summary>
public class ImportUrlResult : ApiVersion
{
	/// <summary>
	///     Текстовый результат импорта.
	/// </summary>
	public string HumanResultText { get; set; } = default!;

	/// <summary>
	///     Норма-лизированная URL.
	/// </summary>
	public Uri NormalisedUrl { get; set; } = default!;
}
