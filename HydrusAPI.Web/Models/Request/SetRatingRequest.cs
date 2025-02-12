namespace HydrusAPI.Web;

/// <summary>
///     Запрос установки рейтинга.
/// </summary>
public class SetRatingRequest : FilesRequest
{
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
