namespace HydrusAPI.Web;

/// <summary>
///     Тип Url.
/// </summary>
public enum UrlType
{
	/// <summary>
	///     Post URL
	/// </summary>
	Post = 0,

	/// <summary>
	///     File URL
	/// </summary>
	File = 2,

	/// <summary>
	///     Gallery URL
	/// </summary>
	Gallery = 3,

	/// <summary>
	///     Watchable URL
	/// </summary>
	Watchable = 4,

	/// <summary>
	///     Unknown URL (i.e. no matching URL Class).
	///     <remarks>
	///         "Неизвестные" URL-адреса обрабатываются в клиенте как прямые файловые URL-адреса.
	///         Несмотря на то, что тип "File URL" доступен, большинство файловых URL-адресов не имеют класса URL, поэтому они будут отображаться как неизвестные.
	///         При добавлении их в клиент они будут переданы в URL-загрузчик в виде необработанного файла для загрузки и импорта.
	///     </remarks>
	/// </summary>
	Unknown = 5
}
