namespace Fitnurest.Email.Abstractions.Models.Requests;

public record ValidateEmailRequest
{
    /// <summary>
    /// The email address to validate. Must be a properly formatted string (e.g. john.doe@example.com).
    /// </summary>
    public string Email { get; set; } = null!;
}
