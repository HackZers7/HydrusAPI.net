using DS.Shared;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HydrusApi.Web.Tests;

public static class Utils
{
	public static string GetSha256(Stream value)
	{
		StringBuilder sb = new StringBuilder();
		using (var hash = SHA256.Create())
		{
			byte[] result = hash.ComputeHash(value.ReadAllBytes());
			foreach (byte b in result)
				sb.Append(b.ToString("x2"));
		}
		return sb.ToString();
	}
}
