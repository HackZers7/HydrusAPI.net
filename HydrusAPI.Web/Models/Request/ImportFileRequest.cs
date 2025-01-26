namespace HydrusAPI.Web;

/// <summary>
///     Запрос на импорт локального файла.
/// </summary>
public class ImportFileRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="path">Путь до файла на локальной машине.</param>
	/// <param name="deleteAfterSuccessfulImport">Удалить файл после импорта. По умолчанию - false.</param>
	/// <param name="fileDomain">Домен файла. По умолчанию - "quiet".</param>
	public ImportFileRequest(string path, bool deleteAfterSuccessfulImport = false, string? fileDomain = null)
	{
		Path = path;
		DeleteAfterSuccessfulImport = deleteAfterSuccessfulImport;
		FileDomain = fileDomain;
	}

	/// <summary>
	///     Путь до файла на локальной машине.
	/// </summary>
	public string Path { get; set; }

	/// <summary>
	///     Удалить файл после импорта. По умолчанию - false.
	/// </summary>
	public bool DeleteAfterSuccessfulImport { get; set; }

	/// <summary>
	///     Домен файла. По умолчанию - "quiet".
	/// </summary>
	public string? FileDomain { get; set; }
}
