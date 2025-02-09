namespace HydrusAPI.Web;

/// <summary>
///     Все родители и сестры.
/// </summary>
public class SiblingsAndParentsResponse : ServicesResponse
{
	/// <summary>
	///     Теги.
	///     <remarks>
	///         Первый ключ - тег, который был отправлен.
	///         Второй ключ - код сервиса.
	///     </remarks>
	/// </summary>
	public Dictionary<string, Dictionary<string, Tag>> Tags { get; set; } = new();
}
