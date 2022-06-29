using NiallVR.Launcher.Logging.Config;
using Serilog;
using Serilog.Events;

namespace NiallVR.Launcher.Logging.Extensions;

/// <summary>
/// Extensions for configuring Serilog sinks.
/// </summary>
public static class SerilogSinkExtensions
{
    /// <summary>
    /// Adds a console sink to the logging config, configured with a theme and template.
    /// </summary>
    /// <param name="config">The config to add the console sink to.</param>
    /// <returns>The config the console sink was added to.</returns>
    public static LoggerConfiguration SetupConsoleSink(this LoggerConfiguration config) {
        return config.SetupConsoleSink(LogEventLevel.Verbose);
    }
    
    /// <summary>
    /// Adds a console sink to the logging config, configured with a theme and template.
    /// </summary>
    /// <param name="config">The config to add the console sink to.</param>
    /// <param name="minLevel">The minimum level that will be logged.</param>
    /// <returns>The config the console sink was added to.</returns>
    public static LoggerConfiguration SetupConsoleSink(this LoggerConfiguration config, LogEventLevel minLevel) {
        config.WriteTo.Console(
            outputTemplate: SerilogConsoleTheme.Template,
            theme: SerilogConsoleTheme.Theme,
            restrictedToMinimumLevel: minLevel
        );
        return config;
    }
}