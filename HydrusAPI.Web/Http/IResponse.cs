using System.Net;

namespace HydrusAPI.Web.Http;

/// <summary>
///     Представляет ответ от API.
/// </summary>
public interface IResponse
{
	/// <summary>
	///     Возвращает необработанное тело ответа. Обычно это строка, но при запросе изображений или файлов это будет поток (Stream).
	/// </summary>
	object? Body { get; }

	/// <summary>
	///     Возвращает заголовки.
	/// </summary>
	IReadOnlyDictionary<string, string> Headers { get; }

	/// <summary>
	///     Возвращает код статуса ответа.
	/// </summary>
	HttpStatusCode StatusCode { get; }

	/// <summary>
	///     Возвращает тип содержимого ответа.
	/// </summary>
	string? ContentType { get; }
}
