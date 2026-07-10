---
title: Roadmap
---

# Roadmap

This page tracks planned features and improvements for StringKit.
For the full list of open issues and discussions, see the [GitHub Issues](https://github.com/DennisTurco/StringKit/issues) page.

## 1. Normalization / Cleanup (`StrNormalize`)

| Feature | Status | Notes |
|---|---|---|
| `NormalizeSpaces()` | ✅ Done (1.0.0) | |
| `RemoveDiacritics()` | ✅ Done (1.0.0) | |
| `RemoveSpecialChars()` | ✅ Done (1.0.0) | |
| `NormalizeNewLines()` | ✅ Done (1.0.0) | |
| `StripHtml()` | ✅ Done (1.0.0) | |
| `CollapseWhitespace()` | ✅ Done (1.0.0) | |
| `StripEmoji()` | 🔜 Planned | Post-1.0.0 |
| `RemoveControlChars()` | 🔜 Planned | Strips non-printable control characters; complements `RemoveSpecialChars()` |
| `NormalizeUnicode(NormalizationForm)` | 🔜 Planned | Exposes NFC/NFD/NFKC/NFKD normalization directly (`RemoveDiacritics` already does NFD internally) |

## 2. Transformation / Formatting (`StrTransform`)

| Feature | Status | Notes |
|---|---|---|
| `ToSlug()` | ✅ Done (1.0.0) | |
| `ToCamelCase()` | ✅ Done (1.0.0) | |
| `ToPascalCase()` | ✅ Done (1.0.0) | |
| `ToSnakeCase()` | ✅ Done (1.0.0) | |
| `ToKebabCase()` | ✅ Done (1.0.0) | |
| `ToTitleCase(locale)` | ✅ Done (1.0.0) | |
| `ToSentenceCase()` | ✅ Done (1.0.0) | |
| `Truncate(length, suffix)` | ✅ Done (1.0.0) | |
| `TruncateWords(n)` | ✅ Done (1.0.0) | |
| `Wrap(prefix, suffix)` | 🔜 Planned | Post-1.0.0 |
| `Repeat(n)` | ✅ Done (1.0.0) | |
| `Reverse()` | ✅ Done (1.0.0) | |
| `Capitalize()` | 🔜 Planned | Uppercases only the first character, leaving the rest untouched — distinct from `ToTitleCase`, which is per-word and culture-aware |
| `ToggleCase()` | 🔜 Planned | Swaps upper/lower per character: "Hello" → "hELLO" |
| `PadCenter(width, char)` | 🔜 Planned | Centers a string within a fixed width |
| `Chunk(size)` | 🔜 Planned | Splits a string into fixed-size chunks |

## 3. Masking / Privacy (`StrPrivacy`)

| Feature | Status | Notes |
|---|---|---|
| `Redact(start, end)` | ✅ Done (1.0.0) | |
| `MaskEmail()` | ✅ Done (1.0.0) | |
| `MaskPhone()` | ✅ Done (1.0.0) | |
| `MaskCreditCard()` | 🔜 Planned | Post-1.0.0 |
| `MaskFiscalCode()` | 🔜 Planned | Post-1.0.0 |
| `MaskIban()` | 🔜 Planned | Natural sibling to `MaskFiscalCode()` given the library's Italian/EU banking-adjacent PII coverage |
| `MaskIpAddress()` | 🔜 Planned | e.g. "192.168.1.1" → "192.168.*.*" |

## 4. Validation (`StrValidation`)

| Feature | Status | Notes |
|---|---|---|
| `IsEmail()` | ✅ Done (1.0.0) | |
| `IsUrl()` | ✅ Done (1.0.0) | |
| `IsNumeric()` | ✅ Done (1.0.0) | |
| `IsAlpha()` | ✅ Done (1.0.0) | |
| `IsAlphanumeric()` | ✅ Done (1.0.0) | |
| `IsNullOrWhiteSpace()` | ✅ Done (1.0.0) | |
| `HasMinLength(n)` / `HasMaxLength(n)` | ✅ Done (1.0.0) | |
| `IsJson()` | 🔜 Planned | Post-1.0.0 |
| `IsPalindrome()` | 🔜 Planned | Checks if a string reads the same forwards/backwards, ignoring case and spaces |
| `IsGuid()` | 🔜 Planned | Validates GUID/UUID format |
| `IsHexColor()` | 🔜 Planned | Validates hex color codes (`#fff`, `#ffffff`) |

## 5. Extraction / Analysis (`StrResearch` / new)

| Feature | Status | Notes |
|---|---|---|
| `ExtractEmails()` | 🔜 Planned | Post-1.0.0 |
| `ExtractUrls()` | 🔜 Planned | Post-1.0.0 |
| `ExtractNumbers()` | 🔜 Planned | Post-1.0.0 |
| `ExtractHashtags()` | 🔜 Planned | Post-1.0.0 |
| `WordCount()` | 🔜 Planned | Post-1.0.0 |
| `CharCount(excludeSpaces)` | 🔜 Planned | Post-1.0.0 |
| `Similarity(other)` | 🔜 Planned | Normalized Levenshtein distance (0.0–1.0) |

## 6. Search / Comparison (`StrResearch`)

| Feature | Status | Notes |
|---|---|---|
| `ContainsAny(params)` | ✅ Done (1.0.0) | |
| `ContainsAll(params)` | ✅ Done (1.0.0) | |
| `StartsWithAny(params)` / `EndsWithAny(params)` | ✅ Done (1.0.0) | |
| `EqualsIgnoreCase(other)` | ✅ Done (1.0.0) | |
| `FuzzyMatch(other, threshold)` | 🔜 Planned | Post-1.0.0 |
| `IndexOfIgnoreCase(substring)` | 🔜 Planned | Case-insensitive `IndexOf`, natural complement to `EqualsIgnoreCase`/`ContainsAny` |
| `LevenshteinDistance(other)` | 🔜 Planned | Raw edit distance (`int`), complementing the already-planned normalized `Similarity(other)` |

## 7. Encoding / Hashing (`StrEncodeDecode`)

| Feature | Status | Notes |
|---|---|---|
| `ToBase64()` / `FromBase64()` | ✅ Done (1.0.0) | |
| `UrlEncode()` / `UrlDecode()` | ✅ Done (1.0.0) | |
| `HtmlEncode()` / `HtmlDecode()` | ✅ Done (1.0.0) | |
| `ToMd5()` | 🔜 Planned | Post-1.0.0 |
| `ToSha256()` | 🔜 Planned | Post-1.0.0 |
| `ToHex()` / `FromHex()` | 🔜 Planned | Hex encoding, natural sibling of Base64/URL/HTML encoding |
| `ToRot13()` | 🔜 Planned | Simple reversible cipher, common in string-utility libraries, no external dependencies |

## 8. Generation

| Feature | Status | Notes |
|---|---|---|
| `GenerateRandomName(...)` | 🔜 Planned | Post-1.0.0 |
| `GenerateRandomString(length, charset)` | 🔜 Planned | More general-purpose than `GenerateRandomName` — useful for tokens/passwords |

## 9. Released

See the [Changelog](../CHANGELOG.md) for what has already shipped.

## 10. Suggest a Feature

Open a [GitHub Issue](https://github.com/DennisTurco/StringKit/issues/new) to propose new features or report bugs.
