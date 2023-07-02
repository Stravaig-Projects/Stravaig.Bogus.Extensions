using Shouldly;
using Stravaig.Bogus.Extensions.Builders;

namespace Stravaig.Bogus.Extensions.Tests.Builders;

[TestFixture]
public class HighRiseFlatBuilderTests
{
    [Test]
    [TestCase(1, 0, ExpectedResult = "Flat 1-A")]
    [TestCase(16, 2, ExpectedResult = "Flat 16-C")]
    [TestCase(32, 3, ExpectedResult = "Flat 32-D")]
    public string HappyPathScenarios(int floorNumber, int flatNumber)
    {
        return new HighRiseFlatBuilder
        {
            FloorNumber = floorNumber,
            FlatNumber = flatNumber,
        }.Generate();
    }

    [Test]
    [TestCase(0, 1, ExpectedResult = "FloorNumber, 0, is out of range; It must be between 1 and 32.")]
    [TestCase(33, 1, ExpectedResult = "FloorNumber, 33, is out of range; It must be between 1 and 32.")]
    [TestCase(1, -1, ExpectedResult = "FlatNumber, -1, is out of range; It must be between 0 and 3.")]
    [TestCase(1, 4, ExpectedResult = "FlatNumber, 4, is out of range; It must be between 0 and 3.")]
    public string ObjectStateIssueThrowsException(int floorNumber, int flatNumber)
    {
        var builder = new HighRiseFlatBuilder
        {
            FloorNumber = floorNumber,
            FlatNumber = flatNumber,
        };

        return Should.Throw<BuilderStatePropertyException>(() => builder.Generate())
            .Message;
    }
}