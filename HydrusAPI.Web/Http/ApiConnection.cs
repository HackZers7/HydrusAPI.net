using System.Net;

namespace HydrusAPI.Web.Http;

/// <summary>
///     Базовый класс для работы с API.
/// </summary>
public class ApiConnection : IApiConnection
{
	private readonly IAuthenticator? _authenticator;
	private readonly Uri _baseAddress;
	private readonly IHttpClient _httpClient;
	private readonly IJsonSerializer _jsonSerializer;

	/// <summary>
	///     Инициализирует новый экземпляр подключения к API.
	/// </summary>
	/// <param name="baseAddress">Базовый адрес.</param>
	/// <param name="jsonSerializer">JSON сериализатор.</param>
	/// <param name="httpClient">HTTP клиент.</param>
	/// <param name="authenticator">Аутентификатор.</param>
	public ApiConnection(Uri baseAddress, IJsonSerializer jsonSerializer, IHttpClient httpClient, IAuthenticator? authenticator)
	{
		_baseAddress = baseAddress;
		_jsonSerializer = jsonSerializer;
		_httpClient = httpClient;
		_authenticator = authenticator;
	}

	/// <inheritdoc />
	public Task<T> Get<T>(Uri uri, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(uri);

		return SendData<T>(uri, HttpMethod.Get, cancel: cancel);
	}

	public Task<T> Get<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel = default)
	{
		throw new NotImplementedException();
	}

	public Task<T> Get<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default)
	{
		throw new NotImplementedException();
	}

	public Task<T> Get<T>(Uri uri, IDictionary<string, string>? parameters, object? body, IDictionary<string, string>? headers, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(uri);

		return SendData<T>(uri, HttpMethod.Get, headers, parameters, body, cancel);
	}

	public Task<T> Post<T>(Uri uri, CancellationToken cancel = default)
	{
		throw new NotImplementedException();
	}

	public Task<T> Post<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel = default)
	{
		throw new NotImplementedException();
	}

	public Task<T> Post<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default)
	{
		throw new NotImplementedException();
	}

	public Task<T> Post<T>(Uri uri, IDictionary<string, string>? parameters, object? body, IDictionary<string, string>? headers, CancellationToken cancel = default)
	{
		throw new NotImplementedException();
	}

	public Task<T> Put<T>(Uri uri, CancellationToken cancel = default)
	{
		throw new NotImplementedException();
	}

	public Task<T> Put<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel = default)
	{
		throw new NotImplementedException();
	}

	public Task<T> Put<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default)
	{
		throw new NotImplementedException();
	}

	public Task<T> Put<T>(Uri uri, IDictionary<string, string>? parameters, object? body, IDictionary<string, string>? headers, CancellationToken cancel = default)
	{
		throw new NotImplementedException();
	}

	public Task<T> Delete<T>(Uri uri, CancellationToken cancel = default)
	{
		throw new NotImplementedException();
	}

	public Task<T> Delete<T>(Uri uri, IDictionary<string, string>? parameters, CancellationToken cancel = default)
	{
		throw new NotImplementedException();
	}

	public Task<T> Delete<T>(Uri uri, IDictionary<string, string>? parameters, object? body, CancellationToken cancel = default)
	{
		throw new NotImplementedException();
	}

	public Task<T> Delete<T>(Uri uri, IDictionary<string, string>? parameters, object? body, IDictionary<string, string>? headers, CancellationToken cancel = default)
	{
		throw new NotImplementedException();
	}

	private async Task<T> SendData<T>(
		Uri uri,
		HttpMethod method,
		IDictionary<string, string>? headers = null,
		IDictionary<string, string>? parameters = null,
		object? body = null,
		CancellationToken cancel = default
	)
	{
		var request = CreateRequest(uri, method, headers, parameters, body);
		var apiResponse = await Run<T>(request, cancel).ConfigureAwait(false);
		return apiResponse.Body!;
	}

	private Request CreateRequest(
		Uri uri,
		HttpMethod method,
		IDictionary<string, string>? headers,
		IDictionary<string, string>? parameters,
		object? body
	)
	{
		ThrowHelper.ArgumentNotNull(uri);
		ThrowHelper.ArgumentNotNull(method);

		return new Request(
			_baseAddress,
			uri,
			method,
			headers ?? new Dictionary<string, string>(),
			parameters ?? new Dictionary<string, string>())
		{
			Body = body
		};
	}

	private async Task<IApiResponse<T>> Run<T>(IRequest request, CancellationToken cancel)
	{
		_jsonSerializer.SerializeRequest(request);
		var response = await RunRequest(request, cancel).ConfigureAwait(false);
		return _jsonSerializer.DeserializeResponse<T>(response);
	}

	private async Task<IResponse> RunRequest(IRequest request, CancellationToken cancel)
	{
		await ApplyAuthenticator(request).ConfigureAwait(false);
		var response = await _httpClient.Send(request, cancel).ConfigureAwait(false);
		HandleErrors(response);
		return response;
	}

	private async Task ApplyAuthenticator(IRequest request)
	{
		if (_authenticator != null)
		{
			await _authenticator!.Apply(request, this).ConfigureAwait(false);
		}
	}

	private static void HandleErrors(IResponse response)
	{
		ThrowHelper.ArgumentNotNull(response);

		if ((int)response.StatusCode >= 200 && (int)response.StatusCode < 400)
		{
			return;
		}

		throw response.StatusCode switch
		{
			HttpStatusCode.Unauthorized => new ApiUnauthorizedException(response),
			(HttpStatusCode)419 => new TokenExpiredException(response),
			_ => new ApiException(response)
		};
	}
}
