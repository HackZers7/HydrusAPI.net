namespace HydrusAPI.Web;

/// <summary>
///     Запрос на взаимодействие со временем.
/// </summary>
public class ViewtimeRequest
{
	// TODO: Переделать на билдер

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
