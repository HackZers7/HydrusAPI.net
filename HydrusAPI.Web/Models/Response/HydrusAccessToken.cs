using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HydrusAPI.Web;

/// <summary>
///     Токен доступа.
/// </summary>
public class HydrusAccessTokenResponse : ApiVersionResponse, IToken
{
    /// <summary>
    ///     Токен доступа.
    /// </summary>
    /// <remarks>
    /// 	Состоит из 64 символов. Не будет валиден пока пользователь не одобрит запрос в UI клиента.
    /// </remarks>
    [JsonProperty("access_key")]
    [JsonPropertyName("access_key")]
    public string Token { get; set; } = default!;

    /// <inheritdoc />
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <inheritdoc />
    /// <remarks>
    /// 	Токен доступа Hydrus не может истечь, если только его не удалят в клиенте.
    /// </remarks>
    public bool IsExpired => false;
}
