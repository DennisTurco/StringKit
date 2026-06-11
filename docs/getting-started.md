# Getting Started

## 1. Installation

Install StringKit via the .NET CLI:

```bash
dotnet add package StringKit
```

Or via the NuGet Package Manager console in Visual Studio:

```powershell
Install-Package StringKit
```

Or search for **StringKit** in the NuGet Package Manager UI inside Visual Studio.

## 2. Add the Namespace

Add the following `using` directive to your file:

```csharp
using StringKit;
```

> All StringKit methods are extension methods on `System.String`.
> Once the namespace is imported, they appear on every `string` instance — no class instantiation is needed.

## 3. Quick Examples

### Case Conversion

```csharp
using System.Globalization;
using StringKit;

"hello world".ToSlug();                              // "hello-world"
"hello world".ToSnakeCase();                         // "hello_world"
"hello world".ToCamelCase();                         // "helloWorld"
"hello world".ToPascalCase();                        // "HelloWorld"
"hello world".ToTitleCase(new CultureInfo("en-US")); // "Hello World"
"hello world. bye world".ToSentenceCase();           // "Hello world. Bye world"
```

### Truncation

```csharp
"Hello World".Truncate(4);              // "Hello W..."
"Hello World".Truncate(4, "…");         // "Hello W…"
"hello beautiful world".TruncateWords(2); // "hello beautiful"
```

### Other Utilities

```csharp
"ab".Repeat(3);    // "ababab"
"hello".Reverse(); // "olleh"
```

### Privacy & PII Masking

```csharp
"mario@mail.it".MaskEmail();   // "m****@mail.it"
"3331234567".MaskPhone();       // "333*****67"
"Hello World".Redact(1, 5);    // "H**** World"
```

### Search & Comparison

```csharp
"Hello World".ContainsAny("World", "Foo");   // true
"Hello World".ContainsAll("Hello", "World"); // true
"Hello World".StartsWithAny("Hello", "Hi");  // true
"Hello World".EndsWithAny("World", "Earth"); // true
"Hello".EqualsIgnoreCase("hello");           // true
```

### Validation

```csharp
"mario@mail.it".IsEmail();    // true
"https://example.com".IsUrl(); // true
"12345".IsNumeric();          // true
"Hello".IsAlpha();            // true
"Hello123".IsAlphanumeric();  // true
"   ".IsNullOrWhiteSpace();   // true
"Hello".HasMinLength(3);      // true
"Hi".HasMaxLength(5);         // true
```

### Encoding & Decoding

```csharp
"Hello".ToBase64();             // "SGVsbG8="
"SGVsbG8=".FromBase64();        // "Hello"
"hello world".UrlEncode();      // "hello+world"
"hello+world".HtmlDecode();     // "hello world"
```

## 4. Next Steps

- Read the full [API Reference](api-reference.md) for all methods, signatures, and edge-case behaviour.
- Check the [Roadmap](roadmap.md) for upcoming features.
- Contribute or report issues on [GitHub](https://github.com/DennisTurco/StringKit).

