namespace HydrusAPI.Web;

/// <summary>
///     Поиск тегов.
/// </summary>
public class TagsSearchResponse : ApiVersion
{
	/// <summary>
	///     Теги.
	/// </summary>
	public List<FoundTag> Tags { get; set; } = new();
}
