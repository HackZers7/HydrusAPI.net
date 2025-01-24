namespace HydrusAPI.Web.Http;

/// <summary>
///     Соединение для выполнения запросов API к эндпоинтам.
/// </summary>
public interface IApiConnection
{
	/// <summary>
	///     Запрашивает данные из API по-указанному URI.
	/// </summary>
	/// <typeparam name="T">Тип запрашиваемых данных.</typeparam>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Полученные данные.</returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Get<T>(Uri uri, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает данные из API по-указанному URI.
	/// </summary>
	/// <typeparam name="T">Тип запрашиваемых данных.</typeparam>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="parameters">Параметры которые необходимо добавить в API запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Полученные данные.</returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Get<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает данные из API по-указанному URI.
	/// </summary>
	/// <typeparam name="T">Тип запрашиваемых данных.</typeparam>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="parameters">Параметры которые необходимо добавить в API запрос.</param>
	/// <param name="body">Объект пописывающий тело запроса, оно будет сериализированно и использовано в теле запроса.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Полученные данные.</returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Get<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает данные из API по-указанному URI.
	/// </summary>
	/// <typeparam name="T">Тип запрашиваемых данных.</typeparam>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="parameters">Параметры которые необходимо добавить в API запрос.</param>
	/// <param name="body">Объект пописывающий тело запроса, оно будет сериализированно и использовано в теле запроса.</param>
	/// <param name="headers">Http заголовки запроса.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Полученные данные.</returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Get<T>(Uri uri, IDictionary<string, string>? parameters, object? body, IDictionary<string, string>? headers, CancellationToken cancel = default);

	/// <summary>
	///     Создает новые данные в API по-указанному URI.
	/// </summary>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <typeparam name="T">Тип данных.</typeparam>
	/// <returns>Созданные данные.</returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Post<T>(Uri uri, CancellationToken cancel = default);

	/// <summary>
	///     Создает новые данные в API по-указанному URI.
	/// </summary>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="parameters">Параметры которые необходимо добавить в API запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <typeparam name="T">Тип данных.</typeparam>
	/// <returns>Созданные данные.</returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Post<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel = default);

	/// <summary>
	///     Создает новые данные в API по-указанному URI.
	/// </summary>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="parameters">Параметры которые необходимо добавить в API запрос.</param>
	/// <param name="body">Объект пописывающий тело запроса, оно будет сериализированно и использовано в теле запроса.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <typeparam name="T">Тип данных.</typeparam>
	/// <returns>Созданные данные.</returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Post<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default);

	/// <summary>
	///     Создает новые данные в API по-указанному URI.
	/// </summary>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="parameters">Параметры которые необходимо добавить в API запрос.</param>
	/// <param name="body">Объект пописывающий тело запроса, оно будет сериализированно и использовано в теле запроса.</param>
	/// <param name="headers">Http заголовки запроса.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <typeparam name="T">Тип данных.</typeparam>
	/// <returns>Созданные данные.</returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Post<T>(Uri uri, IDictionary<string, string>? parameters, object? body, IDictionary<string, string>? headers, CancellationToken cancel = default);

	/// <summary>
	///     Создает или обновляет данные в API по-указанному URI.
	/// </summary>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Созданные данные.</returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Put<T>(Uri uri, CancellationToken cancel = default);

	/// <summary>
	///     Создает или обновляет данные в API по-указанному URI.
	/// </summary>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="parameters">Параметры которые необходимо добавить в API запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Созданные данные.</returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Put<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel = default);

	/// <summary>
	///     Создает или обновляет данные в API по-указанному URI.
	/// </summary>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="parameters">Параметры которые необходимо добавить в API запрос.</param>
	/// <param name="body">Объект пописывающий тело запроса, оно будет сериализированно и использовано в теле запроса.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Созданные данные.</returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Put<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default);

	/// <summary>
	///     Создает или обновляет данные в API по-указанному URI.
	/// </summary>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="parameters">Параметры которые необходимо добавить в API запрос.</param>
	/// <param name="body">Объект пописывающий тело запроса, оно будет сериализированно и использовано в теле запроса.</param>
	/// <param name="headers">Http заголовки запроса.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Созданные данные.</returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Put<T>(Uri uri, IDictionary<string, string>? parameters, object? body, IDictionary<string, string>? headers, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет данные из API по-указанному URI.
	/// </summary>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns></returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Delete<T>(Uri uri, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет данные из API по-указанному URI.
	/// </summary>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="parameters">Параметры которые необходимо добавить в API запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns></returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Delete<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет данные из API по-указанному URI.
	/// </summary>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="parameters">Параметры которые необходимо добавить в API запрос.</param>
	/// <param name="body">Объект пописывающий тело запроса, оно будет сериализированно и использовано в теле запроса.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns></returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Delete<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет данные из API по-указанному URI.
	/// </summary>
	/// <param name="uri">URL по которому необходимо произвести запрос.</param>
	/// <param name="parameters">Параметры которые необходимо добавить в API запрос.</param>
	/// <param name="body">Объект пописывающий тело запроса, оно будет сериализированно и использовано в теле запроса.</param>
	/// <param name="headers">Http заголовки запроса.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns></returns>
	/// <exception cref="ApiException">Выбрасывается, когда происходит ошибка в API.</exception>
	Task<T> Delete<T>(Uri uri, IDictionary<string, string>? parameters, object? body, IDictionary<string, string>? headers, CancellationToken cancel = default);
}
