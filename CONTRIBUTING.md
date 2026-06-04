# Contributing

Thank you for your interest in contributing to StringKit.

## 1. Before You Start

* Search existing issues before opening a new one.
* For bug reports, include enough information to reproduce the problem.
* For feature requests, explain the use case and expected behaviour.

## 2. Reporting Validation Issues

If you believe something is being handled incorrectly, please provide:

1. The value being validated (anonymised if necessary)
2. The expected result
3. The actual result
4. Any relevant personal data or municipality information needed to reproduce the issue

## 3. Development Setup

Setup the pre-cheeck:

```powershell
.\setup.ps1
```

Clone the repository and build locally:

```powershell
dotnet build
dotnet test
```

To preview the documentation locally:

```powershell
docfx .\docfx.json --serve
```

## 4. Pull Requests

Please keep pull requests focused on a single change whenever possible.

## 5. Coding Guidelines

* Follow the existing coding style and project structure.
* Prefer readability over clever implementations.
* Avoid introducing external dependencies unless there is a strong justification.
* Keep all validation logic fully local. The library must not require external services or HTTP calls.

## 7. License

By contributing, you agree that your contributions will be licensed under the MIT License.
