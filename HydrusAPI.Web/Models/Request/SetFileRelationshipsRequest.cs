namespace HydrusAPI.Web;

/// <summary>
///     Запрос добавления связи.
/// </summary>
public class SetFileRelationshipsRequest
{
	/// <summary>
	/// 	Инициализирует новый экземпляр класса. 
	/// </summary>
	/// <param name="relationships">Коллекция связей.</param>
	public SetFileRelationshipsRequest(IList<Relationships> relationships)
	{
		ThrowHelper.ArgumentNotNull(relationships);

		Relationships = relationships;
	}

	/// <summary>
	///     Коллекция связей.
	/// </summary>
	public IList<Relationships> Relationships { get; set; }
}

/// <summary>
///     Связь
/// </summary>
public class Relationships
{
	/// <summary>
	/// Инициализирует новый экземпляр класса. 
	/// </summary>
	/// <param name="hashA">Хэш (SHA256) файла.</param>
	/// <param name="hashB">Хэш (SHA256) файла.</param>
	/// <param name="relationships">Тип связи.</param>
	public Relationships(string hashA, string hashB, RelationshipsType relationships)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hashA);
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hashB);

		HashA = hashA;
		HashB = hashB;
		Relationship = relationships;
	}

	/// <summary>
	///     Хэш (SHA256) файла.
	/// </summary>
	public string HashA { get; set; } = default!;

	/// <summary>
	///     Хэш (SHA256) файла.
	/// </summary>
	public string HashB { get; set; } = default!;

	/// <summary>
	///     Тип связи.
	/// </summary>
	public RelationshipsType Relationship { get; set; }

	/// <summary>
	///     Следует ли загружать пользовательские параметры слияния дублирующегося содержимого и применять их к файлам вместе со связью.
	/// </summary>
	/// <remarks>
	///     По умолчанию - true.
	///     Большинство операций в клиенте выполняются автоматически, но если вы хотите выполнить слияние содержимого самостоятельно, установите для этого параметра значение false.
	/// </remarks>
	public bool DoDefaultContentMerge { get; set; } = true;

	/// <summary>
	///     Удалить после операции.
	/// </summary>
	/// <remarks>
	///     По умолчанию - false.
	/// </remarks>
	public bool DeleteA { get; set; } = false;

	/// <summary>
	///     Удалить после операции.
	/// </summary>
	/// <remarks>
	///     По умолчанию - false.
	/// </remarks>
	public bool DeleteB { get; set; } = false;
}

/// <summary>
///     Тип связи.
/// </summary>
public enum RelationshipsType
{
	/// <summary>
	///     Set as potential duplicates.
	/// </summary>
	PotentialDuplicates = 0,

	/// <summary>
	///     Set as false positives.
	/// </summary>
	FalsePositivesDuplicates = 1,

	/// <summary>
	///     Set as same quality.
	/// </summary>
	SameQuality = 2,

	/// <summary>
	///     Set as alternates.
	/// </summary>
	Alternates = 3,

	/// <summary>
	///     Set A as better.
	/// </summary>
	AIsBetter = 4,

	/// <summary>
	///     Set B as better.
	/// </summary>
	BIsBetter = 7
}
