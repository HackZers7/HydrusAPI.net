namespace HydrusAPI.Web;

/// <summary>
///     Теги.
/// </summary>
public class TagsResponse : ApiVersionResponse
{
	/// <summary>
	///     Коллекция тегов.
	/// </summary>
	public List<string> Tags { get; set; } = new();
}
