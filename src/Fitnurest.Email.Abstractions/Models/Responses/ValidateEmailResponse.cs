namespace Fitnurest.Email.Abstractions.Models.Responses;

public record ValidateEmailResponse
{
    /// <summary>
    /// The original email address that was validated.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Email { get; init; }
#else
    public string Email { get; set; } = null!;
#endif

    /// <summary>
    /// Indicates whether the email address passed all validation checks and is considered capable of receiving messages.
    /// A value of true means the address is syntactically correct, the domain is properly configured, and no issues were detected during verification.
    /// </summary>
#if NET7_0_OR_GREATER
    public required bool Deliverable { get; init; }
#else
    public bool Deliverable { get; set; }
#endif

    /// <summary>
    /// A list of validation results for the given email address.
    /// Each item contains the outcome of a specific validation check (e.g., format, MX, SMTP).
    /// </summary>
#if NET7_0_OR_GREATER
    public required IReadOnlyList<EmailValidationResult> Validations { get; init; } = [];
#else
    public IReadOnlyList<EmailValidationResult> Validations { get; set; } = [];
#endif

    /// <summary>
    /// Describes various characteristics of the email address, such as whether it is role-based, disposable, from a free provider, or part of a catch-all domain.
    /// This property provides metadata about the email’s structure and type, which can help identify its purpose or origin.
    /// Each classification is represented as a boolean flag indicating the presence of a specific trait, like being a role-based email (e.g., info@, support@) or being from a disposable email provider.
    /// </summary>
#if NET7_0_OR_GREATER
    public EmailClassifications? Classifications { get; init; }
#else
    public EmailClassifications? Classifications { get; set; }
#endif
}
