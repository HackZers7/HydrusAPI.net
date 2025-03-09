namespace HydrusAPI.Web;

/// <summary>
///     Представляет файлы Hydrus.
/// </summary>
public class FileRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	public FileRequest(string hash)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		Hash = hash;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	public FileRequest(ulong id)
	{
		ThrowHelper.ArgumentOutOfRange(id, (ulong)0, ulong.MaxValue);

		FileId = id;
	}

	/// <summary>
	///     Хэш (SHA256) файла.
	/// </summary>
	public string? Hash { get; set; }

	/// <summary>
	///     Идентификатор файла.
	/// </summary>
	public ulong? FileId { get; set; }
}
