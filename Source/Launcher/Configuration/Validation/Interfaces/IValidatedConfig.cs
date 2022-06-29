namespace NiallVR.Launcher.Configuration.Validation.Interfaces;

/// <summary>
/// Classes which inherit this interface are validated at the start of the application.
/// </summary>
public interface IValidatedConfig
{
    /// <summary>
    /// Called during startup to validate the configuration.
    /// </summary>
    void ValidateConfig();
}