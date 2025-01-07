namespace HydrusAPI.Web.Http;

public interface IApiResponse<out T>
{
	/// <summary>
	///     Возвращает десериализованный объект.
	/// </summary>
	T? Body { get; }

	/// <summary>
	///     Исходный, не десериализованный HTTP-ответ.
	/// </summary>
	IResponse Response { get; }
}
