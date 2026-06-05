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

## 4. Next Steps

- Read the full [API Reference](api-reference.md) for all methods, signatures, and edge-case behaviour.
- Check the [Roadmap](roadmap.md) for upcoming features.
- Contribute or report issues on [GitHub](https://github.com/DennisTurco/StringKit).

