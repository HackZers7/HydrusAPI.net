using HydrusAPI.Web;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.IO;

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
			using (var stream = System.IO.File.OpenRead(IoC.FilePath2))
			{
				var result = await _client.FilesClient.SendFile(stream);

				Assert.That(result, Is.Not.Null);
				Assert.That(result.Status, Is.EqualTo(FileStatus.Success).Or.EqualTo(FileStatus.AlreadyExists));
				Assert.That(result.Hash, Is.Not.Empty);
			}
		}

		[Test]
		public async Task FileWithProgress()
		{
			var progress = new Progress<int>(TestContext.WriteLine);

			using (var stream = System.IO.File.OpenRead(IoC.FilePath))
			{
				var result = await _client.FilesClient.SendFile(stream, progress);

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

		public DeleteTest()
		{
			_client = IoC.GetHydrusClient();
		}

		[Test]
		public async Task ByHash()
		{
			await _client.FilesClient.DeleteFiles(IoC.FileHash);
		}

		[Test]
		public async Task ById()
		{
			await _client.FilesClient.DeleteFiles(IoC.FileId);
		}

		[Test]
		public async Task MultiplyFiles()
		{
			var deleteFiles = new DeleteFilesRequest(new List<string>() { IoC.FileHash, IoC.FileHash2 });

			await _client.FilesClient.DeleteFiles(deleteFiles);
		}

		[Test]
		public async Task MultiplyFilesWithHashAndId()
		{
			var deleteFiles = new DeleteFilesRequest(new List<ulong> { IoC.FileId })
			{
				Hashes = new List<string> { IoC.FileHash2 }
			};

			await _client.FilesClient.DeleteFiles(deleteFiles);
		}

		[Test]
		public async Task MultiplyWithHashAndId()
		{
			var deleteFiles = new DeleteFilesRequest(IoC.FileId)
			{
				Hash = IoC.FileHash2
			};

			await _client.FilesClient.DeleteFiles(deleteFiles);
		}

		[Test]
		public async Task WithReasons()
		{
			await _client.FilesClient.DeleteFiles(IoC.FileHash, "testReason");
		}
	}

	[TestFixture]
	public class RestoreTest
	{
		private readonly IHydrusClient _client;

		public RestoreTest()
		{
			_client = IoC.GetHydrusClient();
		}

		[Test]
		public async Task ByHash()
		{
			await _client.FilesClient.RestoreFiles(IoC.FileHash);
		}

		[Test]
		public async Task ById()
		{
			await _client.FilesClient.RestoreFiles(IoC.FileId);
		}

		[Test]
		public async Task MultiplyFiles()
		{
			var request = new FilesWithDomainRequest(new List<string>() { IoC.FileHash, IoC.FileHash2 });

			await _client.FilesClient.RestoreFiles(request);
		}

		[Test]
		public async Task MultiplyFilesWithHashAndId()
		{
			var request = new FilesWithDomainRequest(new List<ulong> { IoC.FileId })
			{
				Hashes = new List<string>() { IoC.FileHash2 }
			};

			await _client.FilesClient.RestoreFiles(request);
		}
	}

	[TestFixture]
	public class ClearFilesDeletionTest
	{
		private readonly IHydrusClient _client;

		public ClearFilesDeletionTest()
		{
			_client = IoC.GetHydrusClient();
		}

		[Test]
		public async Task ByHash()
		{
			await _client.FilesClient.ClearFilesDeletion(IoC.FileHash);
		}

		[Test]
		public async Task ById()
		{
			await _client.FilesClient.ClearFilesDeletion(IoC.FileId);
		}

		[Test]
		public async Task MultiplyFiles()
		{
			var request = new FilesRequest(new List<string>() { IoC.FileHash, IoC.FileHash2 });

			await _client.FilesClient.ClearFilesDeletion(request);
		}

		[Test]
		public async Task MultiplyFilesWithHashAndId()
		{
			var request = new FilesRequest(new List<ulong> { IoC.FileId })
			{
				Hashes = new List<string>() { IoC.FileHash2 }
			};

			await _client.FilesClient.ClearFilesDeletion(request);
		}
	}

	[TestFixture]
	public class MigrateTest
	{
		private readonly IHydrusClient _client;

		public MigrateTest()
		{
			_client = IoC.GetHydrusClient();
		}

		[Test]
		public async Task ByHash()
		{
			await _client.FilesClient.MigrateFiles(IoC.TestFileDomain, IoC.FileHash);
		}

		[Test]
		public async Task ById()
		{
			await _client.FilesClient.MigrateFiles(IoC.TestFileDomain, IoC.FileId);
		}

		[Test]
		public async Task MultiplyFiles()
		{
			var request = new FilesWithDomainRequest(new List<string>() { IoC.FileHash, IoC.FileHash2 })
			{
				FileServiceKey = IoC.TestFileDomain
			};

			await _client.FilesClient.MigrateFiles(request);
		}

		[Test]
		public async Task MultiplyFilesWithHashAndId()
		{
			var request = new FilesWithDomainRequest(new List<ulong> { IoC.FileId })
			{
				Hashes = new List<string>() { IoC.FileHash2 },
				FileServiceKey = IoC.TestFileDomain
			};

			await _client.FilesClient.MigrateFiles(request);
		}
	}

	[TestFixture]
	public class ArchiveFilesTest
	{
		private readonly IHydrusClient _client;

		public ArchiveFilesTest()
		{
			_client = IoC.GetHydrusClient();
		}

		[Test]
		public async Task ByHash()
		{
			await _client.FilesClient.ArchiveFiles(IoC.FileHash);
		}

		[Test]
		public async Task ById()
		{
			await _client.FilesClient.ArchiveFiles(IoC.FileId);
		}

		[Test]
		public async Task MultiplyFiles()
		{
			var request = new FilesRequest(new List<string>() { IoC.FileHash, IoC.FileHash2 });

			await _client.FilesClient.ArchiveFiles(request);
		}

		[Test]
		public async Task MultiplyFilesWithHashAndId()
		{
			var request = new FilesRequest(new List<ulong> { IoC.FileId })
			{
				Hashes = new List<string>() { IoC.FileHash2 }
			};

			await _client.FilesClient.ArchiveFiles(request);
		}
	}

	[TestFixture]
	public class UnarchiveFilesTest
	{
		private readonly IHydrusClient _client;

		public UnarchiveFilesTest()
		{
			_client = IoC.GetHydrusClient();
		}

		[Test]
		public async Task ByHash()
		{
			await _client.FilesClient.UnarchiveFiles(IoC.FileHash);
		}

		[Test]
		public async Task ById()
		{
			await _client.FilesClient.UnarchiveFiles(IoC.FileId);
		}

		[Test]
		public async Task MultiplyFiles()
		{
			var request = new FilesRequest(new List<string>() { IoC.FileHash, IoC.FileHash2 });

			await _client.FilesClient.UnarchiveFiles(request);
		}

		[Test]
		public async Task MultiplyFilesWithHashAndId()
		{
			var request = new FilesRequest(new List<ulong> { IoC.FileId })
			{
				Hashes = new List<string>() { IoC.FileHash2 }
			};

			await _client.FilesClient.UnarchiveFiles(request);
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
		public async Task File()
		{
			var result = await _client.FilesClient.GetFile(IoC.FileHash);

			Assert.That(result, Is.Not.Null);
		}
	}
}
