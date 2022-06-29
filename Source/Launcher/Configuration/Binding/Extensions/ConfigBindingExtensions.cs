using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NiallVR.Launcher.Configuration.Validation.Interfaces;

namespace NiallVR.Launcher.Configuration.Binding.Extensions;

/// <summary>
/// Extensions to assist in binding objects to a configuration.
/// </summary>
public static class ConfigBindingExtensions
{
    /// <summary>
    /// Binds a type to a section of the config.
    /// - Allows access to bound type without the <see cref="IOptions{TOptions}"/> interface.
    /// - Signs up the type for config validation if it implements <see cref="IValidatedConfig"/>.
    /// </summary>
    /// <param name="services">The service collection to add the type to.</param>
    /// <param name="configPath">The config path to map the object to.</param>
    /// <typeparam name="T">The <see cref="IValidatedConfig"/> to map.</typeparam>
    public static IServiceCollection BindConfig<T>(this IServiceCollection services, string configPath) where T : class
    {
        services.AddOptions<T>().BindConfiguration(configPath);
        services.AddSingleton(s => s.GetRequiredService<IOptions<T>>().Value);
        if (typeof(IValidatedConfig).IsAssignableFrom(typeof(T)))
            services.AddSingleton(s => (IValidatedConfig)s.GetRequiredService<IOptions<T>>().Value);
        return services;
    }
}