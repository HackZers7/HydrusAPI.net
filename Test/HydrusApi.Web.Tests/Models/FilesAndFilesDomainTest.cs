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
        var files = new FilesRequest("test1");

        var data = Utils.Serialize(files);

        TestContext.WriteLine(data);

        Assert.That(data, Is.Not.Empty);
    }

    [Test]
    public void FilesMultiplySerializationTest()
    {
        var files = new FilesRequest("test1");
        files.FileId = 500UL;

        var data = Utils.Serialize(files);

        TestContext.WriteLine(data);

        Assert.That(data, Is.Not.Empty);
    }
}
