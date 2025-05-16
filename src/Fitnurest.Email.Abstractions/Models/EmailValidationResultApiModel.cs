using System.ComponentModel;

using Fitnurest.Email.Abstractions.Models.Enums;

namespace Fitnurest.Email.Abstractions.Models;

public record EmailValidationResultApiModel
{
    [Description("Represents the type of validation check performed on the email address. Possible values include: Format – checks whether the email address has a valid syntactic structure; Mx – verifies that the domain has valid Mail Exchange (MX) DNS records configured to receive emails.")]
    public ApiEmailValidationType Type { get; set; }

    [Description("Represents the status of the validation check. Possible values include: Passed – the validation check was successfully completed and the email address met the criteria for that check; Failed – the validation check was completed and the email address did not meet the required criteria.")]
    public ApiEmailValidationStatus Status { get; set; }

    [Description("An optional field providing additional details about the result of the validation. This can contain specific error messages, warnings, or explanations.")]
    public string? Details { get; set; }
}
