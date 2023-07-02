namespace Stravaig.Bogus.Extensions.Builders;

internal class SimpleAlphabetFlatBuilder : SubBuildingBuilder
{
    internal required int FlatNumber { get; init; }
    internal override string Generate()
    {
        ThrowIfBadState();
        char flat = (char)('A' + FlatNumber);
        return $"Flat {flat}";
    }

    private void ThrowIfBadState()
    {
        if (FlatNumber is < 0 or > 7)
            throw BuilderStatePropertyOutOfRangeException.PropertyIsOutOfRange(nameof(FlatNumber), 0, 7, FlatNumber);
    }
}