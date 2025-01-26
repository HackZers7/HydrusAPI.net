namespace HydrusAPI.Web;

/// <summary>
///     Статусы импорта.
/// </summary>
public enum ImportStatus
{
	/// <summary>
	///     Успешно импортирован.
	/// </summary>
	Success = 1,

	/// <summary>
	///     Уже существует в БД.
	/// </summary>
	AlreadyExists = 2,

	/// <summary>
	///     Был ранее удален.
	/// </summary>
	PreviouslyDeleted = 3,

	/// <summary>
	///     Не ужалось импортировать.
	/// </summary>
	Failed = 4,

	/// <summary>
	///     Вето.
	/// </summary>
	Veto = 7
}
