
namespace HydrusAPI.Web;

/// <summary>
///     Запрос получения оставшихся потенциальных пар дубликатов.
/// </summary>
public class GetPotentialsPairsRequest : GetPotentialsRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	public GetPotentialsPairsRequest(string hash) : base(hash)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	public GetPotentialsPairsRequest(ulong id) : base(id)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	public GetPotentialsPairsRequest(IList<string>? hashes) : base(hashes)
	{
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Коллекция идентификаторов файлов.</param>
	public GetPotentialsPairsRequest(IList<ulong>? fileIds) : base(fileIds)
	{
	}

	/// <summary>
	///     Необязательно, максимальное количество пар.
	/// </summary>
	/// <remarks>
	///     По умолчанию - определяется клиентом.
	/// </remarks>
	public int? MaxNumPairs { get; set; }
}
