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
	public static Uri RequestAccessToken(
		string name,
		bool permitsEverything,
		params Permissions[] permissions
	)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(name);

		return "/request_new_permissions?".FormatUri(
			new Dictionary<string, object?>
			{
				{ "name", name },
				{ "permits_everything", permitsEverything },
				{ "basic_permissions", permissions.Select(p => (int)p) },
			}
		);
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
	///     Возвращает <see cref="Uri" /> запроса генерации хешей.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта генерации хешей.</returns>
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
			}
		);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса генерации хешей.
	/// </summary>
	/// <param name="url">URL</param>
	/// <returns><see cref="Uri" /> эндпоинта генерации хешей.</returns>
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
	public static Uri SearchTags(
		string search,
		FileDomainRequest? fileDomain = null,
		string? tagServiceKey = null,
		TagDisplay tagDisplayType = TagDisplay.Storage
	)
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
			}
		);
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
			}
		);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса преобразования хешей.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта преобразования хешей.</returns>
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
			}
		);
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
			}
		);
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
			}
		);
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
			}
		);
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
			}
		);
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
			}
		);
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
			}
		);
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
			}
		);
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
			}
		);
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
			}
		);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения локальных хранилищ Hydrus.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта получения локальных хранилищ Hydrus.</returns>
	public static Uri GetLocalFileStorageLocations()
	{
		return "/get_files/local_file_storage_locations"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса рендера файла.
	/// </summary>
	/// <param name="request">Запрос.</param>
	/// <returns><see cref="Uri" /> эндпоинта рендера файла.</returns>
	public static Uri Render(RenderRequest request)
	{
		ThrowHelper.ArgumentNotNull(request);

		return "/get_files/render?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "hash", request.Hash },
				{ "file_id", request.FileId },
				{ "download", request.Download },
				{ "render_format", request.RenderFormat },
				{ "render_quality", request.RenderQuality },
				{ "width", request.Width },
				{ "height", request.Height }
			}
		);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения связей файла.
	/// </summary>
	/// <param name="request">Запрос.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения связей файла.</returns>
	public static Uri GetFileRelationships(FilesWithDomainRequest request)
	{
		ThrowHelper.ArgumentNotNull(request);

		return "/manage_file_relationships/get_file_relationships?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "hash", request.Hash },
				{ "file_id", request.FileId },
				{ "hashes", request.Hashes },
				{ "file_ids", request.FileIds },
				{ "file_service_key", request.FileServiceKey },
				{ "file_service_keys", request.FileServiceKeys },
				{ "deleted_file_service_key", request.DeletedFileServiceKey },
				{ "deleted_file_service_keys", request.DeletedFileServiceKeys }
			}
		);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения количества оставшихся потенциальных пар дубликатов.
	/// </summary>
	/// <param name="request">Запрос.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения количества оставшихся потенциальных пар дубликатов.</returns>
	public static Uri GetPotentialsCount(GetPotentialsRequest request)
	{
		ThrowHelper.ArgumentNotNull(request);

		return "/manage_file_relationships/get_potentials_count?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "hash", request.Hash },
				{ "file_id", request.FileId },
				{ "hashes", request.Hashes },
				{ "file_ids", request.FileIds },
				{ "tag_service_key_1", request.TagServiceKey1 },
				{ "tags_1", request.Tags1 },
				{ "tag_service_key_2", request.TagServiceKey2 },
				{ "tags_2", request.Tags2 },
				{ "potentials_search_type", request.PotentialsSearchType },
				{ "pixel_duplicates", request.PixelDuplicates },
				{ "max_hamming_distance", request.MaxHammingDistance }
			}
		);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения оставшихся потенциальных пар дубликатов.
	/// </summary>
	/// <param name="request">Запрос.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения оставшихся потенциальных пар дубликатов.</returns>
	public static Uri GetPotentialsPairs(GetPotentialsPairsRequest request)
	{
		ThrowHelper.ArgumentNotNull(request);

		return "/manage_file_relationships/get_potential_pairs?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "hash", request.Hash },
				{ "file_id", request.FileId },
				{ "hashes", request.Hashes },
				{ "file_ids", request.FileIds },
				{ "tag_service_key_1", request.TagServiceKey1 },
				{ "tags_1", request.Tags1 },
				{ "tag_service_key_2", request.TagServiceKey2 },
				{ "tags_2", request.Tags2 },
				{ "potentials_search_type", request.PotentialsSearchType },
				{ "pixel_duplicates", request.PixelDuplicates },
				{ "max_hamming_distance", request.MaxHammingDistance },
				{ "max_num_pairs", request.MaxNumPairs }
			}
		);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения случайных потенциальных пар дубликатов.
	/// </summary>
	/// <param name="request">Запрос.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения случайных потенциальных пар дубликатов.</returns>
	public static Uri GetRandomPotentials(GetPotentialsRequest request)
	{
		ThrowHelper.ArgumentNotNull(request);

		return "/manage_file_relationships/get_random_potentials?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "hash", request.Hash },
				{ "file_id", request.FileId },
				{ "hashes", request.Hashes },
				{ "file_ids", request.FileIds },
				{ "tag_service_key_1", request.TagServiceKey1 },
				{ "tags_1", request.Tags1 },
				{ "tag_service_key_2", request.TagServiceKey2 },
				{ "tags_2", request.Tags2 },
				{ "potentials_search_type", request.PotentialsSearchType },
				{ "pixel_duplicates", request.PixelDuplicates },
				{ "max_hamming_distance", request.MaxHammingDistance }
			}
		);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса удаления потенциальных дубликатов.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта удаления потенциальных дубликатов.</returns>
	public static Uri RemovePotentials()
	{
		return "/manage_file_relationships/remove_potentials"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса добавления связи между файлами.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта добавления связи между файлами.</returns>
	public static Uri SetFileRelationships()
	{
		return "/manage_file_relationships/set_file_relationships"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса установки лучшего родителя.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта установки лучшего родителя.</returns>
	public static Uri SetKings()
	{
		return "/manage_file_relationships/set_kings"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса ожидающих загрузки материалов для каждого сервиса.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта ожидающих загрузки материалов для каждого сервиса.</returns>
	public static Uri GetPendingCounts()
	{
		return "/manage_services/get_pending_counts"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса запуска загрузки ожидающего сервиса.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта запуска загрузки ожидающего сервиса.</returns>
	public static Uri CommitPending()
	{
		return "/manage_services/commit_pending"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса отмены загрузки ожидающего сервиса.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта отмены загрузки ожидающего сервиса.</returns>
	public static Uri ForgetPending()
	{
		return "/manage_services/forget_pending"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения всех открыты страниц.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта получения всех открыты страниц.</returns>
	public static Uri GetPages()
	{
		return "/manage_pages/get_pages"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения информации об странице.
	/// </summary>
	/// <param name="pageKey">Уникальный ключ страницы.</param>
	/// <param name="simple">Вернуть простую структуру. По умолчанию - true.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения информации об странице.</returns>
	public static Uri GetPage(string pageKey, bool simple = true)
	{
		return "/manage_pages/get_page_info?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "page_key", pageKey },
				{ "simple", simple }
			}
		);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса добавления файлов на страницу.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта добавления файлов на страницу.</returns>
	public static Uri AddFilesOnPage()
	{
		return "/manage_pages/add_files"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса фокуса страницы.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта фокуса страницы.</returns>
	public static Uri FocusPage()
	{
		return "/manage_pages/focus_page"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса обновления страницы.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта обновления страницы.</returns>
	public static Uri RefreshPage()
	{
		return "/manage_pages/refresh_page"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения всплывающих окон.
	/// </summary>
	/// <param name="onlyInView">Только те окна, которые сейчас отображаются в клиенте. По умолчанию - false.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения всплывающих окон.</returns>
	public static Uri GetPopups(bool onlyInView = false)
	{
		return "/manage_popups/get_popups"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "only_in_view", onlyInView }
			}
		);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса добавления нового всплывающего окна.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта добавления нового всплывающего окна.</returns>
	public static Uri AddPopup()
	{
		return "/manage_popups/add_popup"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса вызова пользовательской функции.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта вызова пользовательской функции.</returns>
	public static Uri CallUserCallable()
	{
		return "/manage_popups/call_user_callable"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса пытается отменить отображение всплывающего окна.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта пытается отменить отображение всплывающего окна.</returns>
	public static Uri CancelPopup()
	{
		return "/manage_popups/cancel_popup"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса пытается закрыть всплывающее окно.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта пытается закрыть всплывающее окно.</returns>
	public static Uri DismissPopup()
	{
		return "/manage_popups/dismiss_popup"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса пытается завершить всплывающее окно.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта пытается завершить всплывающее окно.</returns>
	public static Uri FinishPopup()
	{
		return "/manage_popups/finish_popup"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса пытается завершить и закрыть всплывающее окно.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта пытается завершить и закрыть всплывающее окно.</returns>
	public static Uri FinishAndDismissPopup()
	{
		return "/manage_popups/finish_and_dismiss_popup"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса обновления всплывающего окна.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта обновления всплывающего окна.</returns>
	public static Uri UpdatePopup()
	{
		return "/manage_popups/update_popup"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса, который заставляет БД немедленно записать все ожидающие изменения.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта запроса, который заставляет БД немедленно записать все ожидающие изменения.</returns>
	public static Uri ForceCommit()
	{
		return "/manage_database/force_commit"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса приостановки работы БД клиента и отключения текущего соединения.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта запроса, приостановки работы БД клиента и отключения текущего соединения.</returns>
	public static Uri LockOn()
	{
		return "/manage_database/lock_on"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса восстановления соединения с БД клиент.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта запроса, восстановления соединения с БД клиент.</returns>
	public static Uri LockOff()
	{
		return "/manage_database/lock_off"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения статистики.
	/// </summary>
	/// <param name="request">Запрос.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения статистики.</returns>
	public static Uri GetBones(BonesRequest request)
	{
		ThrowHelper.ArgumentNotNull(request);

		return "/manage_database/mr_bones?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "hash", request.Hash },
				{ "file_id", request.FileId },
				{ "hashes", request.Hashes },
				{ "file_ids", request.FileIds },
				{ "file_service_key", request.FileServiceKey },
				{ "file_service_keys", request.FileServiceKeys },
				{ "deleted_file_service_key", request.DeletedFileServiceKey },
				{ "deleted_file_service_keys", request.DeletedFileServiceKeys },
				{ "tag_service_key", request.TagServiceKey }
			}
		);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения настроек клиента.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта получения настроек клиента.</returns>
	public static Uri GetClientOptions()
	{
		return "/manage_database/get_client_options"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения куки.
	/// </summary>
	/// <param name="domain">Домен сайта.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения куки.</returns>
	public static Uri GetCookies(string domain)
	{
		return "/manage_cookies/get_cookies?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "domain", domain },
			}
		);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса присвоения куки.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта присвоения куки.</returns>
	public static Uri SetCookies()
	{
		return "/manage_cookies/set_cookies"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения заголовков.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта получения заголовков.</returns>
	public static Uri GetHeaders()
	{
		return "/manage_headers/get_headers"
			.FormatUri();
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса получения заголовков.
	/// </summary>
	/// <param name="domain">Домен сайта.</param>
	/// <returns><see cref="Uri" /> эндпоинта получения заголовков.</returns>
	public static Uri GetHeaders(string domain)
	{
		return "/manage_headers/get_headers?"
			.FormatUri(new Dictionary<string, object?>
			{
				{ "domain", domain },
			}
		);
	}

	/// <summary>
	///     Возвращает <see cref="Uri" /> запроса присвоения заголовков.
	/// </summary>
	/// <returns><see cref="Uri" /> эндпоинта присвоения заголовков.</returns>
	public static Uri SetHeaders()
	{
		return "/manage_headers/set_headers"
			.FormatUri();
	}
}
