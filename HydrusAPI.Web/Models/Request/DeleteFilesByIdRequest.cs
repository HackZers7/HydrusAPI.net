namespace HydrusAPI.Web;

/// <summary>
///     Запрос на удаление файлов.
/// </summary>
public class DeleteFilesByIdRequest : FileIdRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	/// <param name="fileDomain">Домен файла. По умолчанию - "quiet".</param>
	/// <param name="reason">Причина удаления.</param>
	public DeleteFilesByIdRequest(ulong id, string? fileDomain = null, string? reason = null) : this(new[] { id }, fileDomain, reason)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="ids">Идентификаторы файлов.</param>
	public DeleteFilesByIdRequest(params ulong[] ids) : this(ids, null)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <param name="fileDomain">Домен файла. По умолчанию - "quiet".</param>
	/// <param name="reason">Причина удаления.</param>
	public DeleteFilesByIdRequest(IEnumerable<ulong> ids, string? fileDomain = null, string? reason = null) : base(ids)
	{
		FileDomain = fileDomain;
		Reason = reason;
	}
	
	// TODO: Реализовать правильный FileDomain

	/// <summary>
	///     Домен файла. По умолчанию - "my files".
	/// </summary>
	public string? FileDomain { get; set; }

	/// <summary>
	///     Причина удаления
	/// </summary>
	public string? Reason { get; set; }
}
