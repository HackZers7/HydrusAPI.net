namespace HydrusAPI.Web;

/// <summary>
///     Запрос поиска файла.
/// </summary>
public class SearchFilesRequest : FileDomainRequest
{
	// TODO: Добавить поддержку предикатов (predicates)

	/// <summary>
	/// 	Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="tags">Теги для поиска.</param>
	public SearchFilesRequest(IList<string> tags)
	{
		Tags = new List<object>(tags);
	}

	/// <summary>
	/// 	Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="tags">Теги для поиска.</param>
	public SearchFilesRequest(IList<object> tags)
	{
		Tags = tags;
	}

	/// <summary>
	///     Теги для поиска.
	/// </summary>
	/// <remarks>
	///     Значение определено как объект потому что может содержать как строковое значение, так и другую коллекцию с тегами.
	/// </remarks>
	public IList<object> Tags { get; set; }

	/// <summary>
	///     Необязательно, шестнадцатеричный ключ домена, в котором выполняется поиск.
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - "all my files".
	/// </remarks>
	public string? TagServiceKey { get; set; }

	/// <summary>
	///     Необязательно, выполнять поиск по "текущим" тегам.
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - true.
	/// </remarks>
	public bool IncludeCurrentTags { get; set; } = true;

	/// <summary>
	///     Необязательно, выполнять поиск по "ожидающим" тегам.
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - true.
	/// </remarks>
	public bool IncludePendingTags { get; set; } = true;

	/// <summary>
	///     Необязательно, метод сортировки.
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - <see cref="SortingType.ImportTime" />.
	/// </remarks>
	public SortingType FileSortType { get; set; } = SortingType.ImportTime;

	/// <summary>
	///     Необязательно, тип сортировки.
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - true.
	/// </remarks>
	public bool FileSortAsc { get; set; } = true;

	/// <summary>
	///     Необязательно, получить идентификаторы файлов.
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - true.
	/// </remarks>
	public bool ReturnFileIds { get; set; } = true;

	/// <summary>
	///     Необязательно, получить хеши файлов.
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - true.
	/// </remarks>
	public bool ReturnHashes { get; set; } = true;
}
