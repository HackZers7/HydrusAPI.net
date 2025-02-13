using HydrusAPI.Web;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using File = System.IO.File;

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class UrlsClientTest
{
	private readonly IHydrusClient _client;

	public static string URL = "http://safebooru.org/index.php?page=post&s=view&id=2753608";
	public static string URL_2 = "https://safebooru.org/index.php?page=post&s=view&id=3272525";
	private readonly string _badUrl = "https://ya.ru";

	public static string MyTagsServiceKey = "6c6f63616c2074616773";

	// ReSharper disable once ConvertConstructorToMemberInitializers
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

		// ReSharper disable once ConvertConstructorToMemberInitializers
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
			var request = new ImportFromUrlRequest(URL_2);

			request.ShowDestinationPage = true;

			var data = await _client.UrlsClient.ImportFromUrl(request);

			Assert.That(data, Is.Not.Null);
			Assert.That(data.NormalisedUrl, Is.Not.Null);
		}

		[Test]
		public async Task ImportWithDestinationPageName()
		{
			var request = new ImportFromUrlRequest(URL_2);

			request.DestinationPageName = "test";

			var data = await _client.UrlsClient.ImportFromUrl(request);

			Assert.That(data, Is.Not.Null);
			Assert.That(data.NormalisedUrl, Is.Not.Null);
		}

		[Test]
		public async Task ImportWithAdditionalTags()
		{
			var request = new ImportFromUrlRequest(URL_2)
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
			using (var stream = File.OpenRead(IoC.FilePath2))
			{
				var hash = Utils.GetSha256(stream);
				var data = await _client.UrlsClient.AddUrlToFile(hash, URL);

				Assert.That(data, Is.Not.Null);
				Assert.That(data, Is.True);
			}
		}

		[Test]
		public async Task DeleteByHash()
		{
			using (var stream = File.OpenRead(IoC.FilePath2))
			{
				var hash = Utils.GetSha256(stream);
				var data = await _client.UrlsClient.RemoveUrlFromFile(hash, URL);

				Assert.That(data, Is.Not.Null);
				Assert.That(data, Is.True);
			}
		}
	}
}
