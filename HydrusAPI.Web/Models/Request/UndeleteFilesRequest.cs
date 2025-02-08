namespace HydrusAPI.Web;

/// <summary>
///     Запрос на отмену удаления файлов.
/// </summary>
public class UndeleteFilesRequest : FilesAndFilesDomain
{
	/// <summary>
	///     Конструктор по умолчанию.
	/// </summary>
	public UndeleteFilesRequest()
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	public UndeleteFilesRequest(IEnumerable<string> hashes)
	{
		foreach (var hash in hashes)
		{
			AddHash(hash);
		}
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Идентификаторы файлов.</param>
	public UndeleteFilesRequest(IEnumerable<ulong> fileIds)
	{
		foreach (var id in fileIds)
		{
			AddId(id);
		}
	}
}
