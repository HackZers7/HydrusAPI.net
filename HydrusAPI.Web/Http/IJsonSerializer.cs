namespace HydrusAPI.Web.Http;

/// <summary>
///     Представляет сериализатор JSON.
/// </summary>
public interface IJsonSerializer
{
	/// <summary>
	///     Сериализирует запрос.
	/// </summary>
	/// <param name="request">Запрос.</param>
	void SerializeRequest(IRequest request);

	/// <summary>
	///     Десериализует ответ.
	/// </summary>
	/// <param name="response">Ответ.</param>
	/// <typeparam name="T">Тип к которому нужно привести ответ.</typeparam>
	/// <returns>Десериализованный объект.</returns>
	IApiResponse<T> DeserializeResponse<T>(IResponse response);
}
