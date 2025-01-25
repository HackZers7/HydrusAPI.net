using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент для работы с сервисами.
/// </summary>
public class ServicesClient : ApiClient, IServicesClient
{
	/// <inheritdoc />
	public ServicesClient(IApiConnection apiConnection) : base(apiConnection)
	{
	}

	/// <inheritdoc />
	public Task<ServiceResponse> GetServiceByName(string name, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(name);

		return ApiConnection.Get<ServiceResponse>(HydrusUrls.GetServiceByName(name), cancel);
	}

	/// <inheritdoc />
	public Task<ServiceResponse> GetServiceByKey(string key, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(key);

		return ApiConnection.Get<ServiceResponse>(HydrusUrls.GetServiceByKey(key), cancel);
	}

	/// <inheritdoc />
	public Task<ServicesResponse> GetServices(CancellationToken cancel = default)
	{
		return ApiConnection.Get<ServicesResponse>(HydrusUrls.GetServices(), cancel);
	}
}
