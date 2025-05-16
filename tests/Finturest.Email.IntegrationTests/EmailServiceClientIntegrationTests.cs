using Finturest.Email.DependencyInjection;

using Fitnurest.Email.Abstractions;
using Fitnurest.Email.Abstractions.Models.Requests;

using Microsoft.Extensions.DependencyInjection;

using Shouldly;

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
            options.ApiKey = "hidden";
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
    }
}
