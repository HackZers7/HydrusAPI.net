namespace HydrusAPI.Web;

/// <summary>
///     Запрос на очистку информации об удалении файлов.
/// </summary>
public class ClearFilesDeletionRequest : Files
{
	/// <summary>
	///     Конструктор по умолчанию.
	/// </summary>
	public ClearFilesDeletionRequest()
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	public ClearFilesDeletionRequest(IEnumerable<string> hashes)
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
	public ClearFilesDeletionRequest(IEnumerable<ulong> fileIds)
	{
		foreach (var id in fileIds)
		{
			AddId(id);
		}
	}
}
