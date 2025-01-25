namespace HydrusAPI.Web;

/// <summary>
///     Ответ на запрос получения сервиса.
/// </summary>
public class ServiceResponse : ApiVersion
{
	/// <summary>
	///     Сервис.
	/// </summary>
	public Service Service { get; set; } = new();
}
