using System.Text.Json;
using HydrusAPI.Web.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace HydrusAPI.Web;

/// <summary>
///     Запрос установки рейтинга.
/// </summary>
public class SetRatingRequest : FilesRequest, IConvert
{
	private readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
	{
		NullValueHandling = NullValueHandling.Include,
		ContractResolver = new DefaultContractResolver
		{
			NamingStrategy = new SnakeCaseNamingStrategy()
		}
	};

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hash">Хеш (SHA256) файла.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	public SetRatingRequest(string hash, string ratingServiceKey) : base(hash)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(ratingServiceKey);

		RatingServiceKey = ratingServiceKey;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	public SetRatingRequest(ulong id, string ratingServiceKey) : base(id)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(ratingServiceKey);

		RatingServiceKey = ratingServiceKey;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	public SetRatingRequest(IList<string>? hashes, string ratingServiceKey) : base(hashes)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(ratingServiceKey);

		RatingServiceKey = ratingServiceKey;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Коллекция идентификаторов файлов.</param>
	/// <param name="ratingServiceKey">Шестнадцатеричный идентификатор сервиса.</param>
	public SetRatingRequest(IList<ulong>? fileIds, string ratingServiceKey) : base(fileIds)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(ratingServiceKey);

		RatingServiceKey = ratingServiceKey;
	}

	/// <summary>
	///     Шестнадцатеричный идентификатор сервиса.
	/// </summary>
	public string RatingServiceKey { get; set; }

	/// <summary>
	///     Рейтинг.
	/// </summary>
	/// <remarks>
	///		Может быть только <see cref="int" /> или <see cref="bool" /> в зависимости от типа рейтинговой системы.
	/// </remarks>
	public object? Rating { get; set; }

	/// <inheritdoc />
	public string SerializeObject(JsonSerializerOptions options)
	{
		var hashName = options.PropertyNamingPolicy?.ConvertName(nameof(Hash)) ?? nameof(Hash);
		var hashesName = options.PropertyNamingPolicy?.ConvertName(nameof(Hashes)) ?? nameof(Hashes);
		var fileIdName = options.PropertyNamingPolicy?.ConvertName(nameof(FileId)) ?? nameof(FileId);
		var fileIdsName = options.PropertyNamingPolicy?.ConvertName(nameof(FileIds)) ?? nameof(FileIds);
		var ratingServiceKeyName = options.PropertyNamingPolicy?.ConvertName(nameof(RatingServiceKey)) ?? nameof(RatingServiceKey);
		var ratingName = options.PropertyNamingPolicy?.ConvertName(nameof(Rating)) ?? nameof(Rating);

		var jObject = new JObject();

		if (!string.IsNullOrWhiteSpace(Hash))
		{
			jObject.Add(new JProperty(hashName, Hash));
		}

		if (Hashes?.Count > 0)
		{
			jObject.Add(new JProperty(hashesName, Hashes));
		}

		if (FileId != null)
		{
			jObject.Add(new JProperty(fileIdName, FileId));
		}

		if (FileIds?.Count > 0)
		{
			jObject.Add(new JProperty(fileIdsName, FileIds));
		}

		if (!string.IsNullOrWhiteSpace(RatingServiceKey))
		{
			jObject.Add(new JProperty(ratingServiceKeyName, RatingServiceKey));
		}

		jObject.Add(new JProperty(ratingName, Rating));

		return JsonConvert.SerializeObject(jObject, _serializerSettings);
	}
}