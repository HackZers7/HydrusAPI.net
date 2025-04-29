namespace HydrusAPI.Web;

/// <summary>
///     Обновить уведомление.
/// </summary>
public class UpdatePopupRequest : JobStatusKeyRequest
{
    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="jobStatusKey">Уникальный идентификатор задачи.</param>
    public UpdatePopupRequest(string jobStatusKey) : base(jobStatusKey)
    {
    }

    /// <summary>
    ///     Заголовок задачи.
    /// </summary>
    public string? StatusTitle { get; set; } = default!;

    /// <summary>
    ///     Тело задачи.
    /// </summary>
    public string? StatusText_1 { get; set; }

    /// <summary>
    ///     Коллекция с числами, представляющая индикатор выполнения.
    ///     Первое число - текущее, второе максимальное. Минимальное всегда 0.
    /// </summary>
    public List<ushort>? PopupGauge_1 { get; set; }

    /// <summary>
    ///     Произвольный объект.
    /// </summary>
    public object? ApiData { get; set; }

    /// <summary>
    ///     Лейбл для приложенный файлов.
    /// </summary>
    public string? FilesLabel { get; set; }

    /// <summary>
    ///     Файлы привязанные к задаче.
    /// </summary>
    public Files? Files { get; set; }
}
