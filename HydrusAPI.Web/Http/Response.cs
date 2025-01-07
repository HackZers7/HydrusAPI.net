using DS.Shared;
using System.Collections.ObjectModel;
using System.Net;

namespace HydrusAPI.Web.Http;

public class Response : IResponse
{
	public Response(IDictionary<string, string> headers)
	{
		ThrowHelper.ArgumentNotNull(headers);

		Headers = new ReadOnlyDictionary<string, string>(headers);
	}
	
	public Response(HttpStatusCode statusCode, object? body, IDictionary<string, string> headers, string? contentType)
	{
		ThrowHelper.ArgumentNotNull(headers);

		StatusCode = statusCode;
		Body = body;
		Headers = new ReadOnlyDictionary<string, string>(headers);
		ContentType = contentType;
	}

	public object? Body { get; set; }

	public IReadOnlyDictionary<string, string> Headers { get; set; }

	public HttpStatusCode StatusCode { get; set; }

	public string? ContentType { get; set; }
}
