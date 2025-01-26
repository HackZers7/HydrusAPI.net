namespace HydrusAPI.Web;

/// <summary>
///     Представляет основой клиент для работы с API.
/// </summary>
public interface IHydrusClient
{
	/// <summary>
	///     Клиент получения токенов аутентификации.
	/// </summary>
	IOAuthClient OAuthClient { get; }

	/// <summary>
	///     Клиент для работы с сервисами.
	/// </summary>
	IServicesClient ServicesClient { get; }

	/// <summary>
	///     Клиент для работы с файлами.
	/// </summary>
	IFilesClient FilesClient { get; }

	/// <summary>
	///     Запрашивает версию Hydrus.
	/// </summary>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ApiVersion" /> с информацией о версии Hydrus.</returns>
	Task<ApiVersion> GetApiVersion(CancellationToken cancel = default);
}
