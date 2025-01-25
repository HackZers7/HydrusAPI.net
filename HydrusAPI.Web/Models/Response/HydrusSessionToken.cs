using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HydrusAPI.Web;

/// <summary>
///     Токен сессии.
/// </summary>
public class HydrusSessionToken : IToken
{
	/// <summary>
	///     Токен сессии.
	/// </summary>
	[JsonProperty("session_key")]
	[JsonPropertyName("session_key")]
	public string Token { get; set; } = default!;

	/// <inheritdoc />
	public Permissions[] Scopes { get; set; } = default!;

	/// <inheritdoc />
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	/// <summary>
	///     Указывает, истек ли токен или нет.
	///     <remarks>Токен сессии Hydrus истекает каждые 24 часа по умолчанию. Так же он истечет, если клиент был перезапущен.</remarks>
	/// </summary>
	public bool IsExpired => CreatedAt.AddHours(24) <= DateTime.UtcNow;
}
