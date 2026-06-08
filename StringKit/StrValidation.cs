using System.Text.RegularExpressions;

namespace StringKit;

/// <summary>
/// Provides extension methods for string validation.
/// </summary>
/// <remarks>
/// This class is part of the <c>StringKit</c> library and groups operations
/// for validating string formats such as emails, URLs, and character constraints.
/// </remarks>
public static class StrValidation
{
    /// <summary>
    /// Determines whether a string is a valid email address.
    /// </summary>
    /// <param name="email">The string to validate.</param>
    /// <returns><c>true</c> if the string is a valid email address; otherwise, <c>false</c>.</returns>
    /// <example>
    /// <code>
    /// "mario@mail.it".IsEmail()  // true
    /// "not-an-email".IsEmail()   // false
    /// </code>
    /// </example>
    public static bool IsEmail(this string email)
        => !string.IsNullOrWhiteSpace(email) && Regex.IsMatch(email, @"^(?!.*\.{2})([\w\-\+]+(?:\.[\w\-\+]+)*)@([\w\-]+(?:\.[\w\-]+)*\.[a-zA-Z]{2,})$");

    /// <summary>
    /// Determines whether a string is a valid URL.
    /// </summary>
    /// <param name="url">The string to validate.</param>
    /// <returns><c>true</c> if the string is a valid URL; otherwise, <c>false</c>.</returns>
    /// <example>
    /// <code>
    /// "https://example.com".IsUrl()  // true
    /// "not a url".IsUrl()            // false
    /// </code>
    /// </example>
    public static bool IsUrl(this string url)
        => Uri.TryCreate(url, UriKind.Absolute, out var uri)
           && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);


    /// <summary>
    /// Determines whether a string contains only numeric digits.
    /// </summary>
    /// <param name="number">The string to validate.</param>
    /// <returns><c>true</c> if the string contains only digits; otherwise, <c>false</c>.</returns>
    /// <example>
    /// <code>
    /// "12345".IsNumeric()   // true
    /// "123a5".IsNumeric()   // false
    /// </code>
    /// </example>
    public static bool IsNumeric(this string number)
        => !string.IsNullOrEmpty(number) && number.All(char.IsDigit);

    /// <summary>
    /// Determines whether a string contains only alphabetic characters.
    /// </summary>
    /// <param name="letters">The string to validate.</param>
    /// <returns><c>true</c> if the string contains only letters; otherwise, <c>false</c>.</returns>
    /// <example>
    /// <code>
    /// "Hello".IsAlpha()   // true
    /// "Hello1".IsAlpha()  // false
    /// </code>
    /// </example>
    public static bool IsAlpha(this string letters)
        => !string.IsNullOrEmpty(letters) && letters.All(char.IsLetter);

    /// <summary>
    /// Determines whether a string contains only alphanumeric characters.
    /// </summary>
    /// <param name="characters">The string to validate.</param>
    /// <returns><c>true</c> if the string contains only letters and digits; otherwise, <c>false</c>.</returns>
    /// <example>
    /// <code>
    /// "Hello123".IsAlphanumeric()   // true
    /// "Hello 123".IsAlphanumeric()  // false
    /// </code>
    /// </example>
    public static bool IsAlphanumeric(this string characters)
        => !string.IsNullOrEmpty(characters) && characters.All(char.IsLetterOrDigit);

    /// <summary>
    /// Determines whether a string is <c>null</c>, empty, or consists only of whitespace characters.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <returns><c>true</c> if the string is <c>null</c>, empty, or whitespace; otherwise, <c>false</c>.</returns>
    /// <example>
    /// <code>
    /// "   ".IsNullOrWhiteSpace()  // true
    /// "Hi".IsNullOrWhiteSpace()   // false
    /// </code>
    /// </example>
    public static bool IsNullOrWhiteSpace(this string value)
        => string.IsNullOrWhiteSpace(value);

    /// <summary>
    /// Determines whether a string meets a minimum length requirement.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <param name="length">The minimum number of characters required.</param>
    /// <returns><c>true</c> if the string length is greater than or equal to <paramref name="length"/>; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="length"/> is less than or equal to zero.</exception>
    /// <example>
    /// <code>
    /// "Hello".HasMinLength(3)  // true
    /// "Hi".HasMinLength(5)     // false
    /// </code>
    /// </example>
    public static bool HasMinLength(this string value, int length)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(length);
        return value.Length >= length;
    }

    /// <summary>
    /// Determines whether a string does not exceed a maximum length.
    /// </summary>
    /// <param name="value">The string to validate.</param>
    /// <param name="length">The maximum number of characters allowed.</param>
    /// <returns><c>true</c> if the string length is less than or equal to <paramref name="length"/>; otherwise, <c>false</c>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="length"/> is less than or equal to zero.</exception>
    /// <example>
    /// <code>
    /// "Hi".HasMaxLength(5)      // true
    /// "Hello World".HasMaxLength(5)  // false
    /// </code>
    /// </example>
    public static bool HasMaxLength(this string value, int length)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(length);
        return value.Length <= length;
    }
}
