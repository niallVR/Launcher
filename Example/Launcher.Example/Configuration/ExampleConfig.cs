using System.ComponentModel.DataAnnotations;
using NiallVR.Launcher.Configuration.Validation.Abstract;

namespace Launcher.Example.Configuration;

/// <summary>
/// An example of a config model which will be validated at startup.
/// </summary>
public class ExampleConfig : ValidatedConfig
{
    // Here in this model we can use the Data Annotations to validated values.
    // For example, required will ensure our value isn't null or whitespace.
    // But we can add much more, like Regex etc.
    
    [Required]
    public string? Name { get; set; }
}