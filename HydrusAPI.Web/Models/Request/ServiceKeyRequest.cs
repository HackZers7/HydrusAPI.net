namespace HydrusAPI.Web;

/// <summary>
///     Запрос по ключу сервиса.
/// </summary>
public class ServiceKeyRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="serviceKey">Ключ сервиса.</param>
	public ServiceKeyRequest(string serviceKey)
	{
		ServiceKey = serviceKey;
	}

	/// <summary>
	///     Ключ сервиса.
	/// </summary>
	public string ServiceKey { get; }
}
