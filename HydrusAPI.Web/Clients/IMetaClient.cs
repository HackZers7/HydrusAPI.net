namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для редактирования метаданных файла.
/// </summary>
public interface IMetaClient
{
	/// <summary>
	///     Отправляет запрос для установки рейтинга файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется одно из областей (разрешений):
	///     <see cref="Permissions.EditFileRatings" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetRating(SetRatingRequest request, CancellationToken cancel = default);
}
