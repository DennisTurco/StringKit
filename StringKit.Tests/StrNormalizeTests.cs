using StringKit;
using Xunit;

namespace StringKit.Tests;

public class StrNormalizeTests
{
    [Theory]
    [InlineData("ciao mondo", "ciao mondo")]
    [InlineData("  ciao mondo  ", "ciao mondo")]
    [InlineData("ciao   mondo", "ciao mondo")]
    [InlineData("  ciao    mondo  ", "ciao mondo")]
    [InlineData("a     b     c", "a b c")]
    public void NormalizeSpaces_Should_Remove_Extra_Spaces(string input, string expected)
    {
        var result = input.NormalizeSpaces();
        Assert.Equal(expected, result);
    }

    [Fact]
    public void NormalizeSpaces_Should_Return_Empty_When_Input_Is_Empty()
    {
        var input = string.Empty;
        var result = input.NormalizeSpaces();
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void NormalizeSpaces_Should_Return_Single_Word_Unchanged()
    {
        var input = "hello";
        var result = input.NormalizeSpaces();
        Assert.Equal("hello", result);
    }

    [Fact]
    public void RemoveDiacritics_Should_Remove_Accents()
    {
        var input = "àèìòù";
        var result = input.RemoveDiacritics();
        Assert.Equal("aeiou", result);
    }

    [Fact]
    public void RemoveSpecialChars_Should_Remove_Non_Alphanumeric_Characters()
    {
        var input = "Hello! @#$%";
        var result = input.RemoveSpecialChars();
        Assert.Equal("Hello", result);
    }

    [Fact]
    public void NormalizeNewLines_Should_Normalize_Line_Endings_To_Lf()
    {
        var input = "line1\r\nline2\nline3";
        var result = input.NormalizeNewLines();
        Assert.Equal("line1\nline2\nline3", result);
    }

    [Fact]
    public void NormalizeNewLines_Should_Convert_Lone_Cr_To_Lf()
    {
        var input = "line1\rline2";
        var result = input.NormalizeNewLines();
        Assert.Equal("line1\nline2", result);
    }

    [Fact]
    public void StripHtml_Should_Remove_Html_Tags()
    {
        var input = "<p>Hello <b>World</b></p>";
        var result = input.StripHtml();
        Assert.Equal("Hello World", result);
    }

    [Fact]
    public void StripHtml_Should_Preserve_Plain_Text_Containing_Angle_Brackets()
    {
        var input = "1 < 2 and 3 > 4";
        var result = input.StripHtml();
        Assert.Equal("1 < 2 and 3 > 4", result);
    }

    [Fact]
    public void CollapseWhitespace_Should_Collapse_All_Whitespace_To_Single_Space()
    {
        var input = "Hello   World\t\tTest";
        var result = input.CollapseWhitespace();
        Assert.Equal("Hello World Test", result);
    }
}
