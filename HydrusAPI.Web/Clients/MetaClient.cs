using HydrusAPI.Web.Http;

namespace HydrusAPI.Web;

/// <summary>
///     Клиент для редактирования метаданных файла.
/// </summary>
public class MetaClient : ApiClient, IMetaClient
{
	/// <inheritdoc />
	public MetaClient(IApiConnection apiConnection) : base(apiConnection)
	{
	}

	/// <inheritdoc />
	public async Task<bool> SetRating(SetRatingRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.SetRating(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public async Task<bool> IncrementFileViewtime(ViewtimeRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.IncrementFileViewtime(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public async Task<bool> SetFileViewtime(ViewtimeRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.SetFileViewtime(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public async Task<bool> SetTime(SetTimeRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.SetTime(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}

	/// <inheritdoc />
	public Task<NotesResponse> SetNotes(SetNotesRequest request, CancellationToken cancel = default)
	{
		return ApiConnection.Post<NotesResponse>(HydrusUrls.SetNotes(), null, request, cancel);
	}

	/// <inheritdoc />
	public async Task<bool> DeleteNotes(DeleteNotesRequest request, CancellationToken cancel = default)
	{
		var response = await ApiConnection.Post(HydrusUrls.DeleteNotes(), null, request, cancel);
		return response.IsSuccessStatusCode();
	}
}
