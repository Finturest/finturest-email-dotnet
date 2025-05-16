using Finturest.Email.DependencyInjection;

using Fitnurest.Email.Abstractions;
using Fitnurest.Email.Abstractions.Models.Enums;
using Fitnurest.Email.Abstractions.Models.Requests;

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
        var services = new ServiceCollection();

        services.AddFinturestEmail(options =>
        {
            options.ApiKey = "";
        });

        var serviceProvider = services.BuildServiceProvider();

        _sut = serviceProvider.GetRequiredService<IEmailServiceClient>();
    }

    [Fact]
    public async Task ValidateEmailAsync_EmailIsValid_EnsureSuccessStatusCocde()
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
}
