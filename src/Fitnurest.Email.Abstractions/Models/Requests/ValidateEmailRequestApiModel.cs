using System.ComponentModel;

namespace Fitnurest.Email.Abstractions.Models.Requests;

public record ValidateEmailRequestApiModel
{
    [Description("The email address to validate. Must be a properly formatted string (e.g. john.doe@example.com).")]
    public string Email { get; set; } = null!;
}
