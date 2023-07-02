using System;
using Shouldly;
using Stravaig.Bogus.Extensions.Builders;
using Stravaig.Bogus.Extensions.Data;

namespace Stravaig.Bogus.Extensions.Tests.Builders;

[TestFixture]
public class PostCodeBuilderTests
{
    private static LocationInformation Location
    {
        get
        {
            var location = new LocationInformation()
            {
                Code = "AB10",
                PostTown = "Aberdeen",
                PostalCounty = "Aberdeenshire",
                Localities = new[] {"Bridge of Dee", "Mannofield", "Ruthrieston"},
                Country = "Scotland",
                StreetPrefixLists = StreetPrefixes.Bundles.Common,
                StreetNameLists = StreetNames.Bundles.Scotland,
                StreetSuffixLists = StreetSuffixes.Bundles.Scotland,
            };
            return location;
        }
    }
    
    [Test]
    [TestCase(1,0,0, ExpectedResult = "AB10 1AA")]
    [TestCase(1,2,3, ExpectedResult = "AB10 1DE")]
    [TestCase(9,19,19, ExpectedResult = "AB10 9ZZ")]
    public string HappyPathScenarios(int number, int i1, int i2)
    {
        return new PostCodeBuilder()
        {
            Location = Location,
            Number = number,
            Letter1Index = i1,
            Letter2Index = i2,
        }.Generate();
    }
    
    [Test]
    public void MissingStringBuilderThrowsException()
    {
        var builder = new PostCodeBuilder()
        {
            Location = Location,
            Number = 1,
            Letter1Index = 1,
            Letter2Index = 1,
        };
        Should.Throw<ArgumentNullException>(() => builder.Generate(null!))
            .ParamName.ShouldBe("sb");
    }

    [Test]
    [TestCase(false, 1, 1, 1, ExpectedResult = "Location should have content, but was null.")]
    [TestCase(true, 0, 1, 1, ExpectedResult = "Number, 0, is out of range; It must be between 1 and 9.")]
    [TestCase(true, 10, 1, 1, ExpectedResult = "Number, 10, is out of range; It must be between 1 and 9.")]
    [TestCase(true, 1, -1, 1, ExpectedResult = "Letter1Index, -1, is out of range; It must be between 0 and 19.")]
    [TestCase(true, 1, 20, 1, ExpectedResult = "Letter1Index, 20, is out of range; It must be between 0 and 19.")]
    [TestCase(true, 1, 1, -1, ExpectedResult = "Letter2Index, -1, is out of range; It must be between 0 and 19.")]
    [TestCase(true, 1, 1, 20, ExpectedResult = "Letter2Index, 20, is out of range; It must be between 0 and 19.")]
    public string ObjectStateIssueThrowsException(bool useLocation, int number, int i1, int i2)
    {
        var builder = new PostCodeBuilder()
        {
            Location = useLocation ? Location : null!,
            Number = number,
            Letter1Index = i1,
            Letter2Index = i2,
        };
        
        return Should.Throw<BuilderStatePropertyException>(() => builder.Generate())
            .Message;
    }
}