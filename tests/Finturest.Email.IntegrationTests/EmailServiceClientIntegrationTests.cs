using System.Net;
using System.Net.Http;

using Finturest.Email.DependencyInjection;

using Fitnurest.Email.Abstractions;
using Fitnurest.Email.Abstractions.Models.Enums;
using Fitnurest.Email.Abstractions.Models.Requests;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finturest.Email.IntegrationTests;

/// <summary>
/// Integration tests for <see cref="IEmailServiceClient"/>
/// </summary>
public class EmailServiceClientIntegrationTests
{
    private readonly IEmailServiceClient _sut;

    public EmailServiceClientIntegrationTests()
    {
        var configuration = new ConfigurationBuilder()
            .AddEnvironmentVariables(prefix: "Finturest_")
#if DEBUG
            .AddUserSecrets<EmailServiceClientIntegrationTests>()
#endif
            .Build();

        var apiKey = configuration["Email:ApiKey"] ?? throw new InvalidOperationException("Finturest Email API key must be set in environment or user secrets.");

        _sut = BuildClient(apiKey);
    }

    [Fact]
    public async Task ValidateEmailAsync_ApiKeyIsNotValid_EnsureUnauthorizedStatusCode()
    {
        // Arrange
        var request = new ValidateEmailRequest
        {
            Email = "support@finturest.com"
        };

        // Act
        Func<Task> action = async () => await BuildClient(apiKey: "invalid-api-key").ValidateEmailAsync(request).ConfigureAwait(false);

        // Assert
#if NET5_0_OR_GREATER
        var assertion = await action.ShouldThrowAsync<HttpRequestException>();

        assertion.StatusCode.ShouldBe(HttpStatusCode.Unauthorized);
#else
        await action.ShouldThrowAsync<HttpRequestException>();
#endif
    }

    [Fact]
    public async Task ValidateEmailAsync_EmailIsValid_ReturnCorrectResult()
    {
        // Arrange
        var request = new ValidateEmailRequest
        {
            Email = "support@finturest.com"
        };

        // Act
        var result = await _sut.ValidateEmailAsync(request);

        // Assert
        result.ShouldNotBeNull();

        result.Deliverable.ShouldBe(true);

        result.Validations.Count.ShouldBe(2);

        result.Validations[0].Type.ShouldBe(EmailValidationType.Format);
        result.Validations[0].Status.ShouldBe(EmailValidationStatus.Passed);

        result.Validations[1].Type.ShouldBe(EmailValidationType.Mx);
        result.Validations[1].Status.ShouldBe(EmailValidationStatus.Passed);

        result.Classifications.ShouldNotBeNull();
        result.Classifications.Disposable.ShouldBeFalse();
        result.Classifications.Free.ShouldBeFalse();
        result.Classifications.RoleBased.ShouldBeTrue();
    }

    [Fact]
    public async Task ValidateEmailAsync_EmailHasFormatErrors_ReturnCorrectResult()
    {
        // Arrange
        var request = new ValidateEmailRequest
        {
            Email = "support@@finturest.com"
        };

        // Act
        var result = await _sut.ValidateEmailAsync(request);

        // Assert
        result.ShouldNotBeNull();

        result.Deliverable.ShouldBe(false);

        result.Validations.Count.ShouldBe(1);

        result.Validations[0].Type.ShouldBe(EmailValidationType.Format);
        result.Validations[0].Status.ShouldBe(EmailValidationStatus.Failed);

        result.Classifications.ShouldBeNull();
    }

    [Fact]
    public async Task ValidateEmailAsync_EmailHasInvalidDomain_ReturnCorrectResult()
    {
        // Arrange
        var request = new ValidateEmailRequest
        {
            Email = "support@test.com"
        };

        // Act
        var result = await _sut.ValidateEmailAsync(request);

        // Assert
        result.ShouldNotBeNull();

        result.Deliverable.ShouldBe(false);

        result.Validations.Count.ShouldBe(2);

        result.Validations[0].Type.ShouldBe(EmailValidationType.Format);
        result.Validations[0].Status.ShouldBe(EmailValidationStatus.Passed);

        result.Validations[1].Type.ShouldBe(EmailValidationType.Mx);
        result.Validations[1].Status.ShouldBe(EmailValidationStatus.Failed);

        result.Classifications.ShouldBeNull();
    }

    private static IEmailServiceClient BuildClient(string apiKey)
    {
        var services = new ServiceCollection();

        services.AddFinturestEmail(options =>
        {
            options.ApiKey = apiKey;
        });

        var serviceProvider = services.BuildServiceProvider();

        return serviceProvider.GetRequiredService<IEmailServiceClient>();
    }
}
