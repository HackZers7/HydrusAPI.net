using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент для работы базой данных Hydrus.
/// </summary>
public class ManageDataBaseClient : ApiClient, IManageDataBaseClient
{
	/// <inheritdoc />
	public ManageDataBaseClient(IApiConnection apiConnection) : base(apiConnection)
	{
	}

	/// <inheritdoc/>
	public async Task<bool> ForceCommit(CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.ForceCommit(), null, null, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc/>
	public async Task<bool> LockOn(CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.LockOn(), null, null, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc/>
	public async Task<bool> LockOff(CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.LockOff(), null, null, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc/>
	public async Task<Bones> UpdatePopup(BonesRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Get<BonesResponse>(HydrusUrls.GetBones(request), cancel);

		return response.BonedStats;
	}

	/// <inheritdoc/>
	public Task<object?> GetClientOptions(CancellationToken cancel = default)
	{
		return ApiConnection.Get<object?>(HydrusUrls.GetClientOptions(), cancel);
	}
}
