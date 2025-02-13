// ReSharper disable PossibleMultipleEnumeration

namespace HydrusAPI.Web;

/// <summary>
///     Представляет файлы Hydrus.
/// </summary>
public class FilesRequest
{
	/// <summary>
	///     Конструктор по умолчанию.
	/// </summary>
	public FilesRequest()
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	public FilesRequest(IEnumerable<string>? hashes)
	{
		if (hashes?.Any() ?? false)
		{
			Hashes = hashes.ToList();
		}
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Идентификаторы файлов.</param>
	public FilesRequest(IEnumerable<ulong>? fileIds)
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
	///     Коллекция хэшей (SHA256) файлов.
	/// </summary>
	public List<string>? Hashes { get; set; }

	/// <summary>
	///     Идентификатор файла.
	/// </summary>
	public ulong? FileId { get; set; }

	/// <summary>
	///     Коллекция идентификаторов файлов.
	/// </summary>
	public List<ulong>? FileIds { get; set; }
}

/// <summary>
///     Представляет файлы Hydrus с доменом.
/// </summary>
public class FilesWithDomainRequest : FileDomainRequest
{
	/// <summary>
	///     Конструктор по умолчанию.
	/// </summary>
	public FilesWithDomainRequest()
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	public FilesWithDomainRequest(IEnumerable<string>? hashes)
	{
		if (hashes?.Any() ?? false)
		{
			Hashes = hashes.ToList();
		}
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Идентификаторы файлов.</param>
	public FilesWithDomainRequest(IEnumerable<ulong>? fileIds)
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
	///     Коллекция хэшей (SHA256) файлов.
	/// </summary>
	public List<string>? Hashes { get; set; }

	/// <summary>
	///     Идентификатор файла.
	/// </summary>
	public ulong? FileId { get; set; }

	/// <summary>
	///     Коллекция идентификаторов файлов.
	/// </summary>
	public List<ulong>? FileIds { get; set; }
}
