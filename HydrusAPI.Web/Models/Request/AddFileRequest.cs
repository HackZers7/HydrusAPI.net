namespace HydrusAPI.Web;

/// <summary>
///     Запрос на импорт локального файла.
/// </summary>
public class AddFileRequest : FileDomainRequest
{
	/// <summary>
	///     Путь до файла на локальной машине.
	/// </summary>
	public string? Path { get; set; }

	/// <summary>
	///     Удалить файл после импорта.
	/// </summary>
	/// <remarks>
	///     По умолчанию - false.
	/// </remarks>
	public bool DeleteAfterSuccessfulImport { get; set; } = false;
}
