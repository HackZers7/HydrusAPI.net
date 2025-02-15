using HydrusAPI.Web;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class MataClientTest
{
	private readonly IHydrusClient _client;

	// ReSharper disable once ConvertConstructorToMemberInitializers
	public MataClientTest()
	{
		_client = IoC.GetHydrusClient();
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
}
