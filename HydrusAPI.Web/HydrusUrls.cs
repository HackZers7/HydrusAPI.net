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
	/// <param name="permitsEverything">Разрешить доступ ко всем областям (разрешениям).</param>
	/// <param name="permissions">Массив с запрашиваемыми разрешениями.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения API ключа.</returns>
	public static Uri RequestAccessToken(string name, bool permitsEverything, params Permissions[] permissions)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(name);

		var encodedName = name.UriEncode();
		// ReSharper disable once UseStringInterpolation
		var encodedPermissions = string.Format("[{0}]", string.Join(',', permissions.Select(p => ((int)p).ToString())))
			.UriEncode();
		return "/request_new_permissions?name={0}&permits_everything={1}&basic_permissions={2}"
			.FormatUri(encodedName, permitsEverything.ToString().ToLower(), encodedPermissions);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения ключа сессии.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта получения ключа сессии.</returns>
	public static Uri RequestSessionToken()
	{
		return "/session_key".FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса на проверку токена.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта проверки токена.</returns>
	public static Uri VerifyToken()
	{
		return "/verify_access_key".FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса на получение сервиса по имени.
	/// </summary>
	/// <param name="name">Название сервиса.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения сервиса.</returns>
	public static Uri GetServiceByName(string name)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(name);

		var encodedName = name.UriEncode();
		return "/get_service?service_name={0}"
			.FormatUri(encodedName);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса на получение сервиса по ключу.
	/// </summary>
	/// <param name="key">Ключ сервиса.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения сервиса.</returns>
	public static Uri GetServiceByKey(string key)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(key);

		var encodedKey = key.UriEncode();
		return "/get_service?service_key={0}"
			.FormatUri(encodedKey);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса на получение всех доступных сервисов.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта получения сервисов.</returns>
	public static Uri GetServices()
	{
		return "/get_services"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса на отправку файла.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта отправки файла.</returns>
	public static Uri AddFile()
	{
		return "/add_files/add_file"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса на удаление файлов.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта удаления файла.</returns>
	public static Uri DeleteFiles()
	{
		return "/add_files/delete_files"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса на отмену удаление файлов.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта отмены удаления файла.</returns>
	public static Uri UndeleteFiles()
	{
		return "/add_files/undelete_files"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса на очистку информации об удалении файлов.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта очистки информации об удалении файла.</returns>
	public static Uri ClearFilesDeletion()
	{
		return "/add_files/clear_file_deletion_record"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса копирование (миграции) файлов в другой файловый домен.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта копирования (миграция) файлов в другой файловый домен.</returns>
	public static Uri MigrateFiles()
	{
		return "/add_files/migrate_files"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса архивации отправленных файлов.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта архивации отправленных файлов.</returns>
	public static Uri ArchiveFiles()
	{
		return "/add_files/archive_files"
			.FormatUri();
	}
	
	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса разархивации отправленных файлов.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта разархивации отправленных файлов.</returns>
	public static Uri UnarchiveFiles()
	{
		return "/add_files/unarchive_files"
			.FormatUri();
	}
}
