namespace HydrusAPI.Web;

/// <summary>
///     Ответ в виде словаря хешей.
/// </summary>
public class FileHashesResponse : ApiVersionResponse
{
	/// <summary>
	///     Хеши, где ключ - идентификатор.
	/// </summary>
	public Dictionary<string, string> Hashes { get; set; } = default!;
}
