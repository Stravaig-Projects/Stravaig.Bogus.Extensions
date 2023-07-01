using System.ComponentModel.DataAnnotations;
using System.Text;
using Bogus.DataSets;
using Stravaig.Bogus.Extensions.Builders;
using Stravaig.Bogus.Extensions.Data;

namespace Stravaig.Bogus.Extensions;

public static class UkStreet
{
    private const float LikelihoodOfPrefix = 0.02f; // 2% of streets have a prefix

    internal static string GenerateStreetName(this Address address, LocationInformation generalLocation)
    {
        StringBuilder sb = new StringBuilder();
        address.GenerateStreetName(generalLocation, sb);
        return sb.ToString();
    }

    internal static void GenerateStreetName(this Address address, LocationInformation generalLocation, StringBuilder sb)
    {
        var builder = new StreetBuilder
        {
            UsePrefix = address.Random.Bool(LikelihoodOfPrefix),
            Prefixes = generalLocation.StreetPrefixLists,
            PrefixIndex = address.Random.Number(0, generalLocation.StreetPrefixLists.MaxIndex),
            Names = generalLocation.StreetNameLists,
            NameIndex = address.Random.Number(0, generalLocation.StreetNameLists.MaxIndex),
            Suffixes = generalLocation.StreetSuffixLists,
            SuffixIndex = address.Random.Number(0, generalLocation.StreetSuffixLists.MaxIndex),
        };
        
        builder.Generate(sb); 
    }
}