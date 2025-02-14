namespace HydrusAPI.Web;

/// <summary>
///     Ответ в виде хэша.
/// </summary>
public class HashResponse : ApiVersion
{
	/// <summary>
	///     Хэш (SHA256).
	/// </summary>
	public string Hash { get; set; } = default!;
}

/// <summary>
///     Ответ в виде коллекции хэшей.
/// </summary>
public class HashesResponse : ApiVersion
{
	/// <summary>
	///     Хэш.
	/// </summary>
	public List<string> Hashes { get; set; } = default!;
}
