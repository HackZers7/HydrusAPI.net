using System.Globalization;
using System.Net;
using System.Text;

// ReSharper disable UseStringInterpolation

namespace HydrusAPI.Web;

internal static class StringExtensions
{
	public static Uri FormatUri(this string source, params object[] args)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(source);

		var uriString = string.Format(CultureInfo.InvariantCulture, source, args);

		return new Uri(uriString, UriKind.Relative);
	}

	public static Uri FormatUri(this string source, Dictionary<string, object?> parameters, params object[] args)
	{
		ThrowHelper.ArgumentNotNullOrWhiteSpace(source);

		var param = new List<string>();

		foreach (var (key, value) in parameters)
		{
			if (value == null)
			{
				continue;
			}

			var encodedValue = value.ToParameter();

			param.Add($"{key}={encodedValue}");
		}

		source += string.Join("&", param);

		return source.FormatUri(args);
	}

	public static string UriEncode(this string source)
	{
		return WebUtility.UrlEncode(source);
	}

	public static string ToBase64String(this string source)
	{
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(source));
	}

	public static string ToStringArray(this IEnumerable<int>? source)
	{
		if (source == null)
		{
			return "[]";
		}

		return string.Format("[{0}]", string.Join(',', source.Select(p => p.ToString())));
	}

	public static string ToStringArray(this IEnumerable<string>? source)
	{
		if (source == null)
		{
			return "[]";
		}

		return string.Format("[{0}]", string.Join(',', source.Select(p => p.Trim() is { } trimString && trimString.StartsWith('[') && trimString.EndsWith(']') ? trimString : $"\"{p}\"")));
	}

	public static string ToStringArray<T>(this IEnumerable<T>? source)
	{
		if (source == null)
		{
			return "[]";
		}

		return string.Format("[{0}]", string.Join(',', source.Select(p => p?.ToString())));
	}

	public static string ToParameter(this object? source)
	{
		if (source == null)
		{
			return string.Empty;
		}

		return source switch
		{
			string value => value.UriEncode(),
			bool value => value.ToString().ToLower(),
			int value => value.ToString(),
			IEnumerable<string> value => value.ToStringArray().UriEncode(),
			IEnumerable<int> value => value.ToStringArray().UriEncode(),
			IEnumerable<object> value => value.Select(ToParameter).ToStringArray().UriEncode(),
			_ => throw new NotSupportedException()
		};
	}
}
