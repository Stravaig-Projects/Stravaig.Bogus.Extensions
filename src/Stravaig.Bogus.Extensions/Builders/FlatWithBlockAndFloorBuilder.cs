namespace Stravaig.Bogus.Extensions.Builders;

internal class FlatWithBlockAndFloorBuilder : SubBuildingBuilder
{
    internal required int BlockNumber { get; init; }
    internal required int FloorNumber { get; init; }
    internal required int FlatNumber { get; init; }
    internal override string Generate()
    {
        ThrowIfBadState();
        char block = (char)('A' + BlockNumber);
        return $"Block {block}, Flat {FloorNumber}/{FlatNumber}";
    }
    
    private void ThrowIfBadState()
    {
        if (BlockNumber is < 0 or > 5)
            throw BuilderStatePropertyOutOfRangeException.PropertyIsOutOfRange(nameof(BlockNumber), 0, 5, BlockNumber);
            
        if (FloorNumber is < 1 or > 12)
            throw BuilderStatePropertyOutOfRangeException.PropertyIsOutOfRange(nameof(FloorNumber), 1, 12, FloorNumber);

        if (FlatNumber is < 1 or > 4)
            throw BuilderStatePropertyOutOfRangeException.PropertyIsOutOfRange(nameof(FlatNumber), 1, 4, FlatNumber);
    }
}