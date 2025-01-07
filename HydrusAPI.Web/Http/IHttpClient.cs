namespace HydrusAPI.Web.Http;

/// <summary>
///     Представляет HTTP клиент.
/// </summary>
public interface IHttpClient : IDisposable
{
	/// <summary>
	///     Посылает запрос и возвращает ответ.
	/// </summary>
	/// <param name="request">Представляет запрос, который будет отправлен.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Представляет ответ на запрос.</returns>
	Task<IResponse> Send(IRequest request, CancellationToken cancel = default);


	/// <summary>
	///     Устанавливает таймаут для подключения.
	/// </summary>
	/// <param name="timeout">Время ожидания.</param>
	void SetRequestTimeout(TimeSpan timeout);
}
