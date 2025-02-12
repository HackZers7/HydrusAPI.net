namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы с тегами.
/// </summary>
public interface ITagsClient
{
	/// <summary>
	///     Приводит теги к формату определенным в Hydrus.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTags" />.
	/// </remarks>
	/// <param name="tags">Теги.</param>
	/// <returns>Возвращает перечисление с очищенными тегами.</returns>
	Task<IEnumerable<string>> CleanTags(params string[] tags);

	/// <summary>
	///     Приводит теги к формату определенным в Hydrus.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTags" />.
	/// </remarks>
	/// <param name="tags">Теги.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает перечисление с очищенными тегами.</returns>
	Task<IEnumerable<string>> CleanTags(IEnumerable<string> tags, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает родителей и сестер тега.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTags" />.
	/// </remarks>
	/// <param name="tags">Теги.</param>
	/// <returns>Возвращает <see cref="SiblingsAndParentsResponse" /> с братьями и сестрами.</returns>
	Task<SiblingsAndParentsResponse> GetSiblingsAndParents(params string[] tags);

	/// <summary>
	///     Запрашивает родителей и сестер тега.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTags" />,
	/// </remarks>
	/// <param name="tags">Теги.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="SiblingsAndParentsResponse" /> с братьями и сестрами.</returns>
	Task<SiblingsAndParentsResponse> GetSiblingsAndParents(IEnumerable<string> tags, CancellationToken cancel = default);

	/// <summary>
	///     Производит поиск тегов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуются все области видимости (разрешения):
	///     <see cref="Permissions.EditFileTags" />,
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="search">Запрос для поиска, формат такой же как и для интерфейса Hydrus.</param>
	/// <param name="fileDomain">Файловый домен.</param>
	/// <param name="tagServiceKey">Ключ домена тегов в котором выполняется поиск. По умолчанию - "all my files".</param>
	/// <param name="tagDisplayType">Указывает на то, следует ли выполнять поиск по необработанным или обработанным тегам.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="TagsSearchResponse" /> с найденными тегами.</returns>
	Task<TagsSearchResponse> SearchTags(string search, FileDomainRequest? fileDomain = null, string? tagServiceKey = null, TagDisplay tagDisplayType = TagDisplay.Storage, CancellationToken cancel = default);

	/// <summary>
	///     Добавляет теги к файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTags" />.
	/// </remarks>
	/// <param name="request">Запрос для добавления тегов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> AddTags(AddTagsRequest request, CancellationToken cancel = default);
}
