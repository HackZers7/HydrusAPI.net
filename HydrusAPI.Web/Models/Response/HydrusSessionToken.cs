using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HydrusAPI.Web;

/// <summary>
///     Токен сессии.
/// </summary>
public class HydrusSessionToken : IToken
{
	/// <summary>
	///     Возвращает ключ сессии.
	/// </summary>
	[JsonProperty("session_key")]
	[JsonPropertyName("session_key")]
	public string Token { get; set; } = default!;

	/// <inheritdoc />
	public Permissions[] Scopes { get; set; } = default!;

	/// <inheritdoc />
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	/// <summary>
	///     Возвращает значение, указывающее, истек ли токен или нет.
	///     <remarks>Ключ сессии Hydrus истекает каждые 24 часа по умолчанию. Так же он истечет, если клиент был перезапущен.</remarks>
	/// </summary>
	public bool IsExpired => CreatedAt.AddHours(24) <= DateTime.UtcNow;
}
