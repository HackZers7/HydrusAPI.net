namespace HydrusAPI.Web;

/// <summary>
///     Запрос для импорта файла по URL.
/// </summary>
public class AddUrlRequest : FileDomain
{
	// TODO: Переписать на билдер
	
	private Dictionary<string, List<string>>? _serviceKeysToAdditionalTags;

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="url">URL с файлом или файлами для импорта.</param>
	public AddUrlRequest(string url) : this(new Uri(url))
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="url">URL с файлом или файлами для импорта.</param>
	public AddUrlRequest(Uri url)
	{
		Url = url;
	}

	/// <summary>
	///     URL файла или файлов для импорта.
	/// </summary>
	public Uri Url { get; set; }

	/// <summary>
	///     Необязательно, идентификатор страницы, в которой будет произведен импорт.
	///     <remarks>
	///         По умолчанию - null.
	///     </remarks>
	/// </summary>
	public string? DestinationPageKey { get; set; }

	/// <summary>
	///     Необязательно, название страницы, в которой будет произведен импорт.
	///     <remarks>
	///         По умолчанию - null.
	///     </remarks>
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
	///     Необязательный, дополнительные теги для присвоения, импортированным с этого URL-адреса.
	///     <remarks>
	///         По умолчанию - null.
	///     </remarks>
	/// </summary>
	public IReadOnlyDictionary<string, List<string>>? ServiceKeysToAdditionalTags => _serviceKeysToAdditionalTags;

	/// <summary>
	///     Необязательный, теги для фильтрации, применимым к URL-адресу.
	/// </summary>
	public List<string> FilterableTags { get; } = new();

	/// <summary>
	///     Добавить тег, для добавления файлу.
	/// </summary>
	/// <param name="serviceKey">Ключ сервиса тегов.</param>
	/// <param name="tag">Тег.</param>
	public void AddAdditionalTag(string serviceKey, string tag)
	{
		if (_serviceKeysToAdditionalTags == null)
		{
			_serviceKeysToAdditionalTags = new Dictionary<string, List<string>>();
		}

		if (!_serviceKeysToAdditionalTags.TryGetValue(serviceKey, out var list))
		{
			list = new List<string>();
			_serviceKeysToAdditionalTags.Add(serviceKey, list);
		}

		list.Add(tag);
	}

	/// <summary>
	///     Удалить тег, для добавления файлу.
	/// </summary>
	/// <param name="serviceKey">Ключ сервиса тегов.</param>
	/// <param name="tag">Тег.</param>
	public bool RemoveAdditionalTag(string serviceKey, string tag)
	{
		if (_serviceKeysToAdditionalTags == null)
		{
			return false;
		}

		if (!_serviceKeysToAdditionalTags.TryGetValue(serviceKey, out var list))
		{
			return false;
		}

		list.Remove(tag);
		return true;
	}

	/// <summary>
	///     Очистить теги, для добавления файлу.
	/// </summary>
	public void ClearAdditionalTags()
	{
		_serviceKeysToAdditionalTags = null;
	}
}
