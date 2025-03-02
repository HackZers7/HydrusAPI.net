namespace HydrusAPI.Web;

/// <summary>
///     Запрос на импорт локального файла.
/// </summary>
public class AddFileRequest : FileDomainRequest
{
	/// <summary>
	/// 	Инициализирует новый экземпляр запроса.
	/// </summary>
	/// <param name="path">Путь до файла на локальной машине.</param>
	/// <param name="deleteAfterSuccessfulImport">Необязательно, удалить файл после успешного импорта. По умолчанию - false.</param>
	public AddFileRequest(string path, bool deleteAfterSuccessfulImport = false)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(path);

		Path = path;
		DeleteAfterSuccessfulImport = deleteAfterSuccessfulImport;
	}

	/// <summary>
	///     Путь до файла на локальной машине.
	/// </summary>
	public string Path { get; set; }

	/// <summary>
	///     Необязательно, удалить файл после успешного импорта.
	/// </summary>
	/// <remarks>
	///     По умолчанию - false.
	/// </remarks>
	public bool DeleteAfterSuccessfulImport { get; set; } = false;
}
