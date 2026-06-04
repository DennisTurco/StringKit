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
        description: 167 tests covering validation, parsing, generation, IBAN, VAT and municipalities.
        url: coverage-report.md
      - name: Open Source
        icon: fa-code-branch
        description: MIT-licensed. Contributions welcome — check the contributing guide to get started.
        url: docs/contributing.md
---

# StringKit

A lightweight .NET library for Italian fiscal compliance: validate, parse and generate **Fiscal Code**, validate **Partita IVA** and **IBAN**, and query a built-in database of Italian municipalities and foreign countries (Belfiore codes). Everything runs locally, no HTTP calls, no data leaves your app.

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

// Validate
bool valid = FiscalCodeValidator.IsValid("RSSMRA85T10A562S"); // true

// Parse
FiscalCodeData data = FiscalCodeParser.Parse("RSSMRA85T10A562S");
Console.WriteLine(data.Gender);       // Male
Console.WriteLine(data.DateOfBirth);  // 10/12/1985
Console.WriteLine(data.BelfioreCode); // A562
```

## 2. Features

- ✅ Fiscal Code **validation** (format, date, Belfiore code, check digit)
- ✅ Fiscal Code **parsing** (extract gender, date of birth, municipality)
- ✅ **Foreign-born** support (Z-codes for 261 countries including historical ones)
- ✅ IBAN **validation**
- ✅ Partita IVA **validation**
- ✅ Zero external dependencies at runtime
- ✅ .NET 9 / NativeAOT friendly

## 3. [📖 Read the documentation →](docs/introduction.md)
