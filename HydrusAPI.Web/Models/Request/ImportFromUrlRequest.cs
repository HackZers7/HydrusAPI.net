namespace HydrusAPI.Web;

/// <summary>
///     Запрос для импорта файла по URL.
/// </summary>
public class ImportFromUrlRequest : FileDomainRequest
{
	/// <summary>
	///     Конструктор по умолчанию.
	/// </summary>
	public ImportFromUrlRequest()
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="uri">URL</param>
	public ImportFromUrlRequest(string uri) : this(new Uri(uri))
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="uri">URL</param>
	public ImportFromUrlRequest(Uri uri)
	{
		Url = uri;
	}

	/// <summary>
	///     URL файла или файлов для импорта.
	/// </summary>
	public Uri? Url { get; set; }

	/// <summary>
	///     Необязательно, идентификатор страницы, в которой будет произведен импорт.
	/// </summary>
	public string? DestinationPageKey { get; set; }

	/// <summary>
	///     Необязательно, название страницы, в которой будет произведен импорт.
	/// </summary>
	public string? DestinationPageName { get; set; }

	/// <summary>
	///     Необязательный, определяет, будет ли пользовательский интерфейс изменять страницы при добавлении.
	///     <remarks>
	///         По умолчанию - false.
	///     </remarks>
	/// </summary>
	public bool ShowDestinationPage { get; set; } = false;

	/// <summary>
	///     Необязательный, дополнительные теги для добавления файлу, где ключом является идентификатор сервиса, а значением коллекция тегов.
	///     <remarks>
	///         Для отправки требуется область видимости (разрешение):
	///         <see cref="Permissions.EditFileTags" />.
	///     </remarks>
	/// </summary>
	public Dictionary<string, List<string>>? ServiceKeysToAdditionalTags { get; set; }

	/// <summary>
	///     Необязательный, теги для фильтрации, применимым к URL-адресу.
	/// </summary>
	public List<string>? FilterableTags { get; set; }
}
