using HydrusAPI.Web;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class RelationshipsClientTest
{
	private readonly string _tagServiceKey = "6c6f63616c2074616773";
	private readonly IHydrusClient _client;

	public RelationshipsClientTest()
	{
		_client = IoC.GetHydrusClient();
	}

	[Test]
	public async Task GetFileRelationships()
	{
		var response = await _client.RelationshipsClient.GetFileRelationships(IoC.FileHash);

		Assert.That(response, Is.Not.Null);
		Assert.That(response.FileRelationships.Count, Is.GreaterThan(0));
	}

	[Test]
	public async Task GetPotentialsCount()
	{
		var response = await _client.RelationshipsClient.GetPotentialsCount();

		Assert.That(response, Is.Not.Null);
		Assert.That(response, Is.GreaterThan(0));
		TestContext.WriteLine(response);
	}

	[Test]
	public async Task GetPotentialsCountRequest()
	{
		var response = await _client.RelationshipsClient.GetPotentialsCount(new GetPotentialsRequest()
		{
			MaxHammingDistance = 50
		});

		Assert.That(response, Is.Not.Null);
		Assert.That(response, Is.GreaterThan(0));
		TestContext.WriteLine(response);
	}

	[Test]
	public async Task GetPotentialsPairs()
	{
		var response = await _client.RelationshipsClient.GetPotentialsPairs();

		Assert.That(response, Is.Not.Null);
		Assert.That(response.PotentialDuplicatePairs.Count, Is.GreaterThan(0));
	}

	[Test]
	public async Task GetPotentialsPairsRequest()
	{
		var response = await _client.RelationshipsClient.GetPotentialsPairs(new GetPotentialsPairsRequest()
		{
			TagServiceKey1 = _tagServiceKey,
			PotentialsSearchType = PotentialsSearchTypes.OneFileMatchesSearchOther,
			PixelDuplicates = PixelDuplicateTypes.MustNotBePixelDuplicates
		});

		Assert.That(response, Is.Not.Null);
		Assert.That(response.PotentialDuplicatePairs.Count, Is.GreaterThan(0));
	}

	[Test]
	public async Task GetRandomPotentials()
	{
		var response = await _client.RelationshipsClient.GetRandomPotentials();

		Assert.That(response, Is.Not.Null);
		Assert.That(response.RandomPotentialDuplicateHashes.Count, Is.GreaterThan(0));
	}

	[Test]
	public async Task GetRandomPotentialsRequest()
	{
		var response = await _client.RelationshipsClient.GetRandomPotentials(new GetPotentialsRequest()
		{
			TagServiceKey1 = _tagServiceKey,
			PotentialsSearchType = PotentialsSearchTypes.OneFileMatchesSearchOther,
			PixelDuplicates = PixelDuplicateTypes.MustNotBePixelDuplicates
		});

		Assert.That(response, Is.Not.Null);
		Assert.That(response.RandomPotentialDuplicateHashes.Count, Is.GreaterThan(0));
	}

	[Test]
	public async Task RemovePotentials()
	{
		await _client.RelationshipsClient.RemovePotentials(IoC.FileHash);
	}

	[Test]
	public async Task SetFileRelationships()
	{
		await _client.RelationshipsClient.SetFileRelationships(new List<Relationships>()
		{
			new Relationships(IoC.FileHash, IoC.FileHash2, RelationshipsType.Alternates)
		});
	}

	[Test]
	public async Task SetKings()
	{
		await _client.RelationshipsClient.SetKings(IoC.FileHash);
	}
}
