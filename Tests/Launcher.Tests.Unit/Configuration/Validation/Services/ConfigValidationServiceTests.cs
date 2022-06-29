using Microsoft.Extensions.DependencyInjection;
using NiallVR.Launcher.Configuration.Validation.Interfaces;
using NiallVR.Launcher.Configuration.Validation.Services;
using NSubstitute;
using Xunit;

namespace Launcher.Tests.Unit.Configuration.Validation.Services;

public class ConfigValidationServiceTests
{
    private readonly IValidatedConfig _config1 = Substitute.For<IValidatedConfig>();
    private readonly IValidatedConfig _config2 = Substitute.For<IValidatedConfig>();
    private readonly IServiceProvider _services;

    public ConfigValidationServiceTests()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton(_config1);
        serviceCollection.AddSingleton(_config2);
        serviceCollection.AddSingleton<ConfigValidationService>();
        _services = serviceCollection.BuildServiceProvider();
    }

    [Fact]
    public void Constructor_Should_ValidateAllConfigs()
    {
        // Act
        _services.GetRequiredService<ConfigValidationService>();

        // Assert
        _config1.Received(1).ValidateConfig();
        _config2.Received(1).ValidateConfig();
    }
}