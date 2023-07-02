using Shouldly;
using Stravaig.Bogus.Extensions.Builders;

namespace Stravaig.Bogus.Extensions.Tests.Builders;

[TestFixture]
public class SimpleFlatBuilderTests
{
    [Test]
    [TestCase(1, ExpectedResult = "Flat 1")]
    [TestCase(5, ExpectedResult = "Flat 5")]
    [TestCase(10, ExpectedResult = "Flat 10")]
    public string HappyPathScenarios(int flatNumber)
    {
        return new SimpleFlatBuilder
        {
            FlatNumber = flatNumber,
        }.Generate();
    }

    [Test]
    [TestCase(0, ExpectedResult = "FlatNumber, 0, is out of range; It must be between 1 and 10.")]
    [TestCase(11, ExpectedResult = "FlatNumber, 11, is out of range; It must be between 1 and 10.")]
    public string ObjectStateIssueThrowsException(int flatNumber)
    {
        var builder = new SimpleFlatBuilder()
        {
            FlatNumber = flatNumber,
        };

        return Should.Throw<BuilderStatePropertyException>(() => builder.Generate())
            .Message;
    }
}