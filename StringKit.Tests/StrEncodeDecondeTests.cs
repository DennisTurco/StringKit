namespace StringKit.Tests;

public class StrEncodeDecodeTests
{
    [Fact]
    public void ToBase64_SimpleString_ReturnsBase64Encoded()
    {
        var input = "Hello, World!";
        var result = input.ToBase64();
        Assert.Equal("SGVsbG8sIFdvcmxkIQ==", result);
    }

    [Fact]
    public void ToBase64_EmptyString_ReturnsEmptyBase64()
    {
        var input = string.Empty;
        var result = input.ToBase64();
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void ToBase64_UnicodeString_ReturnsCorrectBase64()
    {
        var input = "ciao è à ù";
        var result = input.ToBase64();
        Assert.Equal(Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(input)), result);
    }

    [Fact]
    public void FromBase64_ValidBase64_ReturnsOriginalString()
    {
        var input = "SGVsbG8sIFdvcmxkIQ==";
        var result = input.FromBase64();
        Assert.Equal("Hello, World!", result);
    }

    [Fact]
    public void FromBase64_EmptyString_ReturnsEmptyString()
    {
        var input = string.Empty;
        var result = input.FromBase64();
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void FromBase64_InvalidBase64_ThrowsFormatException()
    {
        var input = "not_valid_base64!!!";
        Assert.Throws<FormatException>(() => input.FromBase64());
    }

    [Fact]
    public void ToBase64_ThenFromBase64_RoundTrip_ReturnsOriginal()
    {
        var original = "Round-trip test string 123!@#";
        var result = original.ToBase64().FromBase64();
        Assert.Equal(original, result);
    }

    [Fact]
    public void UrlEncode_StringWithSpaces_ReturnsEncoded()
    {
        var input = "hello world";
        var result = input.UrlEncode();
        Assert.Equal("hello+world", result);
    }

    [Fact]
    public void UrlEncode_StringWithSpecialChars_ReturnsEncoded()
    {
        var input = "foo=bar&baz=qux";
        var result = input.UrlEncode();
        Assert.Equal("foo%3dbar%26baz%3dqux", result);
    }

    [Fact]
    public void UrlEncode_EmptyString_ReturnsEmptyString()
    {
        var input = string.Empty;
        var result = input.UrlEncode();
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void HtmlDecode_UrlEncodedString_ReturnsDecoded()
    {
        var input = "hello+world";
        var result = input.HtmlDecode();
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void HtmlDecode_PercentEncodedString_ReturnsDecoded()
    {
        var input = "foo%3dbar%26baz%3dqux";
        var result = input.HtmlDecode();
        Assert.Equal("foo=bar&baz=qux", result);
    }

    [Fact]
    public void HtmlDecode_EmptyString_ReturnsEmptyString()
    {
        var input = string.Empty;
        var result = input.HtmlDecode();
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void UrlEncode_ThenHtmlDecode_RoundTrip_ReturnsOriginal()
    {
        var original = "test string with spaces & special=chars!";
        var result = original.UrlEncode().HtmlDecode();
        Assert.Equal(original, result);
    }
}
