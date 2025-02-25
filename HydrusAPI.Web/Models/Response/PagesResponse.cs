namespace HydrusAPI.Web;

/// <summary>
///     Ответ со всеми станицами.
/// </summary>
public class PagesResponse
{
	/// <summary>
	///     Страницы.
	/// </summary>
	public Page Pages { get; set; } = default!;
}

/// <summary>
///     Ответ с информацией об странице.
/// </summary>
public class PageInfoResponse
{
	/// <summary>
	/// Информация об странице.
	/// </summary>
	public Page PageInfo { get; set; } = default!;

	public Media? Media { get; set; }
}

/// <summary>
///     Страница.
/// </summary>
public class Page
{
	/// <summary>
	///     Наименование.
	/// </summary>
	public string Name { get; set; } = default!;

	/// <summary>
	///     Уникальный ключ страницы.
	/// </summary>
	public string PageKey { get; set; } = default!;

	/// <summary>
	///     Статус страницы.
	/// </summary>
	public PageStates PageState { get; set; }

	/// <summary>
	///     Тип страницы.
	/// </summary>
	public PageTypes PageType { get; set; }

	/// <summary>
	///     Это обычная страница.
	/// </summary>
	public bool IsMediaPage { get; set; }

	/// <summary>
	///     Страница выбрана.
	/// </summary>
	public bool Selected { get; set; }

	/// <summary>
	///     Дочерние страницы.
	/// </summary>
	public List<Page>? Pages { get; set; }

	public Management? Management { get; set; }
}

/// <summary>
///     Статус страницы.
/// </summary>
public enum PageStates
{
	/// <summary>
	///     Ready.
	/// </summary>
	Ready = 0,

	/// <summary>
	///     Initialising.
	/// </summary>
	Initialising = 1,

	/// <summary>
	///     Searching/Loading.
	/// </summary>
	SearchingLoading = 2,

	/// <summary>
	///     Search cancelled.
	/// </summary>
	SearchCancelled = 3
}

/// <summary>
///     Тип страницы.
/// </summary>
public enum PageTypes
{
	/// <summary>
	///     Gallery downloader.
	/// </summary>
	GalleryDownloader = 1,

	/// <summary>
	///     Simple downloader.
	/// </summary>
	SimpleDownloader = 2,

	/// <summary>
	///     Hard drive import.
	/// </summary>
	HardDriveImport = 3,

	/// <summary>
	///     Petitions (used by repository janitors).
	/// </summary>
	Petitions = 5,

	/// <summary>
	///     File search.
	/// </summary>
	FileSearch = 6,

	/// <summary>
	///     URL downloader.
	/// </summary>
	UrlDownloader = 7,

	/// <summary>
	///     Duplicates
	/// </summary>
	/// .
	Duplicates = 8,

	/// <summary>
	///     Thread watcher.
	/// </summary>
	ThreadWatcher = 9,

	/// <summary>
	///     Page of pages
	/// </summary>
	PageOfPages = 10
}

// TODO: Проверить Management на содержание других наблюдателей

public class Media
{
	public int NumFiles { get; set; }
}

public class Management
{
	public MultipleWatcherImport MultipleWatcherImport { get; set; }
	public string Highlight { get; set; }
}

public class MultipleWatcherImport
{
	public List<WatcherImport> WatcherImports { get; set; }
}

public class WatcherImport
{
	public string Url { get; set; }
	public string WatcherKey { get; set; }
	public int Created { get; set; }
	public int LastCheckTime { get; set; }
	public int NextCheckTime { get; set; }
	public bool FilesPaused { get; set; }
	public bool CheckingPaused { get; set; }
	public int CheckingStatus { get; set; }
	public string Subject { get; set; }
	public Imports Imports { get; set; }
	public GalleryLog GalleryLog { get; set; }
}

public class GalleryLog
{
	public string Status { get; set; }
	public string SimpleStatus { get; set; }
	public int TotalProcessed { get; set; }
	public int TotalToProcess { get; set; }
}

public class Imports
{
	public string Status { get; set; }
	public string SimpleStatus { get; set; }
	public int TotalProcessed { get; set; }
	public int TotalToProcess { get; set; }
}