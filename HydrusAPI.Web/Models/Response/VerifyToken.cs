using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HydrusAPI.Web;

/// <summary>
///     Проверка, что токен валиден.
/// </summary>
public class VerifyTokenResponse : ApiVersionResponse
{
	/// <summary>
	///     Название токена.
	/// </summary>
	public string Name { get; set; } = default!;

	/// <summary>
	///     Разрешен доступ ко всем областям (разрешениям), в том числе и тем что появятся в будущем.
	/// </summary>
	public bool PermitsEverything { get; set; } = default!;

	/// <summary>
	///     Области видимости (разрешения) токена.
	/// </summary>
	[JsonProperty("basic_permissions")]
	[JsonPropertyName("basic_permissions")]
	public List<Permissions> Permissions { get; set; } = default!;

	/// <summary>
	///     Описание токена.
	/// </summary>
	public string HumanDescription { get; set; } = default!;
}
