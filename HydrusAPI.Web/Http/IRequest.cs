namespace HydrusAPI.Web.Http;

/// <summary>
///     Представляет http запрос.
/// </summary>
public interface IRequest
{
	/// <summary>
	///     Возвращает базовый адрес клиента.
	/// </summary>
	Uri BaseAddress { get; }

	/// <summary>
	///     Возвращает эндпоинт сервиса.
	/// </summary>
	Uri Endpoint { get; }

	/// <summary>
	///     Возвращает заголовки.
	/// </summary>
	IDictionary<string, string> Headers { get; }

	/// <summary>
	///     Возвращает параметры.
	/// </summary>
	IDictionary<string, string> Parameters { get; }

	/// <summary>
	///     Возвращает метод запроса.
	/// </summary>
	HttpMethod Method { get; }

	/// <summary>
	///     Возвращает тело запроса.
	/// </summary>
	object? Body { get; set; }

	/// <summary>
	///     Возвращает таймаут.
	/// </summary>
	TimeSpan Timeout { get; }

	/// <summary>
	///     Возвращает тип контента.
	/// </summary>
	string? ContentType { get; }
}
