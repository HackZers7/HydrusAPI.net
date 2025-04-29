namespace HydrusAPI.Web;

/// <summary>
///     Ответ с заголовками.
/// </summary>
public class HeadersResponse : ApiVersionResponse
{
    /// <summary>
    ///     Сетевой контекст.
    /// </summary>
    public NetworkContext? NetworkContext { get; set; }

    /// <summary>
    ///     Словарь с заголовками.
    /// </summary>
    public Dictionary<string, Header>? Headers { get; set; }
}

/// <summary>
///     Типы контекстов.
/// </summary>
public enum NetworkContextTypes
{
    /// <summary>
    ///     Глобальное значение.
    /// </summary>
    Global = 0,

    /// <summary>
    ///     Домен.
    /// </summary>
    Domain = 2
}

/// <summary>
///     Сетевой контекст.
/// </summary>
public class NetworkContext
{
    /// <summary>
    ///     Тип.
    /// </summary>
    public NetworkContextTypes Type { get; set; }

    /// <summary>
    ///     Домен.
    /// </summary>
    public string? Data { get; set; }
}

/// <summary>
///     Заголовок.
/// </summary>
public class Header
{
    /// <summary>
    ///     Значение.
    /// </summary>
    public string? Value { get; set; }

    // [TODO]: Переделать в перечисление?
    /// <summary>
    ///     Одобрен.
    /// </summary>
    /// <remarks>
    ///     Возможные значения: "approved", "denied", "pending".
    /// </remarks>
    public string? Approved { get; set; }

    /// <summary>
    ///     Причина.
    /// </summary>
    public string? Reason { get; set; }
}
