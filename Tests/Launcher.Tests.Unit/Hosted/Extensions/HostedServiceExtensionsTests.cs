using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NiallVR.Launcher.Hosted.Abstract;
using NiallVR.Launcher.Hosted.Extensions;
using Xunit;

namespace Launcher.Tests.Unit.Hosted.Extensions;

public class HostedServiceExtensionsTests
{
    public class MockHostedService : HostedServiceBase
    {
    }

    [Fact]
    public void AddHostedServiceAsSelf_Generic_Should_AddServiceAsInterfaceAndType()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();

        // Act
        serviceCollection.AddHostedServiceAsSelf<MockHostedService>();

        // Assert
        var services = serviceCollection.BuildServiceProvider();
        services.GetService<IHostedService>().Should().NotBeNull();
        services.GetService<IHostedService>().Should().BeAssignableTo<MockHostedService>();
        services.GetService<MockHostedService>().Should().NotBeNull();
    }

    [Fact]
    public void AddHostedServiceAsSelf_Func_Should_AddServiceAsInterfaceAndType()
    {
        // Arrange
        var serviceCollection = new ServiceCollection();

        // Act
        serviceCollection.AddHostedServiceAsSelf(_ => new MockHostedService());

        // Assert
        var services = serviceCollection.BuildServiceProvider();
        services.GetService<IHostedService>().Should().NotBeNull();
        services.GetService<IHostedService>().Should().BeAssignableTo<MockHostedService>();
        services.GetService<MockHostedService>().Should().NotBeNull();
    }
}