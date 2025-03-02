
namespace HydrusAPI.Web;

/// <summary>
///     Запрос для импорта файла по URL.
/// </summary>
public class AssociateUrlRequest : FilesRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	public AssociateUrlRequest(string hash) : base(hash)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	public AssociateUrlRequest(ulong id) : base(id)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	public AssociateUrlRequest(IList<string>? hashes) : base(hashes)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Коллекция идентификаторов файлов.</param>
	public AssociateUrlRequest(IList<ulong>? fileIds) : base(fileIds)
	{
	}

	/// <summary>
	///     Ссылка для ассоциации (добавления).
	/// </summary>
	public Uri? UrlToAdd { get; set; }

	/// <summary>
	///     Коллекция ссылок для ассоциации (добавления).
	/// </summary>
	public IList<Uri>? UrlsToAdd { get; set; }

	/// <summary>
	///     Ссылка для диссоциации (удаления).
	/// </summary>
	public Uri? UrlToDelete { get; set; }

	/// <summary>
	///     Коллекция ссылок для диссоциации (удаления).
	/// </summary>
	public IList<Uri>? UrlsToDelete { get; set; }

	/// <summary>
	///     Нормализовать URL. Работает только для ассоциации.
	///     <remarks>По умолчанию - true.</remarks>
	/// </summary>
	public bool NormaliseUrls { get; set; } = true;
}
