namespace HydrusAPI.Web;

/// <summary>
///     Запрос на удаление файлов.
/// </summary>
public class DeleteFilesRequest : FilesWithDomainRequest
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
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	/// <param name="reason">Причина удаления.</param>
	public DeleteFilesRequest(IEnumerable<string> hashes, string? reason) : base(hashes)
	{
		Reason = reason;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Идентификаторы файлов.</param>
	/// <param name="reason">Причина удаления.</param>
	public DeleteFilesRequest(IEnumerable<ulong> fileIds, string? reason) : base(fileIds)
	{
		Reason = reason;
	}

	/// <summary>
	///     Причина удаления.
	/// </summary>
	public string? Reason { get; set; }
}
