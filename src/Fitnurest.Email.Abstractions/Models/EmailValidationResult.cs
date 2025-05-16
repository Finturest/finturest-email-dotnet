using Fitnurest.Email.Abstractions.Models.Enums;

namespace Fitnurest.Email.Abstractions.Models;

public record EmailValidationResult
{
    /// <summary>
    /// Represents the type of validation check performed on the email address.
    /// Possible values include:
    /// - <c>Format</c>: Checks whether the email address has a valid syntactic structure.
    /// - <c>Mx</c>: Verifies that the domain has valid Mail Exchange (MX) DNS records configured to receive emails.
    /// </summary>
    public EmailValidationType Type { get; set; }


    /// <summary>
    /// Represents the status of the validation check.
    /// Possible values include:
    /// - <c>Passed</c>: The validation check was successfully completed and the email address met the criteria for that check.
    /// - <c>Failed</c>: The validation check was completed and the email address did not meet the required criteria.
    /// </summary>
    public EmailValidationStatus Status { get; set; }

    /// <summary>
    /// An optional field providing additional details about the result of the validation.
    /// This can contain specific error messages, warnings, or explanations.
    /// </summary>
    public string? Details { get; set; }
}
