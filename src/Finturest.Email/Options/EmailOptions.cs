namespace Finturest.Email.Options;

/// <summary>
/// Represents configuration options for accessing the Finturest Email API.
/// </summary>
public record EmailOptions
{
    /// <summary>
    /// Gets or sets the API key used to authenticate requests to the Finturest Email API.
    /// This property is required.
    /// </summary>
#if NET7_0_OR_GREATER
    public required string ApiKey { get; set; }
#else
    public string ApiKey { get; set; } = null!;
#endif

    /// <summary>
    /// Gets or sets the base URL of the Finturest Email API.
    /// Defaults to <c>https://api.finturest.com/</c>.
    /// </summary>
    public string BaseAddress { get; set; } = "https://api.finturest.com/";
}
