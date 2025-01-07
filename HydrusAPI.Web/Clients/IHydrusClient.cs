namespace HydrusAPI.Web;

/// <summary>
/// Представляет основой клиент для работы с API.
/// </summary>
public interface IHydrusClient
{
	Task<ApiVersion> GetApiVersion(CancellationToken cancel = default);
}
