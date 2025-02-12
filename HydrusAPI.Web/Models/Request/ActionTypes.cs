namespace HydrusAPI.Web;

/// <summary>
///     Типы действий с тегами.
/// </summary>
public enum ActionTypes
{
	/// <summary>
	///     Добавить в локальный сервис тегов.
	/// </summary>
	Add = 0,

	/// <summary>
	///     Удалить из локального сервиса тегов.
	/// </summary>
	Delete = 1,

	/// <summary>
	///     Привязать к хранилищу тегов.
	/// </summary>
	Pend = 2,

	/// <summary>
	///     Отменить привязку к хранилищу тегов.
	/// </summary>
	RescindPend = 3,

	/// <summary>
	///     Petition from a tag repository. (This is special)
	/// </summary>
	Petition = 4,

	/// <summary>
	///     Rescind a petition from a tag repository.
	/// </summary>
	RescindPetition = 5
}
