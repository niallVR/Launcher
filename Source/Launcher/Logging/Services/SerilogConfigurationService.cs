using NiallVR.Launcher.Hosted.Abstract;
using Serilog;

namespace NiallVR.Launcher.Logging.Services;

internal class SerilogConfigurationService : HostedServiceBase
{
    public SerilogConfigurationService(IServiceProvider services, Action<IServiceProvider, LoggerConfiguration> config)
    {
        var logger = new LoggerConfiguration().Enrich.FromLogContext();
        config(services, logger);
        Log.Logger = logger.CreateLogger();
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        Log.CloseAndFlush();
        return Task.CompletedTask;
    }
}