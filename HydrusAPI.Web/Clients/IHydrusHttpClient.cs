namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы с http запросами Hydrus.
/// </summary>
public interface IHydrusHttpClient
{
	/// <summary>
	///     Получает куки установленные у домена.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManageCookiesHeaders" />.
	/// </remarks>
	/// <param name="domain">Домен сайта.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Коллекция с куки.</returns>
	Task<List<List<object?>>> GetCookies(string domain, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает куки.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManageCookiesHeaders" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetCookies(SetCookiesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Получает глобальные заголовки. 
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManageCookiesHeaders" />.
	/// </remarks>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Коллекция с куки.</returns>
	Task<HeadersResponse> GetHeaders(CancellationToken cancel = default);

	/// <summary>
	///     Получает заголовки для домена. 
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManageCookiesHeaders" />.
	/// </remarks>
	/// <param name="domain">Домен сайта.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Коллекция с куки.</returns>
	Task<HeadersResponse> GetHeaders(string domain, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает заголовки.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManageCookiesHeaders" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetHeaders(SetHeadersRequest request, CancellationToken cancel = default);
}
