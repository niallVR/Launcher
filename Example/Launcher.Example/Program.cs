using Launcher.Example.Configuration;
using Launcher.Example.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NiallVR.Launcher.Configuration.Binding.Extensions;
using NiallVR.Launcher.Configuration.Validation.Extensions;
using NiallVR.Launcher.Logging.Extensions;

await Host.CreateDefaultBuilder()
    // Here we can configure Serilog and set it up using HostedServices.
    // The setup console sink extension alters the theme and colours a little.
    .AddAndConfigSerilog((_, config) => config.SetupConsoleSink())
    
    // This adds the config validation service to the service collection.
    .AddConfigValidation(services =>
    {
        // Using this extension method will:
        // - Bind the configuration.
        // - Make it accessible through T instead of IOptions<T>.
        // - Sign it up for validation if it implements IConfigValidation.
        services.BindConfig<ExampleConfig>("Example");
    })
    
    // Add the hosted service to the service collection.
    .ConfigureServices(services =>
    {
        services.AddHostedService<GreetingService>();
    })
    
    // Start the application.
    .RunConsoleAsync();