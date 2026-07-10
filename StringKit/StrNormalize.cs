using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace StringKit;

/// <summary>
/// Provides extension methods for normalizing and cleaning up string content,
/// such as collapsing whitespace, removing diacritics, and stripping special characters.
/// </summary>
public static class StrNormalize
{
    /// <summary>
    /// Trims the string and collapses any run of multiple consecutive spaces into a single space.
    /// </summary>
    /// <param name="value">The string to normalize.</param>
    /// <returns>The trimmed string with internal whitespace runs collapsed to single spaces.</returns>
    public static string NormalizeSpaces(this string value)
        => Regex.Replace(value.Trim(), @"\s+", " ");

    /// <summary>
    /// Removes diacritical marks (accents) from the characters in the string,
    /// e.g. converting "café" to "cafe".
    /// </summary>
    /// <param name="value">The string to strip diacritics from.</param>
    /// <returns>The string with non-spacing combining marks removed, re-normalized to composed form.</returns>
    public static string RemoveDiacritics(this string value)
    {
        var normalized = value.Normalize(NormalizationForm.FormD);
        var builder = new StringBuilder();

        foreach (char c in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                builder.Append(c);
        }

        return builder.ToString().Normalize(NormalizationForm.FormC);
    }

    /// <summary>
    /// Removes special (non-alphanumeric) characters from the string, optionally replacing them
    /// with the given replacement string.
    /// </summary>
    /// <param name="value">The string to clean.</param>
    /// <param name="replace">The string to substitute for each special character removed. Defaults to an empty string.</param>
    /// <returns>The string with special characters removed or replaced.</returns>
    public static string RemoveSpecialChars(this string value, string replace = "")
        => Regex.Replace(value, @"([^a-zA-Z0-9])", replace);

    /// <summary>
    /// Normalizes line ending sequences in the string to a consistent format.
    /// </summary>
    /// <param name="value">The string whose line endings should be normalized.</param>
    /// <returns>The string with normalized line endings.</returns>
    public static string NormalizeNewLines(this string value)
        => value.Replace("\r\n", "\n").Replace("\n\r", "\n").Replace("\r", "\n");

    /// <summary>
    /// Removes HTML tags from the string, leaving only the plain text content.
    /// </summary>
    /// <param name="value">The string containing HTML markup to strip.</param>
    /// <returns>The plain text with HTML tags removed.</returns>
    public static string StripHtml(this string value)
        => Regex.Replace(value, @"(<[a-zA-Z/][^>]*>)", "");

    /// <summary>
    /// Collapses all whitespace characters (spaces, tabs, newlines, etc.) in the string
    /// into single spaces.
    /// </summary>
    /// <param name="value">The string whose whitespace should be collapsed.</param>
    /// <returns>The string with all whitespace runs collapsed to single spaces.</returns>
    public static string CollapseWhitespace(this string value)
        => value.Replace("\t", " ").NormalizeSpaces();

    /// <summary>
    /// Joins all lines in the string into one by removing newline characters.
    /// </summary>
    /// <param name="value">The multi-line string to join.</param>
    /// <returns>The string with all newline characters removed.</returns>
    public static string JoinLines(this string value)
        => value.NormalizeNewLines().Replace("\n", "");
}
