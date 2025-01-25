using HydrusAPI.Web;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HydrusApi.Web.Tests.Clients;

public class HydrusClientTests
{
	private readonly IHydrusClient _client;

	// ReSharper disable once ConvertConstructorToMemberInitializers
	public HydrusClientTests()
	{
		_client = IoC.GetHydrusClient();
	}

	[Test]
	public async Task GetApiVersion()
	{
		var apiVersion = await _client.GetApiVersion();

		Assert.That(apiVersion, Is.Not.Null);
		Assert.That(apiVersion, Has.Property(nameof(ApiVersion.Version)).GreaterThan(0));
		Assert.That(apiVersion, Has.Property(nameof(ApiVersion.HydrusVersion)).GreaterThan(0));
	}
}
