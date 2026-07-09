---
title: Introduction
---

# Introduction

**StringKit** is a lightweight, open-source .NET library that provides a collection of extension methods for common string transformations and formatting operations.

## What is StringKit?

StringKit extends the built-in `System.String` type with fluent extension methods — so you can perform everyday string manipulation without writing boilerplate code.

```csharp
// Case conversion & text transforms (StrTransform)
"hello world".ToSlug()                              // "hello-world"
"hello world".ToCamelCase()                         // "helloWorld"
"hello world".ToPascalCase()                        // "HelloWorld"
"hello world".ToSnakeCase()                         // "hello_world"
"hello world".ToTitleCase(new CultureInfo("en-US")) // "Hello World"
"hello world. bye world".ToSentenceCase()           // "Hello world. Bye world"
"Hello World".Truncate(5)                           // "Hello W..."
"ab".Repeat(3)                                      // "ababab"
"hello".Reverse()                                   // "olleh"

// Privacy / PII masking (StrPrivacy)
"mario@mail.it".MaskEmail()   // "m****@mail.it"
"3331234567".MaskPhone()       // "333*****67"

// Search & comparison (StrResearch)
"Hello World".ContainsAny("World", "Foo")  // true
"Hello".EqualsIgnoreCase("hello")          // true

// Validation (StrValidation)
"mario@mail.it".IsEmail()     // true
"12345".IsNumeric()           // true
"Hello".HasMinLength(3)       // true

// Encoding / decoding (StrEncodeDecode)
"Hello".ToBase64()            // "SGVsbG8="
"SGVsbG8=".FromBase64()       // "Hello"
"hello world".UrlEncode()     // "hello+world"
"<b>Hi</b>".HtmlEncode()      // "&lt;b&gt;Hi&lt;/b&gt;"

// Normalization (StrNormalize)
"  ciao    mondo  ".NormalizeSpaces()             // "ciao mondo"
"café".RemoveDiacritics()                         // "cafe"
"Hello! @#$%".RemoveSpecialChars()                // "Hello"
"<p>Hello <b>World</b></p>".StripHtml()           // "Hello World"
```

## Design Goals

- **Zero dependencies** — relies only on the .NET Base Class Library; no third-party packages are required.
- **Thread-safe** — all methods are `static` and stateless; safe to call from multiple threads simultaneously.
- **No I/O** — all transformations run entirely in memory; no network calls, no file access.
- **Clean API** — extension methods on `string` that read like natural language.

## Supported Platforms

StringKit targets **net9.0**.

## License

StringKit is released under the [MIT License](https://opensource.org/licenses/MIT).
