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

	[Test]
	public async Task DeleteFileByHash()
	{
		using (var stream = File.OpenRead(IoC.FilePath))
		{
			var hash = Utils.GetSha256(stream);
			var result = await _client.FilesClient.DeleteFiles(hash);

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
		}
	}

	[Test]
	public async Task DeleteFileById()
	{
		var result = await _client.FilesClient.DeleteFiles(1);

		Assert.That(result, Is.Not.Null);
		Assert.That(result, Is.True);
	}
	
	[Test]
	public async Task DeleteMultiplyFiles()
	{
		var deleteFiles = new DeleteFilesRequest();
		using (var stream = File.OpenRead(IoC.FilePath))
		{
			var hash = Utils.GetSha256(stream);
			deleteFiles.AddHash(hash);
		}
		
		using (var stream = File.OpenRead(IoC.FilePath2))
		{
			var hash = Utils.GetSha256(stream);
			deleteFiles.AddHash(hash);
		}
		
		var result = await _client.FilesClient.DeleteFiles(deleteFiles);

		Assert.That(result, Is.Not.Null);
		Assert.That(result, Is.True);
	}
	
	[Test]
	public async Task DeleteMultiplyFilesWithHashAndId()
	{
		var deleteFiles = new DeleteFilesRequest();
		deleteFiles.AddId(1);
		
		using (var stream = File.OpenRead(IoC.FilePath2))
		{
			var hash = Utils.GetSha256(stream);
			deleteFiles.AddHash(hash);
		}
		
		var result = await _client.FilesClient.DeleteFiles(deleteFiles);

		Assert.That(result, Is.Not.Null);
		Assert.That(result, Is.True);
	}

	[Test]
	public async Task DeleteFileWithReasons()
	{
		using (var stream = File.OpenRead(IoC.FilePath))
		{
			var hash = Utils.GetSha256(stream);
			var result = await _client.FilesClient.DeleteFiles(hash, "testReason");

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
		}
	}
}
