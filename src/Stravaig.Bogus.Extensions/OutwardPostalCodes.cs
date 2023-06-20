using Bogus.DataSets;

namespace Stravaig.Bogus.Extensions;

internal class OutwardPostalCodes
{
    internal string Code { get; init; }
    internal string PostTown { get; init; }
    internal string PostalCounty { get; init; }
    internal string?[] Localities { get; init; }

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
    };
    private static readonly int MaxIndex = Data.Length - 1;
}