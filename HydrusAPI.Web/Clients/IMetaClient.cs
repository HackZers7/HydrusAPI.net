namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для редактирования метаданных файла.
/// </summary>
public interface IMetaClient
{
	/// <summary>
	///     Устанавливает рейтинг файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRatings" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetRating(SetRatingRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Добавляет время в статистику просмотра.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> IncrementFileViewtime(ViewtimeRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает статичное время просмотра в статистике.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetFileViewtime(ViewtimeRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает время для файла.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileTimes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetTime(SetTimeRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает заметки файлу.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileNotes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="NotesResponse" /> с текущими заметками.</returns>
	Task<NotesResponse> SetNotes(SetNotesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Производит удаление заметок.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileNotes" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DeleteNotes(DeleteNotesRequest request, CancellationToken cancel = default);
}
