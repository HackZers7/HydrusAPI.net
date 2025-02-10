using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Основной клиент для работы с API.
/// </summary>
public class HydrusClient : IHydrusClient
{
	private readonly IApiConnection _apiConnection;

	/// <summary>
	///     Инициализирует новый экземпляр клиента.
	/// </summary>
	/// <param name="baseAddress">Адрес клиента Hydrus.</param>
	/// <param name="token">Ключ доступа.</param>
	public HydrusClient(Uri baseAddress, IToken token) :
		this(HydrusClientConfig.CreateDefault(baseAddress, token?.Token ?? throw new ArgumentNullException(nameof(token))))
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр клиента.
	/// </summary>
	/// <param name="baseAddress">Адрес клиента Hydrus.</param>
	/// <param name="token">Ключ доступа.</param>
	public HydrusClient(Uri baseAddress, string token) :
		this(HydrusClientConfig.CreateDefault(baseAddress, token))
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр клиента.
	/// </summary>
	/// <exception cref="ArgumentNullException">Выбрасывается если не был объявлен аутентификатор.</exception>
	public HydrusClient(HydrusClientConfig config)
	{
		ThrowHelper.ArgumentNotNull(config);

		if (config.Authenticator == null)
		{
			throw new ArgumentNullException(nameof(config.Authenticator));
		}

		_apiConnection = config.BuildApiConnection();

		OAuthClient = new OAuthClient(_apiConnection);
		ServicesClient = new ServicesClient(_apiConnection);
		FilesClient = new FilesClient(_apiConnection);
		UrlsClient = new UrlsClient(_apiConnection);
		TagsClient = new TagsClient(_apiConnection);
		MetaClient = new MetaClient(_apiConnection);
	}

	/// <inheritdoc />
	public IOAuthClient OAuthClient { get; }

	/// <inheritdoc />
	public IServicesClient ServicesClient { get; }

	/// <inheritdoc />
	public IFilesClient FilesClient { get; }

	/// <inheritdoc />
	public IUrlsClient UrlsClient { get; }

	/// <inheritdoc />
	public ITagsClient TagsClient { get; }

	/// <inheritdoc />
	public IMetaClient MetaClient { get; }

	/// <inheritdoc />
	public Task<ApiVersion> GetApiVersion(CancellationToken cancel = default)
	{
		return GetApiVersion(_apiConnection, cancel);
	}

	/// <summary>
	///     Запрашивает версию Hydrus.
	/// </summary>
	/// <param name="apiConnection">Подключение к клиенту Hydrus.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="ApiVersion" /> с информацией о версии Hydrus.</returns>
	public static Task<ApiVersion> GetApiVersion(IApiConnection apiConnection, CancellationToken cancel = default)
	{
		return apiConnection.Get<ApiVersion>(HydrusUrls.ApiVersion(), cancel);
	}
}
