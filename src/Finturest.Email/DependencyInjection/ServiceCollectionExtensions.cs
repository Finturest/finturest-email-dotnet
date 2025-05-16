using Finturest.Email.Constants;
using Finturest.Email.Options;

using Fitnurest.Email.Abstractions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Finturest.Email.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFinturestEmail(this IServiceCollection services, IConfigurationSection configurationSection)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        if (configurationSection is null)
        {
            throw new ArgumentNullException(nameof(configurationSection));
        }

        services.Configure<EmailOptions>(configurationSection);

        services.AddFinturestEmail();

        return services;
    }

    public static IServiceCollection AddFinturestEmail(this IServiceCollection services, Action<EmailOptions> configureOptions)
    {
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        if (configureOptions is null)
        {
            throw new ArgumentNullException(nameof(configureOptions));
        }

        services.Configure(configureOptions);

        services.AddFinturestEmail();

        return services;
    }

    private static IServiceCollection AddFinturestEmail(this IServiceCollection services)
    {
        services.AddHttpClient<IEmailServiceClient, EmailServiceClient>((serviceProvider, client) =>
        {
            var options = serviceProvider.GetRequiredService<IOptions<EmailOptions>>().Value;

            client.BaseAddress = new Uri(options.BaseAddress);

            client.DefaultRequestHeaders.Add(HeaderConstants.ApiKey, options.ApiKey);
        });

        return services;
    }
}
