// Source: https://github.com/octokit/octokit.net/blob/main/Octokit/Http/HttpClientAdapter.cs

using DS.Shared;
using System.Net.Http.Headers;
using System.Text;

namespace HydrusAPI.Web.Http;

public class NetHttpClient : IHttpClient
{
	private readonly HttpClient _httpClient;

	public NetHttpClient()
	{
		_httpClient = new HttpClient();
	}

	public NetHttpClient(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}

	public async Task<IResponse> Send(IRequest request, CancellationToken cancel = default)
	{
		ThrowHelper.ArgumentNotNull(request);
		var cancellationTokenForRequest = GetCancellationTokenForRequest(request, cancel);

		using (var requestMessage = BuildRequestMessage(request))
		{
			var responseMessage = await _httpClient
				.SendAsync(requestMessage, HttpCompletionOption.ResponseContentRead, cancellationTokenForRequest)
				.ConfigureAwait(false);

			return await BuildResponse(responseMessage, cancel).ConfigureAwait(false);
		}
	}

	public void SetRequestTimeout(TimeSpan timeout)
	{
		_httpClient.Timeout = timeout;
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			_httpClient?.Dispose();
		}
	}

	protected virtual HttpRequestMessage BuildRequestMessage(IRequest request)
	{
		ThrowHelper.ArgumentNotNull(request);
		HttpRequestMessage requestMessage = null;

		try
		{
			var fullUri = new Uri(request.BaseAddress, request.Endpoint);
			requestMessage = new HttpRequestMessage(request.Method, fullUri);

			foreach (var header in request.Headers)
			{
				requestMessage.Headers.Add(header.Key, header.Value);
			}

			switch (request.Body)
			{
				case HttpContent body:
					requestMessage.Content = body;
					break;
				case string body:
					requestMessage.Content = new StringContent(body, Encoding.UTF8, request.ContentType);
					break;
				case Stream body:
					requestMessage.Content = new StreamContent(body);
					requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(request.ContentType);
					break;
			}
		}
		catch (Exception)
		{
			if (requestMessage != null)
			{
				requestMessage.Dispose();
			}

			throw;
		}

		return requestMessage;
	}

	private static async Task<IResponse> BuildResponse(HttpResponseMessage responseMessage, CancellationToken cancel)
	{
		ThrowHelper.ArgumentNotNull(responseMessage);

		object responseBody = null;
		string contentType = null;

		// We added support for downloading images,zip-files and application/octet-stream.
		// Let's constrain this appropriately.
		var binaryContentTypes = new[]
		{
			"application/zip",
			"application/x-gzip",
			"application/octet-stream"
		};

		var content = responseMessage.Content;
		if (content != null)
		{
			contentType = GetContentMediaType(content);

			if (contentType != null && (contentType.StartsWith("image/") || binaryContentTypes
				    .Any(item => item.Equals(contentType, StringComparison.OrdinalIgnoreCase))))
			{
				responseBody = await content.ReadAsStreamAsync().ConfigureAwait(false);
			}
			else
			{
				responseBody = await content.ReadAsStringAsync().ConfigureAwait(false);
				content.Dispose();
			}
		}

		var responseHeaders = responseMessage.Headers.ToDictionary(h => h.Key, h => h.Value.First());

		return new Response(
			responseMessage.StatusCode,
			responseBody,
			responseHeaders,
			contentType);
	}

	private static string? GetContentMediaType(HttpContent httpContent)
	{
		if (httpContent.Headers?.ContentType != null)
		{
			return httpContent.Headers.ContentType.MediaType;
		}

		// Issue #2898 - Bad "zip" Content-Type coming from Blob Storage for artifacts
		if (httpContent.Headers?.TryGetValues("Content-Type", out var contentTypeValues) == true
		    && contentTypeValues.FirstOrDefault() == "zip")
		{
			return "application/zip";
		}

		return null;
	}

	private static CancellationToken GetCancellationTokenForRequest(IRequest request, CancellationToken cancel)
	{
		var cancellationTokenForRequest = cancel;

		if (request.Timeout != TimeSpan.Zero)
		{
			var timeoutCancellation = new CancellationTokenSource(request.Timeout);
			var unifiedCancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancel, timeoutCancellation.Token);

			cancellationTokenForRequest = unifiedCancellationToken.Token;
		}

		return cancellationTokenForRequest;
	}
}
