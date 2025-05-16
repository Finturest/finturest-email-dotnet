using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

using Finturest.Email.Constants;
using Finturest.Email.Options;

using Fitnurest.Email.Abstractions;
using Fitnurest.Email.Abstractions.Models.Requests;
using Fitnurest.Email.Abstractions.Models.Responses;

using Microsoft.Extensions.Options;

namespace Finturest.Email;

public class EmailServiceClient : IEmailServiceClient
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public EmailServiceClient(IOptions<EmailOptions> options, HttpClient httpClient)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        _httpClient = httpClient;

        _httpClient.BaseAddress = new Uri(options.Value.BaseAddress);

        _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-API-KEY", options.Value.ApiKey);

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        _jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }

    public async Task<ValidateEmailResponse> ValidateEmailAsync(ValidateEmailRequest request, CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        var uri = $"{RouteConstants.V1}/{RouteConstants.Emails}/{RouteConstants.Validate}";

        var response = await _httpClient.PostAsJsonAsync(uri, request, _jsonSerializerOptions, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ValidateEmailResponse>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false) ?? throw new InvalidOperationException("Failed to deserialize response.");
    }
}
