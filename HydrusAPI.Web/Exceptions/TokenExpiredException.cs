using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
/// Ошибка 419. Токен устарел.
/// </summary>
public class TokenExpiredException : ApiException
{
	public TokenExpiredException(IResponse response) : base(response)
	{
	}

	public TokenExpiredException()
	{
	}

	public TokenExpiredException(string message) : base(message)
	{
	}

	public TokenExpiredException(string message, Exception innerException) : base(message, innerException)
	{
	}
}
