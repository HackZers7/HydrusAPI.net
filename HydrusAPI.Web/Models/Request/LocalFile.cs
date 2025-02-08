namespace HydrusAPI.Web;

/// <summary>
///     Локальный файл.
/// </summary>
public class LocalFile
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="path">Путь до файла на локальной машине.</param>
	public LocalFile(string path)
	{
		Path = path;
	}

	/// <summary>
	///     Путь до файла на локальной машине.
	/// </summary>
	public string Path { get; set; }
}
