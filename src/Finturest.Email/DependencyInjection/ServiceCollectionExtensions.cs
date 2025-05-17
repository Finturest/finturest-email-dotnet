using Finturest.Email.Abstractions;
using Finturest.Email.Constants;
using Finturest.Email.Options;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Finturest.Email.DependencyInjection;

/// <summary>
/// Provides extension methods to register the Finturest Email API client and its dependencies with the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds and configures the Finturest Email client using configuration from the specified <see cref="IConfigurationSection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <param name="configurationSection">The configuration section containing settings for <see cref="EmailOptions"/>.</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance so that additional calls can be chained.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="services"/> or <paramref name="configurationSection"/> is <c>null</c>.</exception>
    public static IServiceCollection AddFinturestEmail(this IServiceCollection services, IConfigurationSection configurationSection)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configurationSection);
#else
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        if (configurationSection is null)
        {
            throw new ArgumentNullException(nameof(configurationSection));
        }
#endif

        services.Configure<EmailOptions>(configurationSection);

        services.AddFinturestEmail();

        return services;
    }

    /// <summary>
    /// Adds and configures the Finturest Email client using an action delegate to set <see cref="EmailOptions"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <param name="configureOptions">An action delegate to configure the <see cref="EmailOptions"/>.</param>
    /// <returns>The same <see cref="IServiceCollection"/> instance so that additional calls can be chained.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="services"/> or <paramref name="configureOptions"/> is <c>null</c>.</exception>
    public static IServiceCollection AddFinturestEmail(this IServiceCollection services, Action<EmailOptions> configureOptions)
    {
#if NET6_0_OR_GREATER
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configureOptions);
#else
        if (services is null)
        {
            throw new ArgumentNullException(nameof(services));
        }

        if (configureOptions is null)
        {
            throw new ArgumentNullException(nameof(configureOptions));
        }
#endif

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
