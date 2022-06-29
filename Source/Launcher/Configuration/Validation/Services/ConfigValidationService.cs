using NiallVR.Launcher.Configuration.Validation.Interfaces;
using NiallVR.Launcher.Hosted.Abstract;

namespace NiallVR.Launcher.Configuration.Validation.Services;

/// <summary>
/// A service which validates all the <see cref="IValidatedConfig"/>s in a <see cref="IServiceProvider"/>.
/// </summary>
public class ConfigValidationService : HostedServiceBase
{
    /// <param name="configsToValidate">All of the configuration files to validate.</param>
    public ConfigValidationService(IEnumerable<IValidatedConfig> configsToValidate)
    {
        foreach (var config in configsToValidate)
            config.ValidateConfig();
    }
}