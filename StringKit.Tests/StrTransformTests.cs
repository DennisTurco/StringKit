using System.Globalization;

namespace StringKit.Tests;

public class StrTransformTests
{
    [Theory]
    [InlineData("hello world", "hello-world")]
    [InlineData("Hello World", "hello-world")]
    [InlineData("HELLO WORLD", "hello-world")]
    [InlineData("hello", "hello")]
    [InlineData("hello-world", "hello-world")]
    [InlineData("", "")]
    [InlineData("a b c d e", "a-b-c-d-e")]
    [InlineData("hello  world", "hello-world")]
    [InlineData("  Hello World  ", "hello-world")]
    [InlineData("Hello, World!", "hello-world")]
    [InlineData("Café Menu", "cafe-menu")]
    public void ToSlug_ReturnsExpected(string input, string expected)
        => Assert.Equal(expected, input.ToSlug());

    [Fact]
    public void ToSlug_NoUppercaseInResult()
    {
        var result = "Hello Beautiful WORLD".ToSlug();
        Assert.Equal(result, result.ToLower());
    }

    [Fact]
    public void ToSlug_NoSpacesInResult()
    {
        var result = "hello beautiful world".ToSlug();
        Assert.DoesNotContain(" ", result);
    }

    [Theory]
    [InlineData("hello world", "hello-world")]
    [InlineData("Hello World", "hello-world")]
    [InlineData("hello", "hello")]
    [InlineData("hello-world", "hello-world")]
    [InlineData("", "")]
    [InlineData("hello  world", "hello-world")]
    [InlineData("helloWorld", "hello-world")]
    [InlineData("HelloWorld", "hello-world")]
    [InlineData("hello_world", "hello-world")]
    public void ToKebabCase_ReturnsExpected(string input, string expected)
        => Assert.Equal(expected, input.ToKebabCase());

    [Fact]
    public void ToKebabCase_NoUppercaseInResult()
    {
        var result = "Hello Beautiful WORLD".ToKebabCase();
        Assert.Equal(result, result.ToLower());
    }

    [Theory]
    [InlineData("hello world", "hello_world")]
    [InlineData("Hello World", "hello_world")]
    [InlineData("HELLO WORLD", "hello_world")]
    [InlineData("hello", "hello")]
    [InlineData("Hello", "hello")]
    [InlineData("hello_world", "hello_world")]
    [InlineData("hello  world", "hello__world")]
    [InlineData("", "")]
    [InlineData("a b c d e", "a_b_c_d_e")]
    [InlineData("Hello Beautiful World", "hello_beautiful_world")]
    public void ToSnakeCase_ReturnsExpected(string input, string expected)
        => Assert.Equal(expected, input.ToSnakeCase());

    [Theory]
    [InlineData("hello world", "helloWorld")]
    [InlineData("Hello World", "helloWorld")]
    [InlineData("HELLO WORLD", "helloWorld")]
    [InlineData("hello", "hello")]
    [InlineData("Hello", "hello")]
    [InlineData("hello beautiful world", "helloBeautifulWorld")]
    [InlineData("one two three four", "oneTwoThreeFour")]
    [InlineData("", "")]
    public void ToCamelCase_ReturnsExpected(string input, string expected)
        => Assert.Equal(expected, input.ToCamelCase());

    [Fact]
    public void ToCamelCase_FirstLetterIsAlwaysLowercase()
    {
        var result = "Any String".ToCamelCase();
        Assert.True(char.IsLower(result[0]), $"First char '{result[0]}' should be lowercase");
    }

    [Fact]
    public void ToCamelCase_NoSpacesInResult()
    {
        var result = "hello beautiful world".ToCamelCase();
        Assert.DoesNotContain(" ", result);
    }

    [Theory]
    [InlineData("hello world", "HelloWorld")]
    [InlineData("Hello World", "HelloWorld")]
    [InlineData("HELLO WORLD", "HelloWorld")]
    [InlineData("hello", "Hello")]
    [InlineData("Hello", "Hello")]
    [InlineData("hello beautiful world", "HelloBeautifulWorld")]
    [InlineData("one two three four", "OneTwoThreeFour")]
    public void ToPascalCase_ReturnsExpected(string input, string expected)
        => Assert.Equal(expected, input.ToPascalCase());

    [Fact]
    public void ToPascalCase_FirstLetterIsAlwaysUppercase()
    {
        var result = "any string".ToPascalCase();
        Assert.True(char.IsUpper(result[0]), $"First char '{result[0]}' should be uppercase");
    }

    [Fact]
    public void ToPascalCase_NoSpacesInResult()
    {
        var result = "hello beautiful world".ToPascalCase();
        Assert.DoesNotContain(" ", result);
    }

    [Fact]
    public void ToPascalCase_EachWordStartsWithUppercase()
    {
        var result = "hello beautiful world".ToPascalCase();
        // H-e-l-l-o-B-e-a-u-t-i-f-u-l-W-o-r-l-d
        Assert.True(char.IsUpper(result[0]));   // Hello
        Assert.True(char.IsUpper(result[5]));   // Beautiful
        Assert.True(char.IsUpper(result[14]));  // World
    }

    [Theory]
    [InlineData("hello world. hello again.", "hello world. Hello again.")]
    [InlineData("one. two. three.", "one. Two. Three.")]
    [InlineData("no sentence break", "no sentence break")]
    [InlineData("Hello World", "hello world")]
    [InlineData("a. b. c. d.", "a. B. C. D.")]
    [InlineData("", "")]
    public void ToSentenceCase_ReturnsExpected(string input, string expected)
        => Assert.Equal(expected, input.ToSentenceCase());

    [Fact]
    public void ToSentenceCase_OutputIsAllLowercaseWithoutPeriods()
    {
        var result = "HELLO WORLD GOODBYE".ToSentenceCase();
        Assert.Equal("hello world goodbye", result);
    }

    [Theory]
    [InlineData("Hello World", 4, "Hello W...")]
    [InlineData("Hello World", 1, "Hello Worl...")]
    [InlineData("Hello", 5, "...")]
    [InlineData("Hello", 2, "Hel...")]
    public void Truncate_ValidLength_ReturnsExpected(string input, int length, string expected)
        => Assert.Equal(expected, input.Truncate(length));


    [Theory]
    [InlineData("Hi", 10)]
    [InlineData("Hello", 6)]
    [InlineData("", 1)]
    public void Truncate_LengthExceedsStringLength_ThrowsStrTransformException(string input, int length)
        => Assert.Throws<ArgumentOutOfRangeException>(() => input.Truncate(length));

    [Theory]
    [InlineData("hello world", 5)]
    [InlineData("one", 2)]
    [InlineData("", 1)]
    public void TruncateWords_NExceedsWordCount_ThrowsStrTransformException(string input, int n)
        => Assert.Throws<ArgumentOutOfRangeException>(() => input.TruncateWords(n));

    [Theory]
    [InlineData("hello beautiful world", 2, "hello beautiful")]
    [InlineData("hello world foo", 2, "hello world")]
    [InlineData("one two three four", 3, "one two three")]
    public void TruncateWords_ValidN_ReturnsFirstNWords(string input, int n, string expected)
        => Assert.Equal(expected, input.TruncateWords(n));

    [Fact]
    public void TruncateWords_NEqualsWordCount_ReturnsEmptyString()
        => Assert.Equal(string.Empty, "hello world".TruncateWords(2));

    [Theory]
    [InlineData("ab", 1u, "ab")]
    [InlineData("ab", 2u, "abab")]
    [InlineData("ab", 3u, "ababab")]
    [InlineData("ab", 5u, "ababababab")]
    [InlineData("x", 4u, "xxxx")]
    [InlineData("", 5u, "")]
    public void Repeat_ReturnsExpected(string input, int n, string expected)
        => Assert.Equal(expected, input.Repeat(n));

    [Fact]
    public void Repeat_One_ReturnsSameString()
        => Assert.Equal("hello", "hello".Repeat(1));

    [Fact]
    public void Repeat_Zero_ReturnsEmptyString()
        => Assert.Equal(string.Empty, "ab".Repeat(0));

    [Fact]
    public void Repeat_ResultLengthIsMultipleOfOriginal()
    {
        var input = "abc";
        int n = 4;
        var result = input.Repeat(n);
        Assert.Equal(input.Length * n, result.Length);
    }

    [Theory]
    [InlineData("hello world", "dlrow olleh")]
    [InlineData("Hello", "olleH")]
    [InlineData("a", "a")]
    [InlineData("", "")]
    [InlineData("racecar", "racecar")]
    [InlineData("abcde", "edcba")]
    [InlineData("12345", "54321")]
    [InlineData("  ab  ", "  ba  ")]
    [InlineData("A", "A")]
    public void Reverse_ReturnsExpected(string input, string expected)
        => Assert.Equal(expected, input.Reverse());

    [Fact]
    public void Reverse_TwiceReturnsSameString()
    {
        var input = "Hello World";
        var result = input.Reverse().Reverse();
        Assert.Equal(input, result);
    }

    [Fact]
    public void Reverse_LengthIsPreserved()
    {
        var input = "Hello World";
        var result = input.Reverse();
        Assert.Equal(input.Length, result.Length);
    }

    [Theory]
    [InlineData("hello world", "Hello World")]
    [InlineData("Hello World", "Hello World")]
    [InlineData("HELLO WORLD", "Hello World")]
    [InlineData("hello", "Hello")]
    [InlineData("hello beautiful world", "Hello Beautiful World")]
    [InlineData("the quick brown fox", "The Quick Brown Fox")]
    [InlineData("", "")]
    [InlineData("a", "A")]
    [InlineData("a b c", "A B C")]
    public void ToTitleCase_InvariantCulture_ReturnsExpected(string input, string expected)
        => Assert.Equal(expected, input.ToTitleCase(CultureInfo.InvariantCulture));

    [Theory]
    [InlineData("ciao mondo", "Ciao Mondo")]
    [InlineData("buongiorno", "Buongiorno")]
    [InlineData("CIAO MONDO", "Ciao Mondo")]
    public void ToTitleCase_ItalianCulture_ReturnsExpected(string input, string expected)
        => Assert.Equal(expected, input.ToTitleCase(new CultureInfo("it-IT")));

    [Fact]
    public void ToTitleCase_TurkishCulture_CapitalizesIWithDot()
    {
        var result = "istanbul".ToTitleCase(new CultureInfo("tr-TR"));
        Assert.Equal("İstanbul", result);
    }

    [Fact]
    public void ToTitleCase_EnglishCulture_CapitalizesIWithoutDot()
    {
        var result = "istanbul".ToTitleCase(new CultureInfo("en-US"));
        Assert.Equal("Istanbul", result);
    }

    [Theory]
    [InlineData("hello world")]
    [InlineData("foo bar baz")]
    [InlineData("one two three")]
    public void ToTitleCase_FirstCharOfEachWord_IsUppercase(string input)
    {
        var result = input.ToTitleCase(CultureInfo.InvariantCulture);
        foreach (var word in result.Split(' '))
            Assert.True(char.IsUpper(word[0]),
                $"The first letter of '{word}' should be capitalized");
    }

    [Theory]
    [InlineData("HELLO WORLD")]
    [InlineData("FOO BAR")]
    public void ToTitleCase_AllCaps_DoesNotReturnAllCaps(string input)
    {
        var result = input.ToTitleCase(CultureInfo.InvariantCulture);
        Assert.NotEqual(input, result);
    }

    [Fact]
    public void ToTitleCase_PreservesSpaces()
    {
        var input = "hello world";
        var result = input.ToTitleCase(CultureInfo.InvariantCulture);
        Assert.Equal(input.Count(c => c == ' '), result.Count(c => c == ' '));
    }

    [Fact]
    public void ToTitleCase_PreservesWordCount()
    {
        var input = "hello beautiful world";
        var result = input.ToTitleCase(CultureInfo.InvariantCulture);
        Assert.Equal(input.Split(' ').Length, result.Split(' ').Length);
    }

    [Theory]
    [InlineData("it-IT", "è un bel giorno", "È Un Bel Giorno")]
    [InlineData("fr-FR", "à paris en été", "À Paris En Été")]
    public void ToTitleCase_AccentedChars_CapitalizedCorrectly(
        string culture, string input, string expected)
        => Assert.Equal(expected,
               input.ToTitleCase(new CultureInfo(culture)));

    [Fact]
    public void ToTitleCase_CurrentCulture_DoesNotThrow()
    {
        var ex = Record.Exception(() => "hello world".ToTitleCase(CultureInfo.CurrentCulture));
        Assert.Null(ex);
    }
}
