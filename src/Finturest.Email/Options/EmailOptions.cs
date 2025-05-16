namespace Finturest.Email.Options;

public record EmailOptions
{
    public string ApiKey { get; set; }

    public string BaseAddress { get; set; } = "https://api.finturest.com";
}
