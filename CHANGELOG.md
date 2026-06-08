# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased]

### Added

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
