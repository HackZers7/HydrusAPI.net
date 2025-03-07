namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы с тегами.
/// </summary>
public interface ITagsClient
{
	/// <summary>
	///     Приводит теги к формату определенным в Hydrus.
	///     В большинстве случаев Hydrus просто удаляет лишние пробелы, но другие примеры - это редкие проблемы, с которыми вы можете столкнуться. 
	/// 	"system" - это недопустимое пространство имен, теги не могут начинаться с дефиса, и любой тег, начинающийся с ":", обрабатывается как "[нет пространства имен]:[двоеточие с префиксом подзаголовка]". 
	///		Опять же, вы, вероятно, с этим не столкнетесь, но если вы где-то видите несоответствие и хотите разобраться в нем или просто хотите отсортировать некоторые пронумерованные теги, вы можете использовать очистку.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTags" />.
	/// </remarks>
	/// <param name="tags">Коллекция тегов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает перечисление с очищенными тегами.</returns>
	Task<TagsResponse> CleanTags(IList<string> tags, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает родителей и сестер тега.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTags" />,
	/// </remarks>
	/// <param name="tags">Коллекция тегов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="SiblingsAndParentsResponse" /> с братьями и сестрами.</returns>
	Task<SiblingsAndParentsResponse> GetSiblingsAndParents(IList<string> tags, CancellationToken cancel = default);

	/// <summary>
	///     Производит поиск тегов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуются все области видимости (разрешения):
	///     <see cref="Permissions.EditFileTags" />,
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="search">Запрос для поиска, формат такой же как и для интерфейса Hydrus.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="TagsSearchResponse" /> с найденными тегами.</returns>
	Task<TagsSearchResponse> SearchTags(string search, CancellationToken cancel = default);

	/// <summary>
	///     Производит поиск тегов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуются все области видимости (разрешения):
	///     <see cref="Permissions.EditFileTags" />,
	///     <see cref="Permissions.SearchFetchFiles" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="TagsSearchResponse" /> с найденными тегами.</returns>
	Task<TagsSearchResponse> SearchTags(SearchTagsRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Добавляет теги к файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTags" />.
	/// </remarks>
	/// <param name="request">Запрос для добавления тегов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task AddTags(AddTagsRequest request, CancellationToken cancel = default);
}
