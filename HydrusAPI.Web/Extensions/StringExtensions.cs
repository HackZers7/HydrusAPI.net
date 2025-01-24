using System.Globalization;
using System.Net;
using System.Text;

namespace HydrusAPI.Web;

internal static class StringExtensions
{
	public static Uri FormatUri(this string pattern, params object[] args)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(pattern);

		var uriString = string.Format(CultureInfo.InvariantCulture, pattern, args);

		return new Uri(uriString, UriKind.Relative);
	}

	public static string UriEncode(this string input)
	{
		return WebUtility.UrlEncode(input);
	}

	public static string ToBase64String(this string input)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(input));
	}
}
