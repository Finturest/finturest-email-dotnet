namespace Finturest.Email.Abstractions.Models.Requests;

public record ValidateEmailRequestModel
{
    /// <summary>
    /// The email address to validate. Must be a properly formatted string (e.g. john.doe@example.com).
    /// </summary>
#if NET7_0_OR_GREATER
    public required string Email { get; init; }
#else
    public string Email { get; set; } = null!;
#endif
}
