using HydrusAPI.Web;
using NUnit.Framework;
using System.IO;
using System.Threading.Tasks;

namespace HydrusApi.Web.Tests.Clients;

[TestFixture]
public class FilesClientTest
{
	[TestFixture]
	public class SendTest
	{
		private readonly IHydrusClient _client;

		// ReSharper disable once ConvertConstructorToMemberInitializers
		public SendTest()
		{
			_client = IoC.GetHydrusClient();
		}

		[Test]
		public async Task LocalFile()
		{
			var result = await _client.FilesClient.SendLocalFile(IoC.FilePath);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Status, Is.EqualTo(ImportStatus.Success).Or.EqualTo(ImportStatus.AlreadyExists));
			Assert.That(result.Hash, Is.Not.Empty);
		}

		[Test]
		public async Task File()
		{
			using (var stream = System.IO.File.OpenRead(IoC.FilePath))
			{
				var result = await _client.FilesClient.SendFile(stream);

				Assert.That(result, Is.Not.Null);
				Assert.That(result.Status, Is.EqualTo(ImportStatus.Success).Or.EqualTo(ImportStatus.AlreadyExists));
				Assert.That(result.Hash, Is.Not.Empty);
			}
		}
	}

	[TestFixture]
	public class DeleteTest
	{
		private readonly IHydrusClient _client;

		// ReSharper disable once ConvertConstructorToMemberInitializers
		public DeleteTest()
		{
			_client = IoC.GetHydrusClient();
		}

		[Test]
		public async Task ByHash()
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
		public async Task ById()
		{
			var result = await _client.FilesClient.DeleteFiles(1);

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
		}

		[Test]
		public async Task MultiplyFiles()
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
		public async Task MultiplyFilesWithHashAndId()
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
		public async Task WithReasons()
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
	
	[TestFixture]
	public class UndeleteTest
	{
		private readonly IHydrusClient _client;

		// ReSharper disable once ConvertConstructorToMemberInitializers
		public UndeleteTest()
		{
			_client = IoC.GetHydrusClient();
		}

		[Test]
		public async Task ByHash()
		{
			using (var stream = File.OpenRead(IoC.FilePath))
			{
				var hash = Utils.GetSha256(stream);
				var result = await _client.FilesClient.UndeleteFiles(hash);

				Assert.That(result, Is.Not.Null);
				Assert.That(result, Is.True);
			}
		}

		[Test]
		public async Task ById()
		{
			var result = await _client.FilesClient.UndeleteFiles(1);

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
		}

		[Test]
		public async Task MultiplyFiles()
		{
			var undeleteFiles = new UndeleteFilesRequest();
			using (var stream = File.OpenRead(IoC.FilePath))
			{
				var hash = Utils.GetSha256(stream);
				undeleteFiles.AddHash(hash);
			}

			using (var stream = File.OpenRead(IoC.FilePath2))
			{
				var hash = Utils.GetSha256(stream);
				undeleteFiles.AddHash(hash);
			}

			var result = await _client.FilesClient.UndeleteFiles(undeleteFiles);

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
		}

		[Test]
		public async Task MultiplyFilesWithHashAndId()
		{
			var undeleteFiles = new UndeleteFilesRequest();
			undeleteFiles.AddId(1);

			using (var stream = File.OpenRead(IoC.FilePath2))
			{
				var hash = Utils.GetSha256(stream);
				undeleteFiles.AddHash(hash);
			}

			var result = await _client.FilesClient.UndeleteFiles(undeleteFiles);

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
		}
	}
}
