using System.Text;
using Bogus.DataSets;

namespace Stravaig.Bogus.Extensions;

public static class UkStreet
{
    private const float LikelihoodOfCardinalDirection = 0.01f;
    public static string GenerateStreetName(this Address address, StringBuilder? sb = null)
    {
        sb ??= new();
        var hasCardinalDirection = address.Random.Bool(LikelihoodOfCardinalDirection);
        if (hasCardinalDirection)
        {
            sb.Append(address.CardinalDirection());
            sb.Append(" ");
        }

        var name = Names[address.Random.Number(0, NamesMaxIndex)];
        sb.Append(name);
        sb.Append(" ");

        var suffix = name;
        while (suffix == name)
        {
            suffix = Suffix[address.Random.Number(0, SuffixMaxIndex)];
        }

        sb.Append(suffix);
        return sb.ToString();
    }
    
    private static readonly string[] Suffix = new[]
    {
        "Avenue",
        "Brae",
        "Close",
        "Crescent",
        "Cross",
        "Drive",
        "Hill",
        "Lane",
        "Mews",
        "Park",
        "Road",
        "Square",
        "Street",
        "Terrace",
        "Way",
    };

    private static readonly int SuffixMaxIndex = Suffix.Length - 1;
    
    private static string[] Names = new[]
    {
        "Bank",
        "Bridge",
        "Castle",
        "Church",
        "Green",
        "High",
        "Hill",
        "Main",
        "Manse",
        "Mill",
        "New",
        "School",
        "Station",
        "Union",
        "Park",
        "The",
        "John",
        "Market",
        "Cross",
        "Commercial",
        "Water",
        "Ash",
        "Bryn",
        "Brook",
        "Railway",
        "Shore",
        "Back",
        "Gate",
        "Chapel",
        "Orchard",
        "Manor",
        "Queen",
        "King",
        "Victoria",
        "George",
        "Edward",
        "Elizabeth",
        "Charles",
        "James",
        "Sandy",
        "Brown",
        "Aberdeen",
        "Birmingham",
        "Bristol",
        "Cardiff",
        "Carlisle",
        "Cambridge",
        "Dundee",
        "Dornoch",
        "Dover",
        "Dunfermline",
        "Edinburgh",
        "Falkirk",
        "Glasgow",
        "Grimsby",
        "Helensburgh",
        "Inverness",
        "Ipswich",
        "Jedburgh",
        "Keswick",
        "Kilmarnock",
        "Kingussie",
        "London",
        "Liverpool",
        "Maidenhead",
        "Manchester",
        "Norwich",
        "Newbridge",
        "Oxford",
        "Paisley",
        "Perth",
        "Preston",
        "Queensferry",
        "Reading",
        "Stevenage",
        "Stirling",
        "Swansea",
        "Taunton",
        "Thomson",
        "Uxbridge",
        "Vauxhall",
        "Weymouth",
        "York",
    };

    private static readonly int NamesMaxIndex = Names.Length - 1;
}