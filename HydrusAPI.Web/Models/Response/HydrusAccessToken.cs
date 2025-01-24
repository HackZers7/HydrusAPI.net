using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HydrusAPI.Web;

/// <summary>
///     Токен доступа.
/// </summary>
public class HydrusAccessToken : ApiVersion, IToken
{
	/// <summary>
	///     Возвращает ключ доступа.
	/// </summary>
	[JsonProperty("access_key")]
	[JsonPropertyName("access_key")]
	public string Token { get; set; } = default!;

	/// <inheritdoc />
	public Permissions[] Scopes { get; set; } = default!;

	/// <inheritdoc />
	public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	/// <summary>
	///     Возвращает значение, указывающее, истек ли токен или нет.
	///     <remarks>Ключ доступа Hydrus не может истечь, если только его не удалят.</remarks>
	/// </summary>
	public bool IsExpired => true;
}
