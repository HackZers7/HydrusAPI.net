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
		fileDomain.AddFileDomain("test1");

		var data = Utils.Serialize(fileDomain);

		TestContext.WriteLine(data);

		Assert.That(data, Is.Not.Empty);
	}

	[Test]
	public void FileDomainMultiplySerializationTest()
	{
		var fileDomain = new TestFileDomainRequest();
		fileDomain.AddFileDomain("test1");
		fileDomain.AddDeletedFileDomain("test1");

		var data = Utils.Serialize(fileDomain);

		TestContext.WriteLine(data);

		Assert.That(data, Is.Not.Empty);
	}

	private class TestFileDomainRequest : FileDomainRequest
	{
	}
}
