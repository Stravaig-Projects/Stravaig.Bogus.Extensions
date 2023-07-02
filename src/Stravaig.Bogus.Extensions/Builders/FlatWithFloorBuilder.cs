namespace Stravaig.Bogus.Extensions.Builders;

internal class FlatWithFloorBuilder : SubBuildingBuilder
{
    internal required int FloorNumber { get; init; }
    internal required int FlatNumber { get; init; }
    internal override string Generate()
    {
        ThrowIfBadState();
        string floor = FloorNumber switch
        {
            -1 => "LG", // Lower Ground
            0 => "G", // Ground
            _ => FloorNumber.ToString(),
        };
        return $"Flat {floor}/{FlatNumber}";
    }
    
    private void ThrowIfBadState()
    {
        if (FloorNumber is < -1 or > 6)
            throw BuilderStatePropertyOutOfRangeException.PropertyIsOutOfRange(nameof(FloorNumber), -1, 6, FloorNumber);

        if (FlatNumber is < 1 or > 4)
            throw BuilderStatePropertyOutOfRangeException.PropertyIsOutOfRange(nameof(FlatNumber), 1, 4, FlatNumber);
    }
}