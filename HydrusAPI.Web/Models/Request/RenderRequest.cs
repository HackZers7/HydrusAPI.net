namespace HydrusAPI.Web;

/// <summary>
///     Запрос рендеринга изображения.
/// </summary>
public class RenderRequest : FileRequest
{
	/// <summary>
	///     Ставит Content-Disposition=attachment.
	/// </summary>
	/// <remarks>
	///     По умолчанию - false.
	/// </remarks>
	public bool Download { get; set; } = false;

	/// <summary>
	///     Выходной формат изображения. Рекомендуется использовать <see cref="RenderOutputFormat" />
	/// </summary>
	/// <remarks>
	///     По умолчанию - <see cref="RenderOutputFormat.Png" />.
	/// </remarks>
	public int RenderFormat { get; set; }

	/// <summary>
	///     Качество выходного изображения.
	/// </summary>
	/// <remarks>
	///     По умолчанию:
	///     PNG - 1;
	///     JPEG, WEBP - 80.
	/// </remarks>
	public ushort? RenderQuality { get; set; }

	/// <summary>
	///     Ширина выходного изображения.
	/// </summary>
	public ulong? Width { get; set; }

	/// <summary>
	///     Высота выходного изображения.
	/// </summary>
	public ulong? Height { get; set; }
}

/// <summary>
///     Выходные форматы рендера.
/// </summary>
public enum RenderOutputFormat
{
	/// <summary>
	///     JPEG
	/// </summary>
	Jpeg = 1,

	/// <summary>
	///     PNG
	/// </summary>
	Png = 2,

	/// <summary>
	///     APNG
	/// </summary>
	Apng = 23,

	/// <summary>
	///     WEBP
	/// </summary>
	WebP = 33,

	/// <summary>
	///     Animated WEBP
	/// </summary>
	AWebP = 83
}
