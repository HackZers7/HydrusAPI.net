namespace HydrusAPI.Web;

/// <summary>
///     Запрос на удаление файлов.
/// </summary>
public class DeleteFilesByHashRequest : HashRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hash">Хэш в формате SHA256.</param>
	/// <param name="fileDomain">Домен файла. По умолчанию - "quiet".</param>
	/// <param name="reason">Причина удаления.</param>
	public DeleteFilesByHashRequest(string hash, string? fileDomain = null, string? reason = null) : this(new[] { hash }, fileDomain, reason)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Хэши в формате SHA256.</param>
	public DeleteFilesByHashRequest(params string[] hashes) : this(hashes, null)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Хэши в формате SHA256.</param>
	/// <param name="fileDomain">Домен файла. По умолчанию - "quiet".</param>
	/// <param name="reason">Причина удаления.</param>
	public DeleteFilesByHashRequest(IEnumerable<string> hashes, string? fileDomain = null, string? reason = null) : base(hashes)
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
