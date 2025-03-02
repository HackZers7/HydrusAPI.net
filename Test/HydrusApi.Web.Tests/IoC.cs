using HydrusAPI.Web;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace HydrusApi.Web.Tests;

public static class IoC
{
	public static readonly string Token;
	public static readonly string FilePath;
	public static readonly string FileHash;
	public static readonly ulong FileId;
	public static readonly string FilePath2;
	public static readonly string FileHash2;
	public static readonly string FilePath3;
	public static readonly string FileHash3;

	public static readonly string TestFileDomain;

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
			TestFileDomain = configuration["TestFileDomain"]!;

			using (var stream = File.OpenRead(IoC.FilePath))
			{
				FileHash = Utils.GetSha256(stream);
			}

			using (var stream = File.OpenRead(IoC.FilePath2))
			{
				FileHash2 = Utils.GetSha256(stream);
			}

			using (var stream = File.OpenRead(IoC.FilePath3))
			{
				FileHash3 = Utils.GetSha256(stream);
			}

			FileId = 1;
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
