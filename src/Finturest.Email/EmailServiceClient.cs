using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

using Finturest.Email.Constants;

using Fitnurest.Email.Abstractions;
using Fitnurest.Email.Abstractions.Models.Requests;
using Fitnurest.Email.Abstractions.Models.Responses;

namespace Finturest.Email;

public class EmailServiceClient : IEmailServiceClient
{
    private readonly HttpClient _httpClient;

    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public EmailServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;

        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        _jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }

    public async Task<ValidateEmailResponse> ValidateEmailAsync(ValidateEmailRequest request, CancellationToken cancellationToken = default)
    {
#if NET7_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(request);
#else
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }
#endif

        var uri = $"{RouteConstants.V1}/{RouteConstants.Emails}/{RouteConstants.Validate}";

        var response = await _httpClient.PostAsJsonAsync(uri, request, _jsonSerializerOptions, cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<ValidateEmailResponse>(_jsonSerializerOptions, cancellationToken).ConfigureAwait(false) ?? throw new InvalidOperationException("Failed to deserialize response.");
    }
}
