using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace HydrusAPI.Web;

/// <summary>
///     Проверка, что токен валиден.
/// </summary>
public class VerifyToken : ApiVersion
{
	/// <summary>
	///     Название токена.
	/// </summary>
	public string Name { get; set; } = default!;

	/// <summary>
	///     Метка, что ключу доступны все области видимости.
	/// </summary>
	public string PermitsEverything { get; set; } = default!;

	/// <summary>
	///     Области видимости токена.
	/// </summary>
	[JsonProperty("basic_permissions")]
	[JsonPropertyName("basic_permissions")]
	public Permissions[] Scopes { get; set; } = default!;

	/// <summary>
	///     Человеческое описание информации про токен.
	/// </summary>
	public string HumanDescription { get; set; } = default!;
}
