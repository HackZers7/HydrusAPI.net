using HydrusAPI.Web;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class HydrusClientTests
{
    private readonly IHydrusClient _client;

    public HydrusClientTests()
    {
        _client = IoC.GetHydrusClient();
    }

    [Test]
    public async Task GetApiVersion()
    {
        var apiVersion = await _client.GetApiVersion();

        TestContext.WriteLine($"{nameof(ApiVersionResponse.HydrusVersion)}: {apiVersion.HydrusVersion}");
        TestContext.WriteLine($"{nameof(ApiVersionResponse.Version)}: {apiVersion.Version}");

        Assert.That(apiVersion, Is.Not.Null);
        Assert.That(apiVersion, Has.Property(nameof(ApiVersionResponse.Version)).GreaterThan(0));
        Assert.That(apiVersion, Has.Property(nameof(ApiVersionResponse.HydrusVersion)).GreaterThan(0));
    }
}
