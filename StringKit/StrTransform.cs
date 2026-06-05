using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace StringKit;

/// <summary>
/// Provides extension methods for string transformation and formatting.
/// </summary>
/// <remarks>
/// This class is part of the <c>StringKit</c> library and groups operations
/// for converting between formats (slug, camelCase, snake_case, etc.), truncation,
/// repetition and reversal of strings.
/// </remarks>
public static class StrTransform
{

    /// <summary>
    /// Converts a string to slug format, replacing spaces with hyphens and lowercasing the result.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The slug-formatted string.</returns>
    /// <example>
    /// <code>
    /// "Hello World".ToSlug() // "hello-world"
    /// </code>
    /// </example>
    public static string ToSlug(this string value)
        => value.ToLower().Replace(" ", "-");

    /// <summary>
    /// Converts a string to snake_case, replacing spaces with underscores and lowercasing the result.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The snake_case-formatted string.</returns>
    /// <example>
    /// <code>
    /// "Hello World".ToSnakeCase() // "hello_world"
    /// </code>
    /// </example>
    public static string ToSnakeCase(this string value)
        => value.ToLower().Replace(" ", "_");

    /// <summary>
    /// Converts a string to camelCase, capitalizing the first letter of each word except the first.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The camelCase-formatted string.</returns>
    /// <example>
    /// <code>
    /// "hello world".ToCamelCase() // "helloWorld"
    /// </code>
    /// </example>
    public static string ToCamelCase(this string value)
        => Regex.Replace(value.ToLower(), @"\s+([à-ža-z])", m => m.Groups[1].Value.ToUpper());

    /// <summary>
    /// Converts a string to PascalCase, capitalizing the first letter of every word including the first.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The PascalCase-formatted string.</returns>
    /// <example>
    /// <code>
    /// "hello world".ToPascalCase() // "HelloWorld"
    /// </code>
    /// </example>
    public static string ToPascalCase(this string value)
        => Regex.Replace(value.ToCamelCase(), @"^([à-ža-z])", m => m.Groups[1].Value.ToUpper());

    /// <summary>
    /// Converts a string to Title Case using the rules of the specified culture.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <param name="culture">The culture to use for capitalization rules.</param>
    /// <returns>The Title Case-formatted string.</returns>
    /// <example>
    /// <code>
    /// "hello world".ToTitleCase(new CultureInfo("en-US")) // "Hello World"
    /// </code>
    /// </example>
    public static string ToTitleCase(this string value, CultureInfo culture)
        => culture.TextInfo.ToTitleCase(value.ToLower());

    /// <summary>
    /// Converts a string to Sentence case, capitalizing the first letter after each period.
    /// </summary>
    /// <param name="value">The string to convert.</param>
    /// <returns>The Sentence case-formatted string.</returns>
    /// <example>
    /// <code>
    /// "hello world. bye world".ToSentenceCase() // "Hello world. Bye world"
    /// </code>
    /// </example>
    public static string ToSentenceCase(this string value)
        => Regex.Replace(value.ToLower(), @"(\.)\s+(.)", m => ". " + m.Groups[2].Value.ToUpper());


    /// <summary>
    /// Truncates a string to the specified length, appending a suffix if needed.
    /// </summary>
    /// <param name="value">The string to truncate.</param>
    /// <param name="length">The maximum number of characters before the suffix.</param>
    /// <param name="suffix">The suffix to append when truncation occurs. Default: "..."</param>
    /// <returns>The truncated string with suffix, or the original string if short enough.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="length"/> is less than or equal to zero.</exception>
    /// <example>
    /// <code>
    /// "Hello World".Truncate(5)       // "Hello..."
    /// "Hello World".Truncate(5, "…")  // "Hello…"
    /// "Hi".Truncate(10)               // "Hi"
    /// </code>
    /// </example>
    public static string Truncate(this string value, int length, string suffix = "...")
    {
        int end = value.Length - length;

        if (length <= 0)
            throw new ArgumentOutOfRangeException(nameof(length), "Length must be greater than 0.");

        if (end < 0)
            throw new ArgumentOutOfRangeException(nameof(length), "Length cannot be greater than the string length");

        if (string.IsNullOrEmpty(value))
            return value;

        return value.Substring(0, end) + suffix;
    }

    /// <summary>
    /// Truncates a string to the specified number of words.
    /// </summary>
    /// <param name="value">The string to truncate.</param>
    /// <param name="n">The number of words to keep.</param>
    /// <returns>A string containing at most <paramref name="n"/> words.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if <paramref name="n"/> exceeds the number of words in the string,
    /// or if the string is empty and <paramref name="n"/> is greater than zero.
    /// </exception>
    /// <example>
    /// <code>
    /// "hello world foo".TruncateWords(2) // "hello world"
    /// </code>
    /// </example>
    public static string TruncateWords(this string value, int n)
    {
        var words = value.Split();

        if (words.Length < n || (string.IsNullOrEmpty(value) && n > 0)) throw new ArgumentOutOfRangeException($"Cannot truncate {n} words because it's exceeded the number of words of the string");
        if (words.Length == n) return string.Empty;

        return words[0..n].ToString() ?? "";
    }

    /// <summary>
    /// Repeats a string a specified number of times.
    /// </summary>
    /// <param name="value">The string to repeat.</param>
    /// <param name="n">The number of repetitions.</param>
    /// <returns>The string repeated <paramref name="n"/> times.</returns>
    /// <example>
    /// <code>
    /// "ab".Repeat(3) // "ababab"
    /// </code>
    /// </example>
    public static string Repeat(this string value, int n)
    {
        string newStr = "";
        for (int i = 0; i < n; i++)
            newStr += value;
        return newStr;
    }

    /// <summary>
    /// Reverses a string character by character.
    /// </summary>
    /// <param name="value">The string to reverse.</param>
    /// <returns>The reversed string.</returns>
    /// <example>
    /// <code>
    /// "hello".Reverse() // "olleh"
    /// </code>
    /// </example>
    public static string Reverse(this string value)
    {
        StringBuilder newStr = new();

        for (int i = value.Length - 1; i >= 0; i--)
            newStr.Append(value[i]);

        return newStr.ToString();
    }
}
