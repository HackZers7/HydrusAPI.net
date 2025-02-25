namespace HydrusAPI.Web;

/// <summary>
/// Запрос получения статистики.
/// </summary>
public class BonesRequest : FilesWithDomainRequest
{
	/// <summary>
	/// Необязательно, шестнадцатеричный ключ домена тегов.
	/// </summary>
	public string? TagServiceKey { get; set; }
}
