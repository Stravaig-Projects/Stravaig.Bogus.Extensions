using System.Linq;
using System.Text;
using Bogus.DataSets;

namespace Stravaig.Bogus.Extensions;

internal class OutwardPostalCodes
{
    internal required string Code { get; init; }
    internal required string PostTown { get; init; }
    internal required string PostalCounty { get; init; }
    internal required string?[] Localities { get; init; }

    public override string ToString()
    {
        // ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        StringBuilder sb = new StringBuilder();
        sb.Append(nameof(OutwardPostalCodes));
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

        sb.Append(", ");
        sb.Append(nameof(Localities));
        sb.Append(':');
        if (Localities == null)
            sb.Append("null");
        else
        {
            sb.Append('[');
            bool isFirst = true;
            foreach (var locality in Localities.OrderBy(l => l))
            {
                if (isFirst)
                    isFirst = false;
                else
                    sb.Append(", ");

                if (locality == null)
                    sb.Append("null");
                else
                {
                    sb.Append('"');
                    sb.Append(locality);
                    sb.Append('"');
                }
            }
            sb.Append(']');
        }
        
        sb.Append(')');
        return sb.ToString();
        // ReSharper restore ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
    }

    internal string? GetRandomLocality(Address address) =>
        Localities[address.Random.Number(0, Localities.Length - 1)];

    internal static OutwardPostalCodes GetRandom(Address address) =>
        Data[address.Random.Number(0, MaxIndex)];

    // From: 
    // https://en.wikipedia.org/wiki/List_of_postcode_districts_in_the_United_Kingdom
    private static readonly OutwardPostalCodes[] Data = new OutwardPostalCodes[]
    {
        new()
        {
            Code = "AB10",
            PostTown = "Aberdeen",
            PostalCounty = "Aberdeenshire",
            Localities = new[] {"Bridge of Dee", "Mannofield", "Ruthrieston"},
        },
        new()
        {
            Code = "AB11",
            PostTown = "Aberdeen",
            PostalCounty = "Aberdeenshire",
            Localities = new[] {"Ferryhill", "Torry"},
        },
        new()
        {
            Code = "AL5",
            PostTown = "Harpenden",
            PostalCounty = "Hertfordshire",
            Localities = new[] {null, "Kinsbourne Green"},
        },
        new()
        {
            Code="B90",
            PostTown = "Solihull",
            PostalCounty = "West Midlands",
            Localities = new[] {null, "Shirley", "Solihull Lodge", "Major's Green", "Dickens Heath", "Cheswick Green"},
        },
        new()
        {
            Code="BA1",
            PostTown = "Bath",
            PostalCounty = "Avon",
            Localities = new[]{ null, "Batheaston", "Bathford" },
        },
        new()
        {
            Code="BA2",
            PostTown = "Bath",
            PostalCounty = "Avon",
            Localities = new[]{ null, "Farmborough", "Timsbury", "Peasedown St John", "Wellow", "Hinton Charterhouse", "Norton St Philip", "Freshford", "Limpley Stoke" },
        },
        new()
        {
            Code="BB1",
            PostTown = "Blackburn",
            PostalCounty = "Lancashire",
            Localities = new[]{ null, "Bank Hey", "Belthorn", "Blackamoor", "Clayton-le-Dale", "Guide", "Knuzden", "Mellor", "Ramsgreave", "Rishton", "Salesbury", "Shadsworth", "Sunnybower", "Tottleworth", "Whitebirk", "Wilpshire"},
        },
        new()
        {
            Code="BD24",
            PostTown = "Settle",
            PostalCounty = "North Yorkshire",
            Localities = new[]{null, "Giggleswick", "Horton in Ribblesdale"},
        },
        new()
        {
            Code="BH12",
            PostTown = "Poole",
            PostalCounty = "Dorset",
            Localities = new[]{null, "Branksome", "Alderney", "Upper Parkstone", "Newtown", "Bournemouth University" },
        },
        new()
        {
            Code="BL7",
            PostTown = "Bolton",
            PostalCounty = "Lancashire",
            Localities = new[]{null, "Belmont", "Bromley Cross", "Chapeltown", "Edgworth", "Egerton", "Turton"},
        },
        new()
        {
            Code="BN22",
            PostTown = "Eastbourne",
            PostalCounty = "East Sussex",
            Localities = new[]{ null, "Old Town"},
        },
        new()
        {
            Code="BR6",
            PostTown = "Orpington",
            PostalCounty = "Kent",
            Localities = new[]{null, "Locksbottom", "Farnborough", "Crofton", "Chelsfield", "Downe", "Pratt's Bottom", "Well Hill" },
        },
        new()
        {
            Code="BS27",
            PostTown = "Cheddar",
            PostalCounty = "Somerset",
            Localities = new[]{null, "Draycott"},
        },
        new()
        {
            Code="BT38",
            PostTown = "Carrickfergus",
            PostalCounty = "County Antrim",
            Localities = new[]{null, "Ballycarry", "Greenisland", "Kilroot", "Whitehead"}
        },
        new()
        {
            Code="CA12",
            PostTown = "Keswick",
            PostalCounty = "Cumbria",
            Localities = new[] {null, "Seatoller", "Braithwaite", "Bassenthwaite", "Threlkeld"},
        },
        new()
        {
            Code="DD8",
            PostTown = "Forfar",
            PostalCounty = "Angus",
            Localities = new [] { null, "Glamis", "Letham" },
        },
        new()
        {
            Code="DD8",
            PostTown = "Kirriemuir",
            PostalCounty = "Angus",
            Localities = new string?[] { null },
        },
        new()
        {
            Code="EH1",
            PostTown = "Edinburgh",
            PostalCounty = "Midlothian",
            Localities = new[]{ "Old Town", null },
        },
        new()
        {
            Code="EH48",
            PostTown = "Bathgate",
            PostalCounty = "West Lothian",
            Localities = new [] { "Armadale", null },
        },
        new()
        {
            Code="FK1",
            PostTown = "Falkirk",
            PostalCounty = "Stirlingshire",
            Localities = new[]{null, "Avonbridge", "California", "Camelon", "Limerigg", "Shieldhill", "Slamannan", "Standburn"},
        },
        new()
        {
            Code="G1",
            PostTown = "Glasgow",
            PostalCounty = "Lanarkshire",
            Localities = new[]{"Merchant City", null},
        },
        new()
        {
            Code="G52",
            PostTown = "Glasgow",
            PostalCounty = "Lanarkshire",
            Localities = new[]{"Cardonald", "Hillington","Penilee", "Mosspark"},
        },
        new()
        {
            Code="HG1",
            PostTown = "Harrogate",
            PostalCounty = "North Yorkshire",
            Localities = new[]{null, "Bilton", "High Harrogate", "Jennyfields", "Duchy", "New Park"},
        },
        new()
        {
            Code="IG7",
            PostTown = "Chigwell",
            PostalCounty = "Essex",
            Localities = new[]{null, "Chigwell Row", "Hainault"}
        },
        new()
        {
            Code="IV25",
            PostTown = "Dornoch",
            PostalCounty = "Sutherland",
            Localities = new string?[]{null},
        },
        new()
        {
            Code="IV28",
            PostTown = "Rogart",
            PostalCounty = "Sutherland",
            Localities = new string?[]{null},
        },
        new()
        {
            Code="KA7",
            PostTown = "Ayr",
            PostalCounty = "Ayrshire",
            Localities = new[]{null, "Holmston", "Forehill", "Belmont", "Castlehill", "Kincaidson", "Alloway", "Doonfoot", "Masonhill", "Dunure"}
        },
        new()
        {
            Code="L40",
            PostTown="Ormskirk",
            PostalCounty = "Merseyside",
            Localities = new[]{null, "Burscough", "Holmeswood", "Mawdesley", "Scarisbrick", "Rufford"}
        },
        new()
        {
            Code="LL61",
            PostTown = "Llanfairpwllgwyngyll",
            PostalCounty = "Gwynedd",
            Localities = new[]{null, "Brynsiencyn", "Dwyran", "Newborough", "Penmynydd"}
        },
        new()
        {
            Code="M28",
            PostTown = "Manchester",
            PostalCounty = "Lancashire",
            Localities = new[]{"Worsley", "Walkden", "Boothstown", "Mosley Common", "Wardley"}
        },
        new()
        {
            Code="N4",
            PostTown = "London",
            PostalCounty = "London",
            Localities = new[]{"Finsbury Park", "Manor House", "Harringay", "Stroud Green"}
        },
        new()
        {
            Code="OX15",
            PostTown = "Banbury",
            PostalCounty = "Oxfordhire",
            Localities = new[]{"Bloxham", "Drayton", "Wroxton", "North Newington", "South Newington", "Swalcliffe", "Sibford Gower", "Sibford Ferris", "Barford St Michael", "Barford St John", "Deddington", "Hempton", "Broughton", "Hornton", "Horley", "Balscote", "Shenington", "Alkerton", "Wigginton", "Milton", "Hook Norton", "Milcombe", "Shutford", "Epwell", "Tadmarton", "Swerford", "Bodicote", "Brailes", "Edge Hill", "Ratley", "Upton", "Winderton"},
        },
        new()
        {
            Code="PA12",
            PostTown = "Lochwinnoch",
            PostalCounty = "Renfrewshire",
            Localities = new[]{ null, "Newton of Belltrees"},
        },
        new()
        {
            Code="RG22",
            PostTown = "Basingstoke",
            PostalCounty = "Hampshire",
            Localities = new[]{"South Ham", "Brighton Hill", "Kempshott", "Buckskin", "Beggarwood"},
        },
        new()
        {
            Code="SA12",
            PostTown = "Port Talbot",
            PostalCounty = "West Glamorgan",
            Localities = new[]{null, "Aberafan", "Aberavon", "Baglan", "Cwmafan", "Sandfields"},
        },
        new()
        {
            Code="TD14",
            PostTown = "Eyemouth",
            PostalCounty = "Berwickshire",
            Localities = new[]{null, "Coldingham", "St Abbs", "Ayton", "Burnmouth", "Reston", "Auchencrow", "Houndwood"}
        },
        new()
        {
            Code="UB7",
            PostTown = "West Drayton",
            PostalCounty = "Middlesex",
            Localities = new[]{null, "Harmondsworth", "Sipson", "Yiewsley", "Longford"}
        },
        new()
        {
            Code="W5",
            PostTown = "London",
            PostalCounty = "London",
            Localities = new[]{"Ealing", "South Ealing", "Ealing Common", "North Ealing", "Northfields", "Pitshanger", "Hanger Lane"},
        },
        new()
        {
            Code="YO10",
            PostTown = "York",
            PostalCounty = "North Yorkshire",
            Localities = new[]{"Fishergate", "Fulford", "Heslington", "Osbaldwick", "Tang Hall"},
        },
        new()
        {
            Code="ZE2",
            PostTown = "Shetland",
            PostalCounty = "Shetland",
            Localities = new[]{"Mainland", "Yell", "Unst", "Fetlar", "Foula", "Fair Isle"}
        },
    };
    private static readonly int MaxIndex = Data.Length - 1;
}