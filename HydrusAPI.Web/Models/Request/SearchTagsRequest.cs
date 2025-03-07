namespace HydrusAPI.Web;

/// <summary>
/// 	Запрос поиска тегов.
/// </summary>
public class SearchTagsRequest : FileDomainRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="search">Запрос для поиска, формат такой же как и для интерфейса Hydrus.</param>
	public SearchTagsRequest(string search)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(search);

		Search = search;
	}

	/// <summary>
	/// 	Запрос для поиска, формат такой же как и для интерфейса Hydrus.
	/// </summary>
	public string Search { get; set; }

	/// <summary>
	/// 	Ключ домена тегов в котором выполняется поиск. 
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - "all known tags".
	/// </remarks>
	public string? TagServiceKey { get; set; }

	/// <summary>
	/// 	Указывает на то, следует ли выполнять поиск по необработанным или обработанным тегам.
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - <see cref="TagDisplay.Storage"/>.
	/// </remarks>
	public TagDisplay TagDisplayType { get; set; } = TagDisplay.Storage;
}
