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
		var client = new HydrusClient();
		await client.GetApiVersion();
		await client.AccessClient.GetAccessKey("test test", Permissions.CommitPending, Permissions.ManagePopups, Permissions.EditFileRelationships);
	}
}
