namespace HydrusAPI.Web;

/// <summary>
///     Запрос на удаление файлов.
/// </summary>
public class DeleteFilesRequest : FilesWithDomainRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <param name="reason">Причина удаления.</param>
	public DeleteFilesRequest(string hash, string? reason = null) : base(hash)
	{
		Reason = reason;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	/// <param name="reason">Причина удаления.</param>
	public DeleteFilesRequest(ulong id, string? reason = null) : base(id)
	{
		Reason = reason;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	/// <param name="reason">Причина удаления.</param>
	public DeleteFilesRequest(IList<string> hashes, string? reason = null) : base(hashes)
	{
		Reason = reason;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Идентификаторы файлов.</param>
	/// <param name="reason">Причина удаления.</param>
	public DeleteFilesRequest(IList<ulong> fileIds, string? reason = null) : base(fileIds)
	{
		Reason = reason;
	}

	/// <summary>
	///     Причина удаления.
	/// </summary>
	public string? Reason { get; set; }
}
