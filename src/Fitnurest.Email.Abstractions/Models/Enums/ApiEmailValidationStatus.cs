namespace Fitnurest.Email.Abstractions.Models.Enums;

public enum ApiEmailValidationStatus
{
    /// <summary>
    /// Indicates the validation check was successful and the email met the criteria.
    /// </summary>
    Passed = 0,

    /// <summary>
    /// Indicates the validation check failed (e.g., invalid format, non-existent mailbox).
    /// </summary>
    Failed = 1
}
