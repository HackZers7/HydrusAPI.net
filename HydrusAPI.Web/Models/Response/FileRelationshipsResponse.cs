namespace HydrusAPI.Web;

/// <summary>
///     Связи файлов.
/// </summary>
public class FileRelationshipsResponse : ApiVersion
{
	/// <summary>
	///     Словарь со связями файла, где первый ключ - хэш (SHA256) файл, а второй свойство.
	/// </summary>
	/// <remarks>
	///     API возвращает "числовые" названия некоторый свойств, что трудно прочитать автоматически методами.
	/// </remarks>
	public Dictionary<string, Dictionary<string, object>>? FileRelationships { get; set; }
}

// TODO: Добавить структурированный тип

/// <summary>
///     Связи файлов.
/// </summary>
public class FileRelationships
{
	/// <summary>
	///     Это лучший файл.
	/// </summary>
	public bool IsKing { get; set; }

	/// <summary>
	///     Лучший файл из группы дубликатов.
	/// </summary>
	public string King { get; set; } = default!;

	/// <summary>
	///     Лучший в его домене.
	/// </summary>
	public bool KingIsOnFileDomain { get; set; }

	/// <summary>
	///     Лучший существует на сервере.
	/// </summary>
	public bool KingIsLocal { get; set; }
}
