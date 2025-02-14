namespace HydrusAPI.Web;

/// <summary>
///     Ответ в виде словаря хэшей.
/// </summary>
public class FileHashesResponse
{
	/// <summary>
	///     Хэши.
	/// </summary>
	public Dictionary<string, string> Hashes { get; set; } = default!;
}
