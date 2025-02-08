namespace HydrusAPI.Web;

/// <summary>
///     Запрос на удаление файлов.
/// </summary>
public class DeleteFilesRequest : Files
{
	/// <summary>
	///     Конструктор по умолчанию.
	/// </summary>
	public DeleteFilesRequest()
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <param name="reason">Причина удаления.</param>
	public DeleteFilesRequest(IEnumerable<string> hashes, string? reason)
	{
		Reason = reason;
		foreach (var hash in hashes)
		{
			AddHash(hash);
		}
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Идентификаторы файлов.</param>
	/// <param name="reason">Причина удаления.</param>
	public DeleteFilesRequest(IEnumerable<ulong> fileIds, string? reason)
	{
		Reason = reason;
		foreach (var id in fileIds)
		{
			AddId(id);
		}
	}

	/// <summary>
	///     Причина удаления
	/// </summary>
	public string? Reason { get; set; }
}
