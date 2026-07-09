---
title: API Reference
---

# API Reference

All methods live in the `StringKit` namespace and are extension methods on `System.String`.

The library is organised into the following static classes:

| Class | Purpose |
|-------|---------|
| `StrTransform` | Case conversion, truncation, and other text transformations |
| `StrPrivacy` | Masking and redacting sensitive data (PII) |
| `StrResearch` | Searching and comparing strings |
| `StrValidation` | Validating string formats |
| `StrEncodeDecode` | Encoding and decoding strings (Base64, URL, HTML) |
| `StrNormalize` | Cleaning and normalizing string content (whitespace, diacritics, HTML, line endings) |

---

## Case Conversion

### `ToSlug`

Converts a string to slug format: lowercases the text and replaces every space with a hyphen.

```csharp
public static string ToSlug(this string value)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to convert. |

**Returns** `string` — the slug-formatted string.

**Examples**

```csharp
"Hello World".ToSlug()       // "hello-world"
"HELLO WORLD".ToSlug()       // "hello-world"
"hello".ToSlug()             // "hello"
"hello  world".ToSlug()      // "hello--world"
```

> **Note:** Multiple consecutive spaces produce multiple consecutive hyphens.

---

### `ToSnakeCase`

Converts a string to snake_case: lowercases the text and replaces every space with an underscore.

```csharp
public static string ToSnakeCase(this string value)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to convert. |

**Returns** `string` — the snake_case-formatted string.

**Examples**

```csharp
"Hello World".ToSnakeCase()   // "hello_world"
"HELLO WORLD".ToSnakeCase()   // "hello_world"
"hello".ToSnakeCase()         // "hello"
"hello  world".ToSnakeCase()  // "hello__world"
```

---

### `ToCamelCase`

Converts a string to camelCase: the first word is fully lowercase and each subsequent word starts with an uppercase letter. All spaces are removed.

```csharp
public static string ToCamelCase(this string value)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to convert. |

**Returns** `string` — the camelCase-formatted string.

**Examples**

```csharp
"hello world".ToCamelCase()         // "helloWorld"
"Hello World".ToCamelCase()         // "helloWorld"
"HELLO WORLD".ToCamelCase()         // "helloWorld"
"hello beautiful world".ToCamelCase() // "helloBeautifulWorld"
```

---

### `ToPascalCase`

Converts a string to PascalCase: every word, including the first, starts with an uppercase letter. All spaces are removed.

```csharp
public static string ToPascalCase(this string value)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to convert. |

**Returns** `string` — the PascalCase-formatted string.

**Examples**

```csharp
"hello world".ToPascalCase()          // "HelloWorld"
"Hello World".ToPascalCase()          // "HelloWorld"
"hello beautiful world".ToPascalCase() // "HelloBeautifulWorld"
```

---

### `ToTitleCase`

Converts a string to Title Case using the capitalisation rules of the specified culture. The input is first lowercased, then each word is capitalised according to the culture's `TextInfo`.

```csharp
public static string ToTitleCase(this string value, CultureInfo culture)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to convert. |
| `culture` | `CultureInfo` | The culture whose capitalisation rules are applied. |

**Returns** `string` — the Title Case-formatted string.

**Examples**

```csharp
"hello world".ToTitleCase(CultureInfo.InvariantCulture)  // "Hello World"
"ciao mondo".ToTitleCase(new CultureInfo("it-IT"))       // "Ciao Mondo"
"istanbul".ToTitleCase(new CultureInfo("tr-TR"))          // "İstanbul"
"à paris en été".ToTitleCase(new CultureInfo("fr-FR"))   // "À Paris En Été"
```

> **Note:** Culture matters. Turkish `"tr-TR"` capitalises `"i"` to `"İ"` (with dot), whereas `"en-US"` capitalises it to `"I"`.

---

### `ToSentenceCase`

Converts a string to Sentence case: the entire string is first lowercased, then the first letter after each period-and-space (`". "`) is capitalised.

```csharp
public static string ToSentenceCase(this string value)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to convert. |

**Returns** `string` — the Sentence case-formatted string.

**Examples**

```csharp
"hello world. bye world".ToSentenceCase()   // "Hello world. Bye world"
"one. two. three.".ToSentenceCase()         // "one. Two. Three."
"Hello World".ToSentenceCase()              // "hello world"
"HELLO WORLD GOODBYE".ToSentenceCase()      // "hello world goodbye"
```

> **Note:** The very first word is **not** capitalised by this method — only words that follow a period are capitalised. Capitalise the first character separately if needed.

---

## Truncation

### `Truncate`

Truncates a string to a specified number of remaining characters from the start, appending a suffix to indicate the cut.

```csharp
public static string Truncate(this string value, int length, string suffix = "...")
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to truncate. |
| `length` | `int` | Number of characters to **remove** from the end (must be > 0 and ≤ `value.Length`). |
| `suffix` | `string` | Appended after the cut. Defaults to `"..."`. |

**Returns** `string` — the truncated string with the suffix appended.

**Throws**
- `ArgumentOutOfRangeException` — if `length` ≤ 0.
- `ArgumentOutOfRangeException` — if `length` > `value.Length`.

**Examples**

```csharp
"Hello World".Truncate(4)       // "Hello W..."
"Hello World".Truncate(1)       // "Hello Worl..."
"Hello World".Truncate(4, "…")  // "Hello W…"
"Hello".Truncate(5)             // "..."
```

---

### `TruncateWords`

Truncates a string to a specified number of words.

```csharp
public static string TruncateWords(this string value, int n)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to truncate. |
| `n` | `int` | Number of words to keep. |

**Returns** `string` — a string containing the first `n` words. Returns an empty string when `n` equals the total word count.

**Throws**
- `ArgumentOutOfRangeException` — if `n` exceeds the number of words in the string, or if the string is empty and `n` > 0.

**Examples**

```csharp
"hello beautiful world".TruncateWords(2) // "hello beautiful"
"hello world".TruncateWords(2)           // ""  (n == word count → empty string)
```

---

## Other Utilities

### `Repeat`

Repeats a string a specified number of times and returns the concatenated result.

```csharp
public static string Repeat(this string value, int n)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to repeat. |
| `n` | `int` | Number of repetitions. |

**Returns** `string` — the string repeated `n` times. Returns an empty string if `n` is 0 or if `value` is empty.

**Examples**

```csharp
"ab".Repeat(1)  // "ab"
"ab".Repeat(3)  // "ababab"
"x".Repeat(4)   // "xxxx"
"".Repeat(5)    // ""
```

---

### `Reverse`

Reverses a string character by character.

```csharp
public static string Reverse(this string value)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to reverse. |

**Returns** `string` — the reversed string. Returns an empty string if `value` is empty.

**Examples**

```csharp
"hello".Reverse()        // "olleh"
"hello world".Reverse()  // "dlrow olleh"
"racecar".Reverse()      // "racecar"
"".Reverse()             // ""
```

---

## Privacy (`StrPrivacy`)

### `Redact`

Replaces characters in a string with asterisks between the specified indices.

```csharp
public static string Redact(this string value, int start, int end)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to redact. |
| `start` | `int` | Index of the first character to redact (inclusive). |
| `end` | `int` | Index of the last character to redact (exclusive). |

**Returns** `string` — the string with the specified range replaced by `*`.

**Throws**
- `ArgumentOutOfRangeException` — if `end` ≥ `value.Length`, or if `start` > `end`.

**Examples**

```csharp
"Hello World".Redact(1, 5)  // "H**** World"
```

---

### `MaskEmail`

Masks an email address, hiding all characters between the first character and the `@` symbol.

```csharp
public static string MaskEmail(this string email)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `email` | `string` | The email address to mask. |

**Returns** `string` — the masked email address.

**Examples**

```csharp
"mario@mail.it".MaskEmail()  // "m****@mail.it"
```

---

### `MaskPhone`

Masks a phone number, hiding characters from index 3 to 8.

```csharp
public static string MaskPhone(this string phone)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `phone` | `string` | The phone number to mask. |

**Returns** `string` — the masked phone number.

**Examples**

```csharp
"3331234567".MaskPhone()  // "333*****67"
```

---

## Search & Comparison (`StrResearch`)

### `ContainsAny`

Returns `true` if the string contains at least one of the specified substrings.

```csharp
public static bool ContainsAny(this string value, params string[] strings)
```

**Examples**

```csharp
"Hello World".ContainsAny("World", "Foo")  // true
"Hello World".ContainsAny("Foo", "Bar")    // false
```

---

### `ContainsAll`

Returns `true` if the string contains all of the specified substrings.

```csharp
public static bool ContainsAll(this string value, params string[] strings)
```

**Examples**

```csharp
"Hello World".ContainsAll("Hello", "World")  // true
"Hello World".ContainsAll("Hello", "Foo")    // false
```

---

### `StartsWithAny`

Returns `true` if the string starts with at least one of the specified prefixes.

```csharp
public static bool StartsWithAny(this string value, params string[] strings)
```

**Examples**

```csharp
"Hello World".StartsWithAny("Hello", "Foo")  // true
"Hello World".StartsWithAny("Foo", "Bar")    // false
```

---

### `EndsWithAny`

Returns `true` if the string ends with at least one of the specified suffixes.

```csharp
public static bool EndsWithAny(this string value, params string[] strings)
```

**Examples**

```csharp
"Hello World".EndsWithAny("World", "Foo")  // true
"Hello World".EndsWithAny("Foo", "Bar")    // false
```

---

### `EqualsIgnoreCase`

Returns `true` if two strings are equal, ignoring case.

```csharp
public static bool EqualsIgnoreCase(this string value, string other)
```

**Examples**

```csharp
"Hello".EqualsIgnoreCase("hello")  // true
"Hello".EqualsIgnoreCase("World")  // false
```

---

## Validation (`StrValidation`)

### `IsEmail`

Determines whether a string is a valid email address.

```csharp
public static bool IsEmail(this string email)
```

**Examples**

```csharp
"mario@mail.it".IsEmail()  // true
"not-an-email".IsEmail()   // false
```

---

### `IsUrl`

Determines whether a string is a valid absolute HTTP/HTTPS URL.

```csharp
public static bool IsUrl(this string url)
```

**Examples**

```csharp
"https://example.com".IsUrl()  // true
"not a url".IsUrl()            // false
```

---

### `IsNumeric`

Returns `true` if the string contains only digit characters.

```csharp
public static bool IsNumeric(this string number)
```

**Examples**

```csharp
"12345".IsNumeric()   // true
"123a5".IsNumeric()   // false
```

---

### `IsAlpha`

Returns `true` if the string contains only alphabetic characters.

```csharp
public static bool IsAlpha(this string letters)
```

**Examples**

```csharp
"Hello".IsAlpha()   // true
"Hello1".IsAlpha()  // false
```

---

### `IsAlphanumeric`

Returns `true` if the string contains only letters and digits.

```csharp
public static bool IsAlphanumeric(this string characters)
```

**Examples**

```csharp
"Hello123".IsAlphanumeric()   // true
"Hello 123".IsAlphanumeric()  // false
```

---

### `IsNullOrWhiteSpace`

Returns `true` if the string is `null`, empty, or consists only of whitespace.

```csharp
public static bool IsNullOrWhiteSpace(this string value)
```

**Examples**

```csharp
"   ".IsNullOrWhiteSpace()  // true
"Hi".IsNullOrWhiteSpace()   // false
```

---

### `HasMinLength`

Returns `true` if the string length is ≥ the specified minimum.

```csharp
public static bool HasMinLength(this string value, int length)
```

**Throws** `ArgumentOutOfRangeException` — if `length` ≤ 0.

**Examples**

```csharp
"Hello".HasMinLength(3)  // true
"Hi".HasMinLength(5)     // false
```

---

### `HasMaxLength`

Returns `true` if the string length is ≤ the specified maximum.

```csharp
public static bool HasMaxLength(this string value, int length)
```

**Throws** `ArgumentOutOfRangeException` — if `length` ≤ 0.

**Examples**

```csharp
"Hi".HasMaxLength(5)           // true
"Hello World".HasMaxLength(5)  // false
```

---

## Encoding & Decoding (`StrEncodeDecode`)

### `ToBase64`

Encodes a plain-text string to its Base64 representation using UTF-8 encoding.

```csharp
public static string ToBase64(this string value)
```

**Examples**

```csharp
"Hello".ToBase64()  // "SGVsbG8="
```

---

### `FromBase64`

Decodes a Base64-encoded string back to its original UTF-8 plain-text.

```csharp
public static string FromBase64(this string value)
```

**Examples**

```csharp
"SGVsbG8=".FromBase64()  // "Hello"
```

---

### `UrlEncode`

Encodes a string for safe inclusion in a URL, replacing special characters with their percent-encoded equivalents.

```csharp
public static string UrlEncode(this string link)
```

**Examples**

```csharp
"hello world".UrlEncode()  // "hello+world"
"a=1&b=2".UrlEncode()      // "a%3d1%26b%3d2"
```

---

### `UrlDecode`

Decodes a URL-encoded string, converting percent-encoded sequences back to their original characters.

```csharp
public static string UrlDecode(this string value)
```

**Examples**

```csharp
"hello+world".UrlDecode()   // "hello world"
"a%3d1%26b%3d2".UrlDecode() // "a=1&b=2"
```

---

### `HtmlEncode`

Encodes a string for safe inclusion in HTML, replacing characters such as `<`, `>`, and `&` with their HTML entity equivalents.

```csharp
public static string HtmlEncode(this string value)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to HTML-encode. |

**Returns** `string` — the HTML-encoded string.

**Examples**

```csharp
"<b>Hello</b> & 'World'".HtmlEncode()  // "&lt;b&gt;Hello&lt;/b&gt; &amp; &#39;World&#39;"
```

---

### `HtmlDecode`

Decodes an HTML-encoded string, converting HTML entities back to their original characters.

```csharp
public static string HtmlDecode(this string value)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The HTML-encoded string to decode. |

**Returns** `string` — the decoded string.

**Examples**

```csharp
"&lt;b&gt;Hello&lt;/b&gt;".HtmlDecode()  // "<b>Hello</b>"
```

---

## Normalization (`StrNormalize`)

### `NormalizeSpaces`

Trims the string and collapses any run of multiple consecutive spaces into a single space.

```csharp
public static string NormalizeSpaces(this string value)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to normalize. |

**Returns** `string` — the trimmed string with internal whitespace runs collapsed to single spaces.

**Examples**

```csharp
"  ciao    mondo  ".NormalizeSpaces()  // "ciao mondo"
"a     b     c".NormalizeSpaces()     // "a b c"
```

---

### `RemoveDiacritics`

Removes diacritical marks (accents) from the characters in the string.

```csharp
public static string RemoveDiacritics(this string value)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to strip diacritics from. |

**Returns** `string` — the string with non-spacing combining marks removed, re-normalized to composed form.

**Examples**

```csharp
"àèìòù".RemoveDiacritics()   // "aeiou"
"café".RemoveDiacritics()   // "cafe"
```

---

### `JoinLines`

Joins all lines in the string into one by removing newline characters.

```csharp
public static string JoinLines(this string value)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The multi-line string to join. |

**Returns** `string` — the string with all newline characters removed.

**Examples**

```csharp
"line1\nline2\nline3".JoinLines()  // "line1line2line3"
```

---

### `RemoveSpecialChars`

Removes non-alphanumeric characters (`a-z`, `A-Z`, `0-9` are kept) from the string, optionally replacing each removed character with a given replacement string.

```csharp
public static string RemoveSpecialChars(this string value, string replace = "")
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string to clean. |
| `replace` | `string` | The string to substitute for each special character removed. Defaults to an empty string. |

**Returns** `string` — the string with special characters removed or replaced.

**Examples**

```csharp
"Hello! @#$%".RemoveSpecialChars()       // "Hello"
"Hello! @#$%".RemoveSpecialChars("_")    // "Hello_______"
```

> **Note:** Anything outside the ASCII `a-zA-Z0-9` range is treated as "special" — including spaces and accented letters.

---

### `NormalizeNewLines`

Normalizes line ending sequences by removing carriage return (`\r`) characters, collapsing `\r\n` and lone `\r` down to `\n`.

```csharp
public static string NormalizeNewLines(this string value)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string whose line endings should be normalized. |

**Returns** `string` — the string with normalized (`\n`-only) line endings.

**Examples**

```csharp
"line1\r\nline2\nline3".NormalizeNewLines()  // "line1\nline2\nline3"
```

---

### `StripHtml`

Removes HTML tags from the string, leaving only the plain text content.

```csharp
public static string StripHtml(this string value)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string containing HTML markup to strip. |

**Returns** `string` — the plain text with HTML tags removed.

**Examples**

```csharp
"<p>Hello <b>World</b></p>".StripHtml()  // "Hello World"
```

---

### `CollapseWhitespace`

Collapses all whitespace characters (spaces, tabs, newlines, etc.) in the string into single spaces, trimming the result.

```csharp
public static string CollapseWhitespace(this string value)
```

| Parameter | Type | Description |
|-----------|------|-------------|
| `value` | `string` | The string whose whitespace should be collapsed. |

**Returns** `string` — the string with all whitespace runs collapsed to single spaces.

**Examples**

```csharp
"Hello   World\t\tTest".CollapseWhitespace()  // "Hello World Test"
```
