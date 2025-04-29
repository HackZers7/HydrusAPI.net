using HydrusAPI.Web;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class PagesClientTest
{
    private readonly IHydrusClient _client;
    private readonly string _pageKey = "9d79192868f978aeeb3dfb0d278af284442aebf8edceb9a5d6f96cd51fbf98b0";

    public PagesClientTest()
    {
        _client = IoC.GetHydrusClient();
    }

    [Test]
    public async Task GetPages()
    {
        var page = await _client.PagesClient.GetPages();

        Assert.That(page, Is.Not.Null);
        Assert.That(page.Pages, Is.Not.Null);
        Assert.That(page.Pages.Length, Is.GreaterThan(0));
    }

    [Test]
    public async Task GetPage()
    {
        var page = await _client.PagesClient.GetPage(_pageKey);

        Assert.That(page, Is.Not.Null);
        Assert.That(page.PageInfo, Is.Not.Null);
    }

    [Test]
    public async Task AddFilesOnPageHash()
    {
        await _client.PagesClient.AddFilesOnPage(_pageKey, IoC.FileHash);
    }

    [Test]
    public async Task FocusPage()
    {
        await _client.PagesClient.FocusPage(_pageKey);
    }

    [Test]
    public async Task RefreshPage()
    {
        await _client.PagesClient.RefreshPage(_pageKey);
    }
}
