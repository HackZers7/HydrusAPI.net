using HydrusAPI.Web;

namespace HydrusApi.ClientTest;

class Program
{
	static void Main(string[] args)
	{
		Run();
		Console.ReadKey();
	}

	private static async Task Run()
	{
		var client = new HydrusClient();
		await client.GetApiVersion();
	}
}
