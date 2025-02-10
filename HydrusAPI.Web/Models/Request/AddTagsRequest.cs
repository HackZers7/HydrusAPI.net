namespace HydrusAPI.Web;

/// <summary>
///     Запрос добавления тегов к файлу.
/// </summary>
public class AddTagsRequest : Files
{
	// TODO: Переписать на билдер
	// TODO: Реализовать actions...

	private Dictionary<string, List<string>>? _serviceKeysToTags;

	/// <summary>
	///     Словарь с тегами, где ключом является идентификатор сервиса, коллекцией теги.
	/// </summary>
	public IReadOnlyDictionary<string, List<string>>? ServiceKeysToTags => _serviceKeysToTags;

	public void AddTag(string serviceKey, string tag)
	{
		if (_serviceKeysToTags == null)
		{
			_serviceKeysToTags = new Dictionary<string, List<string>>();
		}

		if (!_serviceKeysToTags.TryGetValue(serviceKey, out var list))
		{
			list = new List<string>();
			_serviceKeysToTags.TryAdd(serviceKey, list);
		}

		list.Add(tag);
	}

	public void AddRangeTags(string serviceKey, IEnumerable<string> tags)
	{
		if (_serviceKeysToTags == null)
		{
			_serviceKeysToTags = new Dictionary<string, List<string>>();
		}

		if (!_serviceKeysToTags.TryGetValue(serviceKey, out var list))
		{
			list = new List<string>();
			_serviceKeysToTags.TryAdd(serviceKey, list);
		}

		list.AddRange(tags);
	}

	public bool RemoveTag(string serviceKey, string tag)
	{
		if (_serviceKeysToTags == null)
		{
			return false;
		}

		if (!_serviceKeysToTags.TryGetValue(serviceKey, out var list))
		{
			return false;
		}

		return list.Remove(tag);
	}

	public void ClearTags()
	{
		_serviceKeysToTags = null;
	}
}
