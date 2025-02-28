namespace HydrusAPI.Web;

/// <summary>
///     Ответ в виде хеша.
/// </summary>
public class HashResponse : ApiVersionResponse
{
	/// <summary>
	///     Хэш (SHA256).
	/// </summary>
	public string Hash { get; set; } = default!;
}

/// <summary>
///     Ответ в виде коллекции хешей.
/// </summary>
public class HashesResponse : ApiVersionResponse
{
	/// <summary>
	///     Хэш.
	/// </summary>
	public List<string> Hashes { get; set; } = default!;
}
