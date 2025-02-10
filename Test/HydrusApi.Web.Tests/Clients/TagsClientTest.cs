using HydrusAPI.Web;
using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable PossibleMultipleEnumeration

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class TagsClientTest
{
	private readonly IHydrusClient _client;

	public static string MyTagsServiceKey = "6c6f63616c2074616773";

	public TestContext TestContext { get; set; } = default!;

	public static readonly string[] Tags =
	{
		"test",
		"tag1",
		"tag2",
		"tags_test"
	};

	// ReSharper disable once ConvertConstructorToMemberInitializers
	public TagsClientTest()
	{
		_client = IoC.GetHydrusClient();
	}

	[Test]
	public async Task ClearTags()
	{
		var tags = await _client.TagsClient.CleanTags(Tags);

		TestContext.WriteLine(string.Join(", ", tags));

		Assert.That(tags, Is.Not.Null);
		Assert.That(tags.Count(), Is.GreaterThan(0));
	}

	[Test]
	public async Task GetSiblingsAndParents()
	{
		var tags = await _client.TagsClient.GetSiblingsAndParents(Tags);

		Assert.That(tags, Is.Not.Null);
		Assert.That(tags.Tags.Count, Is.GreaterThan(0));
	}

	[Test]
	public async Task SearchTags()
	{
		var tags = await _client.TagsClient.SearchTags("solo");

		Assert.That(tags, Is.Not.Null);
		Assert.That(tags.Tags.Count, Is.GreaterThan(0));
	}

	[Test]
	public async Task AddTags()
	{
		var request = new AddTagsRequest();
		request.AddRangeTags(MyTagsServiceKey, Tags);
		using (var stream = File.OpenRead(IoC.FilePath))
		{
			var hash = Utils.GetSha256(stream);
			request.AddHash(hash);
		}

		var tags = await _client.TagsClient.AddTags(request);

		Assert.That(tags, Is.Not.Null);
		Assert.That(tags, Is.True);
	}
}
