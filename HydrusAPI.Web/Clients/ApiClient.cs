using DS.Shared;
using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Базовый класс для API клиента.
/// </summary>
public abstract class ApiClient
{
	/// <summary>
	///     Инициализирует новый экземпляр API клиента.
	/// </summary>
	/// <param name="apiConnection">Подключение клиента.</param>
	protected ApiClient(IApiConnection apiConnection)
	{
		ThrowHelper.ArgumentNotNull(apiConnection);

		ApiConnection = apiConnection;
	}

	/// <summary>
	///     Возвращает подключение к API.
	/// </summary>
	protected IApiConnection ApiConnection { get; private set; }
}
