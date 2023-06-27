namespace Stravaig.Bogus.Extensions.Data;

internal static class StreetSuffixes
{
    internal static readonly string[] Common = new[]
    {
        "Avenue",
        "Close",
        "Crescent",
        "Cross",
        "Drive",
        "Field",
        "Gardens",
        "Grove",
        "Hill",
        "Lane",
        "Mews",
        "Park",
        "Road",
        "Square",
        "Street",
        "Terrace",
        "Walk",
        "Way",
    };
    
    internal static readonly string[] Scotland = new[]
    {
        "Brae",
        "Glen",
        "Law",
    };

    internal static class Bundles
    {
        internal static readonly ArrayOfArrays<string> Common = new(StreetSuffixes.Common);
        internal static readonly ArrayOfArrays<string> Scotland = new(StreetSuffixes.Common, StreetSuffixes.Scotland);
    }
}