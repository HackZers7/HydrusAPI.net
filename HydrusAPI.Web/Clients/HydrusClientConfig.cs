using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Настройки клиента Hydrus.
/// </summary>
public class HydrusClientConfig
{
	/// <summary>
	///     Конструктор по умолчанию.
	/// </summary>
	/// <param name="baseAddress">Базовый адрес подключения.</param>
	/// <param name="authenticator">Аутентификатор.</param>
	/// <param name="serializer">Серелизатор.</param>
	/// <param name="httpClient">Http клиент.</param>
	/// <param name="apiConnection">Подключение.</param>
	public HydrusClientConfig(
		Uri baseAddress,
		IAuthenticator? authenticator,
		IJsonSerializer serializer,
		IHttpClient httpClient,
		IApiConnection? apiConnection
	)
	{
		BaseAddress = baseAddress;
		Authenticator = authenticator;
		Serializer = serializer;
		HttpClient = httpClient;
		ApiConnection = apiConnection;
	}

	/// <summary>
	///     Возвращает адрес клиента Hydrus.
	/// </summary>
	public Uri BaseAddress { get; }

	/// <summary>
	///     Возвращает аутентификатор.
	/// </summary>
	public IAuthenticator? Authenticator { get; private set; }

	/// <summary>
	///     Возвращает серелизатор.
	/// </summary>
	public IJsonSerializer Serializer { get; private set; }

	/// <summary>
	///     Возвращает http клиент.
	/// </summary>
	public IHttpClient HttpClient { get; private set; }

	/// <summary>
	///     Возвращает подключение.
	/// </summary>
	public IApiConnection? ApiConnection { get; private set; }

	/// <summary>
	///     Устанавливает новый токен для авторизации.
	/// </summary>
	/// <param name="accessToken">Ключ доступа.</param>
	/// <returns>Экземпляр настроек.</returns>
	public HydrusClientConfig WithToken(string accessToken)
	{
		ThrowHelper.ArgumentNotNull(accessToken);

		return WithAuthenticator(
			new HydrusTokenAuthenticator(accessToken)
		);
	}

	/// <summary>
	///     Устанавливает новый аутентификатор.
	/// </summary>
	/// <param name="authenticator">Новый экземпляр аутентификатора.</param>
	/// <returns>Экземпляр настроек.</returns>
	public HydrusClientConfig WithAuthenticator(IAuthenticator authenticator)
	{
		ThrowHelper.ArgumentNotNull(authenticator);

		Authenticator = authenticator;

		return this;
	}

	/// <summary>
	///     Устанавливает новый http клиент.
	/// </summary>
	/// <param name="httpClient">Новый экземпляр http клиента.</param>
	/// <returns>Экземпляр настроек.</returns>
	public HydrusClientConfig WithHttpClient(IHttpClient httpClient)
	{
		ThrowHelper.ArgumentNotNull(httpClient);

		HttpClient = httpClient;

		return this;
	}

	/// <summary>
	///     Устанавливает новый серелизатор.
	/// </summary>
	/// <param name="jsonSerializer">Новый экземпляр серилизатора.</param>
	/// <returns>Экземпляр настроек.</returns>
	public HydrusClientConfig WithJsonSerializer(IJsonSerializer jsonSerializer)
	{
		ThrowHelper.ArgumentNotNull(jsonSerializer);

		Serializer = jsonSerializer;

		return this;
	}

	/// <summary>
	///     Устанавливает новое подключение.
	/// </summary>
	/// <param name="apiConnector">Новый экземпляр подключения.</param>
	/// <returns>Экземпляр настроек.</returns>
	public HydrusClientConfig WithConnection(IApiConnection apiConnector)
	{
		ThrowHelper.ArgumentNotNull(apiConnector, nameof(apiConnector));

		ApiConnection = apiConnector;

		return this;
	}

	/// <summary>
	///     Создает новый экземпляр настроек по умолчанию.
	/// </summary>
	/// <param name="baseAddress">Адрес клиента Hydrus.</param>
	/// <param name="accessToken">Ключ доступа.</param>
	/// <returns>Настройки по умолчанию.</returns>
	public static HydrusClientConfig CreateDefault(Uri baseAddress, string accessToken)
	{
		return CreateDefault(baseAddress)
			.WithToken(accessToken);
	}

	/// <summary>
	///     Создает новый экземпляр настроек по умолчанию.
	/// </summary>
	/// <param name="baseAddress">Адрес клиента Hydrus.</param>
	/// <returns>Настройки по умолчанию.</returns>
	public static HydrusClientConfig CreateDefault(Uri baseAddress)
	{
		ThrowHelper.ArgumentNotNull(baseAddress);

		return new HydrusClientConfig(
			baseAddress,
			null,
			new NewtonsoftJsonSerializer(),
			new NetHttpClient(),
			null
		);
	}

	/// <summary>
	///     Собирает подключение по текущим настройкам.
	/// </summary>
	/// <returns>Новый экземпляр подключения.</returns>
	public IApiConnection BuildApiConnection()
	{
		return ApiConnection ?? new ApiConnection(
			BaseAddress,
			Serializer,
			HttpClient,
			Authenticator
		);
	}
}
