namespace HydrusAPI.Web;

/// <summary>
///     Ответ на запрос получения всех доступных сервисов.
/// </summary>
public class ServicesResponse : ApiVersionResponse
{
    /// <summary>
    ///     Объект со всеми доступными сервисами. Где ключ - идентификатор сервиса.
    /// </summary>
    public Dictionary<string, Service> Services { get; set; } = new();
}
