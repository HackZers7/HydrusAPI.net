using System.Diagnostics;

namespace HydrusAPI.Web;

/// <summary>
///     Сервис Hydrus.
/// </summary>
[DebuggerDisplay("{ToString()}")]
public class Service
{
	/// <summary>
	///     Название сервиса.
	/// </summary>
	public string Name { get; set; } = default!;

	/// <summary>
	///     Идентификатор сервиса.
	/// </summary>
	public string? ServiceKey { get; set; }

	/// <summary>
	///     Тип сервиса.
	/// </summary>
	public ServicesTypes Type { get; set; } = default!;

	/// <summary>
	///     Описание типа.
	/// </summary>
	public string TypePretty { get; set; } = default!;

	// TODO: переделать на перечисление.
	/// <summary>
	///     Форма звезды оценочного сервиса (только для рейтинговых сервисов).
	/// </summary>
	/// <remarks>
	/// 	Возможные значения - circle | square | fat star | pentagram star.
	/// </remarks>
	public string? StarShape { get; set; }

	/// <summary>
	///     Минимально возможная оценка.
	/// </summary>
	/// <remarks>
	/// 	Возможные значения: 0 - 1.
	/// </remarks>
	public ushort MinStars { get; set; }

	/// <summary>
	///     Максимально возможная оценка.
	/// </summary>
	/// <remarks>
	/// 	Возможные значения: 1 - 20.
	/// </remarks>
	public ushort MaxStars { get; set; }

	/// <inheritdoc/>
	public override string ToString()
	{
		var key = !string.IsNullOrWhiteSpace(ServiceKey) ? $"::{ServiceKey}" : string.Empty;
		return $"{Name}{key} ({Type})";
	}
}
