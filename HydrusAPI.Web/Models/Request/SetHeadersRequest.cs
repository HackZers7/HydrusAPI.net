using System.Text.Json;
using HydrusAPI.Web.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace HydrusAPI.Web;

/// <summary>
///     Запрос присвоения заголовков.
/// </summary>
public class SetHeadersRequest : IConvert
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
    ///     Необаятельно, домен. Если null, то подразумеваются глобальные заголовки.
    /// </summary>
    public string? Domain { get; set; }

    /// <summary>
    ///     Заголовки.
    /// </summary>
    public Dictionary<string, Header> Headers { get; set; } = new Dictionary<string, Header>();

    /// <inheritdoc />
    public string SerializeObject(JsonSerializerOptions options)
    {
        var domainName = options.PropertyNamingPolicy?.ConvertName(nameof(Domain)) ?? nameof(Domain);
        var headersName = options.PropertyNamingPolicy?.ConvertName(nameof(Headers)) ?? nameof(Headers);
        var valueName = options.PropertyNamingPolicy?.ConvertName(nameof(Header.Value)) ?? nameof(Header.Value);
        var approvedName = options.PropertyNamingPolicy?.ConvertName(nameof(Header.Approved)) ?? nameof(Header.Approved);
        var reasonName = options.PropertyNamingPolicy?.ConvertName(nameof(Header.Reason)) ?? nameof(Header.Reason);

        var jObject = new JObject();

        if (!string.IsNullOrWhiteSpace(domainName))
        {
            jObject.Add(new JProperty(domainName, Domain));
        }
        else
        {
            jObject.Add(new JProperty(domainName));
        }

        var headers = new JObject();
        foreach (var (key, header) in Headers)
        {
            headers.Add(new JProperty(key, ConvertHeader(header, valueName, approvedName, reasonName)));
        }

        jObject.Add(new JProperty(headersName, headers));

        return JsonConvert.SerializeObject(jObject, _serializerSettings);
    }

    private static JObject ConvertHeader(Header header, string valueName, string approvedName, string reasonName)
    {
        var jObject = new JObject()
        {
            new JProperty(valueName, header.Value)
        };
        if (!string.IsNullOrEmpty(header.Approved))
        {
            jObject.Add(new JProperty(approvedName, header.Approved));
        }
        if (!string.IsNullOrEmpty(header.Reason))
        {
            jObject.Add(new JProperty(reasonName, header.Reason));
        }
        return jObject;
    }
}
