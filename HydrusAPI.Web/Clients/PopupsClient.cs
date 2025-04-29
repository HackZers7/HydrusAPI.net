using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент для работы со всплывающими окнами Hydrus.
/// </summary>
public class PopupsClient : ApiClient, IPopupsClient
{
    /// <inheritdoc />
    public PopupsClient(IApiConnection apiConnection) : base(apiConnection)
    {
    }

    /// <inheritdoc />
    public Task<JobStatusesResponse> GetPopups(bool onlyInView = false, CancellationToken cancel = default)
    {
        return ApiConnection.Get<JobStatusesResponse>(HydrusUrls.GetPopups(onlyInView), cancel);
    }

    /// <inheritdoc />
    public Task<JobStatusResponse> AddPopup(JobStatus request, CancellationToken cancel = default)
    {
        return ApiConnection.Post<JobStatusResponse>(HydrusUrls.AddPopup(), null, request, cancel);
    }

    /// <inheritdoc />
    public Task CallUserCallable(string jobStatusKey, CancellationToken cancel = default)
    {
        return ApiConnection.Post(HydrusUrls.CallUserCallable(), null, new JobStatusKeyRequest(jobStatusKey), cancel);
    }

    /// <inheritdoc />
    public Task CancelPopup(string jobStatusKey, CancellationToken cancel = default)
    {
        return ApiConnection.Post(HydrusUrls.CancelPopup(), null, new JobStatusKeyRequest(jobStatusKey), cancel);
    }

    /// <inheritdoc />
    public Task DismissPopup(string jobStatusKey, CancellationToken cancel = default)
    {
        return ApiConnection.Post(HydrusUrls.DismissPopup(), null, new JobStatusKeyRequest(jobStatusKey), cancel);
    }

    /// <inheritdoc />
    public Task TaskFinishPopup(string jobStatusKey, CancellationToken cancel = default)
    {
        return ApiConnection.Post(HydrusUrls.FinishPopup(), null, new JobStatusKeyRequest(jobStatusKey), cancel);
    }

    /// <inheritdoc />
    public Task FinishAndDismissPopup(string jobStatusKey, ulong? seconds = null, CancellationToken cancel = default)
    {
        return ApiConnection.Post(HydrusUrls.FinishAndDismissPopup(), null, new JobStatusKeyRequest(jobStatusKey, seconds), cancel);
    }

    /// <inheritdoc/>
    public Task FinishPopup(string jobStatusKey, CancellationToken cancel = default)
    {
        return ApiConnection.Post(HydrusUrls.FinishPopup(), null, new JobStatusKeyRequest(jobStatusKey), cancel);
    }

    /// <inheritdoc />
    public Task<JobStatusResponse> UpdatePopup(UpdatePopupRequest request, CancellationToken cancel = default)
    {
        ThrowHelper.ArgumentNotNull(request);

        return ApiConnection.Post<JobStatusResponse>(HydrusUrls.UpdatePopup(), null, request, cancel);
    }
}
