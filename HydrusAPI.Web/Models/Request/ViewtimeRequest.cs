
namespace HydrusAPI.Web;

/// <summary>
///     Запрос на взаимодействие со временем.
/// </summary>
public class ViewtimeRequest : FilesRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	public ViewtimeRequest(string hash) : base(hash)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	public ViewtimeRequest(ulong id) : base(id)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	public ViewtimeRequest(IList<string>? hashes) : base(hashes)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Коллекция идентификаторов файлов.</param>
	public ViewtimeRequest(IList<ulong>? fileIds) : base(fileIds)
	{
	}

	/// <summary>
	///     Тип, который редактируется.
	///     <remarks>
	///         Для более удобной установки значения рекомендуется использовать <see cref="HydrusAPI.Web.CanvasTypes" />.
	///     </remarks>
	/// </summary>
	public int CanvasType { get; set; }

	/// <summary>
	///     Необязательно, время последнего просмотра в секундах.
	/// </summary>
	public double? Timestamp { get; set; }

	/// <summary>
	///     Необязательно, время последнего просмотра в миллисекундах.
	/// </summary>
	public double? TimestampMs { get; set; }

	/// <summary>
	///     Необязательно, количество добавляемых просмотров.
	/// </summary>
	public int? Views { get; set; }

	/// <summary>
	///     Как долго пользователь просматривал файл.
	/// </summary>
	public double Viewtime { get; set; }
}
