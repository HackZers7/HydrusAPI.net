namespace HydrusAPI.Web;

/// <summary>
///     Ответ с текущими статусами задач.
/// </summary>
public class JobStatusResponse : ApiVersion
{
	/// <summary>
	///     Текущие статусы задач.
	/// </summary>
	public List<JobStatus>? JobStatuses { get; set; }
}

/// <summary>
///     Статусы заданий представляют собой общую информацию. В API они используются только для всплывающих окон.
/// </summary>
public class JobStatus
{
	/// <summary>
	///     Уникальный идентификатор задачи.
	/// </summary>
	public string Key { get; set; } = default!;

	/// <summary>
	///     Время создания задачи.
	/// </summary>
	public double CreationTime { get; set; }

	/// <summary>
	///     Заголовок задачи.
	/// </summary>
	public string? StatusTitle { get; set; } = default!;

	/// <summary>
	///     Тело задачи.
	/// </summary>
	public string? StatusText1 { get; set; }

	/// <summary>
	///     Тело задачи.
	/// </summary>
	public string? StatusText2 { get; set; }

	/// <summary>
	///     Есть ошибки.
	/// </summary>
	public bool HadError { get; set; }

	/// <summary>
	///     Текст ошибки.
	/// </summary>
	public string? Traceback { get; set; }

	/// <summary>
	///     Может быть отменена.
	/// </summary>
	public bool IsCancellable { get; set; }

	/// <summary>
	///     Задача отменена.
	/// </summary>
	public bool IsCanceled { get; set; }

	/// <summary>
	///     Задача удалена.
	/// </summary>
	public bool IsDeleted { get; set; }

	/// <summary>
	///     Задача может быть приостановлена.
	/// </summary>
	public bool IsPausable { get; set; }

	/// <summary>
	///     Задача приостановлена.
	/// </summary>
	public bool IsPaused { get; set; }

	/// <summary>
	///     Задача исполняется.
	/// </summary>
	public bool IsWorking { get; set; }

	/// <summary>
	///     Статус работы задачи. Собирается из <see cref="StatusTitle" />, <see cref="StatusText1" />, <see cref="StatusText2" /> и <see cref="Traceback" />.
	/// </summary>
	public string? NiceString { get; set; }

	/// <summary>
	///     Можно ли объединять файлы относящиеся задаче, с файлами другой задачи с таким же лейблом.
	/// </summary>
	public bool AttachedFilesMergable { get; set; }

	/// <summary>
	///     Коллекция с числами, представляющая индикатор выполнения.
	///     Первое число - текущее, второе максимальное. Минимальное всегда 0.
	/// </summary>
	public List<ushort>? PopupGauge1 { get; set; }

	/// <summary>
	///     Коллекция с числами, представляющая индикатор выполнения.
	///     Первое число - текущее, второе максимальное. Минимальное всегда 0.
	/// </summary>
	public List<ushort>? PopupGauge2 { get; set; }

	/// <summary>
	///     Произвольный объект.
	/// </summary>
	public object? ApiData { get; set; }

	/// <summary>
	///     Файлы привязанные к задаче.
	/// </summary>
	public Files? Files { get; set; }

	/// <summary>
	///     Лейбл кнопки, вызываемой пользователем.
	/// </summary>
	public string? UserCallableLabel { get; set; }

	/// <summary>
	///     Текущая сетевая задача.
	/// </summary>
	public NetworkJob? NetworkJob { get; set; }
}

/// <summary>
///     Файлы привязанные к задаче.
/// </summary>
public class Files
{
	/// <summary>
	///     Коллекция хешей (SHA256).
	/// </summary>
	public List<string>? Hashes { get; set; }

	/// <summary>
	///     Отображаемый лейбл.
	/// </summary>
	public string? Label { get; set; }
}

/// <summary>
///     Сетевая задача.
/// </summary>
public class NetworkJob
{
	/// <summary>
	///     Используемая URL.
	/// </summary>
	public Uri? Url { get; set; } = default!;

	/// <summary>
	///     Ожидается ошибка подключения.
	/// </summary>
	public bool WaitingOnConnectionError { get; set; }

	/// <summary>
	///     Нормальный домен.
	/// </summary>
	public bool DomainOk { get; set; }

	public bool WaitingOnServersideBandwidth { get; set; }

	/// <summary>
	///     Еще нет движка.
	/// </summary>
	public bool NoEngineYet { get; set; }

	/// <summary>
	///     Есть ошибки.
	/// </summary>
	public bool HadError { get; set; }

	/// <summary>
	///     Общее количество использованных байтов.
	/// </summary>
	public ulong? TotalDataUsed { get; set; }

	/// <summary>
	///     Выполнено.
	/// </summary>
	public bool IsDone { get; set; }

	/// <summary>
	///     Статус.
	/// </summary>
	public string? StatusText { get; set; }

	/// <summary>
	///     Скорость (количество байт в секунду).
	/// </summary>
	public ulong? CurrentSpeed { get; set; }

	/// <summary>
	///     Количество прочитанных байтов.
	/// </summary>
	public ulong? BytesRead { get; set; }

	/// <summary>
	///     Количество байтов для чтения.
	/// </summary>
	public ulong? BytesToRead { get; set; }
}
