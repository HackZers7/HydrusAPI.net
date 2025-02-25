using System;

namespace HydrusAPI.Web;

/// <summary>
/// Ответ со статистикой БД.
/// </summary>
public class BonesResponse : ApiVersion
{
	/// <summary>
	/// Статистика.
	/// </summary>
	public Bones BonedStats { get; set; } = default!;
}

/// <summary>
/// Статистика.
/// </summary>
public class Bones
{
	public ulong NumInbox { get; set; }
	public ulong NumArchive { get; set; }
	public ulong NumDeleted { get; set; }
	public ulong SizeInbox { get; set; }
	public ulong SizeArchive { get; set; }
	public ulong SizeDeleted { get; set; }
	public ulong EarliestImportTime { get; set; }
	public List<ulong>? TotalViewtime { get; set; }
	public ulong TotalAlternateFiles { get; set; }
	public ulong TotalDuplicateFiles { get; set; }
	public ulong TotalPotentialPairs { get; set; }
}
