namespace HydrusAPI.Web;

/// <summary>
///     Поиск тегов.
/// </summary>
public class TagsSearchResponse : ApiVersionResponse
{
	/// <summary>
	///     Теги.
	/// </summary>
	public List<FoundTag> Tags { get; set; } = new();
}
