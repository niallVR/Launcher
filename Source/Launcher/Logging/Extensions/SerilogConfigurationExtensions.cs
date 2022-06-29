using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NiallVR.Launcher.Logging.Services;
using Serilog;

namespace NiallVR.Launcher.Logging.Extensions;

/// <summary>
/// Extensions for configuring Serilog.
/// </summary>
public static class SerilogConfigurationExtensions
{
    /// <summary>
    /// Adds Serilog to the service collection and configures the <see cref="Log.Logger"/>.
    /// </summary>
    /// <param name="builder">The builder to add Serilog to.</param>
    /// <param name="config">The logger configuration for Serilog.</param>
    /// <returns>The builder, Serilog was added to.</returns>
    /// <remarks>This should be first in your host builder.</remarks>
    public static IHostBuilder AddAndConfigSerilog(this IHostBuilder builder, Action<LoggerConfiguration> config)
    {
        return AddAndConfigSerilog(builder, (_, c) => config(c));
    }

    /// <summary>
    /// Adds Serilog to the service collection and configures the <see cref="Log.Logger"/>.
    /// </summary>
    /// <param name="builder">The builder to add Serilog to.</param>
    /// <param name="config">The logger configuration for Serilog.</param>
    /// <returns>The builder, Serilog was added to.</returns>
    /// <remarks>This should be first in your host builder.</remarks>
    public static IHostBuilder AddAndConfigSerilog(this IHostBuilder builder, Action<IServiceProvider, LoggerConfiguration> config)
    {
        builder.UseSerilog();
        builder.ConfigureServices((_, services) =>
        {
            services.AddHostedService(s => new SerilogConfigurationService(s, config));
        });
        return builder;
    }
}