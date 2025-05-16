using Fitnurest.Email.Abstractions.Models.Requests;
using Fitnurest.Email.Abstractions.Models.Responses;

namespace Fitnurest.Email.Abstractions;

public interface IEmailServiceClient
{
    Task<ValidateEmailResponse> ValidateEmailAsync(ValidateEmailRequest request, CancellationToken cancellationToken = default);
}
