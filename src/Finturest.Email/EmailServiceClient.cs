using Fitnurest.Email.Abstractions;
using Fitnurest.Email.Abstractions.Models.Requests;
using Fitnurest.Email.Abstractions.Models.Responses;

namespace Finturest.Email;

public class EmailServiceClient : IEmailServiceClient
{
    public Task<ValidateEmailResponse> ValidateEmailAsync(ValidateEmailRequest request)
    {
        throw new NotImplementedException();
    }
}
