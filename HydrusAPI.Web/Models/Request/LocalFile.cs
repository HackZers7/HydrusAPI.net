namespace HydrusAPI.Web;

/// <summary>
///     Локальный файл.
/// </summary>
public class LocalFileRequest
{
    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="path">Путь до файла на локальной машине.</param>
    public LocalFileRequest(string path)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(path);

        Path = path;
    }

    /// <summary>
    ///     Путь до файла на локальной машине.
    /// </summary>
    public string Path { get; set; }
}
