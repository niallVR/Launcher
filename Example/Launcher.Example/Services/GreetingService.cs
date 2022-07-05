using Launcher.Example.Configuration;
using NiallVR.Launcher.Hosted.Abstract;

namespace Launcher.Example.Services;

/// <summary>
/// An example of using a hosted service, using <see cref="HostedServiceBase"/>.
/// </summary>
public class GreetingService : HostedServiceBase
{
    private readonly ExampleConfig _exampleConfig;

    // If we use the extension method to bind the config, we can omit the IOptions<>.
    // It will register the config as a service which pulls from the IOptions<>.Value.
    public GreetingService(ExampleConfig exampleConfig)
    {
        _exampleConfig = exampleConfig;
    }

    // As we inherit from HostedServiceBase, we don't need to implement the Start/Stop methods.
    // This just saves a little bit of typing and keeps things clean and tidy.
    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync($"Hello {_exampleConfig.Name}!");
    }
}