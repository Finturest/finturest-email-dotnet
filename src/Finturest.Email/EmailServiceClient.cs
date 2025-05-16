using System.Net.Http.Json;

using Finturest.Email.Constants;
using Finturest.Email.Options;

using Fitnurest.Email.Abstractions;
using Fitnurest.Email.Abstractions.Models.Requests;
using Fitnurest.Email.Abstractions.Models.Responses;

using Microsoft.Extensions.Options;

namespace Finturest.Email;

public class EmailServiceClient : IEmailServiceClient
{
    private readonly EmailOptions _options;

    private readonly HttpClient _httpClient;

    public EmailServiceClient(IOptions<EmailOptions> options, HttpClient httpClient)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        _options = options.Value;

        _httpClient = httpClient;
    }


    public async Task<ValidateEmailResponse> ValidateEmailAsync(ValidateEmailRequest request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var uri = new Uri($"{_options.BaseAddress}/{RouteConstants.V1}/{RouteConstants.Emails}/{RouteConstants.Validate}");

        var response = await _httpClient.PostAsJsonAsync(uri, request, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ValidateEmailResponse>(cancellationToken).ConfigureAwait(false) ?? throw new InvalidOperationException("Response is null.");
    }
}
