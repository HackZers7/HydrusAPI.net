namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы с тегами.
/// </summary>
public interface ITagsClient
{
	/// <summary>
	///     Отправляет запрос для приведения тегов к правилам к Hydrus.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.EditFileTags" />.
	/// </remarks>
	/// <param name="tags">Теги для очистки.</param>
	/// <returns>Возвращает перечисление с очищенными тегами.</returns>
	Task<IEnumerable<string>> CleanTags(params string[] tags);

	/// <summary>
	///     Отправляет запрос для приведения тегов к правилам к Hydrus.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.EditFileTags" />.
	/// </remarks>
	/// <param name="tags">Теги для очистки.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает перечисление с очищенными тегами.</returns>
	Task<IEnumerable<string>> CleanTags(IEnumerable<string> tags, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет запрос для получения родителей и сестер.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.EditFileTags" />.
	/// </remarks>
	/// <param name="tags">Теги.</param>
	/// <returns>Возвращает <see cref="SiblingsAndParentsResponse" /> с братьями и сестрами.</returns>
	Task<SiblingsAndParentsResponse> GetSiblingsAndParents(params string[] tags);

	/// <summary>
	///     Отправляет запрос для получения родителей и сестер.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.EditFileTags" />,
	/// </remarks>
	/// <param name="tags">Теги.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="SiblingsAndParentsResponse" /> с братьями и сестрами.</returns>
	Task<SiblingsAndParentsResponse> GetSiblingsAndParents(IEnumerable<string> tags, CancellationToken cancel = default);

	/// <summary>
	///     Отправляет запрос для поиска тегов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.EditFileTags" />,
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="search">Запрос для поиска, формат такой же как и для интерфейса Hydrus.</param>
	/// <param name="fileDomain">Файловый домен.</param>
	/// <param name="tagServiceKey">Ключ домена тегов в котором выполняется поиск. По умолчанию - "all known tags".</param>
	/// <param name="tagDisplayType">Указывает на то, следует ли выполнять поиск по необработанным или обработанным тегам.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="TagsSearchResponse" /> с найденными тегами.</returns>
	Task<TagsSearchResponse> SearchTags(string search, FileDomain? fileDomain, string? tagServiceKey, TagDisplay tagDisplayType = TagDisplay.Storage, CancellationToken cancel = default);
}
