namespace HydrusAPI.Web;

/// <summary>
///     Запрос присвоения заголовков.
/// </summary>
public class SetHeadersRequest
{
	/// <summary>
	///     Необаятельно, домен. Если null, то подразумеваются глобальные заголовки.
	/// </summary>
	public string? Domain { get; set; }

	/// <summary>
	///     Заголовки.
	/// </summary>
	public Dictionary<string, Header> Headers { get; set; } = new Dictionary<string, Header>();
}
