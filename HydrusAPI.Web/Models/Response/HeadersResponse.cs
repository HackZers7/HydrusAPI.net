namespace HydrusAPI.Web;

/// <summary>
///     Ответ с заголовками.
/// </summary>
public class HeadersResponse : ApiVersion
{
	public NetworkContext NetworkContext { get; set; }

	/// <summary>
	///     Словарь с заголовками.
	/// </summary>
	public Dictionary<string, Header>? Headers { get; set; }
}

public class NetworkContext
{
	public int Type { get; set; }
	public string Data { get; set; }
}

/// <summary>
///     Заголовок.
/// </summary>
public class Header
{
	/// <summary>
	///     Значение.
	/// </summary>
	public string? Value { get; set; }
	public string? Approved { get; set; }
	public string? Reason { get; set; }
}
