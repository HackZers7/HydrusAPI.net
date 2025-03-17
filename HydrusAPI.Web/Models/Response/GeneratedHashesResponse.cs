namespace HydrusAPI.Web;

/// <summary>
///     Сгенерированные хеши (SHA256) произвольного файла.
/// </summary>
public class GeneratedHashesResponse : ApiVersionResponse
{
    /// <summary>
    ///     Список перцептивных хешей для файла.
    /// </summary>
    public List<string>? PerceptualHashes { get; set; }

    /// <summary>
    ///     Хеш (SHA256) отрендеренного изображения.
    /// </summary>
    public string? PixelHash { get; set; }

    /// <summary>
    ///     Хэш (SHA256). Всегда возвращается для файлов, в остальных случаях только если могут быть сгенерированы.
    /// </summary>
    public string? Hash { get; set; }
}
