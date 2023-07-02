using System.Text;
using Bogus;
using Bogus.DataSets;
using Stravaig.Bogus.Extensions.Builders;
using Stravaig.Bogus.Extensions.Data;

namespace Stravaig.Bogus.Extensions;

public static class ExtensionsForUkAddress
{
    public static string UkPostcode(this Address address)
    {
        var random = address.Random;
        var location = LocationInformation.GetRandom(random);
        var builder = PostCodeBuilder.Create(location, random);
        return builder.Generate();
    }

    public static string UkStreet(this Address address)
    {
        var random = address.Random;
        var location = LocationInformation.GetRandom(random);
        var builder = StreetBuilder.Create(location, random);
        return builder.Generate();
    }

    public static UkAddress UkAddress(this Address address)
    {
        var random = address.Random;
        var data = LocationInformation.GetRandom(random);

        return new()
        {
            SubBuilding = SubBuildingBuilder.Create(random).Generate(),
            StreetAddress = StreetBuilder.Create(data, random).Generate(),
            Locality = LocalityBuilder.Create(data, random).Generate(), // TODO: Locality Builder
            PostTown = data.PostTown,
            County = data.PostalCounty,
            Country = data.Country,
            Postcode = PostCodeBuilder.Create(data, random).Generate(),
        };
    }
}