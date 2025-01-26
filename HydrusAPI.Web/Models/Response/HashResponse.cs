namespace HydrusAPI.Web;

/// <summary>
///     Ответ в виде хэша.
/// </summary>
public class HashResponse : ApiVersion
{
	/// <summary>
	///     Хэш.
	/// </summary>
	public string Hash { get; set; } = default!;
}
