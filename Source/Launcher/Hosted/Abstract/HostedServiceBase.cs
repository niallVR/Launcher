using Microsoft.Extensions.Hosting;

namespace NiallVR.Launcher.Hosted.Abstract;

/// <summary>
/// A small wrapper around <see cref="IHostedService"/>, to avoid the need to specify start/stop methods.
/// </summary>
public abstract class HostedServiceBase : IHostedService
{
    /// <inheritdoc cref="IHostedService.StartAsync"/>
    public virtual Task StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    
    /// <inheritdoc cref="IHostedService.StopAsync"/>
    public virtual Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}