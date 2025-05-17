# Finturest Email API C# SDK

[![NuGet](https://img.shields.io/nuget/v/Finturest.Email.svg)](https://www.nuget.org/packages/Finturest.Email)
![CI](https://github.com/finturest/finturest-email-dotnet/actions/workflows/ci.yml/badge.svg)

Official C# SDK for the [Finturest Email API](https://finturest.com/products/email-api) - supports .NET Standard 2.0+ and all modern .NET versions.

## Overview

This SDK provides a simple and reliable way to integrate Finturest Email API functionality into your .NET applications. It supports .NET Standard 2.0 and later, ensuring compatibility with .NET Core and the latest .NET releases.

## Features

- **Accurate Format Validation**: Ensures email addresses are correctly structured according to RFC standards before processing.

- **Domain Reliability Checks**: Verifies that email domains are properly configured with MX records to improve deliverability and reduce bounce rates.

- **Disposable and Free Email Detection**: Identifies temporary and free email providers to help prevent fraud, spam, fake accounts, and low-quality signups.

- **Role-Based Email Filtering**: Flags generic role-based addresses like `info@`, `support@`, etc., to improve user targeting and communication quality.

## Installation

Using the [.NET Core command-line interface (CLI) tools](https://learn.microsoft.com/en-us/dotnet/core/tools/):

```sh
dotnet add package Finturest.Email
```

Using the [NuGet Command Line Interface (CLI)](https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference):

```sh
nuget install Finturest.Email
```

Using the [Package Manager Console](https://docs.microsoft.com/en-us/nuget/tools/package-manager-console):

```powershell
Install-Package Finturest.Email
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on _Manage NuGet Packages..._
4. Click on the _Browse_ tab and search for "Finturest.Email".
5. Click on the Finturest.Email package, select the appropriate version in the
   right-tab and click _Install_.

## Subscription & Pricing

To get access to the Finturest Email API or subscribe to a plan, please visit the subscription page. An active subscription is required to access the API in production.

[Manage subscriptions](https://finturest.com/dashboard/subscriptions)

## API Key Generation

An API key is required to use the SDK and can be generated on your Finturest dashboard:

[Generate API key](https://finturest.com/dashboard/access-tokens)

## Documentation

For full API reference and usage guides, please visit the official Finturest Email API documentation:

[View API reference](https://api.finturest.com/docs/#tag/email)

## Contact

For support, questions, or inquiries, please contact us at: [support@finturest.com](mailto:support@finturest.com)
