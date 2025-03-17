namespace HydrusAPI.Web;

/// <summary>
///     Потенциальное количество дубликатов.
/// </summary>
public class PotentialDuplicatesCountResponse : ApiVersionResponse
{
    /// <summary>
    ///     Потенциальное количество дубликатов.
    /// </summary>
    public int PotentialDuplicatesCount { get; set; }
}
