using System.Globalization;
using System.Net;
using System.Text;

namespace HydrusAPI.Web;

internal static class StringExtensions
{
	public static Uri FormatUri(this string source, params object[] args)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(source);

		var uriString = string.Format(CultureInfo.InvariantCulture, source, args);

		return new Uri(uriString, UriKind.Relative);
	}

	public static string UriEncode(this string source)
	{
		return WebUtility.UrlEncode(source);
	}

	public static string ToBase64String(this string source)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(source));
	}

	public static string ToStringArray(this IEnumerable<int> source)
	{
		// ReSharper disable once UseStringInterpolation
		return string.Format("[{0}]", string.Join(',', source.Select(p => p.ToString())));
	}

	public static string ToStringArray(this IEnumerable<string> source)
	{
		// ReSharper disable once UseStringInterpolation
		return string.Format("[{0}]", string.Join(',', source.Select(p => $"\"{p}\"")));
	}

	public static string ToStringArray<T>(this IEnumerable<T> source)
	{
		// ReSharper disable once UseStringInterpolation
		return string.Format("[{0}]", string.Join(',', source.Select(p => p?.ToString())));
	}
}
