namespace HydrusAPI.Web;

/// <summary>
///     Ответ со всеми локальными хранилищами Hydrus.
/// </summary>
public class LocalFileStorageLocationsResponse : ApiVersionResponse
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

	/// <summary>
	/// 	Обратите внимание, что значения указано из вежливости и не означают ничего фиксированного. 
	///		В каждом хранилище может храниться все, что угодно, миниатюры или файлы, или ничего, независимо от идеальной ситуации. 
	/// 	Всякий раз, когда папка неидеальна, в диалоговом окне "move media files" отображается сообщение "files need to be moved now", но оно все равно будет продолжать выполнять свою работу.
	/// </summary>
	public int IdealWeight { get; set; }

	/// <summary>
	/// 	Обратите внимание, что значения указано из вежливости и не означают ничего фиксированного. 
	///		В каждом хранилище может храниться все, что угодно, миниатюры или файлы, или ничего, независимо от идеальной ситуации. 
	/// 	Всякий раз, когда папка неидеальна, в диалоговом окне "move media files" отображается сообщение "files need to be moved now", но оно все равно будет продолжать выполнять свою работу.
	/// </summary>
	public ulong? MaxNumBytes { get; set; }

	/// <summary>
	///     Префиксы.
	/// </summary>
	public List<string> Prefixes { get; set; } = new();
}
