using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Предоставляет авторизацию с использованием токенов сессии. Для работы требуется токен доступа.
/// </summary>
public class HydrusTokenAuthenticator : IAuthenticator
{
	/// <summary>
	///     Инициализирует новый экземпляр идентификатора.
	/// </summary>
	/// <param name="accessToken">Ключ доступа.</param>
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
	public HydrusTokenAuthenticator(string accessToken)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(accessToken);

		AccessToken = accessToken;
	}

	/// <summary>
	///     Возвращает и устанавливает ключ доступа к API Hydrus. Может быть определен не сразу.
	/// </summary>
	public string AccessToken { get; set; }

	/// <summary>
	///     Возвращает текущий токен сессии.
	/// </summary>
	/// <remarks>
	/// 	Обновляется, если просрочен.
	/// </remarks>
	public HydrusSessionTokenResponse? SessionToken { get; private set; }

	/// <inheritdoc />
	public async Task Apply(IRequest request, IApiConnection apiConnection)
	{
		ThrowHelper.ArgumentNotNull(request, nameof(request));

		if (request.Headers.ContainsKey(OAuthClient.HydrusAccessHeader) || request.Headers.ContainsKey(OAuthClient.HydrusSessionHeader))
		{
			return;
		}

		if (SessionToken?.IsExpired ?? true)
		{
			var refreshedToken = await OAuthClient.RequestSessionToken(apiConnection, AccessToken).ConfigureAwait(false);
			SessionToken ??= refreshedToken;
			SessionToken.Token = refreshedToken.Token;
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
