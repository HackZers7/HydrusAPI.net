using HydrusAPI.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HydrusAPI.Web;

/// <summary>
///     Представляет ошибку, возникающую при запросе к API.
/// </summary>
[Serializable]
public class ApiException : Exception
{
	private static readonly JsonSerializerSettings _serializerSettings = new()
	{
		NullValueHandling = NullValueHandling.Ignore,
		ContractResolver = new DefaultContractResolver
		{
			NamingStrategy = new SnakeCaseNamingStrategy()
		}
	};

	/// <summary>
	///     Инициирует новый экземпляр класса ошибок API.
	/// </summary>
	public ApiException()
	{
	}

	/// <summary>
	///     Инициирует новый экземпляр класса ошибок API.
	/// </summary>
	public ApiException(string message)
		: this(GetApiErrorFromExceptionMessage(message), null)
	{
	}

	/// <summary>
	///     Инициирует новый экземпляр класса ошибок API.
	/// </summary>
	public ApiException(IResponse response)
		: this(response, null)
	{
	}

	/// <summary>
	///     Инициирует новый экземпляр класса ошибок API.
	/// </summary>
	public ApiException(string message, Exception innerException)
		: this(GetApiErrorFromExceptionMessage(message), innerException)
	{
	}

	/// <summary>
	///     Инициирует новый экземпляр класса ошибок API.
	/// </summary>
	public ApiException(IResponse response, Exception? innerException)
		: base(null, innerException)
	{
		ThrowHelper.ArgumentNotNull(response);

		ApiError = GetApiErrorFromExceptionMessage(response);
		Response = response;
	}

	/// <summary>
	///     Инициирует новый экземпляр класса ошибок API.
	/// </summary>
	protected ApiException(ApiError apiError, Exception? innerException)
		: base(null, innerException)
	{
		ThrowHelper.ArgumentNotNull(apiError);

		ApiError = apiError;
	}

	/// <summary>
	///     Инициирует новый экземпляр класса ошибок API.
	/// </summary>
	protected ApiException(ApiException innerException)
	{
		ThrowHelper.ArgumentNotNull(innerException);

		ApiError = innerException.ApiError;
	}

	/// <inheritdoc />
	public override string Message => ApiErrorMessageSafe ?? "An error occurred with this API request";

	/// <summary>
	///     Ошибка Api.
	/// </summary>
	public ApiError? ApiError { get; }

	/// <summary>
	///     Возвращает ответ, содержащий ошибку.
	/// </summary>
	public IResponse? Response { get; }

	/// <summary>
	///     Возвращает внутреннюю ошибку.
	/// </summary>
	protected string? ApiErrorMessageSafe
	{
		get
		{
			if (ApiError != null && !string.IsNullOrWhiteSpace(ApiError.Error))
			{
				return ApiError.Error;
			}

			return null;
		}
	}

	private static ApiError GetApiErrorFromExceptionMessage(IResponse response)
	{
		var responseBody = response != null ? response.Body as string : null;
		return GetApiErrorFromExceptionMessage(responseBody);
	}

	private static ApiError GetApiErrorFromExceptionMessage(string? responseContent)
	{
		try
		{
			if (!string.IsNullOrEmpty(responseContent))
			{
				return JsonConvert.DeserializeObject<ApiError>(responseContent, _serializerSettings) ?? new ApiError(responseContent);
			}
		}
		catch (Exception)
		{
			// ignored
		}

		return new ApiError(responseContent);
	}
}
