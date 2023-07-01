namespace Stravaig.Bogus.Extensions.Data;

internal static class StreetPrefixes
{
    internal static readonly string[] Common = new[]
    {
        "East",
        "Eastern",
        "High",
        "Lower",
        "North",
        "Northern",
        "South",
        "Southern",
        "Upper",
        "West",
        "Western",
    };

    internal static class Bundles
    {
        internal static readonly ArrayOfArrays<string> Common = new(StreetPrefixes.Common);
    }
}