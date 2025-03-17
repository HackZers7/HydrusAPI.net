namespace HydrusAPI.Web.Http;

/// <summary>
///     Ответ от API.
/// </summary>
/// <typeparam name="T">Тело ответа.</typeparam>
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
