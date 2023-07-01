using System;

namespace Stravaig.Bogus.Extensions;

/// <summary>
/// Represents an exception where the builder object is in an invalid state.
/// </summary>
public class BuilderStatePropertyException : InvalidOperationException
{
    public static BuilderStatePropertyException PropertyIsNull(string propertyName) =>
        new($"{propertyName} should have content, but was null.", propertyName);

    public static BuilderStatePropertyException PropertyIsEmpty(string propertyName) =>
        new($"{propertyName} should have content, but was empty.", propertyName);

    /// <summary>
    /// The name of the property that is in an invalid state.
    /// </summary>
    public string PropertyName { get; }
    
    protected BuilderStatePropertyException(string message, string propertyName)
        : base(message)
    {
        PropertyName = propertyName;
    }
}