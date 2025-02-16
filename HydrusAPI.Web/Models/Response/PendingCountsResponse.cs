namespace HydrusAPI.Web;

/// <summary>
///     Ответ ожидающих загрузки материалов для каждого сервиса.
/// </summary>
public class PendingCountsResponse : ServicesResponse
{
	/// <summary>
	///     Ожидающие загрузки материалы для каждого сервиса.
	/// </summary>
	public Dictionary<string, PendingCounts>? PendingCounts { get; set; }
}

/// <summary>
///     Ожидающие загрузки материалы для сервиса.
/// </summary>
public class PendingCounts
{
	/// <summary>
	///     Ожидающие сопоставления теги.
	/// </summary>
	public ulong PendingTagMappings { get; set; }

	/// <summary>
	///     Запрошенные сопоставления теги.
	/// </summary>
	public ulong PetitionedTagMappings { get; set; }

	/// <summary>
	///     Ожидающие братья и сестры.
	/// </summary>
	public ulong PendingTagSiblings { get; set; }

	/// <summary>
	///     Запрошенные братья и сестры.
	/// </summary>
	public ulong PetitionedTagSiblings { get; set; }

	/// <summary>
	///     Ожидающие родители тега.
	/// </summary>
	public ulong PendingTagParents { get; set; }

	/// <summary>
	///     Запрошенные родители тега.
	/// </summary>
	public ulong PetitionedTagParents { get; set; }

	/// <summary>
	///     Ожидающие файлы.
	/// </summary>
	public ulong PendingFiles { get; set; }

	/// <summary>
	///     Запрошенные файлы.
	/// </summary>
	public ulong PetitionedFiles { get; set; }
}
