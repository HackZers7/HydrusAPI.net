namespace HydrusAPI.Web;

/// <summary>
///     Сервис Hydrus.
/// </summary>
public class Service
{
	/// <summary>
	///     Название сервиса.
	/// </summary>
	public string Name { get; set; } = default!;

	/// <summary>
	///     Ключ сервиса.
	/// </summary>
	public string ServiceKey { get; set; } = default!;

	/// <summary>
	///     Тип сервиса.
	/// </summary>
	public ServicesTypes Type { get; set; } = default!;

	/// <summary>
	///     Человеческое описание типа.
	/// </summary>
	public string TypePretty { get; set; } = default!;

	/// <summary>
	///     Форма звезды оценочного сервиса.
	/// </summary>
	public string StarShape { get; set; } = default!;

	/// <summary>
	///     Минимально возможная оценка.
	/// </summary>
	public int MinStars { get; set; }

	/// <summary>
	///     Максимально возможная оценка.
	/// </summary>
	public int MaxStars { get; set; }
}
