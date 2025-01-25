namespace HydrusAPI.Web;

/// <summary>
///     Стандартная ошибка Hydrus.
/// </summary>
public class ApiError : ApiVersion
{
	/// <summary>
	///     Конструктор по умолчанию.
	/// </summary>
	public ApiError()
	{
	}

	/// <summary>
	///     Конструктор по умолчанию.
	/// </summary>
	/// <param name="message">Ошибка.</param>
	public ApiError(string message)
	{
		Error = message;
	}

	/// <summary>
	///     Текстовая описание ошибки.
	/// </summary>
	public string Error { get; set; } = default!;

	/// <summary>
	///     Тип ошибки.
	/// </summary>
	public string ExceptionType { get; set; } = default!;

	/// <summary>
	///     Статус.
	/// </summary>
	public int StatusCode { get; set; }
}
