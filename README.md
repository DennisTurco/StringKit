<p align="center">
  <img src="assets/icon.svg" alt="StringKit icon" width="96" />
</p>

# StringKit

**FULL DOCUMENTATION**: [https://dennisturco.github.io/StringKit/](https://dennisturco.github.io/StringKit/)

A lightweight .NET library of extension methods for common string transformations and formatting.

![Build](https://github.com/DennisTurco/StringKit/actions/workflows/build.yml/badge.svg)
![Coverage](https://codecov.io/gh/DennisTurco/StringKit/graph/badge.svg)
![Downloads](https://img.shields.io/nuget/dt/StringKit)
[![NuGet](https://img.shields.io/nuget/v/StringKit.svg)](https://www.nuget.org/packages/StringKit)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Installation

```bash
dotnet add package StringKit
```

## Features

- **Case conversion**: `ToSlug`, `ToSnakeCase`, `ToCamelCase`, `ToPascalCase`, `ToTitleCase`, `ToSentenceCase`
- **Truncation**: `Truncate` (by characters) and `TruncateWords` (by word count)
- **Normalization**: `NormalizeSpaces`, `RemoveDiacritics`, `RemoveSpecialChars`, `NormalizeNewLines`, `StripHtml`, `CollapseWhitespace`, `JoinLines`
- **Privacy / PII masking**: `Redact`, `MaskEmail`, `MaskPhone`
- **Search & comparison**: `ContainsAny`, `ContainsAll`, `StartsWithAny`, `EndsWithAny`, `EqualsIgnoreCase`
- **Validation**: `IsEmail`, `IsUrl`, `IsNumeric`, `IsAlpha`, `IsAlphanumeric`, `IsNullOrWhiteSpace`, `HasMinLength`, `HasMaxLength`
- **Encoding / decoding**: `ToBase64`, `FromBase64`, `UrlEncode`, `UrlDecode`, `HtmlEncode`, `HtmlDecode`
- **Utilities**: `Repeat`, `Reverse`
- Zero external dependencies: pure .NET BCL
- All methods are static and thread-safe

## Usage

```csharp
using StringKit;

// Case conversion & truncation
"hello world".ToSlug()                              // "hello-world"
"hello world".ToCamelCase()                         // "helloWorld"
"hello world".ToPascalCase()                        // "HelloWorld"
"hello world".ToSnakeCase()                         // "hello_world"
"hello world".ToTitleCase(new CultureInfo("en-US")) // "Hello World"
"Hello World".Truncate(6)                           // "Hello..."
"ab".Repeat(3)                                      // "ababab"
"hello".Reverse()                                   // "olleh"

// Normalization
"  ciao    mondo  ".NormalizeSpaces()      // "ciao mondo"
"café".RemoveDiacritics()                  // "cafe"
"Hello! @#$%".RemoveSpecialChars()         // "Hello"
"<p>Hello <b>World</b></p>".StripHtml()    // "Hello World"

// Privacy / PII masking
"mario@mail.it".MaskEmail()   // "m****@mail.it"
"3331234567".MaskPhone()      // "333*****67"

// Search & comparison
"Hello World".ContainsAny("World", "Foo")  // true
"Hello".EqualsIgnoreCase("hello")          // true

// Validation
"mario@mail.it".IsEmail()     // true
"12345".IsNumeric()           // true
"Hello".HasMinLength(3)       // true

// Encoding / decoding
"Hello".ToBase64()            // "SGVsbG8="
"hello world".UrlEncode()     // "hello+world"
"<b>Hi</b>".HtmlEncode()      // "&lt;b&gt;Hi&lt;/b&gt;"
```

## Contributing

Contributions are welcome! Please open an issue or pull request on GitHub.

See [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

## License

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
