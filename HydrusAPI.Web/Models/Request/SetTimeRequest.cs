
namespace HydrusAPI.Web;

/// <summary>
///     Запрос установки времени.
/// </summary>
public class SetTimeRequest : FilesRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	public SetTimeRequest(string hash) : base(hash)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	public SetTimeRequest(ulong id) : base(id)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	public SetTimeRequest(IList<string>? hashes) : base(hashes)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Коллекция идентификаторов файлов.</param>
	public SetTimeRequest(IList<ulong>? fileIds) : base(fileIds)
	{
	}

	/// <summary>
	///     Необязательно, время последнего просмотра в секундах.
	/// </summary>
	public double? Timestamp { get; set; }

	/// <summary>
	///     Необязательно, время последнего просмотра в миллисекундах.
	/// </summary>
	public double? TimestampMs { get; set; }

	/// <summary>
	///     Тип времени, который редактируется.
	///     <remarks>
	///         Для более удобной установки значения рекомендуется использовать <see cref="HydrusAPI.Web.TimestampTypes" />.
	///     </remarks>
	/// </summary>
	public int? TimestampType { get; set; }

	/// <summary>
	///     dependant, hexadecimal, the file service you are editing in 'imported'/'deleted'/'previously imported'
	/// </summary>
	public string? FileServiceKey { get; set; }

	/// <summary>
	///     dependant, int, the canvas type you are editing in 'last viewed'
	///     <remarks>
	///         Для более удобной установки значения рекомендуется использовать <see cref="HydrusAPI.Web.CanvasTypes" />.
	///     </remarks>
	/// </summary>
	public int? CanvasType { get; set; }

	/// <summary>
	///     dependant, string, the domain you are editing in 'modified (web domain)'
	/// </summary>
	public string? Domain { get; set; }
}
