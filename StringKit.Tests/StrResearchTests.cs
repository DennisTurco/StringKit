namespace StringKit.Tests;

public class StrResearchTests
{
    [Fact]
    public void ContainsAny_OneMatch_ReturnsTrue()
        => Assert.True("Hello World".ContainsAny("World", "Foo"));

    [Fact]
    public void ContainsAny_NoMatch_ReturnsFalse()
        => Assert.False("Hello World".ContainsAny("Foo", "Bar"));

    [Fact]
    public void ContainsAny_AllMatch_ReturnsTrue()
        => Assert.True("Hello World".ContainsAny("Hello", "World"));

    // ContainsAll
    [Fact]
    public void ContainsAll_AllMatch_ReturnsTrue()
        => Assert.True("Hello World".ContainsAll("Hello", "World"));

    [Fact]
    public void ContainsAll_OneMissing_ReturnsFalse()
        => Assert.False("Hello World".ContainsAll("Hello", "Foo"));

    [Fact]
    public void ContainsAll_NoMatch_ReturnsFalse()
        => Assert.False("Hello World".ContainsAll("Foo", "Bar"));

    [Fact]
    public void StartsWithAny_OneMatch_ReturnsTrue()
        => Assert.True("Hello World".StartsWithAny("Hello", "Foo"));

    [Fact]
    public void StartsWithAny_NoMatch_ReturnsFalse()
        => Assert.False("Hello World".StartsWithAny("Foo", "Bar"));

    [Fact]
    public void StartsWithAny_NoMatch_CaseSensitive()
        => Assert.False("Hello World".StartsWithAny("hello", "foo"));

    [Fact]
    public void EndsWithAny_OneMatch_ReturnsTrue()
        => Assert.True("Hello World".EndsWithAny("World", "Foo"));

    [Fact]
    public void EndsWithAny_NoMatch_ReturnsFalse()
        => Assert.False("Hello World".EndsWithAny("Foo", "Bar"));

    [Fact]
    public void EndsWithAny_NoMatch_CaseSensitive()
        => Assert.False("Hello World".EndsWithAny("world", "foo"));

    [Fact]
    public void EqualsIgnoreCase_SameCase_ReturnsTrue()
        => Assert.True("Hello".EqualsIgnoreCase("Hello"));

    [Fact]
    public void EqualsIgnoreCase_DifferentCase_ReturnsTrue()
        => Assert.True("Hello".EqualsIgnoreCase("hello"));

    [Fact]
    public void EqualsIgnoreCase_DifferentString_ReturnsFalse()
        => Assert.False("Hello".EqualsIgnoreCase("World"));

    [Fact]
    public void EqualsIgnoreCase_TurkishCulture_IsCultureIndependent()
    {
        // "Case-insensitive" must not depend on CurrentCulture. Under tr-TR, "I".ToLower()
        // produces the dotless "ı", not "i": so an implementation using culture-sensitive
        // ToLower() (instead of an ordinal/invariant comparison) breaks for plain ASCII "I".
        var original = System.Threading.Thread.CurrentThread.CurrentCulture;
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            Assert.True("I".EqualsIgnoreCase("i"));
        }
        finally
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = original;
        }
    }
}
