namespace HydrusAPI.Web;

/// <summary>
///     Типы разрешения конфликтов.
/// </summary>
public enum ConflictResolutionType
{
    /// <summary>
    ///     Перезаписывает конфликтную записку.
    /// </summary>
    Replace = 0,

    /// <summary>
    ///     Не производит изменения.
    /// </summary>
    Ignore = 1,

    /// <summary>
    ///     Добавляет текст к существующему тексту.
    /// </summary>
    Append = 2,

    /// <summary>
    ///     Добавляет заметку с новым названием в виде "name (n)".
    /// </summary>
    Rename = 3
}
