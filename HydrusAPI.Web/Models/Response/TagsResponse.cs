namespace HydrusAPI.Web;

/// <summary>
///     Теги.
/// </summary>
public class TagsResponse : ApiVersion
{
	/// <summary>
	///     Коллекция тегов.
	/// </summary>
	public List<string> Tags { get; set; } = new();
}
