namespace HydrusAPI.Web;

/// <summary>
///     Хэш.
/// </summary>
public abstract class HashRequest : FileDomain
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	protected HashRequest(params string[] hashes)
	{
		Hashes = new List<string>(hashes);
	}
	
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	protected HashRequest(IEnumerable<string> hashes)
	{
		Hashes = new List<string>(hashes);
	}

	/// <summary>
	///     Коллекция хэшей.
	/// </summary>
	public List<string> Hashes { get; }
}
