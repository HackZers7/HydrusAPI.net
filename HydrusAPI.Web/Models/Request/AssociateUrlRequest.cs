namespace HydrusAPI.Web;

/// <summary>
///     Запрос для импорта файла по URL.
/// </summary>
public class AssociateUrlRequest : FilesRequest
{
	/// <summary>
	///     Конструктор по умолчанию.
	/// </summary>
	public AssociateUrlRequest()
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	public AssociateUrlRequest(IEnumerable<string>? hashes) : base(hashes)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Идентификаторы файлов.</param>
	public AssociateUrlRequest(IEnumerable<ulong>? fileIds) : base(fileIds)
	{
	}

	/// <summary>
	///     Ссылка для ассоциации (добавления).
	/// </summary>
	public string? UrlToAdd { get; set; }

	/// <summary>
	///     Коллекция ссылок для ассоциации (добавления).
	/// </summary>
	public List<string>? UrlsToAdd { get; set; }

	/// <summary>
	///     Ссылка для диссоциации (удаления).
	/// </summary>
	public string? UrlToDelete { get; set; }

	/// <summary>
	///     Коллекция ссылок для диссоциации (удаления).
	/// </summary>
	public List<string>? UrlsToDelete { get; set; }

	/// <summary>
	///     Нормализовать URL. Работает только для ассоциации.
	///     <remarks>По умолчанию - true.</remarks>
	/// </summary>
	public bool NormaliseUrls { get; set; } = true;
}
