namespace HydrusAPI.Web;

/// <summary>
///     Представляет файловый домен Hydrus.
/// </summary>
public abstract class FileDomainRequest
{
	/// <summary>
	///     Шестнадцатеричный ключ домена, в котором выполняется поиск.
	/// </summary>
	public string? FileServiceKey { get; set; }

	/// <summary>
	///     Коллекция шестнадцатеричных ключей доменов, объединение доменов файлов, по которым выполняется поиск.
	/// </summary>
	public List<string>? FileServiceKeys { get; set; }

	/// <summary>
	///     Шестнадцатеричный ключ домена, в котором выполняется поиск.
	/// </summary>
	public string? DeletedFileServiceKey { get; set; }

	/// <summary>
	///     Коллекция шестнадцатеричных ключей доменов, объединение "deleted from this file domain", по которым выполняется поиск.
	/// </summary>
	public List<string>? DeletedFileServiceKeys { get; set; }
}
