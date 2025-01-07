namespace HydrusAPI.Web;

/// <summary>
///     Класс для получения <see cref="Uri" />-адресов Hydrus API.
/// </summary>
public static class HydrusUrls
{
	/// <summary>
	/// Возвращает <see cref="Uri" />, которое соответствует локальному адресу сервера Hydrus.
	/// </summary>
	public static readonly Uri DefaultLocalhost = new Uri("http://127.0.0.1:45869/");
	
	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения версии API.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта версии API.</returns>
	public static Uri ApiVersion()
	{
		return "/api_version".FormatUri();
	}
}
