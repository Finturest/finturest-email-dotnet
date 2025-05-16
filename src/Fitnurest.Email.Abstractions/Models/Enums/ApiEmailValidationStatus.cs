using System.ComponentModel;

namespace Fitnurest.Email.Abstractions.Models.Enums;

public enum ApiEmailValidationStatus
{
    [Description("Indicates the validation check was successful and the email met the criteria.")]
    Passed = 0,

    [Description("Indicates the validation check failed (e.g., invalid format, non-existent mailbox).")]
    Failed = 1
}
