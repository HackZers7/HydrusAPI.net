using DS.Shared;
using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент получения идентификационных данных для подключения.
/// </summary>
public class AccessClient : ApiClient, IAccessClient
{
	/// <summary>
	///     Инициализирует новый экземпляр API клиента.
	/// </summary>
	/// <param name="apiConnection">Подключение клиента.</param>
	public AccessClient(IApiConnection apiConnection) : base(apiConnection)
	{
	}

	/// <inheritdoc />
	public Task<AuthAccessKey> GetAccessKey(string name, bool permitsEverything = true, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(name);

		return ApiConnection.Get<AuthAccessKey>(HydrusUrls.RequestNewPermissions(name), cancel);
	}

	/// <inheritdoc />
	public Task<AuthAccessKey> GetAccessKey(string name, params Permissions[] permissions)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(name);
		ThrowHelper.ArgumentOutOfRange(permissions.Length, 1, int.MaxValue, nameof(permissions.Length));

		return ApiConnection.Get<AuthAccessKey>(HydrusUrls.RequestNewPermissions(name, permissions));
	}

	/// <inheritdoc />
	public Task<AuthAccessKey> GetAccessKey(string name, CancellationToken cancel, params Permissions[] permissions)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(name);
		ThrowHelper.ArgumentOutOfRange(permissions.Length, 1, int.MaxValue, nameof(permissions.Length));

		return ApiConnection.Get<AuthAccessKey>(HydrusUrls.RequestNewPermissions(name, permissions), cancel);
	}
}
