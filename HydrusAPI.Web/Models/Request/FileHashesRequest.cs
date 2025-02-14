using System.Security.Authentication;

namespace HydrusAPI.Web;

/// <summary>
///     Запрос преобразования хэша файла.
/// </summary>
public class FileHashesRequest
{
	/// <summary>
	///     Хэш файла.
	/// </summary>
	public string? Hash { get; set; }

	/// <summary>
	///     Коллекция хэшей файлов.
	/// </summary>
	public List<string>? Hashes { get; set; }

	/// <summary>
	///     Тип отправленного хеша. Для определения тип рекомендуется использовать <see cref="HashAlgorithmType" />, см. пример.
	/// </summary>
	/// <code>
	/// 	HashAlgorithmType.Sha256.ToString().ToLower();
	///  </code>
	/// <remarks>
	///     По умолчанию - <see cref="HashAlgorithmType.Sha256" />.
	/// </remarks>
	public string SourceHashType { get; set; } = HashAlgorithmType.Sha256.ToString().ToLower();

	/// <summary>
	///     Тип хэша, который необходимо получить. Для определения тип рекомендуется использовать <see cref="HashAlgorithmType" />, см. пример.
	/// </summary>
	/// <code>
	/// 	HashAlgorithmType.Sha256.ToString().ToLower();
	///  </code>
	public string DesiredHashType { get; set; } = default!;
}
