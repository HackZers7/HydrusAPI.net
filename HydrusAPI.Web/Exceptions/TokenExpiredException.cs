using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Ошибка 419. Токен устарел.
/// </summary>
public class TokenExpiredException : ApiException
{
    /// <inheritdoc/>
    public TokenExpiredException(IResponse response) : base(response)
    {
    }

    /// <inheritdoc/>
    public TokenExpiredException()
    {
    }

    /// <inheritdoc/>
    public TokenExpiredException(string message) : base(message)
    {
    }

    /// <inheritdoc/>
    public TokenExpiredException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
