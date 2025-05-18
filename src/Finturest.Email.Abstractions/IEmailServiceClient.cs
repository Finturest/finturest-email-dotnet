using Finturest.Email.Abstractions.Models.Requests;
using Finturest.Email.Abstractions.Models.Responses;

namespace Finturest.Email.Abstractions;

/// <summary>
/// Provides methods for sending requests to and receiving responses from the Finturest Email API.
/// </summary>
public interface IEmailServiceClient
{
    /// <summary>
    /// Validate email
    /// </summary>
    /// <param name="request">Request model to validate email</param>
    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <exception cref="ArgumentNullException">The request model was null.</exception>
    /// <exception cref="HttpRequestException">The request failed due to an underlying issue such as network connectivity, DNS failure, server certificate validation or timeout.</exception>
    Task<ValidateEmailResponseModel> ValidateEmailAsync(ValidateEmailRequestModel request, CancellationToken cancellationToken = default);
}
