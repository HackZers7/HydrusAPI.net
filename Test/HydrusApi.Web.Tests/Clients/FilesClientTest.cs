using HydrusAPI.Web;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class FilesClientTest
{
	private readonly IHydrusClient _client;

	// ReSharper disable once ConvertConstructorToMemberInitializers
	public FilesClientTest()
	{
		_client = IoC.GetHydrusClient();
	}

	[Test]
	public async Task SendLocalFile()
	{
		var result = await _client.FilesClient.SendLocalFile(IoC.FilePath);

		Assert.That(result, Is.Not.Null);
		Assert.That(result.Status, Is.EqualTo(ImportStatus.Success).Or.EqualTo(ImportStatus.AlreadyExists));
		Assert.That(result.Hash, Is.Not.Empty);
	}
	
	[Test]
	public async Task SendFile()
	{
		using (var stream = File.OpenRead(IoC.FilePath))
		{
			var result = await _client.FilesClient.SendFile(stream);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Status, Is.EqualTo(ImportStatus.Success).Or.EqualTo(ImportStatus.AlreadyExists));
			Assert.That(result.Hash, Is.Not.Empty);
		}
	}
}
