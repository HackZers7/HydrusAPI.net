using HydrusAPI.Web;
using Microsoft.Extensions.Configuration;

namespace HydrusApi.Web.Tests;

public static class IoC
{
	public static readonly string Token;
	public static readonly string FilePath;

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
			FilePath = configuration["FilePath"]!;
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
