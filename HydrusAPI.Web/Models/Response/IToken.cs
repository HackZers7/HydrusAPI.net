namespace HydrusAPI.Web;

/// <summary>
///     Токен доступа.
/// </summary>
public interface IToken
{
    /// <summary>
    ///     Токен.
    /// </summary>
    public string Token { get; }

    /// <summary>
    ///    Время (UTC), когда токен был создан.
    /// </summary>
    public DateTime CreatedAt { get; }

    /// <summary>
    ///     Указывает, истек ли токен или нет.
    /// </summary>
    public bool IsExpired { get; }
}
