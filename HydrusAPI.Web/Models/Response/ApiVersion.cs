namespace HydrusAPI.Web;

/// <summary>
///     Версия API Hydrus.
/// </summary>
public class ApiVersionResponse
{
    /// <summary>
    ///     Версия Hydrus API.
    /// </summary>
    public int Version { get; set; }

    /// <summary>
    ///     Версия Hydrus.
    /// </summary>
    public int HydrusVersion { get; set; }
}
