using System.Security.Authentication;

namespace HydrusAPI.Web;

/// <summary>
///     Запрос преобразования хеша файла.
/// </summary>
public class FileHashesRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <param name="desiredHashType">Тип хеша, который необходимо получить.</param>
	/// <param name="sourceHashType">Тип отправленного хеша. По умолчанию - <see cref="HashAlgorithmType.Sha256" />.</param>
	public FileHashesRequest(string hash, HashAlgorithmType desiredHashType, HashAlgorithmType sourceHashType = HashAlgorithmType.Sha256)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(hash);

		Hash = hash;
		SourceHashType = sourceHashType.ToString().ToLower();
		DesiredHashType = desiredHashType.ToString().ToLower();
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	/// <param name="desiredHashType">Тип хеша, который необходимо получить.</param>
	/// <param name="sourceHashType">Тип отправленного хеша. По умолчанию - <see cref="HashAlgorithmType.Sha256" />.</param>
	public FileHashesRequest(IList<string>? hashes, HashAlgorithmType desiredHashType, HashAlgorithmType sourceHashType = HashAlgorithmType.Sha256)
	{
		if (hashes?.Any() ?? false)
		{
			Hashes = hashes.ToList();
		}

		SourceHashType = sourceHashType.ToString().ToLower();
		DesiredHashType = desiredHashType.ToString().ToLower();
	}

	/// <summary>
	///     Хэш файла.
	/// </summary>
	public string? Hash { get; set; }

	/// <summary>
	///     Коллекция хешей файлов.
	/// </summary>
	public List<string>? Hashes { get; set; }

	/// <summary>
	///     Тип отправленного хеша. Для определения тип рекомендуется использовать <see cref="HashAlgorithmType" />, см. пример.
	/// </summary>
	/// <code>
	/// 	HashAlgorithmType.Sha256.ToString().ToLower();
	/// </code>
	/// <remarks>
	///     По умолчанию - <see cref="HashAlgorithmType.Sha256" />.
	/// </remarks>
	public string SourceHashType { get; set; }

	/// <summary>
	///     Тип хеша, который необходимо получить. Для определения тип рекомендуется использовать <see cref="HashAlgorithmType" />, см. пример.
	/// </summary>
	/// <code>
	/// 	HashAlgorithmType.Sha256.ToString().ToLower();
	///  </code>
	public string DesiredHashType { get; set; }
}
