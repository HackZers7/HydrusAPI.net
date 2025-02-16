namespace HydrusAPI.Web;

/// <summary>
///     Запрос получения количества оставшихся потенциальных пар дубликатов.
/// </summary>
public class GetPotentialsRequest : FilesRequest
{
	/// <summary>
	///     Необязательно, ключ сервисов тегов.
	/// </summary>
	/// <remarks>
	///     По умолчанию - "all known tags".
	/// </remarks>
	public string? TagServiceKey1 { get; set; }

	/// <summary>
	///     Необязательно, теги для поиска.
	/// </summary>
	/// <remarks>
	///     Значение определено как объект потому что может содержать как строковое значение, так и другую коллекцию с тегами.
	/// </remarks>
	public List<object>? Tags1 { get; set; }

	/// <summary>
	///     Необязательно, ключ сервисов тегов.
	/// </summary>
	/// <remarks>
	///     По умолчанию - "all known tags".
	/// </remarks>
	public string? TagServiceKey2 { get; set; }

	/// <summary>
	///     Необязательно, теги для поиска.
	/// </summary>
	/// <remarks>
	///     Значение определено как объект потому что может содержать как строковое значение, так и другую коллекцию с тегами.
	/// </remarks>
	public List<object>? Tags2 { get; set; }

	/// <summary>
	///     Необязательно, как пары должны соответствовать поиску.
	/// </summary>
	/// <remarks>
	///     По умолчанию - <see cref="PotentialsSearchTypes.OneFileMatchesSearch" />.
	/// </remarks>
	public int PotentialsSearchType { get; set; } = (int)PotentialsSearchTypes.OneFileMatchesSearch;

	/// <summary>
	///     Необязательно, должны ли пары быть пиксельными дубликатами.
	/// </summary>
	/// <remarks>
	///     По умолчанию - <see cref="PixelDuplicateTypes.CanBePixelDuplicates" />.
	/// </remarks>
	public int PixelDuplicates { get; set; } = (int)PixelDuplicateTypes.CanBePixelDuplicates;

	/// <summary>
	///     Необязательно, максимальное "расстояние поиска" пар.
	/// </summary>
	/// <remarks>
	///     По умолчанию - 4.
	/// </remarks>
	public int MaxHammingDistance { get; set; } = (int)PixelDuplicateTypes.CanBePixelDuplicates;
}

/// <summary>
///     Потенциальные типы для поиска.
/// </summary>
public enum PotentialsSearchTypes
{
	/// <summary>
	///     One file matches search 1.
	/// </summary>
	OneFileMatchesSearch = 0,

	/// <summary>
	///     Both files match search 1.
	/// </summary>
	BothFilesMatchSearch = 1,

	/// <summary>
	///     One file matches search 1, the other 2.
	/// </summary>
	OneFileMatchesSearchOther = 2
}

/// <summary>
///     Потенциальные дубликаты пикселей.
/// </summary>
public enum PixelDuplicateTypes
{
	/// <summary>
	///     Must be pixel duplicates.
	/// </summary>
	MustBePixelDuplicates = 0,

	/// <summary>
	///     Can be pixel duplicates.
	/// </summary>
	CanBePixelDuplicates = 1,

	/// <summary>
	///     Must not be pixel duplicates.
	/// </summary>
	MustNotBePixelDuplicates = 2
}
