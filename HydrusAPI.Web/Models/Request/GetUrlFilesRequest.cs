namespace HydrusAPI.Web;

/// <summary>
///		Запрос о статусах файлов по URL.
/// </summary>
public class GetUrlFilesRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="url">URL.</param>
	/// <param name="doubleCheckFileSystem">
	///     Если true – то любой результат, который <see cref="FileStatus.AlreadyExists" /> (2), будет дважды сверен с фактической файловой системой.
	///     Эта проверка выполняется в любом обычном процессе импорта файлов, для проверки и исправления отсутствующих файлов (если файл отсутствует, статус становится <see cref="FileStatus.FileNotExists" /> (0)).
	// </param>
	public GetUrlFilesRequest(string url, bool doubleCheckFileSystem = false) : this(new Uri(url), doubleCheckFileSystem)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="url">URL.</param>
	/// <param name="doubleCheckFileSystem">
	///     Если true – то любой результат, который <see cref="FileStatus.AlreadyExists" /> (2), будет дважды сверен с фактической файловой системой.
	///     Эта проверка выполняется в любом обычном процессе импорта файлов, для проверки и исправления отсутствующих файлов (если файл отсутствует, статус становится <see cref="FileStatus.FileNotExists" /> (0)).
	// </param>
	public GetUrlFilesRequest(Uri url, bool doubleCheckFileSystem = false)
	{
		ThrowHelper.ArgumentNotNull(url);

		Url = url;
		DoubleCheckFileSystem = doubleCheckFileSystem;
	}

	/// <summary>
	/// URL.
	/// </summary>
	public Uri Url { get; set; }

	/// <summary>
	///     Если true – то любой результат, который <see cref="FileStatus.AlreadyExists" /> (2), будет дважды сверен с фактической файловой системой.
	///     Эта проверка выполняется в любом обычном процессе импорта файлов, для проверки и исправления отсутствующих файлов (если файл отсутствует, статус становится <see cref="FileStatus.FileNotExists" /> (0)).
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - false.
	/// </remarks>
	public bool DoubleCheckFileSystem { get; set; } = false;
}
