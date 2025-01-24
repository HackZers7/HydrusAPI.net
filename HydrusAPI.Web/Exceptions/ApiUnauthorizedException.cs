using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

[Serializable]
public class ApiUnauthorizedException : ApiException
{
	public ApiUnauthorizedException(IResponse response) : base(response)
	{
	}

	public ApiUnauthorizedException()
	{
	}

	public ApiUnauthorizedException(string message) : base(message)
	{
	}

	public ApiUnauthorizedException(string message, Exception innerException) : base(message, innerException)
	{
	}
}
