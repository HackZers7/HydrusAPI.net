namespace HydrusAPI.Web;

/// <summary>
///     Ответ в виде словаря хешей.
/// </summary>
public class FileHashesResponse : ApiVersion
{
	/// <summary>
	///     Хеши.
	/// </summary>
	public Dictionary<string, string> Hashes { get; set; } = default!;
}
