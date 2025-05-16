namespace Fitnurest.Email.Abstractions.Models;

public record EmailClassifications
{
    /// <summary>
    /// Indicates whether the email address is from a known disposable or temporary email provider.
    /// </summary>
    public bool Disposable { get; set; }

    /// <summary>
    /// Indicates whether the email address is from a known free email provider (e.g., Gmail, Yahoo).
    /// </summary>
    public bool Free { get; set; }

    /// <summary>
    /// Indicates whether the email address is a role-based address (e.g., info@, support@).
    /// </summary>
    public bool RoleBased { get; set; }
}
