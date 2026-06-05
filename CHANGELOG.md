# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

#### Documentation

- `docs/introduction.md` — overview of StringKit: purpose, design goals (zero dependencies, thread-safe, no I/O), supported platform, and license
- `docs/getting-started.md` — complete getting-started guide: installation (CLI, NuGet, Visual Studio), namespace setup, and quick usage examples for all method groups
- `docs/api-reference.md` — full API reference for all 10 public methods (`ToSlug`, `ToSnakeCase`, `ToCamelCase`, `ToPascalCase`, `ToTitleCase`, `ToSentenceCase`, `Truncate`, `TruncateWords`, `Repeat`, `Reverse`) with signatures, parameter tables, return values, exceptions, and examples
- `docs/toc.yml` — added *API Reference* entry to the documentation sidebar

#### Project

- `README.md` — filled in the library description, feature list, and usage examples; fixed the Contributing section (previously contained placeholder copy from another project)
- `assets/icon.svg` — replaced the placeholder "CF" icon (repurposed from another project) with a proper StringKit icon: dark purple/indigo gradient, `"SK"` monogram, decorative curly quotation marks, and a violet accent bar
- `assets/icon.png` — regenerated (512×512) to match the new icon design
- `images/icon.svg` — updated to match the new icon design (keeps `height="32"` for inline use)
- `images/icon.png` — regenerated (64×64) to match the new icon design
- `.github/FUNDING.yml` — fixed GitHub Sponsors button format (`github: ["DennisTurco"]` → `github: DennisTurco`); the sponsor button now renders correctly on the repository page

## [1.0.0] - 

### Added

#### Documentation

- Full [DocFX](https://dotnet.github.io/docfx/) documentation site published to GitHub Pages
- API reference generated from XML doc comments (zero CS1591 warnings)
- Conceptual docs: introduction, getting started

### Notes

- All public methods are **static** and **thread-safe**
- No HTTP calls, no external services — all transformations run locally in-process
- Targets **.NET 9.0**

[Unreleased]: https://github.com/DennisTurco/StringKit/compare/v1.0.0...HEAD
[1.0.0]: https://github.com/DennisTurco/StringKit/releases/tag/v1.0.0
