namespace HydrusAPI.Web;

/// <summary>
///     Представляет основой клиент для работы с API.
/// </summary>
public interface IHydrusClient
{
	/// <summary>
	///     Клиент для получения ключа доступа.
	/// </summary>
	IAccessClient AccessClient { get; }

	/// <summary>
	///     Запрашивает версию Hydrus.
	/// </summary>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ApiVersion" /> с информацией о версии Hydrus.</returns>
	Task<ApiVersion> GetApiVersion(CancellationToken cancel = default);
}
