using HydrusAPI.Web;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable PossibleMultipleEnumeration

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class TagsClientTest
{
	private readonly IHydrusClient _client;

	public TestContext TestContext { get; set; } = default!;

	public readonly static string[] Tags =
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
}
