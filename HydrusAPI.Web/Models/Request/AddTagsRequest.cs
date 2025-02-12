namespace HydrusAPI.Web;

/// <summary>
///     Запрос добавления тегов к файлу.
/// </summary>
public class AddTagsRequest : FilesRequest
{
	/// <summary>
	///     Словарь с тегами, где ключом является идентификатор сервиса, а значением коллекция тегов.
	/// </summary>
	public Dictionary<string, List<string>>? ServiceKeysToTags { get; set; }

	/// <summary>
	///     Словарь с действиями, где первым ключом является идентификатор сервиса, а вторым тип действия (рекомендуется использовать <see cref="ActionTypes" />). Значение - коллекция тегов.
	///     <remarks>
	///         Значение определено как объект потому что может содержать как строковое значение, так и другую коллекцию с тегами.
	///     </remarks>
	/// </summary>
	public Dictionary<string, Dictionary<int, List<object>>>? ServiceKeysToActionsToTags { get; set; }

	/// <summary>
	///     Перезаписать предыдущие удаленный мэппинг.
	///     <remarks>
	///         По умолчанию - true.
	///     </remarks>
	/// </summary>
	public bool OverridePreviouslyDeletedMappings { get; set; } = true;

	/// <summary>
	///     Создать новый удаленный мэппинг.
	///     <remarks>
	///         По умолчанию - true.
	///     </remarks>
	/// </summary>
	public bool CreateNewDeletedMappings { get; set; } = true;
}
