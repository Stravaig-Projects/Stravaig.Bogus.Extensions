namespace Stravaig.Bogus.Extensions.Builders;

internal class HighRiseFlatBuilder : SubBuildingBuilder
{
    internal required int FloorNumber { get; init; }
    internal required int FlatNumber { get; init; }
    internal override string Generate()
    {
        ThrowIfBadState();
        char flat = (char)('A' + FlatNumber);
        return $"Flat {FloorNumber}-{flat}";
    }
    
    private void ThrowIfBadState()
    {
        if (FloorNumber is < 1 or > 32)
            throw BuilderStatePropertyOutOfRangeException.PropertyIsOutOfRange(nameof(FloorNumber), 1, 32, FloorNumber);

        if (FlatNumber is < 0 or > 3)
            throw BuilderStatePropertyOutOfRangeException.PropertyIsOutOfRange(nameof(FlatNumber), 0, 3, FlatNumber);
    }
}