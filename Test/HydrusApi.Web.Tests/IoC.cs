using HydrusAPI.Web;
using Microsoft.Extensions.Configuration;

namespace HydrusApi.Web.Tests;

public static class IoC
{
	private static readonly string Token;
	private static readonly object Lock = new();
	private static HydrusClient? _client;

	static IoC()
	{
		lock (Lock)
		{
			var configuration = new ConfigurationBuilder()
				.AddUserSecrets<Settings>()
				.Build();

			Token = configuration["Token"]!;
		}
	}

	public static IHydrusClient GetHydrusClient()
	{
		if (_client != null)
		{
			return _client;
		}

		lock (Lock)
		{
			var config = HydrusClientConfig.CreateDefault(HydrusUrls.DefaultLocalhost);
			config.WithToken(Token);
			_client = new HydrusClient(config);
		}

		return _client;
	}
}
