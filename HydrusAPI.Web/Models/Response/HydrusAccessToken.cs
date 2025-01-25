using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HydrusAPI.Web;

/// <summary>
///     Токен доступа.
/// </summary>
public class HydrusAccessToken : ApiVersion, IToken
{
	/// <summary>
	///     Токен доступа.
	/// </summary>
	[JsonProperty("access_key")]
	[JsonPropertyName("access_key")]
	public string Token { get; set; } = default!;

	/// <inheritdoc />
	public Permissions[] Scopes { get; set; } = default!;

	/// <inheritdoc />
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	/// <summary>
	///     Указывает, истек ли токен или нет.
	///     <remarks>Токен доступа Hydrus не может истечь, если только его не удалят.</remarks>
	/// </summary>
	public bool IsExpired => true;
}
