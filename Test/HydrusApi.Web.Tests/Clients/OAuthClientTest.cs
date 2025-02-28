using HydrusAPI.Web;
using HydrusAPI.Web.Http;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class OAuthClientTest
{
	private readonly IApiConnection _apiConnection;

	public OAuthClientTest()
	{
		var config = HydrusClientConfig.CreateDefault(HydrusUrls.DefaultLocalhost);
		_apiConnection = config.Build();
	}

	[Test]
	public async Task RequestAccessTokenOnlyName()
	{
		var request = new AccessTokenRequest("test");

		var response = await OAuthClient.RequestAccessToken(_apiConnection, request);

		Assert.That(response, Is.Not.Null);
		Assert.That(response.Token, Is.Not.Empty);
	}

	[Test]
	public async Task RequestAccessTokenPermits()
	{
		var request = new AccessTokenRequest("test", true);

		var response = await OAuthClient.RequestAccessToken(_apiConnection, request);

		Assert.That(response, Is.Not.Null);
		Assert.That(response.Token, Is.Not.Empty);
	}

	[Test]
	public async Task RequestAccessTokenPermissions()
	{
		var request = new AccessTokenRequest("test", new List<Permissions> { Permissions.ImportEditUrls, Permissions.EditFileTags });

		var response = await OAuthClient.RequestAccessToken(_apiConnection, request);

		Assert.That(response, Is.Not.Null);
		Assert.That(response.Token, Is.Not.Empty);
	}

	[Test]
	public async Task RequestSessionToken()
	{
		var response = await OAuthClient.RequestSessionToken(_apiConnection, IoC.Token);

		Assert.That(response, Is.Not.Null);
		Assert.That(response.Token, Is.Not.Empty);
	}

	[Test]
	public async Task VerifyAccessToken()
	{
		var response = await OAuthClient.VerifyAccessToken(_apiConnection, IoC.Token);

		Assert.That(response, Is.Not.Null);
		Assert.That(response.Name, Is.Not.Empty);
		Assert.That(response.PermitsEverything, Is.False);
		Assert.That(response.Permissions.Count, Is.GreaterThan(0));

		TestContext.WriteLine(response.HumanDescription);
	}

	[Test]
	public async Task VerifySessionToken()
	{
		var sessionToken = await OAuthClient.RequestSessionToken(_apiConnection, IoC.Token);

		var response = await OAuthClient.VerifySessionToken(_apiConnection, sessionToken.Token);

		Assert.That(response, Is.Not.Null);
		Assert.That(response.Name, Is.Not.Empty);
		Assert.That(response.PermitsEverything, Is.False);
		Assert.That(response.Permissions.Count, Is.GreaterThan(0));

		TestContext.WriteLine(response.HumanDescription);
	}
}
