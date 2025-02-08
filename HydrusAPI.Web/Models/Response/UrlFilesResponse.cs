namespace HydrusAPI.Web;

/// <summary>
///     Файлы привязанные к указанной URL.
/// </summary>
public class UrlFilesResponse : ApiVersion
{
	/// <summary>
	///     Норма-лизированная URL.
	/// </summary>
	public Uri NormalisedUrl { get; set; } = default!;

	/// <summary>
	///     Статус привязанных файлов.
	/// </summary>
	public List<FileInfo> UrlFileStatuses { get; set; } = new();
}
