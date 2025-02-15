namespace HydrusAPI.Web;

/// <summary>
///     Ответ с метаданными файла.
/// </summary>
public class MetaDataResponse<T> : ServicesResponse where T : class
{
	/// <summary>
	///     Коллекция метаданных.
	/// </summary>
	public List<T> Metadata { get; set; } = default!;
}
