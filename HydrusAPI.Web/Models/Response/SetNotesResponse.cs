namespace HydrusAPI.Web;

/// <summary>
///     Ответ с заметками.
/// </summary>
public class SetNotesResponse : ApiVersionResponse
{
    /// <summary>
    ///     Словарь с заметками, где ключ название заметки.
    /// </summary>
    public Dictionary<string, string> Notes { get; set; } = default!;
}
