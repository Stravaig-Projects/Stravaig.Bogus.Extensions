namespace Stravaig.Bogus.Extensions.Builders;

internal class NullSubBuildingBuilder : SubBuildingBuilder
{
    internal static readonly NullSubBuildingBuilder Instance = new();
    internal override string? Generate()
    {
        return null;
    }
}