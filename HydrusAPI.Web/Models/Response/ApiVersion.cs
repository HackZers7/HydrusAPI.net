namespace HydrusAPI.Web;

/// <summary>
///     Версия API Hydrus.
/// </summary>
public class ApiVersion
{
	/// <summary>
	///     Возвращает версию Hydrus API.
	/// </summary>
	public int Version { get; set; }

	/// <summary>
	///     Возвращает версию Hydrus.
	/// </summary>
	public int HydrusVersion { get; set; }
}
