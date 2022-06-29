using System.ComponentModel.DataAnnotations;
using NiallVR.Launcher.Configuration.Validation.Interfaces;

namespace NiallVR.Launcher.Configuration.Validation.Abstract;

/// <summary>
/// A wrapper around <see cref="IValidatedConfig"/> using <see cref="Validator.ValidateObject(object, ValidationContext, bool)"/>.
/// </summary>
public class ValidatedConfig : IValidatedConfig
{
    /// <inheritdoc cref="IValidatedConfig.ValidateConfig"/>
    public void ValidateConfig()
    {
        Validator.ValidateObject(this, new ValidationContext(this), true);
    }
}