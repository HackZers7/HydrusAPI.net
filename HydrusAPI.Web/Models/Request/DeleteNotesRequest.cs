namespace HydrusAPI.Web;

/// <summary>
///     Запрос на удаление заметки.
/// </summary>
public class DeleteNotesRequest : FileRequest
{
    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="hash">Хеш (SHA256) файла.</param>
    /// <param name="names">Коллекция наименований заметок.</param>
    public DeleteNotesRequest(string hash, IList<string> names) : base(hash)
    {
        NoteNames = names;
    }

    /// <summary>
    ///     Инициализирует новый экземпляр класса.
    /// </summary>
    /// <param name="id">Идентификатор файла.</param>
    /// <param name="names">Коллекция наименований заметок.</param>
    public DeleteNotesRequest(ulong id, IList<string> names) : base(id)
    {
        NoteNames = names;
    }

    /// <summary>
    ///     Коллекция наименований заметок.
    /// </summary>
    public IList<string> NoteNames { get; set; }
}
