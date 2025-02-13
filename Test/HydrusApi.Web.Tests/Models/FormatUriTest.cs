using HydrusAPI.Web;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable UseStringInterpolation

namespace HydrusApi.Web.Tests.Models;

[TestFixture]
public class FormatUriTest
{
	public TestContext TestContext { get; set; } = default!;

	[Test]
	public void FormatUri()
	{
		var data = HydrusUrls.SearchFiles(new SearchFilesRequest
		{
			Tags = new List<object>
			{
				"test",
				"test2",
				new List<string>
				{
					"test4",
					"test5"
				}
			}
		});

		TestContext.WriteLine(data);

		Assert.That(data, Is.Not.Null);
	}

	[Test]
	public void ToParameter()
	{
		var data = ToParameter(new List<object>
		{
			"test",
			"test2",
			new List<string>
			{
				"test4",
				"test5"
			}
		});

		TestContext.WriteLine(data);

		Assert.That(data, Is.Not.Null);
	}

	public static string ToParameter(object? source)
	{
		if (source == null)
		{
			return string.Empty;
		}

		return source switch
		{
			string value => value,
			bool value => value.ToString().ToLower(),
			int value => value.ToString(),
			IEnumerable<string> value => ToStringArray(value),
			IEnumerable<object> value => ToStringArray(value.Select(ToParameter)),
			_ => throw new NotSupportedException()
		};
	}

	public static string ToStringArray(IEnumerable<string>? source)
	{
		if (source == null)
		{
			return "[]";
		}

		return string.Format("[{0}]", string.Join(',', source.Select(p => p.Trim() is { } trimString && trimString.StartsWith('[') && trimString.EndsWith(']') ? trimString : $"\"{p}\"")));
	}
}
