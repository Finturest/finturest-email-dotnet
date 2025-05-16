using Finturest.Email.Options;

using Fitnurest.Email.Abstractions;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finturest.Email.DependencyInjection;

public static class EmailServiceCollectionExtensions
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
        services.AddHttpClient<IEmailServiceClient, EmailServiceClient>();

        return services;
    }
}
