namespace HydrusAPI.Web;

/// <summary>
///     Содержит данные бо локальном пути к файлу.
/// </summary>
public class FilePathResponse : ApiVersionResponse
{
    /// <summary>
    ///     Путь к файлу.
    /// </summary>
    public string Path { get; set; } = default!;

    /// <summary>
    ///     Тип файла.
    /// </summary>
    public string Filetype { get; set; } = default!;

    /// <summary>
    ///     Размер файла.
    /// </summary>
    public ulong Size { get; set; }
}

/// <summary>
///     Содержит данные бо локальном пути к эскизу.
/// </summary>
public class ThumbnailFilePathResponse : ApiVersionResponse
{
    /// <summary>
    ///     Путь к файлу.
    /// </summary>
    public string Path { get; set; } = default!;

    /// <summary>
    ///     Тип файла.
    /// </summary>
    public string? Filetype { get; set; }
}
