using HydrusAPI.Web;

namespace HydrusApi.ClientTest;

internal class Program
{
	private static void Main(string[] args)
	{
		Run();
		Console.ReadKey();
	}

	private static async Task Run()
	{
		try
		{
			var config = HydrusClientConfig.CreateDefault(HydrusUrls.DefaultLocalhost);
		
			var auth = new OAuthClient(config);
			var accessToken = await auth.RequestAccessToken("test", false, Permissions.CommitPending, Permissions.ManagePopups);
			config.WithToken(accessToken.Token);
		
			var client = new HydrusClient(config);
			await client.GetApiVersion();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}
	}
}
