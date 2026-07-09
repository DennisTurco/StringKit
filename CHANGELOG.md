# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

#### `StrEncodeDecode` — new class

- `ToBase64(string)` — encodes a plain-text string to its Base64 representation using UTF-8 encoding
- `FromBase64(string)` — decodes a Base64-encoded string back to its original UTF-8 plain-text
- `UrlEncode(string)` — encodes a string for safe inclusion in a URL (percent-encodes special characters)
- `UrlDecode(string)` — decodes a URL-encoded string back to its original characters

#### `StrResearch` — new class

- `ContainsAny(string, params string[])` — returns `true` if the string contains at least one of the given substrings
- `ContainsAll(string, params string[])` — returns `true` if the string contains all of the given substrings
- `StartsWithAny(string, params string[])` — returns `true` if the string starts with at least one of the given prefixes
- `EndsWithAny(string, params string[])` — returns `true` if the string ends with at least one of the given suffixes
- `EqualsIgnoreCase(string, string)` — returns `true` if two strings are equal ignoring case

#### `StrValidation` — new class

- `IsEmail(string)` — validates that a string is a well-formed email address
- `IsUrl(string)` — validates that a string is an absolute HTTP/HTTPS URL
- `IsNumeric(string)` — returns `true` if the string contains only digit characters
- `IsAlpha(string)` — returns `true` if the string contains only alphabetic characters
- `IsAlphanumeric(string)` — returns `true` if the string contains only letters and digits
- `IsNullOrWhiteSpace(string)` — returns `true` if the string is `null`, empty, or whitespace-only
- `HasMinLength(string, int)` — returns `true` if the string length is ≥ the specified minimum
- `HasMaxLength(string, int)` — returns `true` if the string length is ≤ the specified maximum

#### `StrPrivacy` — new class

- `Redact(string, int, int)` — replaces characters in the specified index range with asterisks
- `MaskEmail(string)` — masks an email address, hiding all characters between the first character and the `@` symbol
- `MaskPhone(string)` — masks a phone number, hiding characters from index 3 to 8

#### Documentation

- Full [DocFX](https://dotnet.github.io/docfx/) documentation site published to GitHub Pages
- API reference generated from XML doc comments (zero CS1591 warnings)

#### Project

- `README.md` — filled in the library description, feature list, and usage examples; fixed the Contributing section (previously contained placeholder copy from another project)
- `assets/icon.svg` — replaced the placeholder "CF" icon (repurposed from another project) with a proper StringKit icon: dark purple/indigo gradient, `"SK"` monogram, decorative curly quotation marks, and a violet accent bar
- `.github/FUNDING.yml` — fixed GitHub Sponsors button format (`github: ["DennisTurco"]` → `github: DennisTurco`); the sponsor button now renders correctly on the repository page

### Notes

- All public methods are **static** and **thread-safe**
- No HTTP calls, no external services — all transformations run locally in-process
- Targets **.NET 9.0**

[Unreleased]: https://github.com/DennisTurco/StringKit/compare/v1.0.0...HEAD
[1.0.0]: https://github.com/DennisTurco/StringKit/releases/tag/v1.0.0
