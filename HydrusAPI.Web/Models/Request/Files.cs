namespace HydrusAPI.Web;

/// <summary>
///     Представляет файлы Hydrus.
/// </summary>
public abstract class Files
{
	private List<ulong>? _fileIds;
	private List<string>? _hashes;

	/// <summary>
	///     Коллекция хэшей (SHA256) файлов.
	/// </summary>
	public IReadOnlyCollection<string>? Hashes => _hashes;

	/// <summary>
	///     Коллекция идентификаторов файлов.
	/// </summary>
	public IReadOnlyCollection<ulong>? FileIds => _fileIds;

	/// <summary>
	///     Добавить хэш (SHA256) файла.
	/// </summary>
	/// <param name="hash">Хэш (SHA256).</param>
	public void AddHash(string hash)
	{
		if (_hashes == null)
		{
			_hashes = new List<string>();
		}

		_hashes.Add(hash.ToUpper());
	}

	/// <summary>
	///     Добавить идентификатор файла.
	/// </summary>
	/// <param name="id">Идентификатор.</param>
	public void AddId(ulong id)
	{
		if (_fileIds == null)
		{
			_fileIds = new List<ulong>();
		}

		_fileIds.Add(id);
	}

	/// <summary>
	///     Удалить хэш (SHA256) файла.
	/// </summary>
	/// <param name="hash">Хэш (SHA256).</param>
	public bool RemoveHash(string hash)
	{
		return _hashes != null && _hashes.Remove(hash.ToUpper());
	}

	/// <summary>
	///     Удалить идентификатор файла.
	/// </summary>
	/// <param name="id">Идентификатор.</param>
	public bool RemoveId(ulong id)
	{
		return _fileIds != null && _fileIds.Remove(id);
	}

	/// <summary>
	///     Очищает все файлы.
	/// </summary>
	public void ClearAllFiles()
	{
		ClearHashes();
		CleatFileIds();
	}

	/// <summary>
	///     Очищает хэши файлов.
	/// </summary>
	public void ClearHashes()
	{
		_hashes = null;
	}

	/// <summary>
	///     Очищает идентификаторы файлов.
	/// </summary>
	public void CleatFileIds()
	{
		_fileIds = null;
	}
}

/// <summary>
///     Представляет файлы Hydrus.
/// </summary>
public abstract class FilesAndFilesDomain : FileDomain
{
	private List<ulong>? _fileIds;
	private List<string>? _hashes;

	/// <summary>
	///     Коллекция хэшей (SHA256) файлов.
	/// </summary>
	public IReadOnlyCollection<string>? Hashes => _hashes;

	/// <summary>
	///     Коллекция идентификаторов файлов.
	/// </summary>
	public IReadOnlyCollection<ulong>? FileIds => _fileIds;

	/// <summary>
	///     Добавить хэш (SHA256) файла.
	/// </summary>
	/// <param name="hash">Хэш (SHA256).</param>
	public void AddHash(string hash)
	{
		if (_hashes == null)
		{
			_hashes = new List<string>();
		}

		_hashes.Add(hash.ToUpper());
	}

	/// <summary>
	///     Добавить идентификатор файла.
	/// </summary>
	/// <param name="id">Идентификатор.</param>
	public void AddId(ulong id)
	{
		if (_fileIds == null)
		{
			_fileIds = new List<ulong>();
		}

		_fileIds.Add(id);
	}

	/// <summary>
	///     Удалить хэш (SHA256) файла.
	/// </summary>
	/// <param name="hash">Хэш (SHA256).</param>
	public bool RemoveHash(string hash)
	{
		return _hashes != null && _hashes.Remove(hash.ToUpper());
	}

	/// <summary>
	///     Удалить идентификатор файла.
	/// </summary>
	/// <param name="id">Идентификатор.</param>
	public bool RemoveId(ulong id)
	{
		return _fileIds != null && _fileIds.Remove(id);
	}

	/// <summary>
	///     Очищает все файлы.
	/// </summary>
	public void ClearAllFiles()
	{
		ClearHashes();
		CleatFileIds();
	}

	/// <summary>
	///     Очищает хэши файлов.
	/// </summary>
	public void ClearHashes()
	{
		_hashes = null;
	}

	/// <summary>
	///     Очищает идентификаторы файлов.
	/// </summary>
	public void CleatFileIds()
	{
		_fileIds = null;
	}
}
