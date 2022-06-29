using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using NiallVR.Launcher.Configuration.Binding.Extensions;
using NiallVR.Launcher.Configuration.Validation.Abstract;
using NiallVR.Launcher.Configuration.Validation.Interfaces;
using Xunit;

namespace Launcher.Tests.Unit.Configuration.Binding.Extensions;

public class ConfigBindingExtensionsTests
{
    public class MockNonValidatedConfig { }
    public class MockValidatedConfig : ValidatedConfig { }

    private readonly IServiceCollection _serviceCollection = new ServiceCollection();
    
    public ConfigBindingExtensionsTests()
    {
        _serviceCollection.AddSingleton<IConfiguration>(new ConfigurationBuilder().Build());
    }

    [Fact]
    public void BindConfig_Should_BindModelToPath() {
        // Act
        _serviceCollection.BindConfig<MockNonValidatedConfig>("Test");
        var services = _serviceCollection.BuildServiceProvider();

        // Assert
        services.GetService<IOptions<MockNonValidatedConfig>>().Should().NotBeNull();
        services.GetService<MockNonValidatedConfig>().Should().NotBeNull();
    }
    
    [Fact]
    public void BindConfig_Should_NotAddAsValidatedConfig_When_DoesntImplementInterface() { 
        // Act
        _serviceCollection.BindConfig<MockNonValidatedConfig>("Test");

        // Assert
        _serviceCollection.BuildServiceProvider().GetService<IValidatedConfig>().Should().BeNull();
    }
    
    [Fact]
    public void BindConfig_Should_AddAsValidatedConfig_When_ImplementsValidatedConfig() {
        // Act
        _serviceCollection.BindConfig<MockValidatedConfig>("Test");

        // Assert
        _serviceCollection.BuildServiceProvider().GetService<IValidatedConfig>().Should().NotBeNull();
    }
}