namespace HydrusAPI.Web;

/// <summary>
///     Токен доступа.
/// </summary>
public interface IToken
{
	/// <summary>
	///     Возвращает ключ.
	/// </summary>
	public string Token { get; }

	/// <summary>
	///     Возвращает все доступные области видимости для ключа.
	/// </summary>
	public Permissions[] Scopes { get; }

	/// <summary>
	///     Возвращает время (UTC), когда токен был создан.
	/// </summary>
	public DateTime CreatedAt { get; }

	/// <summary>
	///     Возвращает значение, указывающее, истек ли токен или нет.
	/// </summary>
	public bool IsExpired { get; }
}
