using System;
using System.Security.AccessControl;
using System.Text;
using Bogus;

// ReSharper disable StringLiteralTypo

namespace Stravaig.Bogus.Extensions.Data;

internal class LocationInformation
{
    internal required string Code { get; init; }
    internal required string PostTown { get; init; }
    internal string? PostalCounty { get; init; }
    internal required string?[] Localities { get; init; }
    
    internal required string Country { get; init; }

    internal ArrayOfArrays<string> StreetPrefixLists { get; init; } = ArrayOfArrays<string>.Empty();

    internal ArrayOfArrays<string> StreetNameLists { get; init; } = ArrayOfArrays<string>.Empty();

    internal ArrayOfArrays<string> StreetSuffixLists { get; init; } = ArrayOfArrays<string>.Empty();

    public override string ToString()
    {
        // ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        StringBuilder sb = new StringBuilder();
        sb.Append(nameof(LocationInformation));
        sb.Append('(');
        sb.Append(nameof(Code));
        sb.Append(':');
        if (Code == null)
            sb.Append("null");
        else
        {
            sb.Append('"');
            sb.Append(Code);
            sb.Append('"');
        }

        sb.Append(", ");

        sb.Append(nameof(PostTown));
        sb.Append(':');
        if (PostTown == null)
            sb.Append("null");
        else
        {
            sb.Append('"');
            sb.Append(PostTown);
            sb.Append('"');
        }

        sb.Append(", ");
        sb.Append(nameof(PostalCounty));
        sb.Append(':');
        if (PostalCounty == null)
            sb.Append("null");
        else
        {
            sb.Append('"');
            sb.Append(PostalCounty);
            sb.Append('"');
        }
        
        sb.Append(')');
        return sb.ToString();
        // ReSharper restore ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
    }

    internal static LocationInformation GetRandom(Randomizer random)
    {
        int index = random.Number(0, MaxIndex);
        return Data[index];
    }
    
    // From: 
    // https://en.wikipedia.org/wiki/List_of_postcode_districts_in_the_United_Kingdom
    private static readonly LocationInformation[] Data = new LocationInformation[]
    {
        new()
        {
            Code = "AB10",
            PostTown = "Aberdeen",
            PostalCounty = "Aberdeenshire",
            Localities = new[] {"Bridge of Dee", "Mannofield", "Ruthrieston"},
            Country = "Scotland",
            StreetPrefixLists = StreetPrefixes.Bundles.Common,
            StreetNameLists = StreetNames.Bundles.Scotland,
            StreetSuffixLists = StreetSuffixes.Bundles.Scotland,
        },
        new()
        {
            Code = "AB11",
            PostTown = "Aberdeen",
            PostalCounty = "Aberdeenshire",
            Localities = new[] {"Ferryhill", "Torry"},
            Country = "Scotland",
            StreetPrefixLists = StreetPrefixes.Bundles.Common,
            StreetNameLists = StreetNames.Bundles.Scotland,
            StreetSuffixLists = StreetSuffixes.Bundles.Scotland,
        },
        new()
        {
            Code = "AL5",
            PostTown = "Harpenden",
            PostalCounty = "Hertfordshire",
            Country = "England",
            Localities = new[] {null, "Kinsbourne Green"},
        },
        new()
        {
            Code="B90",
            PostTown = "Solihull",
            PostalCounty = "West Midlands",
            Country = "England",
            Localities = new[] {null, "Shirley", "Solihull Lodge", "Major's Green", "Dickens Heath", "Cheswick Green"},
        },
        new()
        {
            Code="BA1",
            PostTown = "Bath",
            PostalCounty = "Avon",
            Country = "England",
            Localities = new[]{ null, "Batheaston", "Bathford" },
        },
        new()
        {
            Code="BA2",
            PostTown = "Bath",
            PostalCounty = "Avon",
            Country = "England",
            Localities = new[]{ null, "Farmborough", "Timsbury", "Peasedown St John", "Wellow", "Hinton Charterhouse", "Norton St Philip", "Freshford", "Limpley Stoke" },
        },
        new()
        {
            Code="BB1",
            PostTown = "Blackburn",
            PostalCounty = "Lancashire",
            Country = "England",
            Localities = new[]{ null, "Bank Hey", "Belthorn", "Blackamoor", "Clayton-le-Dale", "Guide", "Knuzden", "Mellor", "Ramsgreave", "Rishton", "Salesbury", "Shadsworth", "Sunnybower", "Tottleworth", "Whitebirk", "Wilpshire"},
        },
        new()
        {
            Code="BD24",
            PostTown = "Settle",
            PostalCounty = "North Yorkshire",
            Country = "England",
            Localities = new[]{null, "Giggleswick", "Horton in Ribblesdale"},
        },
        new()
        {
            Code="BH12",
            PostTown = "Poole",
            PostalCounty = "Dorset",
            Country = "England",
            Localities = new[]{null, "Branksome", "Alderney", "Upper Parkstone", "Newtown", "Bournemouth University" },
        },
        new()
        {
            Code="BL7",
            PostTown = "Bolton",
            PostalCounty = "Lancashire",
            Country = "England",
            Localities = new[]{null, "Belmont", "Bromley Cross", "Chapeltown", "Edgworth", "Egerton", "Turton"},
        },
        new()
        {
            Code="BN22",
            PostTown = "Eastbourne",
            PostalCounty = "East Sussex",
            Country = "England",
            Localities = new[]{ null, "Old Town"},
        },
        new()
        {
            Code="BR6",
            PostTown = "Orpington",
            PostalCounty = "Kent",
            Country = "England",
            Localities = new[]{null, "Locksbottom", "Farnborough", "Crofton", "Chelsfield", "Downe", "Pratt's Bottom", "Well Hill" },
        },
        new()
        {
            Code="BS27",
            PostTown = "Cheddar",
            PostalCounty = "Somerset",
            Country = "England",
            Localities = new[]{null, "Draycott"},
        },
        new()
        {
            Code="BT38",
            PostTown = "Carrickfergus",
            PostalCounty = "County Antrim",
            Country = "Northern Ireland",
            Localities = new[]{null, "Ballycarry", "Greenisland", "Kilroot", "Whitehead"}
        },
        new()
        {
            Code="CA12",
            PostTown = "Keswick",
            PostalCounty = "Cumbria",
            Country = "England",
            Localities = new[] {null, "Seatoller", "Braithwaite", "Bassenthwaite", "Threlkeld"},
        },
        new()
        {
            Code="CB8",
            PostTown = "Newmarket",
            PostalCounty = "Suffolk",
            Country = "England",
            Localities = new[]{null, "Ashley", "Brinkley", "Burrough End", "Burrough Green", "Carlton", "Cheveley", "Clopton Green", "Cowlinge", "Dalham", "Denston", "Ditton Green", "Dullingham", "Dunstall Green", "Exning", "Gazeley", "Great Bradley", "Kennett", "Kentford", "Kirtling", "Kirtling Green", "Lady's Green", "Landwade", "Lidgate", "Moulton", "Ousden", "Six Mile Bottom", "Snailwell", "Stetchworth", "Stradishall", "Thorns", "Upend", "Westley Waterless", "Wickhambrook", "Woodditton"},
        },
        new()
        {
            Code="CF24",
            PostTown = "Cardiff",
            PostalCounty = "South Glamorgan",
            Country = "Wales",
            Localities = new[]{null, "Cathays", "Roath", "Plasnewydd", "Splott", "Adamsdown"},
        },
        new()
        {
            Code="CH4",
            PostTown = "Chester",
            PostalCounty = "Cheshire",
            Country = "England",
            Localities = new[]{null, "Chester", "Curzon Park", "Handbridge", "Lache", "Pulford", "Penyffordd", "Broughton", "Saltney"},
        },
        new()
        {
            Code="CM2",
            PostTown = "Chelmsford",
            PostalCounty = "Essex",
            Country = "England",
            Localities = Array.Empty<string>(),
        },
        new()
        {
            Code="DD8",
            PostTown = "Forfar",
            PostalCounty = "Angus",
            Country = "Scotland",
            Localities = new [] { null, "Glamis", "Letham" },
            StreetPrefixLists = StreetPrefixes.Bundles.Common,
            StreetNameLists = StreetNames.Bundles.Scotland,
            StreetSuffixLists = StreetSuffixes.Bundles.Scotland,
        },
        new()
        {
            Code="DD8",
            PostTown = "Kirriemuir",
            PostalCounty = "Angus",
            Country = "Scotland",
            Localities = Array.Empty<string>(),
            StreetPrefixLists = StreetPrefixes.Bundles.Common,
            StreetNameLists = StreetNames.Bundles.Scotland,
            StreetSuffixLists = StreetSuffixes.Bundles.Scotland,
        },
        new()
        {
            Code="EH1",
            PostTown = "Edinburgh",
            PostalCounty = "Midlothian",
            Country = "Scotland",
            Localities = new[]{ "Old Town", null },
            StreetPrefixLists = StreetPrefixes.Bundles.Common,
            StreetNameLists = StreetNames.Bundles.Scotland,
            StreetSuffixLists = StreetSuffixes.Bundles.Scotland,
        },
        new()
        {
            Code="EH48",
            PostTown = "Bathgate",
            PostalCounty = "West Lothian",
            Country = "Scotland",
            Localities = new [] { "Armadale", null },
            StreetPrefixLists = StreetPrefixes.Bundles.Common,
            StreetNameLists = StreetNames.Bundles.Scotland,
            StreetSuffixLists = StreetSuffixes.Bundles.Scotland,
        },
        new()
        {
            Code="FK1",
            PostTown = "Falkirk",
            PostalCounty = "Stirlingshire",
            Country = "Scotland",
            Localities = new[]{null, "Avonbridge", "California", "Camelon", "Limerigg", "Shieldhill", "Slamannan", "Standburn"},
            StreetPrefixLists = StreetPrefixes.Bundles.Common,
            StreetNameLists = StreetNames.Bundles.Scotland,
            StreetSuffixLists = StreetSuffixes.Bundles.Scotland,
        },
        new()
        {
            Code="G1",
            PostTown = "Glasgow",
            PostalCounty = "Lanarkshire",
            Country = "Scotland",
            Localities = new[]{"Merchant City", null},
            StreetPrefixLists = StreetPrefixes.Bundles.Common,
            StreetNameLists = StreetNames.Bundles.Scotland,
            StreetSuffixLists = StreetSuffixes.Bundles.Scotland,
        },
        new()
        {
            Code="G52",
            PostTown = "Glasgow",
            PostalCounty = "Lanarkshire",
            Country = "Scotland",
            Localities = new[]{"Cardonald", "Hillington","Penilee", "Mosspark"},
            StreetPrefixLists = StreetPrefixes.Bundles.Common,
            StreetNameLists = StreetNames.Bundles.Scotland,
            StreetSuffixLists = StreetSuffixes.Bundles.Scotland,
        },
        new()
        {
            Code="HG1",
            PostTown = "Harrogate",
            PostalCounty = "North Yorkshire",
            Country = "England",
            Localities = new[]{null, "Bilton", "High Harrogate", "Jennyfields", "Duchy", "New Park"},
        },
        new()
        {
            Code="IG7",
            PostTown = "Chigwell",
            PostalCounty = "Essex",
            Country = "England",
            Localities = new[]{null, "Chigwell Row", "Hainault"}
        },
        new()
        {
            Code="IV25",
            PostTown = "Dornoch",
            PostalCounty = "Sutherland",
            Country = "Scotland",
            Localities = new string?[]{null},
            StreetPrefixLists = StreetPrefixes.Bundles.Common,
            StreetNameLists = StreetNames.Bundles.Scotland,
            StreetSuffixLists = StreetSuffixes.Bundles.Scotland,
        },
        new()
        {
            Code="IV28",
            PostTown = "Rogart",
            PostalCounty = "Sutherland",
            Country = "Scotland",
            Localities = new string?[]{null},
            StreetPrefixLists = StreetPrefixes.Bundles.Common,
            StreetNameLists = StreetNames.Bundles.Scotland,
            StreetSuffixLists = StreetSuffixes.Bundles.Scotland,
        },
        new()
        {
            Code="KA7",
            PostTown = "Ayr",
            PostalCounty = "Ayrshire",
            Country = "Scotland",
            Localities = new[]{null, "Holmston", "Forehill", "Belmont", "Castlehill", "Kincaidson", "Alloway", "Doonfoot", "Masonhill", "Dunure"},
            StreetPrefixLists = StreetPrefixes.Bundles.Common,
            StreetNameLists = StreetNames.Bundles.Scotland,
            StreetSuffixLists = StreetSuffixes.Bundles.Scotland,
        },
        new()
        {
            Code="L40",
            PostTown="Ormskirk",
            PostalCounty = "Merseyside",
            Country = "England",
            Localities = new[]{null, "Burscough", "Holmeswood", "Mawdesley", "Scarisbrick", "Rufford"}
        },
        new()
        {
            Code="LL61",
            PostTown = "Llanfairpwllgwyngyll",
            PostalCounty = "Gwynedd",
            Country = "Wales",
            Localities = new[]{null, "Brynsiencyn", "Dwyran", "Newborough", "Penmynydd"}
        },
        new()
        {
            Code="M28",
            PostTown = "Manchester",
            PostalCounty = "Lancashire",
            Country = "England",
            Localities = new[]{"Worsley", "Walkden", "Boothstown", "Mosley Common", "Wardley"}
        },
        new()
        {
            Code="N4",
            PostTown = "London",
            Country = "England",
            Localities = new[]{"Finsbury Park", "Manor House", "Harringay", "Stroud Green"}
        },
        new()
        {
            Code="OX15",
            PostTown = "Banbury",
            PostalCounty = "Oxfordhire",
            Country = "England",
            Localities = new[]{"Bloxham", "Drayton", "Wroxton", "North Newington", "South Newington", "Swalcliffe", "Sibford Gower", "Sibford Ferris", "Barford St Michael", "Barford St John", "Deddington", "Hempton", "Broughton", "Hornton", "Horley", "Balscote", "Shenington", "Alkerton", "Wigginton", "Milton", "Hook Norton", "Milcombe", "Shutford", "Epwell", "Tadmarton", "Swerford", "Bodicote", "Brailes", "Edge Hill", "Ratley", "Upton", "Winderton"},
        },
        new()
        {
            Code="PA12",
            PostTown = "Lochwinnoch",
            PostalCounty = "Renfrewshire",
            Localities = new[]{ null, "Newton of Belltrees"},
            Country = "Scotland",
            StreetPrefixLists = StreetPrefixes.Bundles.Common,
            StreetNameLists = StreetNames.Bundles.Scotland,
            StreetSuffixLists = StreetSuffixes.Bundles.Scotland,
        },
        new()
        {
            Code="RG22",
            PostTown = "Basingstoke",
            PostalCounty = "Hampshire",
            Country = "England",
            Localities = new[]{"South Ham", "Brighton Hill", "Kempshott", "Buckskin", "Beggarwood"},
        },
        new()
        {
            Code="SA12",
            PostTown = "Port Talbot",
            PostalCounty = "West Glamorgan",
            Country = "Wales",
            Localities = new[]{null, "Aberafan", "Aberavon", "Baglan", "Cwmafan", "Sandfields"},
        },
        new()
        {
            Code="TD14",
            PostTown = "Eyemouth",
            PostalCounty = "Berwickshire",
            Country = "Scotland",
            Localities = new[]{null, "Coldingham", "St Abbs", "Ayton", "Burnmouth", "Reston", "Auchencrow", "Houndwood"}
        },
        new()
        {
            Code="UB7",
            PostTown = "West Drayton",
            PostalCounty = "Middlesex",
            Country = "England",
            Localities = new[]{null, "Harmondsworth", "Sipson", "Yiewsley", "Longford"}
        },
        new()
        {
            Code="W5",
            PostTown = "London",
            Country = "England",
            Localities = new[]{"Ealing", "South Ealing", "Ealing Common", "North Ealing", "Northfields", "Pitshanger", "Hanger Lane"},
        },
        new()
        {
            Code="YO10",
            PostTown = "York",
            PostalCounty = "North Yorkshire",
            Country = "England",
            Localities = new[]{"Fishergate", "Fulford", "Heslington", "Osbaldwick", "Tang Hall"},
        },
        new()
        {
            Code="ZE2",
            PostTown = "Shetland",
            PostalCounty = "Shetland",
            Country = "Scotland",
            Localities = new[]{"Mainland", "Yell", "Unst", "Fetlar", "Foula", "Fair Isle"}
        },
    };

    private static readonly int MaxIndex = Data.Length - 1;
}