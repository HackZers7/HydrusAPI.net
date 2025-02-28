namespace HydrusAPI.Web;

/// <summary>
///     Запрос получения токена доступа.
/// </summary>
public class AccessTokenRequest
{
	/// <summary>
	/// 	Инициализирует новый экземпляр запроса.
	/// </summary>
	/// <param name="name">Наименование токена.</param>
	/// <param name="permitsEverything">Разрешить доступ ко всем областям (разрешениям), в том числе и тем что появятся в будущем. По умолчанию - false.</param>
	public AccessTokenRequest(string name, bool permitsEverything = false)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(name);

		Name = name;
		PermitsEverything = permitsEverything;
	}

	/// <summary>
	/// 	Инициализирует новый экземпляр запроса.
	/// </summary>
	/// <param name="name">Наименование токена.</param>
	/// <param name="permissions">Коллекция областей (разрешений).</param>
	public AccessTokenRequest(string name, IList<Permissions> permissions)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(name);

		Name = name;
		Permissions = permissions;
	}

	/// <summary>
	///     Наименование токена.
	/// </summary>
	public string Name { get; }

	/// <summary>
	///     Разрешить доступ ко всем областям (разрешениям), в том числе и тем что появятся в будущем.
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - false.
	/// </remarks>
	public bool PermitsEverything { get; set; } = false;

	/// <summary>
	/// 	Коллекция областей (разрешений).
	/// </summary>
	public IList<Permissions> Permissions { get; } = new List<Permissions>();
}
