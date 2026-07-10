---
_layout: landing
landingData:
  heroSection:
    name: StringKit
    tagline: Full string util for .NET
    image: images/icon.svg
    features:
      - name: Zero Dependencies
        icon: fa-feather
        description: No external packages at runtime. .NET 9, NativeAOT-friendly, runs fully offline.
        url: docs/introduction.md
      - name: Coverage
        icon: fa-circle-check
        description: 191 tests covering case conversion, normalization, privacy, search, validation, and encoding.
        url: coverage-report.md
      - name: Open Source
        icon: fa-code-branch
        description: MIT-licensed. Contributions welcome: check the contributing guide to get started.
        url: docs/contributing.md
---

# StringKit

A lightweight .NET library of extension methods for common string transformations and formatting.

[![NuGet](https://img.shields.io/nuget/v/StringKit.svg)](https://www.nuget.org/packages/StringKit)
[![NuGet Downloads](https://img.shields.io/nuget/dt/StringKit.svg)](https://www.nuget.org/packages/StringKit)
[![CI](https://github.com/DennisTurco/StringKit/actions/workflows/ci.yml/badge.svg)](https://github.com/DennisTurco/StringKit/actions/workflows/ci.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![GitHub Stars](https://img.shields.io/github/stars/DennisTurco/StringKit?style=social)](https://github.com/DennisTurco/StringKit/stargazers)

## 1. Quick Start

Install via NuGet:

```bash
dotnet add package StringKit
```

```csharp
using StringKit;
```

## 2. Features

- **Case conversion & truncation**: `ToSlug`, `ToCamelCase`, `ToPascalCase`, `ToSnakeCase`, `ToTitleCase`, `ToSentenceCase`, `Truncate`, `Repeat`, `Reverse`
- **Normalization**: `NormalizeSpaces`, `RemoveDiacritics`, `RemoveSpecialChars`, `NormalizeNewLines`, `StripHtml`, `CollapseWhitespace`, `JoinLines`
- **Privacy / PII masking**: `Redact`, `MaskEmail`, `MaskPhone`
- **Search & comparison**: `ContainsAny`, `ContainsAll`, `StartsWithAny`, `EndsWithAny`, `EqualsIgnoreCase`
- **Validation**: `IsEmail`, `IsUrl`, `IsNumeric`, `IsAlpha`, `IsAlphanumeric`, `IsNullOrWhiteSpace`, `HasMinLength`, `HasMaxLength`
- **Encoding / decoding**: `ToBase64`, `FromBase64`, `UrlEncode`, `UrlDecode`, `HtmlEncode`, `HtmlDecode`

## 3. [📖 Read the documentation $\rightarrow$](docs/introduction.md)
