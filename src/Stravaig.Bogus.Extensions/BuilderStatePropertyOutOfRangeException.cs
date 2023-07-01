namespace Stravaig.Bogus.Extensions;

public class BuilderStatePropertyOutOfRangeException : BuilderStatePropertyException
{
    public static BuilderStatePropertyOutOfRangeException PropertyIsOutOfRange(string propertyName, int low, int high, int requested) =>
        new BuilderStatePropertyOutOfRangeException($"{propertyName}, {requested}, is out of range; It must be between {low} and {high}.", propertyName, low, high, requested);
    
    public int Requested { get; }
    public int LowBound { get; }
    public int HighBound { get; }

    protected BuilderStatePropertyOutOfRangeException(string message, string propertyName, int low, int high, int requested)
        : base(message, propertyName)
    {
        LowBound = low;
        HighBound = high;
        Requested = requested;
    }
}