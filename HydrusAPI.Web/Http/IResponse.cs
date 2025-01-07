using System.Net;

namespace HydrusAPI.Web.Http;

/// <summary>
///     Представляет ответ от API.
/// </summary>
public interface IResponse
{
	/// <summary>
	///     Необработанное тело ответа. Обычно это строка, но при запросе изображений или файлов это будет поток (Stream).
	/// </summary>
	object? Body { get; }

	IReadOnlyDictionary<string, string> Headers { get; }

	/// <summary>
	///     Код статуса ответа.
	/// </summary>
	HttpStatusCode StatusCode { get; }

	/// <summary>
	///     Тип содержимого ответа.
	/// </summary>
	string? ContentType { get; }
}
