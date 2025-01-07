using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Представляет ошибку, возникающую при запросе к API.
/// </summary>
[Serializable]
public class ApiException : Exception
{
	/// <summary>
	///     Инициирует новый экземпляр класса ошибок API.
	/// </summary>
	public ApiException()
	{
	}

	/// <summary>
	///     Инициирует новый экземпляр класса ошибок API.
	/// </summary>
	/// <param name="response">Ответ.</param>
	public ApiException(IResponse response) : base(GetApiErrorFromExceptionMessage(response))
	{
		Response = response;
	}

	/// <summary>
	///     Инициирует новый экземпляр класса ошибок API.
	/// </summary>
	/// <param name="message">Сообщение.</param>
	public ApiException(string message) : base(message)
	{
	}

	/// <summary>
	///     Инициирует новый экземпляр класса ошибок API.
	/// </summary>
	/// <param name="message">Сообщение.</param>
	/// <param name="innerException">Внутренняя ошибка.</param>
	public ApiException(string message, Exception innerException) : base(message, innerException)
	{
	}

	/// <summary>
	///     Возвращает ответ, содержащий ошибку.
	/// </summary>
	public IResponse? Response { get; }

	private static string? GetApiErrorFromExceptionMessage(IResponse response)
	{
		var responseBody = response != null ? response.Body as string : null;
		return GetApiErrorFromExceptionMessage(responseBody);
	}

	private static string? GetApiErrorFromExceptionMessage(string? responseContent)
	{
		throw new NotImplementedException();
	}
}
