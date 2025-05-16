namespace Fitnurest.Email.Abstractions.Models;

public record EmailClassifications
{
    /// <summary>
    /// Indicates whether the email address is from a known disposable or temporary email provider.
    /// </summary>
#if NET6_0_OR_GREATER
    public required bool Disposable { get; init; }
#else
    public bool Disposable { get; set; }
#endif

    /// <summary>
    /// Indicates whether the email address is from a known free email provider (e.g., Gmail, Yahoo).
    /// </summary>
#if NET6_0_OR_GREATER
    public required bool Free { get; init; }
#else
    public bool Free { get; set; }
#endif

    /// <summary>
    /// Indicates whether the email address is a role-based address (e.g., info@, support@).
    /// </summary>
#if NET6_0_OR_GREATER
    public required bool RoleBased { get; init; }
#else
    public bool RoleBased { get; set; }
#endif
}
