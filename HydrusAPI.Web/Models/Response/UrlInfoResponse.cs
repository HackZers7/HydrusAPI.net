namespace HydrusAPI.Web;

/// <summary>
///     Информация об URL.
/// </summary>
public class UrlInfoResponse : ApiVersion
{
	/// <summary>
	///     URL для запроса.
	/// </summary>
	public Uri RequestUrl { get; set; } = default!;

	/// <summary>
	///     Норма-лизированная URL.
	/// </summary>
	public Uri NormalisedUrl { get; set; } = default!;

	/// <summary>
	///     Тип URL.
	/// </summary>
	public UrlType UrlType { get; set; } = default!;

	/// <summary>
	///     Тип URL строкой.
	/// </summary>
	public string UrlTypeString { get; set; } = default!;

	/// <summary>
	///     Название совпавшего типа.
	/// </summary>
	public string? MatchName { get; set; }

	/// <summary>
	///     Можно спарсить.
	/// </summary>
	public bool CanParse { get; set; }
}
