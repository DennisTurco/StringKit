namespace StringKit.Tests;

public class StrPrivacyTests
{
    // Redact
    [Fact]
    public void Redact_ReplacesCorrectRange()
        => Assert.Equal("H**** World", "Hello World".Redact(1, 5));

    [Fact]
    public void Redact_StartEqualsEnd_NoChange()
        => Assert.Equal("Hello", "Hello".Redact(1, 1));

    [Fact]
    public void Redact_EndGreaterOrEqualLength_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => "Hello".Redact(0, 5));

    [Fact]
    public void Redact_StartGreaterThanEnd_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => "Hello".Redact(3, 1));

    // MaskEmail
    [Fact]
    public void MaskEmail_MasksLocalPart()
        => Assert.Equal("m****@mail.it", "mario@mail.it".MaskEmail());

    [Fact]
    public void MaskEmail_SingleCharBeforeAt_NoMask()
        => Assert.Equal("m@mail.it", "m@mail.it".MaskEmail());

    [Fact]
    public void MaskEmail_PreservesDomainsWithSubdomain()
        => Assert.Equal("t***@sub.domain.com", "test@sub.domain.com".MaskEmail());

    // MaskPhone
    [Fact]
    public void MaskPhone_MasksMiddleDigits()
        => Assert.Equal("333*****67", "3331234567".MaskPhone());

    [Fact]
    public void MaskPhone_ShortPhone_Throws()
        => Assert.Throws<ArgumentOutOfRangeException>(() => "123".MaskPhone());
}
