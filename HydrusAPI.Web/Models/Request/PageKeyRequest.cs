namespace HydrusAPI.Web;

/// <summary>
///     Запрос с помощью уникального ключа страницы.
/// </summary>
public class PageKeyRequest
{
	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="pageKey">Уникальный ключ страницы.</param>
	public PageKeyRequest(string pageKey)
	{
		PageKey = pageKey;
	}

	/// <summary>
	///     Уникальный ключ страницы.
	/// </summary>
	public string PageKey { get; }
}
