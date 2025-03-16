using Newtonsoft.Json;

namespace HydrusAPI.Web;

/// <summary>
///     Связи файлов.
/// </summary>
public class FileRelationshipsResponse : ApiVersionResponse
{
	/// <summary>
	///     Словарь со связями файла, где первый ключ - хэш (SHA256) файл, а второй свойство.
	/// </summary>
	public Dictionary<string, FileRelationships> FileRelationships { get; set; } = new();
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

	/// <summary>
	/// 	Потенциальные дубликаты.
	/// </summary>
	[JsonProperty("0")]
	public List<string> PotentialDuplicates { get; set; } = new();

	/// <summary>
	/// 	Отрицательные срабатывания.
	/// </summary>
	[JsonProperty("1")]
	public List<string> FalsePositives { get; set; } = new();

	/// <summary>
	/// 	Альтернативы.
	/// </summary>
	[JsonProperty("3")]
	public List<string> Alternates { get; set; } = new();

	/// <summary>
	/// 	Дубликаты.
	/// </summary>
	[JsonProperty("8")]
	public List<string> Duplicates { get; set; } = new();
}
