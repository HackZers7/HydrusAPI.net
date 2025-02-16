namespace HydrusAPI.Web;

/// <summary>
///     Ответ со всеми локальными хранилищами Hydrus.
/// </summary>
public class LocalFileStorageLocationsResponse : ApiVersion
{
	/// <summary>
	///     Коллекция хранилищ.
	/// </summary>
	public List<StorageLocation> Locations { get; set; } = default!;
}

/// <summary>
///     Описание хранилища.
/// </summary>
public class StorageLocation
{
	/// <summary>
	///     Путь к хранилищу.
	/// </summary>
	public string Path { get; set; } = default!;

	public int IdealWeight { get; set; }

	public ulong? MaxNumBytes { get; set; }

	/// <summary>
	///     Префиксы.
	/// </summary>
	public List<string> Prefixes { get; set; }
}
