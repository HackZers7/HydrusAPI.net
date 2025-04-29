using HydrusAPI.Web;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class PopupsClientTest
{
    private readonly IHydrusClient _client;

    public PopupsClientTest()
    {
        _client = IoC.GetHydrusClient();
    }

    [Test]
    public async Task GetPopups()
    {
        var popups = await _client.PopupsClient.GetPopups();

        Assert.That(popups, Is.Not.Null);
        Assert.That(popups.JobStatuses, Is.Not.Null);
        Assert.That(popups.JobStatuses.Length, Is.GreaterThan(0));
    }

    [Test]
    public async Task AddPopup()
    {
        var job = new JobStatus()
        {
            StatusText_1 = "Note to user"
        };
        var popup = await _client.PopupsClient.AddPopup(job);

        Assert.That(popup, Is.Not.Null);
    }

    [Test]
    public async Task CallUserCallable()
    {
        await _client.PopupsClient.CallUserCallable(await CreatePopupAsync());
    }

    [Test]
    public async Task CancelPopup()
    {
        await _client.PopupsClient.CancelPopup(await CreatePopupAsync());
    }

    [Test]
    public async Task DismissPopup()
    {
        await _client.PopupsClient.DismissPopup(await CreatePopupAsync());
    }

    [Test]
    public async Task FinishPopup()
    {
        await _client.PopupsClient.FinishPopup(await CreatePopupAsync());
    }

    [Test]
    public async Task FinishAndDismissPopup()
    {
        await _client.PopupsClient.FinishAndDismissPopup(await CreatePopupAsync());
    }

    [Test]
    public async Task UpdatePopup()
    {
        var key = await CreatePopupAsync();
        var job = new UpdatePopupRequest(key)
        {
            StatusText_1 = "Note to user222",
            ApiData = new Dictionary<string, string>()
            {
                { "whatever", "stuff" }
            },
            FilesLabel = "test"
        };
        await _client.PopupsClient.UpdatePopup(job);
    }

    private async Task<string> CreatePopupAsync()
    {
        var job = new JobStatus()
        {
            StatusText_1 = "Note to user",
            IsCancellable = true,
            ApiData = new Dictionary<string, string>()
            {
                { "whatever", "stuff" }
            },
            FilesLabel = "test"
        };
        var popup = await _client.PopupsClient.AddPopup(job);
        return popup.JobStatus.Key;
    }
}
