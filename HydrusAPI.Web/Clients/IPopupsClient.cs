namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы со всплывающими окнами Hydrus.
/// </summary>
public interface IPopupsClient
{
	/// <summary>
	///     Запрашивает все всплывающие окна.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePopups" />.
	/// </remarks>
	/// <param name="onlyInView">Только те окна, которые сейчас отображаются в клиенте. По умолчанию - false.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает перечисление с текущими задачами.</returns>
	Task<IEnumerable<JobStatus>> GetPopups(bool onlyInView = false, CancellationToken cancel = default);

	/// <summary>
	///     Добавляет новое всплывающее окно.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePopups" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает созданную задачу.</returns>
	Task<JobStatus> AddPopup(JobStatus request, CancellationToken cancel = default);

	/// <summary>
	///     Вызывает пользовательскую функцию.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePopups" />.
	/// </remarks>
	/// <param name="jobStatusKey">Уникальный идентификатор задачи.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> CallUserCallable(string jobStatusKey, CancellationToken cancel = default);

	/// <summary>
	///     Пытается отменить отображение всплывающего окна.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePopups" />.
	/// </remarks>
	/// <param name="jobStatusKey">Уникальный идентификатор задачи.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> CancelPopup(string jobStatusKey, CancellationToken cancel = default);

	/// <summary>
	///     Пытается закрыть всплывающее окно.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePopups" />.
	/// </remarks>
	/// <param name="jobStatusKey">Уникальный идентификатор задачи.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> DismissPopup(string jobStatusKey, CancellationToken cancel = default);

	/// <summary>
	///     Пытается завершить всплывающее окно.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePopups" />.
	/// </remarks>
	/// <param name="jobStatusKey">Уникальный идентификатор задачи.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> FinishPopup(string jobStatusKey, CancellationToken cancel = default);
	
	/// <summary>
	///     Пытается завершить и закрыть всплывающее окно.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePopups" />.
	/// </remarks>
	/// <param name="jobStatusKey">Уникальный идентификатор задачи.</param>
	/// <param name="seconds">Необязательно, количество секунд, которое ожидается перед закрытием всплывающего окна.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> FinishAndDismissPopup(string jobStatusKey, ulong? seconds = null, CancellationToken cancel = default);
	
	/// <summary>
	///     Обновляет всплывающее окно.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.ManagePopups" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает обновленную задачу.</returns>
	Task<JobStatus> UpdatePopup(JobStatus request, CancellationToken cancel = default);
}
