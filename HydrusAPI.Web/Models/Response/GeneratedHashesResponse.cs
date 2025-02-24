namespace HydrusAPI.Web;

/// <summary>
///     Сгенерированные хэши (SHA256) произвольного файла.
/// </summary>
public class GeneratedHashesResponse : HashResponse
{
	/// <summary>
	///     Список перцептивных хешей для файла.
	/// </summary>
	public List<string>? PerceptualHashes { get; set; }

	/// <summary>
	///     Хеш (SHA256) отрендеренного изображения.
	/// </summary>
	public string? PixelHash { get; set; }
}
