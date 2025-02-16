namespace HydrusAPI.Web;

/// <summary>
///     Запрос получения оставшихся потенциальных пар дубликатов.
/// </summary>
public class GetPotentialsPairsRequest : GetPotentialsRequest
{
	/// <summary>
	///     Необязательно, максимальное количество пар.
	/// </summary>
	/// <remarks>
	///     По умолчанию - определяется клиентом.
	/// </remarks>
	public int? MaxNumPairs { get; set; }
}
