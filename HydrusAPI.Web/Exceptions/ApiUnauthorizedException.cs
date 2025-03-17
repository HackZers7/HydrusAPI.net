using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Ошибка авторизации. 
/// </summary>
[Serializable]
public class ApiUnauthorizedException : ApiException
{
    /// <inheritdoc/>
	public ApiUnauthorizedException(IResponse response) : base(response)
    {
    }

    /// <inheritdoc/>
    public ApiUnauthorizedException()
    {
    }

    /// <inheritdoc/>
    public ApiUnauthorizedException(string message) : base(message)
    {
    }

    /// <inheritdoc/>
    public ApiUnauthorizedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    /// <inheritdoc/>
    public ApiUnauthorizedException(IResponse response, Exception? innerException) : base(response, innerException)
    {
    }

    /// <inheritdoc/>
    protected ApiUnauthorizedException(ApiError apiError, Exception? innerException) : base(apiError, innerException)
    {
    }

    /// <inheritdoc/>
    protected ApiUnauthorizedException(ApiException innerException) : base(innerException)
    {
    }
}
