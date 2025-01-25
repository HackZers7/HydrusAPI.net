using HydrusAPI.Web;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class ServicesClientTest
{
	private readonly IHydrusClient _client;

	// ReSharper disable once ConvertConstructorToMemberInitializers
	public ServicesClientTest()
	{
		_client = IoC.GetHydrusClient();
	}

	[Test]
	public async Task GetFileServiceByName()
	{
		var name = "my files";
		var services = await _client.ServicesClient.GetServiceByName(name);

		Assert.That(services, Is.Not.Null);
		Assert.That(services.Service, Is.Not.Null);
		Assert.That(services.Service.Name, Is.EqualTo(name));
		Assert.That(services.Service.ServiceKey, Is.Not.Empty);
	}
	
	[Test]
	public async Task GetFileServiceByKey()
	{
		var key = "6c6f63616c2066696c6573";
		var services = await _client.ServicesClient.GetServiceByKey(key);

		Assert.That(services, Is.Not.Null);
		Assert.That(services.Service, Is.Not.Null);
		Assert.That(services.Service.Name, Is.Not.Empty);
		Assert.That(services.Service.ServiceKey, Is.EqualTo(key));
	}
	
	[Test]
	public async Task GetServices()
	{
		var services = await _client.ServicesClient.GetServices();

		Assert.That(services, Is.Not.Null);
		Assert.That(services.Services, Has.Count.GreaterThan(0));
	}
}
