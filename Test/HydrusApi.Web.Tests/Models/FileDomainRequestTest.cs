using HydrusAPI.Web;
using NUnit.Framework;

namespace HydrusApi.Web.Tests.Models;

[TestFixture]
public class FileDomainRequestTest
{
	public TestContext TestContext { get; set; } = default!;

	[Test]
	public void FileDomainSerializationTest()
	{
		var fileDomain = new TestFileDomainRequest();
		fileDomain.FileServiceKey = "test1";

		var data = Utils.Serialize(fileDomain);

		TestContext.WriteLine(data);

		Assert.That(data, Is.Not.Empty);
	}

	[Test]
	public void FileDomainMultiplySerializationTest()
	{
		var fileDomain = new TestFileDomainRequest();
		fileDomain.FileServiceKey = "test1";
		fileDomain.DeletedFileServiceKey = "test1";

		var data = Utils.Serialize(fileDomain);

		TestContext.WriteLine(data);

		Assert.That(data, Is.Not.Empty);
	}

	private class TestFileDomainRequest : FileDomainRequest
	{
	}
}
