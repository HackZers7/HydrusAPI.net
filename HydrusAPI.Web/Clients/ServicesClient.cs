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
        ThrowHelper.ArgumentNotNullOrWhiteSpace(name);

        return ApiConnection.Get<ServiceResponse>(HydrusUrls.GetServiceByName(name), cancel);
    }

    /// <inheritdoc />
    public Task<ServiceResponse> GetServiceByKey(string key, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(key);

        return ApiConnection.Get<ServiceResponse>(HydrusUrls.GetServiceByKey(key), cancel);
    }

    /// <inheritdoc />
    public Task<ServicesResponse> GetServices(CancellationToken cancel = default)
    {
        return ApiConnection.Get<ServicesResponse>(HydrusUrls.GetServices(), cancel);
    }

    /// <inheritdoc />
    public Task<PendingCountsResponse> GetPendingCounts(CancellationToken cancel = default)
    {
        return ApiConnection.Get<PendingCountsResponse>(HydrusUrls.GetPendingCounts(), cancel);
    }

    /// <inheritdoc />
    public async Task CommitPending(string serviceKey, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(serviceKey);

        await ApiConnection.Post(HydrusUrls.CommitPending(), null, new ServiceKeyRequest(serviceKey), cancel);
    }

    /// <inheritdoc />
    public async Task ForgetPending(string serviceKey, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNullOrWhiteSpace(serviceKey);

        await ApiConnection.Post(HydrusUrls.ForgetPending(), null, new ServiceKeyRequest(serviceKey), cancel);
    }
}
