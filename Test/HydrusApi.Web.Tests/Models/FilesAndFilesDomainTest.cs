using HydrusAPI.Web;
using NUnit.Framework;

namespace HydrusApi.Web.Tests.Models;

[TestFixture]
public class FilesAndFilesDomainTest
{
	public TestContext TestContext { get; set; } = default!;

	[Test]
	public void FilesSerializationTest()
	{
		var files = new Files();
		files.AddHash("test1");

		var data = Utils.Serialize(files);

		TestContext.WriteLine(data);

		Assert.That(data, Is.Not.Empty);
	}

	[Test]
	public void FilesMultiplySerializationTest()
	{
		var files = new Files();
		files.AddHash("test1");
		files.AddId(500);

		var data = Utils.Serialize(files);

		TestContext.WriteLine(data);

		Assert.That(data, Is.Not.Empty);
	}
}
