namespace HydrusAPI.Web.Models.Response;

/// <summary>
/// Ответ с куки Hydrus.
/// </summary>
public class CookiesResponse : ApiVersion
{
	/// <summary>
	/// Коллекция куки в формате [название, значение, домен, путь, истекает].
	/// </summary>
	public List<List<object?>> Cookies { get; set; } = default!;
}
