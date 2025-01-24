using System.Collections.ObjectModel;
using System.Net;

namespace HydrusAPI.Web.Http;

/// <summary>
///     Представляет http ответ.
/// </summary>
public class Response : IResponse
{
	/// <summary>
	///     Инициализирует новый экземпляр ответа.
	/// </summary>
	/// <param name="headers">Заголовки ответа.</param>
	public Response(IDictionary<string, string> headers)
	{
		ThrowHelper.ArgumentNotNull(headers);

		Headers = new ReadOnlyDictionary<string, string>(headers);
	}

	/// <summary>
	///     Инициализирует новый экземпляр ответа.
	/// </summary>
	/// <param name="statusCode">Статус ответа.</param>
	/// <param name="body">Необработанное тело.</param>
	/// <param name="headers">Заголовки ответа.</param>
	/// <param name="contentType">Тип контента.</param>
	public Response(HttpStatusCode statusCode, object? body, IDictionary<string, string> headers, string? contentType)
	{
		ThrowHelper.ArgumentNotNull(headers);

		StatusCode = statusCode;
		Body = body;
		Headers = new ReadOnlyDictionary<string, string>(headers);
		ContentType = contentType;
	}

	/// <inheritdoc />
	public object? Body { get; set; }

	/// <inheritdoc />
	public IReadOnlyDictionary<string, string> Headers { get; set; }

	/// <inheritdoc />
	public HttpStatusCode StatusCode { get; set; }

	/// <inheritdoc />
	public string? ContentType { get; set; }
}
