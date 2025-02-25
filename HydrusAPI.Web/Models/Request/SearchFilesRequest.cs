namespace HydrusAPI.Web;

/// <summary>
///     Запрос поиска файла.
/// </summary>
public class SearchFilesRequest : FileDomainRequest
{
	// TODO: Добавить поддержку предикатов (predicates)

	/// <summary>
	///     Теги для поиска.
	/// </summary>
	/// <remarks>
	///     Значение определено как объект потому что может содержать как строковое значение, так и другую коллекцию с тегами.
	/// </remarks>
	public List<object>? Tags { get; set; }

	/// <summary>
	///     Необязательно, шестнадцатеричный ключ домена, в котором выполняется поиск.
	///     <remarks>
	///         По умолчанию - "all my files".
	///     </remarks>
	/// </summary>
	public string? TagServiceKey { get; set; }

	/// <summary>
	///     Необязательно, выполнять поиск по "текущим" тегам.
	///     <remarks>
	///         По умолчанию - true.
	///     </remarks>
	/// </summary>
	public bool IncludeCurrentTags { get; set; } = true;

	/// <summary>
	///     Необязательно, выполнять поиск по "ожидающим" тегам.
	///     <remarks>
	///         По умолчанию - true.
	///     </remarks>
	/// </summary>
	public bool IncludePendingTags { get; set; } = true;

	/// <summary>
	///     Необязательно, метод сортировки.
	///     <remarks>
	///         По умолчанию - <see cref="SortingType.ImportTime" />.
	///     </remarks>
	/// </summary>
	public int FileSortType { get; set; } = (int)SortingType.ImportTime;

	/// <summary>
	///     Необязательно, тип сортировки.
	///     <remarks>
	///         По умолчанию - true.
	///     </remarks>
	/// </summary>
	public bool FileSortAsc { get; set; } = true;

	/// <summary>
	///     Необязательно, получить идентификаторы файлов.
	///     <remarks>
	///         По умолчанию - true.
	///     </remarks>
	/// </summary>
	public bool ReturnFileIds { get; set; } = true;

	/// <summary>
	///     Необязательно, получить хэши файлов.
	///     <remarks>
	///         По умолчанию - true.
	///     </remarks>
	/// </summary>
	public bool ReturnHashes { get; set; } = true;
}
