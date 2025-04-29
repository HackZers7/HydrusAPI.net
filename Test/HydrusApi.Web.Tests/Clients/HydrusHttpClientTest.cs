using HydrusAPI.Web;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class HydrusHttpClientTest
{
    private readonly IHydrusClient _client;

    public HydrusHttpClientTest()
    {
        _client = IoC.GetHydrusClient();
    }

    [Test]
    public async Task GetCookies()
    {
        var domain = "somesite.com";
        var cookies = await _client.HydrusHttpClient.GetCookies(domain);

        Assert.That(cookies, Is.Not.Null);
        Assert.That(cookies.Cookies, Is.Not.Null);
        Assert.That(cookies.Cookies.Count, Is.GreaterThan(0));
    }

    [Test]
    public async Task SetCookies()
    {
        var cookies = new SetCookiesRequest()
        {
            Cookies = new List<object?[]>
            {
                new object?[]
                {
                    "PHPSESSID", "07669eb2a1a6e840e498bb6e0799f3fb", ".somesite.com", "/", null
                }
            }
        };
        await _client.HydrusHttpClient.SetCookies(cookies);
    }

    [Test]
    public async Task GetHeaders()
    {
        var response = await _client.HydrusHttpClient.GetHeaders();

        Assert.That(response, Is.Not.Null);
        Assert.That(response.NetworkContext, Is.Not.Null);
        Assert.That(response.Headers, Is.Not.Null);
        Assert.That(response.Headers!.Count, Is.GreaterThan(0));
    }

    [Test]
    public async Task GetHeadersWD()
    {
        var domain = "pixiv.net";
        var response = await _client.HydrusHttpClient.GetHeaders(domain);

        Assert.That(response, Is.Not.Null);
        Assert.That(response.NetworkContext, Is.Not.Null);
        Assert.That(response.Headers, Is.Not.Null);
        Assert.That(response.Headers!.Count, Is.GreaterThan(0));
    }

    [Test]
    public async Task SetHeaders()
    {
        var headers = new SetHeadersRequest()
        {
            Headers = new Dictionary<string, Header>
            {
                { "User-Agent", new Header() { Value = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0" } },
                { "DNT", new Header() { Value = "1" } },
                {
                    "CoolStuffToken",
                    new Header()
                    {
                        Value = "abcdef0123456789",
                        Approved = "pending",
                        Reason = "This unlocks the Sonic fanfiction!"
                    }
                }
            }
        };

        await _client.HydrusHttpClient.SetHeaders(headers);
    }

    [Test]
    public async Task SetHeadersWD()
    {
        var headers = new SetHeadersRequest()
        {
            Domain = "mysite.com",
            Headers = new Dictionary<string, Header>
            {
                { "User-Agent", new Header() { Value = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:56.0) Gecko/20100101 Firefox/56.0" } },
                { "DNT", new Header() { Value = "1" } },
                {
                    "CoolStuffToken",
                    new Header()
                    {
                        Value = "abcdef0123456789",
                        Approved = "pending",
                        Reason = "This unlocks the Sonic fanfiction!"
                    }
                }
            }
        };

        await _client.HydrusHttpClient.SetHeaders(headers);
    }
}
