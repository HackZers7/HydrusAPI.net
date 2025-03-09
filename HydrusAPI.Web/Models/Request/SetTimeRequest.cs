
using System.Text.Json;
using HydrusAPI.Web.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace HydrusAPI.Web;

/// <summary>
///     Запрос установки времени.
/// </summary>
public class SetTimeRequest : FilesRequest, IConvert
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
	/// <param name="timestampType">Тип времени.</param>
	public SetTimeRequest(string hash, TimestampTypes timestampType) : base(hash)
	{
		TimestampType = (int)timestampType;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="id">Идентификатор файла.</param>
	/// <param name="timestampType">Тип времени.</param>
	public SetTimeRequest(ulong id, TimestampTypes timestampType) : base(id)
	{
		TimestampType = (int)timestampType;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="hashes">Коллекция хешей (SHA256) файлов.</param>
	/// <param name="timestampType">Тип времени.</param>
	public SetTimeRequest(IList<string>? hashes, TimestampTypes timestampType) : base(hashes)
	{
		TimestampType = (int)timestampType;
	}

	/// <summary>
	///     Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="fileIds">Коллекция идентификаторов файлов.</param>
	/// <param name="timestampType">Тип времени.</param>
	public SetTimeRequest(IList<ulong>? fileIds, TimestampTypes timestampType) : base(fileIds)
	{
		TimestampType = (int)timestampType;
	}

	/// <summary>
	///     Необязательно, время последнего просмотра в секундах.
	/// </summary>
	/// <remarks>
	/// 	Unix-формат. Рекомендуется использовать функцию для конвертирования <see cref="DateTimeOffset.FromUnixTimeSeconds"/>.
	/// </remarks>
	public double? Timestamp { get; set; }

	/// <summary>
	///     Необязательно, время последнего просмотра в миллисекундах.
	/// </summary>
	/// <remarks>
	/// 	Unix-формат. Рекомендуется использовать функцию для конвертирования <see cref="DateTimeOffset.FromUnixTimeSeconds"/>.
	/// </remarks>
	public double? TimestampMs { get; set; }

	/// <summary>
	///     Тип времени, который редактируется.
	/// </summary>
	/// <remarks>
	/// 	Для более удобной установки значения рекомендуется использовать <see cref="HydrusAPI.Web.TimestampTypes" />.
	/// </remarks>
	public int? TimestampType { get; set; }

	/// <summary>
	///     Ключ файлового сервиса.
	/// </summary>
	/// <remarks>
	/// 	Обязателен при <see cref="TimestampTypes.FileImportTime"/>/<see cref="TimestampTypes.FileDeleteTime"/>/'previously imported'.
	/// </remarks>
	public string? FileServiceKey { get; set; }

	/// <summary>
	///     Тип холста.
	/// </summary>
	/// <remarks>
	/// 	Обязателен при <see cref="TimestampTypes.LastViewed"/>
	/// 	Для более удобной установки значения рекомендуется использовать <see cref="HydrusAPI.Web.CanvasTypes" />.
	/// </remarks>
	public int? CanvasType { get; set; }

	/// <summary>
	///     Домен.
	/// </summary>
	/// <remarks>
	/// 	Обязателен при <see cref="TimestampTypes.FileModifiedTimeWeb"/>
	/// </remarks>
	public string? Domain { get; set; }

	/// <inheritdoc />
	public string SerializeObject(JsonSerializerOptions options)
	{
		var hashName = options.PropertyNamingPolicy?.ConvertName(nameof(Hash)) ?? nameof(Hash);
		var hashesName = options.PropertyNamingPolicy?.ConvertName(nameof(Hashes)) ?? nameof(Hashes);
		var fileIdName = options.PropertyNamingPolicy?.ConvertName(nameof(FileId)) ?? nameof(FileId);
		var fileIdsName = options.PropertyNamingPolicy?.ConvertName(nameof(FileIds)) ?? nameof(FileIds);
		var timestampTypeName = options.PropertyNamingPolicy?.ConvertName(nameof(TimestampType)) ?? nameof(TimestampType);
		var timestampName = options.PropertyNamingPolicy?.ConvertName(nameof(Timestamp)) ?? nameof(Timestamp);
		var timestampMsName = options.PropertyNamingPolicy?.ConvertName(nameof(TimestampMs)) ?? nameof(TimestampMs);
		var fileServiceKeyName = options.PropertyNamingPolicy?.ConvertName(nameof(FileServiceKey)) ?? nameof(FileServiceKey);
		var canvasTypeName = options.PropertyNamingPolicy?.ConvertName(nameof(CanvasType)) ?? nameof(CanvasType);
		var domainName = options.PropertyNamingPolicy?.ConvertName(nameof(Domain)) ?? nameof(Domain);

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

		jObject.Add(new JProperty(timestampTypeName, TimestampType));

		if (Timestamp != null)
		{
			jObject.Add(new JProperty(timestampName, Timestamp));
		}
		else if (TimestampMs != null)
		{
			jObject.Add(new JProperty(timestampMsName, TimestampMs));
		}
		else
		{
			jObject.Add(new JProperty(timestampName, null));
		}

		if (!string.IsNullOrWhiteSpace(FileServiceKey))
		{
			jObject.Add(new JProperty(fileServiceKeyName, FileServiceKey));
		}

		if (CanvasType != null)
		{
			jObject.Add(new JProperty(canvasTypeName, CanvasType));
		}

		if (!string.IsNullOrWhiteSpace(Domain))
		{
			jObject.Add(new JProperty(domainName, Domain));
		}

		return JsonConvert.SerializeObject(jObject, _serializerSettings);
	}
}
