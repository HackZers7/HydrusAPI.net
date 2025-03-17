using HydrusAPI.Web;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class MetaClientTest
{
    private readonly IHydrusClient _client;

    private readonly static string RatingServiceKey = "dd7876d8df3c75058427d7258ff0037f8396a93b6c28dcc537797431e669d8b5";

    public MetaClientTest()
    {
        _client = IoC.GetHydrusClient();
    }

    [Test]
    public async Task SetRating()
    {
        await _client.MetaClient.SetRating(IoC.FileHash, RatingServiceKey, 2);
    }

    [Test]
    public async Task UnSetRating()
    {
        await _client.MetaClient.SetRating(IoC.FileHash, RatingServiceKey);
    }

    [Test]
    public async Task IncrementFileViewTime()
    {
        await _client.MetaClient.IncrementFileViewTime(IoC.FileHash, CanvasTypes.Media, 100000);
    }

    [Test]
    public async Task SetFileViewTime()
    {
        await _client.MetaClient.SetFileViewTime(IoC.FileHash, CanvasTypes.Media, 100000);
    }


    [Test]
    public async Task SetTime()
    {
        await _client.MetaClient.SetTime(new SetTimeRequest(IoC.FileHash, TimestampTypes.FileModifiedTimeDrive)
        {
            Timestamp = 0
        });
    }

    [Test]
    public async Task SetNotes()
    {
        var response = await _client.MetaClient.SetNotes(new SetNotesRequest(IoC.FileHash)
        {
            Notes = new Dictionary<string, string>()
            {
                { "test", "test2" }
            }
        });

        Assert.That(response, Is.Not.Null);
        Assert.That(response.Notes.Count, Is.GreaterThan(0));
    }

    [Test]
    public async Task DeleteNotes()
    {
        await _client.MetaClient.DeleteNotes(IoC.FileHash, new List<string> { "test" });
    }

    [Test]
    public async Task GetMetadataDefault()
    {
        var search = await _client.FilesClient.SearchFiles(new List<object>()
        {
            "system:everything"
        });

        var data = await _client.MetaClient.GetMetaData(search.Hashes!);

        Assert.That(data, Is.Not.Null);
    }

    [Test]
    public async Task GetMetadataOnlyId()
    {
        var search = await _client.FilesClient.SearchFiles(new List<object>()
        {
            "system:everything"
        });

        var data = await _client.MetaClient.GetId(search.Hashes!);

        Assert.That(data, Is.Not.Null);
    }

    [Test]
    public async Task GetFilePath()
    {
        var data = await _client.MetaClient.GetFilePath(IoC.FileHash);

        Assert.That(data, Is.Not.Null);
        Assert.That(data.Filetype, Is.Not.Empty);
        Assert.That(data.Path, Is.Not.Empty);
    }

    [Test]
    public async Task GetThumbnailFilePath()
    {
        var data = await _client.MetaClient.GetThumbnailFilePath(IoC.FileHash, true);

        Assert.That(data, Is.Not.Null);
        Assert.That(data.Filetype, Is.Not.Empty);
        Assert.That(data.Path, Is.Not.Empty);
    }

    [Test]
    public async Task GetLocalFileStorageLocations()
    {
        var data = await _client.MetaClient.GetLocalFileStorageLocations();

        Assert.That(data, Is.Not.Null);
        Assert.That(data.Locations.Count, Is.GreaterThan(0));
    }
}
