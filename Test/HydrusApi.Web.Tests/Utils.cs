using DS.Shared;
using HydrusAPI.Web;
using HydrusAPI.Web.Http;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace HydrusApi.Web.Tests;

public static class Utils
{
	public static string GetSha256(Stream value)
	{
		var sb = new StringBuilder();
		using (var hash = SHA256.Create())
		{
			var result = hash.ComputeHash(value.ReadAllBytes());
			foreach (var b in result)
			{
				sb.Append(b.ToString("x2"));
			}
		}

		return sb.ToString();
	}

	public static Request GetTestRequest()
	{
		return new Request(HydrusUrls.DefaultLocalhost, HydrusUrls.ApiVersion(), HttpMethod.Get);
	}

	public static string Serialize(object data)
	{
		var request = GetTestRequest();
		request.Body = data;

		var serializer = new NewtonsoftJsonSerializer();
		serializer.SerializeRequest(request);
		return (string)request.Body;
	}
}
