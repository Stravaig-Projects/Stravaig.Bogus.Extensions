namespace Stravaig.Bogus.Extensions.Data;

internal static class StreetNames
{
    public static string[] Common = new[]
    {
        // General
        "High",
        "Main",
        "New",
        "The",
        "Back",
        "Gate",
        "Sandy",

       
        // Trees
        "Ash",
        "Birch",
        "Chestnut",
        "Elm",
        "Fir",
        "Hazel",
        "Holly",
        "Juniper",
        "Larch",
        "Laurel",
        "Lime",
        "Maple",
        "Oak",
        "Orchard",
        "Pine",
        "Poplar",
        "Rowan",
        "Spruce",
        "Willow",
        "Yew",

        // Colour
        "Black",
        "Brown",
        "Green",

        // Names
        "Andrew",
        "Charles",
        "Charlotte",
        "Edward",
        "Elizabeth",
        "George",
        "James",
        "John",
        "Thomson",
        "Victoria",

        // Saints
        "St. Andrew",
        "St. David",
        "St. George",
        "St. John",
        "St. Mary",
        "St. Matthew",
        "St. Patrick",
        "St. Peter",
        "St. Paul",

        // Building / Infrastructure
        "Academy",
        "Bank",
        "Bridge",
        "Castle",
        "Chapel",
        "Church",
        "Manor",
        "Manse",
        "Mill",
        "Railway",
        "School",
        "Station",
        
        // Geography
        "Brook",
        "Cross",
        "Hill",
        "Park",
        "Shore",
        "Water",

        // Political
        "Baron",
        "Duchess",
        "Duke",
        "Earl",
        "King",
        "Prince",
        "Princes",
        "Princess",
        "Queen",
        "Union",

        // Commerce
        "Commercial",
        "Market",
        
        // Places
        "Avon",
        "Birmingham",
        "Bristol",
        "Cardiff",
        "Carlisle",
        "Cambridge",
        "Dover",
        "Grimsby",
        "Inverness",
        "Ipswich",
        "Jedburgh",
        "Keswick",
        "London",
        "Liverpool",
        "Maidenhead",
        "Manchester",
        "Norwich",
        "Newbridge",
        "Oxford",
        "Preston",
        "Queensferry",
        "Reading",
        "Stevenage",
        "Swansea",
        "Taunton",
        "Uxbridge",
        "Vauxhall",
        "Weymouth",
        "York",
        
        //         "Bryn",

    };
    
    internal static string[] Scotland = new[]
    {
        // General
        "Burn",
        "Burnside",
        "Glen",
        "Kirk",
        "Strath",
        
        // Rivers
        "Almond",
        "Clyde",
        "Cromarty",
        "Don",
        "Eden",
        "Esk",
        "Forth",
        "Spey",
        "Tweed",
        
        // Places
        "Aberdeen",
        "Dundee",
        "Dornoch",
        "Dunfermline",
        "Edinburgh",
        "Falkirk",
        "Glasgow",
        "Helensburgh",
        "Kilmarnock",
        "Kingussie",
        "Paisley",
        "Perth",
        "Stirling",
        "Strathspey",
    };

    internal static class Bundles
    {
        internal static readonly ArrayOfArrays<string> Common = new(StreetNames.Common);
        internal static readonly ArrayOfArrays<string> Scotland = new(StreetNames.Common, StreetNames.Scotland);
    }
}