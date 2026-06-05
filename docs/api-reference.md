---
title: API Reference
---

# API Reference

All methods live in the `StringKit` namespace and are extension methods on `System.String`.  
They are defined in the static class `StrTransform`.

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
