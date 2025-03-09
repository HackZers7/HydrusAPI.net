
namespace HydrusAPI.Web;

/// <summary>
///     Запрос на взаимодействие со временем.
/// </summary>
public class ViewTimeRequest : FilesRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <param name="type">Тип холста.</param>
	/// <param name="viewTime">Как долго пользователь просматривал файл. Unix-формат.</param>
	public ViewTimeRequest(string hash, CanvasTypes type, double viewTime) : base(hash)
	{
		CanvasType = (int)type;
		Viewtime = viewTime;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	/// <param name="type">Тип холста.</param>
	/// <param name="viewTime">Как долго пользователь просматривал файл. Unix-формат.</param>
	public ViewTimeRequest(ulong id, CanvasTypes type, double viewTime) : base(id)
	{
		CanvasType = (int)type;
		Viewtime = viewTime;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	/// <param name="type">Тип холста.</param>
	/// <param name="viewTime">Как долго пользователь просматривал файл. Unix-формат.</param>
	public ViewTimeRequest(IList<string>? hashes, CanvasTypes type, double viewTime) : base(hashes)
	{
		CanvasType = (int)type;
		Viewtime = viewTime;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Коллекция идентификаторов файлов.</param>
	/// <param name="type">Тип холста.</param>
	/// <param name="viewTime">Как долго пользователь просматривал файл. Unix-формат.</param>
	public ViewTimeRequest(IList<ulong>? fileIds, CanvasTypes type, double viewTime) : base(fileIds)
	{
		CanvasType = (int)type;
		Viewtime = viewTime;
	}

	/// <summary>
	///     Тип холста.
	///     <remarks>
	///         Для более удобной установки значения рекомендуется использовать <see cref="HydrusAPI.Web.CanvasTypes" />.
	///     </remarks>
	/// </summary>
	public int CanvasType { get; set; }

	/// <summary>
	///     Необязательно, время последнего просмотра в секундах.
	/// </summary>
	/// <remarks>
	/// 	Unix-формат. Рекомендуется использовать функцию для конвертирования <see cref="DateTimeOffset.FromUnixTimeSeconds"/>.
	/// </remarks>
	public double? Timestamp { get; set; }

	/// <summary>
	///     Необязательно, время последнего просмотра в миллисекундах.
	/// </summary>
	/// <remarks>
	/// 	Unix-формат. Рекомендуется использовать функцию для конвертирования <see cref="DateTimeOffset.FromUnixTimeSeconds"/>.
	/// </remarks>
	public double? TimestampMs { get; set; }

	/// <summary>
	///     Необязательно, количество добавляемых просмотров.
	/// </summary>
	/// <remarks>
	/// 	По умолчанию - 1.
	/// </remarks>
	public int Views { get; set; } = 1;

	/// <summary>
	///     Как долго пользователь просматривал файл.
	/// </summary>
	/// <remarks>
	/// 	Unix-формат. Рекомендуется использовать функцию для конвертирования <see cref="DateTimeOffset.FromUnixTimeSeconds"/>.
	/// </remarks>
	public double Viewtime { get; set; }
}
