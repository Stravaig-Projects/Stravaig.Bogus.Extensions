namespace Stravaig.Bogus.Extensions.Data;

internal static class StreetPrefixes
{
    internal static readonly string[] Common = new[]
    {
        "East",
        "High",
        "Lower",
        "North",
        "South",
        "Upper",
        "West",
    };

    internal static class Bundles
    {
        internal static readonly ArrayOfArrays<string> Common = new(StreetPrefixes.Common);
    }
}