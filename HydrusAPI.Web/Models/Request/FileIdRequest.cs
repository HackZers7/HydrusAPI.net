namespace HydrusAPI.Web;

/// <summary>
///     Запрос по идентификаторам.
/// </summary>
public abstract class FileIdRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	protected FileIdRequest(params ulong[] hashes)
	{
		FileIds = new List<ulong>(hashes);
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	protected FileIdRequest(IEnumerable<ulong> hashes)
	{
		FileIds = new List<ulong>(hashes);
	}

	/// <summary>
	///     Коллекция идентификаторов.
	/// </summary>
	public List<ulong> FileIds { get; }
}
