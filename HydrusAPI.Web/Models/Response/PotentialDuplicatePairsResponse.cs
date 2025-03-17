namespace HydrusAPI.Web;

/// <summary>
///     Ответ с потенциальными парами дубликатов.
/// </summary>
public class PotentialDuplicatePairsResponse : ApiVersionResponse
{
    /// <summary>
    ///     Потенциальные пары дубликатов.
    /// </summary>
    public List<List<string>> PotentialDuplicatePairs { get; set; } = new List<List<string>>();
}
