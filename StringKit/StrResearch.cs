namespace StringKit;

/// <summary>
/// Provides extension methods for searching and comparing strings.
/// </summary>
/// <remarks>
/// This class is part of the <c>StringKit</c> library and groups operations
/// for checking string contents, prefixes, suffixes, and case-insensitive comparisons.
/// </remarks>
public static class StrResearch
{
    /// <summary>
    /// Determines whether a string contains at least one of the specified substrings.
    /// </summary>
    /// <param name="value">The string to search in.</param>
    /// <param name="strings">The substrings to search for.</param>
    /// <returns><c>true</c> if the string contains at least one of the specified substrings; otherwise, <c>false</c>.</returns>
    /// <example>
    /// <code>
    /// "Hello World".ContainsAny("World", "Foo")  // true
    /// "Hello World".ContainsAny("Foo", "Bar")    // false
    /// </code>
    /// </example>
    public static bool ContainsAny(this string value, params string[] strings)
        => strings.Any(x => value.Contains(x));

    /// <summary>
    /// Determines whether a string contains all of the specified substrings.
    /// </summary>
    /// <param name="value">The string to search in.</param>
    /// <param name="strings">The substrings to search for.</param>
    /// <returns><c>true</c> if the string contains all of the specified substrings; otherwise, <c>false</c>.</returns>
    /// <example>
    /// <code>
    /// "Hello World".ContainsAll("Hello", "World")  // true
    /// "Hello World".ContainsAll("Hello", "Foo")    // false
    /// </code>
    /// </example>
    public static bool ContainsAll(this string value, params string[] strings)
        => strings.All(x => value.Contains(x));

    /// <summary>
    /// Determines whether a string starts with at least one of the specified prefixes.
    /// </summary>
    /// <param name="value">The string to search in.</param>
    /// <param name="strings">The prefixes to check.</param>
    /// <returns><c>true</c> if the string starts with at least one of the specified prefixes; otherwise, <c>false</c>.</returns>
    /// <example>
    /// <code>
    /// "Hello World".StartsWithAny("Hello", "Foo")  // true
    /// "Hello World".StartsWithAny("Foo", "Bar")    // false
    /// </code>
    /// </example>
    public static bool StartsWithAny(this string value, params string[] strings)
        => strings.Any(x => value.StartsWith(x));

    /// <summary>
    /// Determines whether a string ends with at least one of the specified suffixes.
    /// </summary>
    /// <param name="value">The string to search in.</param>
    /// <param name="strings">The suffixes to check.</param>
    /// <returns><c>true</c> if the string ends with at least one of the specified suffixes; otherwise, <c>false</c>.</returns>
    /// <example>
    /// <code>
    /// "Hello World".EndsWithAny("World", "Foo")  // true
    /// "Hello World".EndsWithAny("Foo", "Bar")    // false
    /// </code>
    /// </example>
    public static bool EndsWithAny(this string value, params string[] strings)
        => strings.Any(x => value.EndsWith(x));

    /// <summary>
    /// Determines whether a string is equal to another string, ignoring case.
    /// </summary>
    /// <param name="value">The string to compare.</param>
    /// <param name="other">The string to compare against.</param>
    /// <returns><c>true</c> if the strings are equal ignoring case; otherwise, <c>false</c>.</returns>
    /// <example>
    /// <code>
    /// "Hello".EqualsIgnoreCase("hello")  // true
    /// "Hello".EqualsIgnoreCase("World")  // false
    /// </code>
    /// </example>
    public static bool EqualsIgnoreCase(this string value, string other)
        => value.ToLower().Equals(other.ToLower());
}
