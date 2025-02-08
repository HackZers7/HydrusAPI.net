namespace HydrusAPI.Web;

/// <summary>
///     Запрос для импорта файла по URL.
/// </summary>
public class AssociateUrlRequest : Files
{
	private List<string>? _urlsToAdd;
	private List<string>? _urlsToDelete;

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
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
	///     Ссылки для ассоциации с файлом.
	/// </summary>
	public IReadOnlyCollection<string>? UrlsToAdd => _urlsToAdd;

	/// <summary>
	///     Ссылки для диссоциации с файлом.
	/// </summary>
	public IReadOnlyCollection<string>? UrlsToDelete => _urlsToDelete;

	/// <summary>
	///     Нормализовать URL. Работает только для ассоциации.
	///     <remarks>По умолчанию - true.</remarks>
	/// </summary>
	public bool NormaliseUrls { get; set; } = true;

	/// <summary>
	///     Добавить URL для ассоциации.
	/// </summary>
	/// <param name="url">URL</param>
	public void AddAssociateUrl(string url)
	{
		if (_urlsToAdd == null)
		{
			_urlsToAdd = new List<string>();
		}

		_urlsToAdd.Add(url);
	}
	
	/// <summary>
	///     Добавить URL для ассоциации.
	/// </summary>
	/// <param name="urls">URL</param>
	public void AddRangeAssociateUrl(IEnumerable<string> urls)
	{
		if (_urlsToAdd == null)
		{
			_urlsToAdd = new List<string>();
		}

		_urlsToAdd.AddRange(urls);
	}

	/// <summary>
	///     Удалить URL для ассоциации.
	/// </summary>
	/// <param name="url">URL</param>
	public bool RemoveAssociateUrl(string url)
	{
		if (_urlsToAdd == null)
		{
			return false;
		}

		return _urlsToAdd.Remove(url);
	}

	/// <summary>
	///     Очистить URL для ассоциации.
	/// </summary>
	public void ClearAdditionalTags()
	{
		_urlsToAdd = null;
	}

	/// <summary>
	///     Добавить URL для диссоциации.
	/// </summary>
	/// <param name="url">URL</param>
	public void AddDisassociateUrl(string url)
	{
		if (_urlsToDelete == null)
		{
			_urlsToDelete = new List<string>();
		}

		_urlsToDelete.Add(url);
	}
	
	/// <summary>
	///     Добавить URL для диссоциации.
	/// </summary>
	/// <param name="urls">URL</param>
	public void AddDisassociateUrl(IEnumerable<string> urls)
	{
		if (_urlsToDelete == null)
		{
			_urlsToDelete = new List<string>();
		}

		_urlsToDelete.AddRange(urls);
	}

	/// <summary>
	///     Удалить url для диссоциации.
	/// </summary>
	/// <param name="url">URL</param>
	public bool RemoveDisassociateUrl(string url)
	{
		if (_urlsToDelete == null)
		{
			return false;
		}

		return _urlsToDelete.Remove(url);
	}

	/// <summary>
	///     Очистить URL для диссоциации.
	/// </summary>
	public void ClearDisassociateTags()
	{
		_urlsToDelete = null;
	}
}
