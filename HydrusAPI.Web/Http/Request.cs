namespace HydrusAPI.Web.Http;

/// <summary>
///     Базовое представление запроса.
/// </summary>
public class Request : IRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса <see cref="Request" />.
	/// </summary>
	public Request(Uri baseAddress, Uri endpoint, HttpMethod method) : this(
		baseAddress,
		endpoint,
		method,
		new Dictionary<string, string>(),
		new Dictionary<string, string>()
	)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса <see cref="Request" />.
	/// </summary>
	public Request(Uri baseAddress, Uri endpoint, HttpMethod method, IDictionary<string, string> headers) : this(
		baseAddress,
		endpoint,
		method,
		headers,
		new Dictionary<string, string>()
	)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса <see cref="Request" />.
	/// </summary>
	public Request(
		Uri baseAddress,
		Uri endpoint,
		HttpMethod method,
		IDictionary<string, string> headers,
		IDictionary<string, string> parameters
	)
	{
		Headers = headers;
		Parameters = parameters;
		BaseAddress = baseAddress;
		Endpoint = endpoint;
		Method = method;
	}

	/// <inheritdoc />
	public Uri BaseAddress { get; set; }

	/// <inheritdoc />
	public Uri Endpoint { get; set; }

	/// <inheritdoc />
	public IDictionary<string, string> Headers { get; }

	/// <inheritdoc />
	public IDictionary<string, string> Parameters { get; }

	/// <inheritdoc />
	public HttpMethod Method { get; set; }

	/// <inheritdoc />
	public object? Body { get; set; }

	/// <inheritdoc />
	public TimeSpan Timeout { get; set; }

	/// <inheritdoc />
	public string? ContentType { get; set; }
}
