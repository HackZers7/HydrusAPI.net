using HydrusAPI.Web;
using Microsoft.Extensions.Configuration;

namespace HydrusApi.Web.Tests;

public static class IoC
{
	public static readonly string Token;
	public static readonly string FilePath;
	public static readonly string FilePath2;
	public static readonly string FilePath3;

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
			FilePath2 = configuration["FilePath2"]!;
			FilePath3 = configuration["FilePath2"]!;
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
