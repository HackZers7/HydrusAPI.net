using HydrusAPI.Web;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using File = System.IO.File;

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
			var result = await _client.FilesClient.SendFile(IoC.FilePath);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.Status, Is.EqualTo(FileStatus.Success).Or.EqualTo(FileStatus.AlreadyExists));
			Assert.That(result.Hash, Is.Not.Empty);
		}

		[Test]
		public async Task File()
		{
			using (var stream = System.IO.File.OpenRead(IoC.FilePath))
			{
				var result = await _client.FilesClient.SendFile(stream);

				Assert.That(result, Is.Not.Null);
				Assert.That(result.Status, Is.EqualTo(FileStatus.Success).Or.EqualTo(FileStatus.AlreadyExists));
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
			var result = await _client.FilesClient.DeleteFiles(IoC.FileHash);

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
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
			deleteFiles.Hashes = new List<string>();
			using (var stream = File.OpenRead(IoC.FilePath))
			{
				deleteFiles.Hashes.Add(Utils.GetSha256(stream));
			}

			using (var stream = File.OpenRead(IoC.FilePath2))
			{
				deleteFiles.Hashes.Add(Utils.GetSha256(stream));
			}

			var result = await _client.FilesClient.DeleteFiles(deleteFiles);

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
		}

		[Test]
		public async Task MultiplyFilesWithHashAndId()
		{
			var deleteFiles = new DeleteFilesRequest();
			deleteFiles.FileIds = new List<ulong> { 1 };

			using (var stream = File.OpenRead(IoC.FilePath2))
			{
				deleteFiles.Hashes = new List<string> { Utils.GetSha256(stream) };
			}

			var result = await _client.FilesClient.DeleteFiles(deleteFiles);

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
		}

		[Test]
		public async Task MultiplyWithHashAndId()
		{
			var deleteFiles = new DeleteFilesRequest();
			deleteFiles.FileId = 1;

			using (var stream = File.OpenRead(IoC.FilePath2))
			{
				deleteFiles.Hash = Utils.GetSha256(stream);
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
			var undeleteFiles = new FilesWithDomainRequest();
			undeleteFiles.Hashes = new List<string>();
			using (var stream = File.OpenRead(IoC.FilePath))
			{
				undeleteFiles.Hashes.Add(Utils.GetSha256(stream));
			}

			using (var stream = File.OpenRead(IoC.FilePath2))
			{
				undeleteFiles.Hashes.Add(Utils.GetSha256(stream));
			}

			var result = await _client.FilesClient.UndeleteFiles(undeleteFiles);

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
		}

		[Test]
		public async Task MultiplyFilesWithHashAndId()
		{
			var undeleteFiles = new FilesWithDomainRequest();
			undeleteFiles.FileIds = new List<ulong> { 1 };

			using (var stream = File.OpenRead(IoC.FilePath2))
			{
				undeleteFiles.Hashes = new List<string> { Utils.GetSha256(stream) };
			}

			var result = await _client.FilesClient.UndeleteFiles(undeleteFiles);

			Assert.That(result, Is.Not.Null);
			Assert.That(result, Is.True);
		}
	}

	[TestFixture]
	public class GenerateHashesTest
	{
		private readonly IHydrusClient _client;

		// ReSharper disable once ConvertConstructorToMemberInitializers
		public GenerateHashesTest()
		{
			_client = IoC.GetHydrusClient();
		}

		[Test]
		public async Task LocalFile()
		{
			var result = await _client.FilesClient.GenerateHashes(IoC.FilePath);

			Assert.That(result, Is.Not.Null);
			Assert.That(result.PerceptualHashes, Is.Not.Null);
			Assert.That(result.PixelHash, Is.Not.Null);
			Assert.That(result.Hash, Is.Not.Empty);
		}

		[Test]
		public async Task File()
		{
			using (var stream = System.IO.File.OpenRead(IoC.FilePath))
			{
				var result = await _client.FilesClient.GenerateHashes(stream);

				Assert.That(result, Is.Not.Null);
				Assert.That(result.PerceptualHashes, Is.Not.Null);
				Assert.That(result.PixelHash, Is.Not.Null);
				Assert.That(result.Hash, Is.Not.Empty);
			}
		}

		[Test]
		public async Task NotExistFile()
		{
			using (var stream = System.IO.File.OpenRead(IoC.FilePath3))
			{
				var result = await _client.FilesClient.GenerateHashes(stream);

				Assert.That(result, Is.Not.Null);
				Assert.That(result.Hash, Is.Not.Empty);
			}
		}
	}

	[TestFixture]
	public class GetFilesTest
	{
		private readonly IHydrusClient _client;

		// ReSharper disable once ConvertConstructorToMemberInitializers
		public GetFilesTest()
		{
			_client = IoC.GetHydrusClient();
		}

		[Test]
		public async Task SearchFiles()
		{
			var response = await _client.FilesClient.SearchFiles(new List<string>
			{
				"tag1"
			});

			Assert.That(response, Is.Not.Null);
			Assert.That(response.Hashes, Is.Not.Null);
			Assert.That(response.Hashes!.Count, Is.GreaterThan(0));
			Assert.That(response.FileIds, Is.Not.Null);
			Assert.That(response.FileIds!.Count, Is.GreaterThan(0));
		}

		[Test]
		public async Task OneFileHash()
		{
			using (var stream = File.OpenRead(IoC.FilePath))
			{
				var response = await _client.FilesClient.GetFileHashes(Utils.GetSha256(stream), HashAlgorithmType.Md5);

				Assert.That(response, Is.Not.Null);
				Assert.That(response.Count(), Is.GreaterThan(0));
			}
		}

		[Test]
		public async Task MultiplyFileHash()
		{
			var list = new List<string>();

			using (var stream = File.OpenRead(IoC.FilePath))
			{
				list.Add(Utils.GetSha256(stream));
			}

			using (var stream = File.OpenRead(IoC.FilePath2))
			{
				list.Add(Utils.GetSha256(stream));
			}

			var response = await _client.FilesClient.GetFileHashes(list, HashAlgorithmType.Md5);

			Assert.That(response, Is.Not.Null);
			Assert.That(response.Count(), Is.GreaterThan(0));
		}
	}


	[TestFixture]
	public class GetTest
	{
		private readonly IHydrusClient _client;

		// ReSharper disable once ConvertConstructorToMemberInitializers
		public GetTest()
		{
			_client = IoC.GetHydrusClient();
		}

		[Test]
		public async Task LocalFile()
		{
			var result = await _client.FilesClient.GetFile(IoC.FileHash);

			Assert.That(result, Is.Not.Null);
		}
	}
}
