namespace Stravaig.Bogus.Extensions.Builders;

internal class SimpleFlatBuilder : SubBuildingBuilder
{
    internal required int FlatNumber { get; init; }
    internal override string Generate()
    {
        ThrowIfBadState();
        return $"Flat {FlatNumber}";
    }

    private void ThrowIfBadState()
    {
        if (FlatNumber is < 1 or > 10)
            throw BuilderStatePropertyOutOfRangeException.PropertyIsOutOfRange(nameof(FlatNumber), 1, 10, FlatNumber);
    }
    
}