namespace HydrusAPI.Web.Http;

/// <summary>
///     Базовый ответ от API.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ApiResponse<T> : IApiResponse<T>
{
	/// <summary>
	///     Инициализирует новый экземпляр ответа.
	/// </summary>
	/// <param name="response">Ответ.</param>
	/// <param name="body">Тело ответа.</param>
	public ApiResponse(IResponse response, T? body = default)
	{
		ThrowHelper.ArgumentNotNull(response);

		Body = body;
		Response = response;
	}

	/// <inheritdoc />
	public T? Body { get; }

	/// <inheritdoc />
	public IResponse Response { get; }
}
