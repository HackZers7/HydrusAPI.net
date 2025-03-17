using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HydrusAPI.Web;

/// <summary>
///     Токен сессии.
/// </summary>
public class HydrusSessionTokenResponse : IToken
{
    /// <summary>
    ///     Токен сессии.
    /// </summary>
    [JsonProperty("session_key")]
    [JsonPropertyName("session_key")]
    public string Token { get; set; } = default!;

    /// <inheritdoc />
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <inheritdoc />
    /// <remarks>
    /// 	Токен сессии Hydrus истекает каждые 24 часа по умолчанию. Так же он истечет, если клиент был перезапущен.
    /// </remarks>
    public bool IsExpired => CreatedAt.AddHours(24) <= DateTime.UtcNow;
}
