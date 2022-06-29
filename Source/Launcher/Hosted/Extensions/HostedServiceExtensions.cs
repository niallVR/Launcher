using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace NiallVR.Launcher.Hosted.Extensions;

/// <summary>
/// Extensions for the <see cref="IHostedService"/> interface.
/// </summary>
public static class HostedServiceExtensions
{
    /// <summary>
    /// Registers an <see cref="IHostedService"/> to the service container as itself and a <see cref="IHostedService"/>. 
    /// </summary>
    /// <param name="services">The service collection to add the service to.</param>
    /// <typeparam name="T">The type of <see cref="IHostedService"/> to add.</typeparam>
    /// <returns>The service collection the hosted service was added to.</returns>
    public static IServiceCollection AddHostedServiceAsSelf<T>(this IServiceCollection services) where T : class, IHostedService
    {
        services.TryAddSingleton<T>();
        services.AddHostedService(s => s.GetRequiredService<T>());
        return services;
    }

    /// <inheritdoc cref="AddHostedServiceAsSelf{T}(Microsoft.Extensions.DependencyInjection.IServiceCollection)"/>
    /// <param name="services">The service collection to add the hosted service to.</param>
    /// <param name="factory">The function used to generate the instance.</param>
    public static IServiceCollection AddHostedServiceAsSelf<T>(this IServiceCollection services, Func<IServiceProvider, T> factory) where T : class, IHostedService
    {
        services.TryAddSingleton(factory);
        services.AddHostedService(s => s.GetRequiredService<T>());
        return services;
    }
}