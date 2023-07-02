using Shouldly;
using Stravaig.Bogus.Extensions.Builders;

namespace Stravaig.Bogus.Extensions.Tests.Builders;

[TestFixture]
public class FlatWithFloorBuilderTests
{
    [Test]
    [TestCase(-1, 1, ExpectedResult = "Flat LG/1")]
    [TestCase(0, 2, ExpectedResult = "Flat G/2")]
    [TestCase(6, 4, ExpectedResult = "Flat 6/4")]
    public string HappyPathScenarios(int floorNumber, int flatNumber)
    {
        return new FlatWithFloorBuilder()
        {
            FloorNumber = floorNumber,
            FlatNumber = flatNumber,
        }.Generate();
    }

    [Test]
    [TestCase(-2, 1, ExpectedResult = "FloorNumber, -2, is out of range; It must be between -1 and 6.")]
    [TestCase(7, 1, ExpectedResult = "FloorNumber, 7, is out of range; It must be between -1 and 6.")]
    [TestCase(1, 0, ExpectedResult = "FlatNumber, 0, is out of range; It must be between 1 and 4.")]
    [TestCase(1, 5, ExpectedResult = "FlatNumber, 5, is out of range; It must be between 1 and 4.")]
    public string ObjectStateIssueThrowsException(int floorNumber, int flatNumber)
    {
        var builder = new FlatWithFloorBuilder()
        {
            FloorNumber = floorNumber,
            FlatNumber = flatNumber,
        };

        return Should.Throw<BuilderStatePropertyException>(() => builder.Generate())
            .Message;
    }
}