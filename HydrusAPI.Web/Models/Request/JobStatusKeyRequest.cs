namespace HydrusAPI.Web;

/// <summary>
///     Запрос по ключу зачади.
/// </summary>
public class JobStatusKeyRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="jobStatusKey">Уникальный идентификатор задачи.</param>
	/// <param name="seconds">Необязательно, количество секунд, которое ожидается перед закрытием всплывающего окна.</param>
	public JobStatusKeyRequest(string jobStatusKey, ulong? seconds = null)
	{
		JobStatusKey = jobStatusKey;
		Seconds = seconds;
	}

	/// <summary>
	///     Уникальный идентификатор задачи.
	/// </summary>
	public string JobStatusKey { get; }

	/// <summary>
	///     Необязательно, количество секунд, которое ожидается перед закрытием всплывающего окна.
	/// </summary>
	public ulong? Seconds { get; }
}
