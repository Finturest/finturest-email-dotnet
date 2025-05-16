using System.ComponentModel;

namespace Fitnurest.Email.Abstractions.Models;

public record EmailClassificationsApiModel
{
    [Description("Indicates whether the email address is from a known disposable or temporary email provider.")]
    public bool Disposable { get; set; }

    [Description("Indicates whether the email address is from a known free email provider (e.g., Gmail, Yahoo).")]
    public bool Free { get; set; }

    [Description("Indicates whether the email address is a role-based address (e.g., info@, support@).")]
    public bool RoleBased { get; set; }
}
