namespace HydrusAPI.Web;

/// <summary>
///     Представляет файловый домен Hydrus.
/// </summary>
public abstract class FileDomain
{
	private List<string>? _deletedFileServiceKeys;
	private List<string>? _fileServiceKeys;

	/// <summary>
	///     Коллекция шестнадцатеричных доменов, объединение доменов файлов, по которым выполняется поиск.
	/// </summary>
	public IReadOnlyCollection<string>? FileServiceKeys => _fileServiceKeys;

	/// <summary>
	///     Коллекция шестнадцатеричных доменов, объединение "deleted from this file domain", по которому выполняется поиск/
	/// </summary>
	public IReadOnlyCollection<string>? DeletedFileServiceKeys => _deletedFileServiceKeys;

	/// <summary>
	///     Добавляет домен.
	/// </summary>
	/// <param name="domainKey">Домен.</param>
	public void AddFileDomain(string domainKey)
	{
		if (_fileServiceKeys == null)
		{
			_fileServiceKeys = new List<string>();
		}

		_fileServiceKeys.Add(domainKey.ToLower());
	}

	/// <summary>
	///     Добавляет домен.
	/// </summary>
	/// <param name="domainKey">Домен.</param>
	public void AddDeletedFileDomain(string domainKey)
	{
		if (_deletedFileServiceKeys == null)
		{
			_deletedFileServiceKeys = new List<string>();
		}

		_deletedFileServiceKeys.Add(domainKey.ToLower());
	}

	/// <summary>
	///     Удаляет домен.
	/// </summary>
	/// <param name="domainKey">Домен.</param>
	public bool RemoveFileDomain(string domainKey)
	{
		return _fileServiceKeys != null && _fileServiceKeys.Remove(domainKey.ToLower());
	}

	/// <summary>
	///     Удаляет домен.
	/// </summary>
	/// <param name="domainKey">Домен.</param>
	public bool RemoveDeletedFileDomain(string domainKey)
	{
		return _deletedFileServiceKeys != null && _deletedFileServiceKeys.Remove(domainKey.ToLower());
	}

	/// <summary>
	///     Очищает все домены.
	/// </summary>
	public void ClearAllFilesDomain()
	{
		ClearFilesDomain();
		CleatDeletedFilesDomains();
	}

	/// <summary>
	///     Очищает домены.
	/// </summary>
	public void ClearFilesDomain()
	{
		_fileServiceKeys = null;
	}

	/// <summary>
	///     Очищает домены.
	/// </summary>
	public void CleatDeletedFilesDomains()
	{
		_deletedFileServiceKeys = null;
	}
}
