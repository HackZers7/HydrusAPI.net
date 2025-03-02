
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
	public SetRatingRequest(string hash) : base(hash)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	public SetRatingRequest(ulong id) : base(id)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	public SetRatingRequest(IList<string>? hashes) : base(hashes)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Коллекция идентификаторов файлов.</param>
	public SetRatingRequest(IList<ulong>? fileIds) : base(fileIds)
	{
	}

	/// <summary>
	///     Шестнадцатеричный идентификатор сервиса.
	/// </summary>
	public string RatingServiceKey { get; set; } = default!;

	/// <summary>
	///     Рейтинг.
	///     <remarks>
	///         Может быть только <see cref="int" /> или <see cref="bool" /> в зависимости от типа рейтинговой системы.
	///     </remarks>
	/// </summary>
	public object? Rating { get; }
}
