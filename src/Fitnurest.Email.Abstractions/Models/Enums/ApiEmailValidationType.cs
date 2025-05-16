using System.ComponentModel;

namespace Fitnurest.Email.Abstractions.Models.Enums;

public enum ApiEmailValidationType
{
    [Description("Validates that the email address has correct syntax according to RFC standards (e.g., user@example.com).")]
    Format = 0,

    [Description("Checks whether the domain in the email address has valid Mail Exchange (MX) DNS records.")]
    Mx = 1,
}
