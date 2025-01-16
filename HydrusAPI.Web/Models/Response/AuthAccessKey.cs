namespace HydrusAPI.Web;

/// <summary>
///     Класс представляющий API ключ.
/// </summary>
public class AuthAccessKey : ApiVersion
{
	/// <summary>
	///     Возвращает API ключ.
	/// </summary>
	public string AccessKey { get; set; } = default!;
}
