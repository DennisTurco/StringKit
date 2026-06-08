namespace StringKit.Tests;

public class StrValidationTests
{
    // IsEmail
    [Theory]
    [InlineData("mario@mail.it", true)]
    [InlineData("user.name+tag@sub.domain.com", true)]
    [InlineData("not-an-email", false)]
    [InlineData("missing@domain", false)]
    [InlineData("@mail.it", false)]
    [InlineData("", false)]
    public void IsEmail(string input, bool expected)
        => Assert.Equal(expected, input.IsEmail());

    // IsUrl
    [Theory]
    [InlineData("https://example.com", true)]
    [InlineData("http://example.com/path?q=1", true)]
    [InlineData("ftp://example.com", false)]
    [InlineData("not a url", false)]
    [InlineData("example.com", false)]
    public void IsUrl(string input, bool expected)
        => Assert.Equal(expected, input.IsUrl());

    // IsNumeric
    [Theory]
    [InlineData("12345", true)]
    [InlineData("0", true)]
    [InlineData("123a5", false)]
    [InlineData("", false)]
    [InlineData(" ", false)]
    public void IsNumeric(string input, bool expected)
        => Assert.Equal(expected, input.IsNumeric());

    // IsAlpha
    [Theory]
    [InlineData("Hello", true)]
    [InlineData("àèì", true)]
    [InlineData("Hello1", false)]
    [InlineData("Hello World", false)]
    [InlineData("", false)]
    public void IsAlpha(string input, bool expected)
        => Assert.Equal(expected, input.IsAlpha());

    // IsAlphanumeric
    [Theory]
    [InlineData("Hello123", true)]
    [InlineData("ABC", true)]
    [InlineData("Hello 123", false)]
    [InlineData("Hello!", false)]
    [InlineData("", false)]
    public void IsAlphanumeric(string input, bool expected)
        => Assert.Equal(expected, input.IsAlphanumeric());

    // IsNullOrWhiteSpace
    [Theory]
    [InlineData("   ", true)]
    [InlineData("", true)]
    [InlineData(null, true)]
    [InlineData("Hi", false)]
    [InlineData(" x ", false)]
    public void IsNullOrWhiteSpace(string? input, bool expected)
        => Assert.Equal(expected, input?.IsNullOrWhiteSpace());

    // HasMinLength
    [Theory]
    [InlineData("Hello", 3, true)]
    [InlineData("Hello", 5, true)]
    [InlineData("Hi", 5, false)]
    public void HasMinLength(string input, int length, bool expected)
        => Assert.Equal(expected, input.HasMinLength(length));

    [Fact]
    public void HasMinLength_ZeroLength_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => "Hello".HasMinLength(0));

    // HasMaxLength
    [Theory]
    [InlineData("Hi", 5, true)]
    [InlineData("Hello", 5, true)]
    [InlineData("Hello World", 5, false)]
    public void HasMaxLength(string input, int length, bool expected)
        => Assert.Equal(expected, input.HasMaxLength(length));

    [Fact]
    public void HasMaxLength_ZeroLength_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => "Hello".HasMaxLength(0));
}
