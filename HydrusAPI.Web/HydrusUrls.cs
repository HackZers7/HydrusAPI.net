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

		return "/request_new_permissions?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "name", name },
				{ "permits_everything", permitsEverything },
				{ "basic_permissions", permissions.Select(p => (int)p) }
			});
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

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса генерации хэшей.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта генерации хэшей.</returns>
	public static Uri GenerateHashes()
	{
		return "/add_files/generate_hashes"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса поиска файла по url.
	/// </summary>
	/// <param name="url">URl файла.</param>
	/// <param name="doublecheckFileSystem">
	///     Если true – то любой результат, который <see cref="FileStatus.AlreadyExists" /> (2), будет дважды сверен с фактической файловой системой.
	///     Эта проверка выполняется в любом обычном процессе импорта файлов, для проверки и исправления отсутствующих файлов (если файл отсутствует, статус становится <see cref="FileStatus.FileNotExists" /> (0)).
	/// </param>
	/// <returns><see cref="Uri" /> эндпоинта поиска файла по url.</returns>
	public static Uri GetUrlFiles(string url, bool doublecheckFileSystem = false)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(url);

		return "/add_urls/get_url_files?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "url", url },
				{ "doublecheck_file_system", doublecheckFileSystem }
			});
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса генерации хэшей.
	/// </summary>
	/// <param name="url">URL</param>
	/// <returns><see cref="Uri" /> эндпоинта генерации хэшей.</returns>
	public static Uri GetUrlInfo(string url)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(url);

		var encodedUrl = url.UriEncode();

		return "/add_urls/get_url_info?url={0}"
			.FormatUri(encodedUrl);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса для импорта файла по URL.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта импорта файла по URL.</returns>
	public static Uri AddUrl()
	{
		return "/add_urls/add_url"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса ассоциации (добавления) и диссоциации (удаления) URL.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта ассоциации (добавления) и диссоциации (удаления) URL.</returns>
	public static Uri AssociateUrl()
	{
		return "/add_urls/associate_url"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса для приведения тегов к правилам к Hydrus.
	/// </summary>
	/// <param name="tags">Перечисление тегов.</param>
	/// <returns><see cref="Uri" /> эндпоинта приведения тегов к правилам к Hydrus.</returns>
	public static Uri CleanTags(IEnumerable<string> tags)
	{
		var encodedTags = tags.ToStringArray()
			.UriEncode();

		return "/add_tags/clean_tags?tags={0}"
			.FormatUri(encodedTags);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения родителей и сестер.
	/// </summary>
	/// <param name="tags">Перечисление тегов.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения родителей и сестер.</returns>
	public static Uri GetSiblingsAndParents(IEnumerable<string> tags)
	{
		var encodedTags = tags.ToStringArray()
			.UriEncode();

		return "/add_tags/get_siblings_and_parents?tags={0}"
			.FormatUri(encodedTags);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса поиска по тегам.
	/// </summary>
	/// <param name="search">Запрос для поиска, формат такой же как и для интерфейса Hydrus.</param>
	/// <param name="fileDomain">Файловый домен.</param>
	/// <param name="tagServiceKey">Ключ домена тегов в котором выполняется поиск. По умолчанию - "all known tags".</param>
	/// <param name="tagDisplayType">Указывает на то, следует ли выполнять поиск по необработанным или обработанным тегам.</param>
	/// <returns><see cref="Uri" /> эндпоинта поиска по тегам.</returns>
	public static Uri SearchTags(string search, FileDomainRequest? fileDomain = null, string? tagServiceKey = null, TagDisplay tagDisplayType = TagDisplay.Storage)
	{
		return "/add_tags/search_tags?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "search", search },
				{ "file_service_key", fileDomain?.FileServiceKey },
				{ "file_service_keys", fileDomain?.FileServiceKeys },
				{ "deleted_file_service_key", fileDomain?.DeletedFileServiceKey },
				{ "deleted_file_service_keys", fileDomain?.DeletedFileServiceKeys },
				{ "tag_service_key", !string.IsNullOrWhiteSpace(tagServiceKey) ? tagServiceKey : null },
				{ "tag_display_type", tagDisplayType.ToString().ToLower() }
			});
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса добавления тегов.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта добавления тегов.</returns>
	public static Uri AddTags()
	{
		return "/add_tags/add_tags"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса установки рейтинга.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта установки рейтинга.</returns>
	public static Uri SetRating()
	{
		return "/edit_ratings/set_rating"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса добавления время просмотра в статистику.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта добавления время просмотра в статистику.</returns>
	public static Uri IncrementFileViewtime()
	{
		return "/edit_times/increment_file_viewtime"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса установки времени просмотра в статистике.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта установки времени просмотра в статистике.</returns>
	public static Uri SetFileViewtime()
	{
		return "/edit_times/set_file_viewtime"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса установки времени просмотр.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта установки времени просмотра.</returns>
	public static Uri SetTime()
	{
		return "/edit_times/set_time"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса установки заметки.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта установки заметки.</returns>
	public static Uri SetNotes()
	{
		return "/add_notes/set_notes"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса удаление заметок.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта удаление заметок.</returns>
	public static Uri DeleteNotes()
	{
		return "/add_notes/delete_notes"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса поиска файлов.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта поиска файлов.</returns>
	public static Uri SearchFiles(SearchFilesRequest request)
	{
		ThrowHelper.ArgumentNotNull(request);

		return "/get_files/search_files?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "tags", request.Tags },
				{ "file_service_key", request.FileServiceKey },
				{ "file_service_keys", request.FileServiceKeys },
				{ "deleted_file_service_key", request.DeletedFileServiceKey },
				{ "deleted_file_service_keys", request.DeletedFileServiceKeys },
				{ "tag_service_key", !string.IsNullOrWhiteSpace(request.TagServiceKey) ? request.TagServiceKey : null },
				{ "include_current_tags", request.IncludeCurrentTags },
				{ "include_pending_tags", request.IncludePendingTags },
				{ "file_sort_type", request.FileSortType },
				{ "file_sort_asc", request.FileSortAsc },
				{ "return_file_ids", request.ReturnFileIds },
				{ "return_hashes", request.ReturnHashes }
			});
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса преобразования хэшей.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта преобразования хэшей.</returns>
	public static Uri GetFileHashes(FileHashesRequest request)
	{
		ThrowHelper.ArgumentNotNull(request);

		return "/get_files/file_hashes?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "hash", request.Hash },
				{ "hashes", request.Hashes },
				{ "source_hash_type", request.SourceHashType },
				{ "desired_hash_type", request.DesiredHashType }
			});
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса мата данных файла.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта мата данных файла.</returns>
	public static Uri GetMetadata(MetaDataRequest request)
	{
		ThrowHelper.ArgumentNotNull(request);

		return "/get_files/file_metadata?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "hash", request.Hash },
				{ "hashes", request.Hashes },
				{ "file_id", request.FileId },
				{ "file_ids", request.FileIds },
				{ "create_new_file_ids", request.CreateNewFileIds },
				{ "only_return_identifiers", request.OnlyReturnIdentifiers },
				{ "only_return_basic_information", request.OnlyReturnBasicInformation },
				{ "detailed_url_information", request.DetailedUrlInformation },
				{ "include_blurhash", request.IncludeBlurHash },
				{ "include_milliseconds", request.IncludeMilliseconds },
				{ "include_notes", request.IncludeNotes },
				{ "include_services_object", request.IncludeServicesObject },
				{ "hide_service_keys_tags", request.HideServiceKeysTags }
			});
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения файла.
	/// </summary>
	/// <param name="hash">Хэш (SHA256) файл.</param>
	/// <param name="download">Ставит Content-Disposition=attachment. По умолчанию - false.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения файла.</returns>
	public static Uri GetFile(string hash, bool download = false)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		return "/get_files/file?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "hash", hash },
				{ "download", download }
			});
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения файла.
	/// </summary>
	/// <param name="fileId">Идентификатор файл.</param>
	/// <param name="download">Ставит Content-Disposition=attachment. По умолчанию - false.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения файла.</returns>
	public static Uri GetFile(ulong fileId, bool download = false)
	{
		ThrowHelper.ArgumentOutOfRange(fileId, (ulong)1, ulong.MaxValue);

		return "/get_files/file?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "file_id", fileId },
				{ "download", download }
			});
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения эскиза.
	/// </summary>
	/// <param name="hash">Хэш (SHA256) файл.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения эскиза.</returns>
	public static Uri GetThumbnail(string hash)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		return "/get_files/thumbnail?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "hash", hash }
			});
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения эскиза.
	/// </summary>
	/// <param name="fileId">Идентификатор файл.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения эскиза.</returns>
	public static Uri GetThumbnail(ulong fileId)
	{
		ThrowHelper.ArgumentOutOfRange(fileId, (ulong)1, ulong.MaxValue);

		return "/get_files/thumbnail?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "file_id", fileId }
			});
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения локального пути к файлу.
	/// </summary>
	/// <param name="hash">Хэш (SHA256) файл.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения локального пути к файлу.</returns>
	public static Uri GetFilePath(string hash)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		return "/get_files/file_path?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "hash", hash }
			});
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения локального пути к файлу.
	/// </summary>
	/// <param name="fileId">Идентификатор файл.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения локального пути к файлу.</returns>
	public static Uri GetFilePath(ulong fileId)
	{
		ThrowHelper.ArgumentOutOfRange(fileId, (ulong)1, ulong.MaxValue);

		return "/get_files/file_path?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "file_id", fileId }
			});
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения локального пути к эскизу.
	/// </summary>
	/// <param name="hash">Хэш (SHA256) файл.</param>
	/// <param name="includeThumbnailFiletype">Добавить в ответ тип файла. По умолчанию - false.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения локального пути к файлу.</returns>
	public static Uri GetThumbnailFilePath(string hash, bool includeThumbnailFiletype = false)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		return "/get_files/thumbnail_path?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "hash", hash },
				{ "include_thumbnail_filetype", includeThumbnailFiletype }
			});
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения локального пути к эскизу.
	/// </summary>
	/// <param name="fileId">Идентификатор файл.</param>
	/// <param name="includeThumbnailFiletype">Добавить в ответ тип файла. По умолчанию - false.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения локального пути к файлу.</returns>
	public static Uri GetThumbnailFilePath(ulong fileId, bool includeThumbnailFiletype = false)
	{
		ThrowHelper.ArgumentOutOfRange(fileId, (ulong)1, ulong.MaxValue);

		return "/get_files/thumbnail_path?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "file_id", fileId },
				{ "include_thumbnail_filetype", includeThumbnailFiletype }
			});
	}
}
