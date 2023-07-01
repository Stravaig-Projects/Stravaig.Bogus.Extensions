namespace Stravaig.Bogus.Extensions;

public class BuilderStateIndexPropertyException : BuilderStatePropertyException
{
    public static BuilderStateIndexPropertyException PropertyIsOutOfRangeIndex(string propertyName, int maxIndex, int requestedIndex) =>
        new($"{propertyName}, {requestedIndex}, is out of range; It must be between 0 and {maxIndex}.", propertyName, maxIndex, requestedIndex);

    public int MaxIndex { get; }
    public int RequestedIndex { get; }
    
    protected BuilderStateIndexPropertyException(string message, string propertyName, int maxIndex, int requestedIndex)
        : base(message, propertyName)
    {
        MaxIndex = maxIndex;
        RequestedIndex = requestedIndex;
    }
}