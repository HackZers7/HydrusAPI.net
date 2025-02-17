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
	public async Task<IEnumerable<JobStatus>> GetPopups(bool onlyInView = false, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Get<JobStatusResponse>(HydrusUrls.GetPopups(onlyInView), cancel);

		return response.JobStatuses!;
	}

	/// <inheritdoc />
	public Task<JobStatus> AddPopup(JobStatus request, CancellationToken cancel = default)
	{
		return ApiConnection.Post<JobStatus>(HydrusUrls.AddPopup(), null, request, cancel);
	}

	/// <inheritdoc />
	public async Task<bool> CallUserCallable(string jobStatusKey, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(jobStatusKey);

		var response = await ApiConnection.Post(HydrusUrls.CallUserCallable(), null, new JobStatusKeyRequest(jobStatusKey), cancel);

		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public async Task<bool> CancelPopup(string jobStatusKey, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(jobStatusKey);

		var response = await ApiConnection.Post(HydrusUrls.CancelPopup(), null, new JobStatusKeyRequest(jobStatusKey), cancel);

		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public async Task<bool> DismissPopup(string jobStatusKey, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(jobStatusKey);

		var response = await ApiConnection.Post(HydrusUrls.DismissPopup(), null, new JobStatusKeyRequest(jobStatusKey), cancel);

		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public async Task<bool> FinishPopup(string jobStatusKey, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(jobStatusKey);

		var response = await ApiConnection.Post(HydrusUrls.FinishPopup(), null, new JobStatusKeyRequest(jobStatusKey), cancel);

		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public async Task<bool> FinishAndDismissPopup(string jobStatusKey, ulong? seconds = null, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(jobStatusKey);

		var response = await ApiConnection.Post(HydrusUrls.FinishAndDismissPopup(), null, new JobStatusKeyRequest(jobStatusKey, seconds), cancel);

		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<JobStatus> UpdatePopup(JobStatus request, CancellationToken cancel = default)
	{
		return ApiConnection.Post<JobStatus>(HydrusUrls.UpdatePopup(), null, request, cancel);
	}
}
