// ReSharper disable PossibleMultipleEnumeration

namespace HydrusAPI.Web;

/// <summary>
///     Представляет файлы Hydrus.
/// </summary>
public class FilesRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	public FilesRequest(string hash)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		Hash = hash;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	public FilesRequest(ulong id)
	{
		ThrowHelper.ArgumentOutOfRange(id, 1UL, ulong.MaxValue);

		FileId = id;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	public FilesRequest(IList<string>? hashes)
	{
		if (hashes?.Any() ?? false)
		{
			Hashes = hashes.ToList();
		}
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Коллекция идентификаторов файлов.</param>
	public FilesRequest(IList<ulong>? fileIds)
	{
		if (fileIds?.Any() ?? false)
		{
			FileIds = fileIds.ToList();
		}
	}

	/// <summary>
	///     Хэш (SHA256) файла.
	/// </summary>
	public string? Hash { get; set; }

	/// <summary>
	///     Коллекция хешей (SHA256) файлов.
	/// </summary>
	public IList<string>? Hashes { get; set; }

	/// <summary>
	///     Идентификатор файла.
	/// </summary>
	public ulong? FileId { get; set; }

	/// <summary>
	///     Коллекция идентификаторов файлов.
	/// </summary>
	public IList<ulong>? FileIds { get; set; }
}

/// <summary>
///     Представляет файлы Hydrus с доменом.
/// </summary>
public class FilesWithDomainRequest : FileDomainRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	public FilesWithDomainRequest(string hash)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		Hash = hash;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	public FilesWithDomainRequest(ulong id)
	{
		ThrowHelper.ArgumentOutOfRange(id, 1UL, ulong.MaxValue);

		FileId = id;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	public FilesWithDomainRequest(IList<string>? hashes)
	{
		if (hashes?.Any() ?? false)
		{
			Hashes = hashes.ToList();
		}
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Коллекция идентификаторов файлов.</param>
	public FilesWithDomainRequest(IList<ulong>? fileIds)
	{
		if (fileIds?.Any() ?? false)
		{
			FileIds = fileIds.ToList();
		}
	}

	/// <summary>
	///     Хэш (SHA256) файла.
	/// </summary>
	public string? Hash { get; set; }

	/// <summary>
	///     Коллекция хешей (SHA256) файлов.
	/// </summary>
	public IList<string>? Hashes { get; set; }

	/// <summary>
	///     Идентификатор файла.
	/// </summary>
	public ulong? FileId { get; set; }

	/// <summary>
	///     Коллекция идентификаторов файлов.
	/// </summary>
	public IList<ulong>? FileIds { get; set; }
}
