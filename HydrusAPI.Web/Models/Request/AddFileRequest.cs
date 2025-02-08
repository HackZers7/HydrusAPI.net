namespace HydrusAPI.Web;

/// <summary>
///     Запрос на импорт локального файла.
/// </summary>
public class AddFileRequest : FileDomain
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="path">Путь до файла на локальной машине.</param>
	/// <param name="deleteAfterSuccessfulImport">Удалить файл после импорта. По умолчанию - false.</param>
	public AddFileRequest(string path, bool deleteAfterSuccessfulImport = false)
	{
		Path = path;
		DeleteAfterSuccessfulImport = deleteAfterSuccessfulImport;
	}

	/// <summary>
	///     Путь до файла на локальной машине.
	/// </summary>
	public string Path { get; set; }

	/// <summary>
	///     Удалить файл после импорта. По умолчанию - false.
	/// </summary>
	public bool DeleteAfterSuccessfulImport { get; set; }
}
