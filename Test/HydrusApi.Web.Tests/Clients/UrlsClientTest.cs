using HydrusAPI.Web;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class UrlsClientTest
{
    private readonly IHydrusClient _client;

    public static string URL = "https://safebooru.org/index.php?id=2753608&page=post&s=view";
    public static string URL_2 = "https://safebooru.org/index.php?page=post&s=view&id=3272525";
    public static string URL_3 = "https://safebooru.org/index.php?page=post&s=view&id=5592221";
    private readonly string _badUrl = "https://ya.ru";

    public static string MyTagsServiceKey = "6c6f63616c2074616773";

    public UrlsClientTest()
    {
        _client = IoC.GetHydrusClient();
    }

    [Test]
    public async Task GetUrls()
    {
        var data = await _client.UrlsClient.GetUrlFiles(URL);

        Assert.That(data, Is.Not.Null);
        Assert.That(data.NormalisedUrl, Is.Not.Null);
    }

    [Test]
    public async Task GetUrlsInfo()
    {
        var data = await _client.UrlsClient.GetUrlInfo(URL);

        Assert.That(data, Is.Not.Null);
        Assert.That(data.NormalisedUrl, Is.Not.Null);
    }

    [Test]
    public async Task GetUrlsInfoBad()
    {
        var data = await _client.UrlsClient.GetUrlInfo(_badUrl);

        Assert.That(data, Is.Not.Null);
        Assert.That(data.NormalisedUrl, Is.Not.Null);
    }

    [TestFixture]
    public class ImportUrlTest
    {
        private readonly IHydrusClient _client;

        public ImportUrlTest()
        {
            _client = IoC.GetHydrusClient();
        }

        [Test]
        public async Task Import()
        {
            var data = await _client.UrlsClient.ImportFromUrl(URL_2);

            Assert.That(data, Is.Not.Null);
            Assert.That(data.NormalisedUrl, Is.Not.Null);
        }

        [Test]
        public async Task ImportWithShowDestinationPage()
        {
            var request = new ImportFromUrlRequest(URL_2)
            {
                ShowDestinationPage = true
            };

            var data = await _client.UrlsClient.ImportFromUrl(request);

            Assert.That(data, Is.Not.Null);
            Assert.That(data.NormalisedUrl, Is.Not.Null);
        }

        [Test]
        public async Task ImportWithDestinationPageName()
        {
            var request = new ImportFromUrlRequest(URL_2)
            {
                DestinationPageName = "test"
            };

            var data = await _client.UrlsClient.ImportFromUrl(request);

            Assert.That(data, Is.Not.Null);
            Assert.That(data.NormalisedUrl, Is.Not.Null);
        }

        [Test]
        public async Task ImportWithAdditionalTags()
        {
            var request = new ImportFromUrlRequest(URL_3)
            {
                ServiceKeysToAdditionalTags = new Dictionary<string, List<string>>
                {
                    { MyTagsServiceKey, ["test"] }
                }
            };

            var data = await _client.UrlsClient.ImportFromUrl(request);

            Assert.That(data, Is.Not.Null);
            Assert.That(data.NormalisedUrl, Is.Not.Null);
        }

        [Test]
        public async Task ImportWithFilterableTags()
        {
            var request = new ImportFromUrlRequest(URL_2);

            request.FilterableTags = new List<string> { "test" };

            var data = await _client.UrlsClient.ImportFromUrl(request);

            Assert.That(data, Is.Not.Null);
            Assert.That(data.NormalisedUrl, Is.Not.Null);
        }
    }

    [TestFixture]
    public class AssociateUrlTest
    {
        private readonly IHydrusClient _client;

        // ReSharper disable once ConvertConstructorToMemberInitializers
        public AssociateUrlTest()
        {
            _client = IoC.GetHydrusClient();
        }

        [Test]
        public async Task AddByHash()
        {
            await _client.UrlsClient.AddUrlToFile(IoC.FileHash2, URL);
        }

        [Test]
        public async Task AddById()
        {
            await _client.UrlsClient.AddUrlToFile(IoC.FileId, URL);
        }

        [Test]
        public async Task DeleteByHash()
        {
            await _client.UrlsClient.RemoveUrlFromFile(IoC.FileHash2, URL);
        }

        [Test]
        public async Task DeleteById()
        {
            await _client.UrlsClient.RemoveUrlFromFile(IoC.FileId, URL);
        }
    }
}
