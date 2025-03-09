using System.Text.Json;
using HydrusAPI.Web.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HydrusAPI.Web.Http;

/// <summary>
///     Базовый сериализатор для работы с API.
/// </summary>
public class NewtonsoftJsonSerializer : IJsonSerializer
{
	private readonly JsonSerializerSettings _serializerSettings;

	private readonly JsonSerializerOptions _serializerOptions;

	/// <summary>
	///     Инициализирует новый экземпляр сериализатора.
	/// </summary>
	public NewtonsoftJsonSerializer()
	{
		var contractResolver = new DefaultContractResolver
		{
			NamingStrategy = new SnakeCaseNamingStrategy()
		};

		_serializerSettings = new JsonSerializerSettings
		{
			NullValueHandling = NullValueHandling.Ignore,
			ContractResolver = contractResolver
		};

		_serializerOptions = new JsonSerializerOptions()
		{
			PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
		};
	}

	/// <inheritdoc />
	public void SerializeRequest(IRequest request)
	{
		ThrowHelper.ArgumentNotNull(request);

		if (request.Body is string || request.Body is Stream || request.Body is HttpContent || request.Body is null)
		{
			return;
		}

		if (request.Body is IConvert convert)
		{
			request.Body = convert.SerializeObject(_serializerOptions);
			return;
		}

		request.Body = JsonConvert.SerializeObject(request.Body, _serializerSettings);
	}

	/// <inheritdoc />
	public IApiResponse<T> DeserializeResponse<T>(IResponse response)
	{
		ThrowHelper.ArgumentNotNull(response);

		if (response.ContentType?.Equals("application/json", StringComparison.OrdinalIgnoreCase) is true)
		{
			var body = JsonConvert.DeserializeObject<T>(response.Body as string ?? "", _serializerSettings);
			return new ApiResponse<T>(response, body!);
		}

		return new ApiResponse<T>(response);
	}
}
