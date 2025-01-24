namespace HydrusAPI.Web.Http;

/// <summary>
///     Предоставляет метод для применения аутентификации к запросу.
/// </summary>
public interface IAuthenticator
{
	/// <summary>
	///     Применяет аутентификацию к запросу.
	/// </summary>
	/// <param name="request">Запрос.</param>
	/// <param name="apiConnection">Подключение.</param>
	Task Apply(IRequest request, IApiConnection apiConnection);
}
