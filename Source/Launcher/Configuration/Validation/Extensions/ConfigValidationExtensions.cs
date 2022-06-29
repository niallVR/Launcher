using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NiallVR.Launcher.Configuration.Validation.Services;

namespace NiallVR.Launcher.Configuration.Validation.Extensions;

/// <summary>
/// Extensions to enable config validation.
/// </summary>
public static class ConfigValidationExtensions
{
    /// <summary>
    /// Adds the config validation service to a service collection.
    /// </summary>
    /// <param name="services">The service collection to add to.</param>
    public static IServiceCollection AddConfigValidation(this IServiceCollection services)
    {
        services.AddHostedService<ConfigValidationService>();
        return services;
    }
    
    /// <summary>
    /// Adds the config validation service to a host builders service collection.
    /// </summary>
    /// <param name="builder">The HostBuilder to add the Config Validation service to.</param>
    public static IHostBuilder AddConfigValidation(this IHostBuilder builder)
    {
        return builder.ConfigureServices((_, services) => { services.AddConfigValidation(); });
    }

    /// <inheritdoc cref="AddConfigValidation(Microsoft.Extensions.Hosting.IHostBuilder)"/>
    /// <param name="builder">The HostBuilder to add the Config Validation service to.</param>
    /// <param name="config">The service collection of the HostBuilder to map config objects.</param>
    public static IHostBuilder AddConfigValidation(this IHostBuilder builder, Action<IServiceCollection> config)
    {
        return builder.ConfigureServices((_, services) =>
        {
            services.AddConfigValidation();
            config(services);
        });
    }
}