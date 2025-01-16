using DS.Shared;

namespace HydrusAPI.Web;

/// <summary>
///     Класс для получения <see cref="Uri" />-адресов Hydrus API.
/// </summary>
public static class HydrusUrls
{
	/// <summary>
	///     Возвращает <see cref="Uri" />, которое соответствует локальному адресу сервера Hydrus.
	/// </summary>
	public static readonly Uri DefaultLocalhost = new("http://127.0.0.1:45869/");

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения версии API.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта версии API.</returns>
	public static Uri ApiVersion()
	{
		return "/api_version".FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения API ключа.
	/// </summary>
	/// <param name="name">Название ключа.</param>
	/// <param name="permitsEverything">selective, bool, whether to permit all tasks now and in future</param>
	/// <returns><see cref="Uri" /> эндпоинта получения API ключа.</returns>
	public static Uri RequestNewPermissions(string name, bool permitsEverything = true)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(name);

		var encodedName = name.UriEncode();

		return "/request_new_permissions?name={0}&permit_everything={1}"
			.FormatUri(encodedName, permitsEverything.ToString().ToLower());
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения API ключа.
	/// </summary>
	/// <param name="name">Название ключа.</param>
	/// <param name="permissions">Массив с запрашиваемыми разрешениями.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения API ключа.</returns>
	public static Uri RequestNewPermissions(string name, params Permissions[] permissions)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(name);
		ThrowHelper.ArgumentOutOfRange(permissions.Length, 1, int.MaxValue, nameof(permissions.Length));

		var encodedName = name.UriEncode();
		// ReSharper disable once UseStringInterpolation
		var encodedPermissions = string.Format("[{0}]", string.Join(',', permissions.Select(p => ((int)p).ToString())))
			.UriEncode();
		return "/request_new_permissions?name={0}&basic_permissions={1}"
			.FormatUri(encodedName, encodedPermissions);
	}
}
