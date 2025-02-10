namespace HydrusAPI.Web;

/// <summary>
///     Запрос установки рейтинга.
/// </summary>
public class SetRatingRequest : Files
{
	/// <summary>
	///     Идентификатор сервиса.
	/// </summary>
	public string RatingServiceKey { get; set; } = default!;

	/// <summary>
	///     Рейтинг.
	/// </summary>
	public object? Rating { get; private set; }

	public void SetRating(bool rating)
	{
		Rating = rating;
	}

	public void SetRating(int rating)
	{
		Rating = rating;
	}
}
