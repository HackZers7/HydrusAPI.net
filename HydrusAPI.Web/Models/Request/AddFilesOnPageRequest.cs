namespace HydrusAPI.Web;

/// <summary>
///     Запрос добавления файлов на страницу.
/// </summary>
public class AddFilesOnPageRequest : FilesRequest
{
	/// <summary>
	///     Уникальный ключ страницы.
	/// </summary>
	public string PageKey { get; set; } = default!;
}
