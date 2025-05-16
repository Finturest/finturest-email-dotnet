namespace Finturest.Email.Options;

public record EmailOptions
{
#if NET6_0_OR_GREATER
    public required string ApiKey { get; set; }
#else
    public string ApiKey { get; set; } = null!;
#endif

    public string BaseAddress { get; set; } = "https://api.finturest.com/";
}
