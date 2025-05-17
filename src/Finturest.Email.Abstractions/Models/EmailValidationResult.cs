using Finturest.Email.Abstractions.Models.Enums;

namespace Finturest.Email.Abstractions.Models;

public record EmailValidationResult
{
    /// <summary>
    /// Represents the type of validation check performed on the email address.
    /// Possible values include:
    /// - <c>Format</c>: Checks whether the email address has a valid syntactic structure.
    /// - <c>Mx</c>: Verifies that the domain has valid Mail Exchange (MX) DNS records configured to receive emails.
    /// </summary>
#if NET7_0_OR_GREATER
    public required EmailValidationType Type { get; init; }
#else
    public EmailValidationType Type { get; set; }
#endif

    /// <summary>
    /// Represents the status of the validation check.
    /// Possible values include:
    /// - <c>Passed</c>: The validation check was successfully completed and the email address met the criteria for that check.
    /// - <c>Failed</c>: The validation check was completed and the email address did not meet the required criteria.
    /// </summary>
#if NET7_0_OR_GREATER
    public required EmailValidationStatus Status { get; init; }
#else
    public EmailValidationStatus Status { get; set; }
#endif

    /// <summary>
    /// An optional field providing additional details about the result of the validation.
    /// This can contain specific error messages, warnings, or explanations.
    /// </summary>
#if NET7_0_OR_GREATER
    public string? Details { get; init; }
#else
    public string? Details { get; set; }
#endif
}
