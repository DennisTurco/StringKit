using System.Text;

namespace StringKit;

/// <summary>
/// Provides extension methods for masking and redacting sensitive data in strings.
/// </summary>
/// <remarks>
/// This class is part of the <c>StringKit</c> library and groups operations
/// for protecting personally identifiable information (PII) such as emails and phone numbers.
/// </remarks>
public static class StrPrivacy
{
    /// <summary>
    /// Replaces characters in a string with asterisks between the specified indices.
    /// </summary>
    /// <param name="value">The string to redact.</param>
    /// <param name="start">The index of the first character to redact (inclusive).</param>
    /// <param name="end">The index of the last character to redact (exclusive).</param>
    /// <returns>The string with the specified range replaced by asterisks.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if <paramref name="end"/> is greater than or equal to the length of <paramref name="value"/>,
    /// or if <paramref name="start"/> is greater than <paramref name="end"/>.
    /// </exception>
    /// <example>
    /// <code>
    /// "Hello World".Redact(1, 5) // "H**** World"
    /// </code>
    /// </example>
    public static string Redact(this string value, int start, int end)
    {
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(end, value.Length);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(start, end);

        StringBuilder builder = new(value);
        for (int i = start; i < end; i++)
            builder[i] = '*';

        return builder.ToString();
    }

    /// <summary>
    /// Masks an email address, hiding all characters between the first and the <c>@</c> symbol.
    /// </summary>
    /// <param name="email">The email address to mask.</param>
    /// <returns>The masked email address.</returns>
    /// <example>
    /// <code>
    /// "mario@mail.it".MaskEmail() // "m****@mail.it"
    /// </code>
    /// </example>
    public static string MaskEmail(this string email)
        => email.Redact(1, email.IndexOf('@'));

    /// <summary>
    /// Masks a phone number, hiding characters from index 3 to 8.
    /// </summary>
    /// <param name="phone">The phone number to mask.</param>
    /// <returns>The masked phone number.</returns>
    /// <example>
    /// <code>
    /// "3331234567".MaskPhone() // "333*****67"
    /// </code>
    /// </example>
    public static string MaskPhone(this string phone)
        => phone.Redact(3, 8);
}
