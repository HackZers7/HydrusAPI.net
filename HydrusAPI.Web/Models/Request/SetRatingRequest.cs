namespace HydrusAPI.Web;

/// <summary>
///     Запрос установки рейтинга.
/// </summary>
public class SetRatingRequest : FilesRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	public SetRatingRequest(string hash, string ratingServiceKey) : base(hash)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(ratingServiceKey);

		RatingServiceKey = ratingServiceKey;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	public SetRatingRequest(ulong id, string ratingServiceKey) : base(id)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(ratingServiceKey);

		RatingServiceKey = ratingServiceKey;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	public SetRatingRequest(IList<string>? hashes, string ratingServiceKey) : base(hashes)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(ratingServiceKey);

		RatingServiceKey = ratingServiceKey;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Коллекция идентификаторов файлов.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	public SetRatingRequest(IList<ulong>? fileIds, string ratingServiceKey) : base(fileIds)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(ratingServiceKey);

		RatingServiceKey = ratingServiceKey;
	}

	/// <summary>
	///     Шестнадцатеричный идентификатор сервиса.
	/// </summary>
	public string RatingServiceKey { get; set; }

	/// <summary>
	///     Рейтинг.
	/// </summary>
	/// <remarks>
	///		Может быть только <see cref="int" /> или <see cref="bool" /> в зависимости от типа рейтинговой системы.
	/// </remarks>
	public object? Rating { get; set; }
}
