using System.Web;

namespace StringKit;

/// <summary>
/// Provides extension methods for encoding and decoding strings
/// using Base64, URL, and HTML formats.
/// </summary>
public static class StrEncodeDecode
{
    /// <summary>
    /// Encodes the current string to its Base64 representation using UTF-8 encoding.
    /// </summary>
    /// <param name="value">The plain-text string to encode.</param>
    /// <returns>A Base64-encoded string.</returns>
    public static string ToBase64(this string value)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(value);
        return Convert.ToBase64String(plainTextBytes);
    }

    /// <summary>
    /// Decodes the current Base64-encoded string back to its original UTF-8 plain-text representation.
    /// </summary>
    /// <param name="value">The Base64-encoded string to decode.</param>
    /// <returns>The decoded plain-text string.</returns>
    public static string FromBase64(this string value)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(value);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }

    /// <summary>
    /// Encodes the current string for safe inclusion in a URL,
    /// replacing special characters with their percent-encoded equivalents.
    /// </summary>
    /// <param name="link">The string to URL-encode.</param>
    /// <returns>A URL-encoded string.</returns>
    public static string UrlEncode(this string link)
        => HttpUtility.UrlEncode(link);

    /// <summary>
    /// Decodes a URL-encoded string, converting percent-encoded sequences
    /// back to their original characters.
    /// </summary>
    /// <param name="value">The URL-encoded string to decode.</param>
    /// <returns>The decoded string.</returns>
    public static string UrlDecode(this string value)
        => HttpUtility.UrlDecode(value);

    /// <summary>
    /// Encodes a string for safe inclusion in HTML, replacing characters such as
    /// <c>&lt;</c>, <c>&gt;</c>, and <c>&amp;</c> with their HTML entity equivalents.
    /// </summary>
    /// <param name="value">The string to HTML-encode.</param>
    /// <returns>An HTML-encoded string.</returns>
    public static string HtmlEncode(this string value)
        => HttpUtility.HtmlEncode(value);

    /// <summary>
    /// Decodes an HTML-encoded string, converting HTML entities back to their original characters.
    /// </summary>
    /// <param name="value">The HTML-encoded string to decode.</param>
    /// <returns>The decoded string.</returns>
    public static string HtmlDecode(this string value)
        => HttpUtility.HtmlDecode(value);
}
