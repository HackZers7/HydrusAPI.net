namespace HydrusAPI.Web;

/// <summary>
/// Запрос присвоения куки.
/// </summary>
public class SetCookiesRequest
{
	/// <summary>
	/// Коллекция куки в формате [название, значение, домен, путь, истекает].
	/// </summary>
	public List<List<object?>> Cookies { get; set; } = new List<List<object?>>();
}
