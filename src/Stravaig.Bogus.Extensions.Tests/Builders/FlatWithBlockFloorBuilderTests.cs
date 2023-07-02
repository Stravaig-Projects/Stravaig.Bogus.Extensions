using Shouldly;
using Stravaig.Bogus.Extensions.Builders;

namespace Stravaig.Bogus.Extensions.Tests.Builders;

[TestFixture]
public class FlatWithBlockFloorBuilderTests
{
    [Test]
    [TestCase(0, 1, 1, ExpectedResult = "Block A, Flat 1/1")]
    [TestCase(2, 6, 3, ExpectedResult = "Block C, Flat 6/3")]
    [TestCase(5, 12, 4, ExpectedResult = "Block F, Flat 12/4")]
    public string HappyPathScenarios(int blockNumber, int floorNumber, int flatNumber)
    {
        return new FlatWithBlockAndFloorBuilder()
        {
            BlockNumber = blockNumber,
            FloorNumber = floorNumber,
            FlatNumber = flatNumber,
        }.Generate();
    }

    [Test]
    [TestCase(-1, 1, 1, ExpectedResult = "BlockNumber, -1, is out of range; It must be between 0 and 5.")]
    [TestCase(6, 1, 1, ExpectedResult = "BlockNumber, 6, is out of range; It must be between 0 and 5.")]
    [TestCase(0, -2, 1, ExpectedResult = "FloorNumber, -2, is out of range; It must be between 1 and 12.")]
    [TestCase(0, 13, 1, ExpectedResult = "FloorNumber, 13, is out of range; It must be between 1 and 12.")]
    [TestCase(0, 1, 0, ExpectedResult = "FlatNumber, 0, is out of range; It must be between 1 and 4.")]
    [TestCase(0, 1, 5, ExpectedResult = "FlatNumber, 5, is out of range; It must be between 1 and 4.")]
    public string ObjectStateIssueThrowsException(int blockNumber, int floorNumber, int flatNumber)
    {
        var builder = new FlatWithBlockAndFloorBuilder()
        {
            BlockNumber = blockNumber,
            FloorNumber = floorNumber,
            FlatNumber = flatNumber,
        };

        return Should.Throw<BuilderStatePropertyException>(() => builder.Generate())
            .Message;
    }
}