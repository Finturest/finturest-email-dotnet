namespace Fitnurest.Email.Abstractions.Models.Enums;

public enum EmailValidationType
{
    /// <summary>
    /// Validates that the email address has correct syntax according to RFC standards (e.g., user@example.com).
    /// </summary>
    Format = 0,

    /// <summary>
    /// Checks whether the domain in the email address has valid Mail Exchange (MX) DNS records.
    /// </summary>
    Mx = 1,
}
