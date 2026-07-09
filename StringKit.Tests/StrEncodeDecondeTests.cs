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
    public void UrlDecode_UrlEncodedString_ReturnsDecoded()
    {
        var input = "hello+world";
        var result = input.UrlDecode();
        Assert.Equal("hello world", result);
    }

    [Fact]
    public void UrlDecode_PercentEncodedString_ReturnsDecoded()
    {
        var input = "foo%3dbar%26baz%3dqux";
        var result = input.UrlDecode();
        Assert.Equal("foo=bar&baz=qux", result);
    }

    [Fact]
    public void UrlDecode_EmptyString_ReturnsEmptyString()
    {
        var input = string.Empty;
        var result = input.UrlDecode();
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void UrlEncode_ThenUrlDecode_RoundTrip_ReturnsOriginal()
    {
        var original = "test string with spaces & special=chars!";
        var result = original.UrlEncode().UrlDecode();
        Assert.Equal(original, result);
    }

    [Fact]
    public void HtmlEncode_StringWithTags_ReturnsEncoded()
    {
        var input = "<b>Hello</b>";
        var result = input.HtmlEncode();
        Assert.Equal("&lt;b&gt;Hello&lt;/b&gt;", result);
    }

    [Fact]
    public void HtmlEncode_StringWithAmpersand_ReturnsEncoded()
    {
        var input = "foo & bar";
        var result = input.HtmlEncode();
        Assert.Equal("foo &amp; bar", result);
    }

    [Fact]
    public void HtmlEncode_EmptyString_ReturnsEmptyString()
    {
        var input = string.Empty;
        var result = input.HtmlEncode();
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void HtmlDecode_HtmlEncodedString_ReturnsDecoded()
    {
        var input = "&lt;b&gt;Hello&lt;/b&gt;";
        var result = input.HtmlDecode();
        Assert.Equal("<b>Hello</b>", result);
    }

    [Fact]
    public void HtmlDecode_EmptyString_ReturnsEmptyString()
    {
        var input = string.Empty;
        var result = input.HtmlDecode();
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void HtmlEncode_ThenHtmlDecode_RoundTrip_ReturnsOriginal()
    {
        var original = "<div class=\"test\">Tom & Jerry's \"show\"</div>";
        var result = original.HtmlEncode().HtmlDecode();
        Assert.Equal(original, result);
    }
}
