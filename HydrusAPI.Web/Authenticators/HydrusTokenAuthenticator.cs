using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Предоставляет авторизацию с использованием токенов сессии. Для работы требуется токен доступа.
/// </summary>
// ReSharper disable once InconsistentNaming
public class HydrusTokenAuthenticator : IAuthenticator
{
	/// <summary>
	///     Инициализирует новый экземпляр идентификатора.
	/// </summary>
	/// <param name="accessToken">Ключ доступа.</param>
	public HydrusTokenAuthenticator(string accessToken)
	{
		AccessToken = accessToken;
	}

	/// <summary>
	///     Возвращает и устанавливает ключ доступа к API Hydrus. Может быть определен не сразу.
	/// </summary>
	public string AccessToken { get; set; }

	/// <summary>
	///     Возвращает текущий токен сессии.
	/// </summary>
	public HydrusSessionToken? SessionToken { get; private set; }

	/// <inheritdoc />
	public async Task Apply(IRequest request, IApiConnection apiConnection)
	{
		ThrowHelper.ArgumentNotNull(request, nameof(request));

		if (request.Headers.ContainsKey(OAuthClient.HydrusAccessHeader))
		{
			return;
		}

		if (SessionToken?.IsExpired ?? true)
		{
			var refreshedToken = await OAuthClient.RequestSessionToken(apiConnection, AccessToken).ConfigureAwait(false);
			SessionToken ??= refreshedToken;
			SessionToken.Token = refreshedToken.Token;
			SessionToken.Scopes = refreshedToken.Scopes;
			SessionToken.CreatedAt = refreshedToken.CreatedAt;

			TokenRefreshed?.Invoke(this, SessionToken);
		}

		request.Headers.Add(OAuthClient.HydrusSessionHeader, $"{SessionToken.Token}");
	}

	/// <summary>
	///     Событие вызывается когда токен сессии был обновлен.
	/// </summary>
	public event EventHandler<IToken> TokenRefreshed;
}
