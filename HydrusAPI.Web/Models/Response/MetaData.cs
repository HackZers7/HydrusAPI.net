namespace HydrusAPI.Web;

/// <summary>
///     Метаданные файла.
/// </summary>
public class MetaData : MetaDataId
{
	/// <summary>
	///     Размер файла.
	/// </summary>
	public ulong? Size { get; set; }

	/// <summary>
	///     Mime type.
	/// </summary>
	public string? Mime { get; set; }

	/// <summary>
	///     Установлен конкретный тип файла.
	/// </summary>
	public bool? FiletypeForced { get; set; }

	/// <summary>
	///     Оригинальный Mime type.
	/// </summary>
	public string? OriginalMime { get; set; }

	/// <summary>
	///     Тип файла строкой.
	/// </summary>
	public string? FiletypeHuman { get; set; }

	// TODO: Найти все типы файлов и сделать перечисление.
	/// <summary>
	///     Тип файла перечислением.
	/// </summary>
	public int? FiletypeEnum { get; set; }

	/// <summary>
	///     Расширение файла.
	/// </summary>
	public string? Ext { get; set; }

	/// <summary>
	///     Ширина изображения/видео.
	/// </summary>
	public int? Width { get; set; }

	/// <summary>
	///     Высота изображения/видео.
	/// </summary>
	public int? Height { get; set; }

	/// <summary>
	///     Продолжительность видео.
	/// </summary>
	public double? Duration { get; set; }

	/// <summary>
	///     Количество кадров.
	/// </summary>
	public ulong? NumFrames { get; set; }

	/// <summary>
	///     Есть аудио.
	/// </summary>
	public bool? HasAudio { get; set; }

	/// <summary>
	///     Время изменения файла.
	/// </summary>
	public double? TimeModified { get; set; }

	/// <summary>
	///     Время изменения файла из разных источников, где ключ - домен сайта.
	/// </summary>
	public Dictionary<string, double>? TimeModifiedDetails { get; set; }

	/// <summary>
	///     Сервисы, в которых находится или был файл.
	/// </summary>
	public FileServices? FileServices { get; set; }

	/// <summary>
	///     Служебный ключ ipfs в любом известном мультихеше для файла.
	/// </summary>
	public Dictionary<string, string>? IpfsMultihashes { get; set; }

	/// <summary>
	///     Количество слов.
	/// </summary>
	public ulong? NumWords { get; set; }

	/// <summary>
	///     Во входящих.
	/// </summary>
	public bool? IsInbox { get; set; }

	/// <summary>
	///     Локальный.
	/// </summary>
	public bool? IsLocal { get; set; }

	/// <summary>
	///     В мусорке.
	/// </summary>
	public bool? IsTrashed { get; set; }

	/// <summary>
	///     Удален.
	/// </summary>
	public bool? IsDeleted { get; set; }

	/// <summary>
	///     Имеет Exchangeable Image File Format.
	/// </summary>
	public bool? HasExif { get; set; }

	/// <summary>
	///     Имеет встроенные метаданные, понятные человеку.
	/// </summary>
	public bool? HasHumanReadableEmbeddedMetadata { get; set; }

	/// <summary>
	///     Имеет цветовой профиль.
	/// </summary>
	public bool? HasIccProfile { get; set; }

	/// <summary>
	///     Имеет прозрачность.
	/// </summary>
	public bool? HasTransparency { get; set; }

	/// <summary>
	///     Известные ссылки.
	/// </summary>
	public List<Uri>? KnownUrls { get; set; }

	/// <summary>
	///     Детальное описание известных ссылок.
	/// </summary>
	public List<UrlDetailedDefinition>? DetailedKnownUrls { get; set; }

	/// <summary>
	///     Рейтинг, где ключ - идентификатор сервиса. Значение может быть типов <see cref="int" /> или <see cref="bool" />.
	/// </summary>
	public Dictionary<string, object?>? Ratings { get; set; }

	/// <summary>
	///     Словарь с тегами, где первый ключ - уникальный идентификатор сервиса, второй, тип тегов.
	/// </summary>
	public Dictionary<string, TagsDefinitions>? Tags { get; set; }

	/// <summary>
	///     Статистика просмотра файла.
	/// </summary>
	public List<FileViewingStatistic>? FileViewingStatistics { get; set; }

	#region Эскиз

	/// <summary>
	///     Хэш эскиза в формате base83.
	/// </summary>
	public string? Blurhash { get; set; }

	/// <summary>
	///     Хэш эскиза в формате SHA256.
	/// </summary>
	public string? PixelHash { get; set; }

	/// <summary>
	///     Ширина эскиза.
	/// </summary>
	public int? ThumbnailWidth { get; set; }

	/// <summary>
	///     Высота эскиза.
	/// </summary>
	public int? ThumbnailHeight { get; set; }

	#endregion
}

/// <summary>
///     Идентификаторы файлов.
/// </summary>
public class MetaDataId
{
	#region Идентификаторы

	/// <summary>
	///     Идентификатор файла. Null если опрошенный хэш еще не был объявлен в Hydrus.
	/// </summary>
	public ulong? FileId { get; set; }

	/// <summary>
	///     Хэш (SHA256) файла.
	/// </summary>
	public string Hash { get; set; } = default!;

	#endregion
}

/// <summary>
///     Типы тегов.
/// </summary>
public enum TagsTypes
{
	/// <summary>
	///     Теги существующие в сервисе.
	/// </summary>
	Current = 0,

	/// <summary>
	///     Теги удаленный из сервиса.
	/// </summary>
	Pending = 1,

	/// <summary>
	///     Теги, которые находятся в очереди на добавление.
	/// </summary>
	Deleted = 2,

	/// <summary>
	///     Теги, которые находятся в очереди на удаление.
	/// </summary>
	Petitioned = 3
}

/// <summary>
///     Сервисы, в которых находится или был файл.
/// </summary>
public class FileServices
{
	/// <summary>
	///     Текущие сервисы.
	/// </summary>
	public Dictionary<string, ServiceDefinitions>? Current { get; set; }

	/// <summary>
	///     Удален из сервисов.
	/// </summary>
	public Dictionary<string, ServiceDefinitions>? Deleted { get; set; }
}

/// <summary>
///     Статистика просмотра файла.
/// </summary>
public class FileViewingStatistic
{
	/// <summary>
	///     Тип вьювера.
	/// </summary>
	public CanvasTypes CanvasType { get; set; }

	/// <summary>
	///     Тип вьювера строкой.
	/// </summary>
	public string CanvasTypePretty { get; set; } = default!;

	/// <summary>
	///     Количество просмотров.
	/// </summary>
	public int Views { get; set; }

	/// <summary>
	///     Общее время просмотра.
	/// </summary>
	public double Viewtime { get; set; }

	/// <summary>
	///     Последнее время просмотра.
	/// </summary>
	public double? LastViewedTimestamp { get; set; }
}

/// <summary>
///     Разделитель тегов.
/// </summary>
public class TagsDefinitions : AbstractService
{
	/// <summary>
	///     Физический тэе.
	/// </summary>
	public Dictionary<TagsTypes, List<string>> StorageTags { get; set; } = new();

	/// <summary>
	///     Отображаемый тег.
	/// </summary>
	public Dictionary<TagsTypes, List<string>> DisplayTags { get; set; } = new();
}

/// <summary>
///     Разделитель сервисов.
/// </summary>
public class ServiceDefinitions : AbstractService
{
	/// <summary>
	///     Время импорта.
	/// </summary>
	public double? TimeImported { get; set; }

	/// <summary>
	///     Время удаления.
	/// </summary>
	public double? TimeDeleted { get; set; }
}

/// <summary>
///     Абстракция сервисов.
/// </summary>
public abstract class AbstractService
{
	/// <summary>
	///     Название сервиса.
	/// </summary>
	public string Name { get; set; }

	/// <summary>
	///     Тип сервиса.
	/// </summary>
	public ServicesTypes? Type { get; set; }

	/// <summary>
	///     Тип сервиса строкой.
	/// </summary>
	public string? TypePretty { get; set; }
}

/// <summary>
///     Информация об URL.
/// </summary>
public class UrlDetailedDefinition : ApiVersion
{
	/// <summary>
	///     Норма-лизированная URL.
	/// </summary>
	public Uri NormalisedUrl { get; set; } = default!;

	/// <summary>
	///     Тип URL.
	/// </summary>
	public UrlType UrlType { get; set; } = default!;

	/// <summary>
	///     Тип URL строкой.
	/// </summary>
	public string UrlTypeString { get; set; } = default!;

	/// <summary>
	///     Название совпавшего типа.
	/// </summary>
	public string? MatchName { get; set; }

	/// <summary>
	///     Можно спарсить.
	/// </summary>
	public bool CanParse { get; set; }

	/// <summary>
	///     Причина по которой не возможно спарсить.
	/// </summary>
	public string? CannotParseReason { get; set; }
}
