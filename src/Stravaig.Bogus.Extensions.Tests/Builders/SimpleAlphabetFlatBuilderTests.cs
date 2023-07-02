using Shouldly;
using Stravaig.Bogus.Extensions.Builders;

namespace Stravaig.Bogus.Extensions.Tests.Builders;

[TestFixture]
public class SimpleAlphabetFlatBuilderTests
{
    [Test]
    [TestCase(0, ExpectedResult = "Flat A")]
    [TestCase(3, ExpectedResult = "Flat D")]
    [TestCase(7, ExpectedResult = "Flat H")]
    public string HappyPathScenarios(int flatNumber)
    {
        return new SimpleAlphabetFlatBuilder
        {
            FlatNumber = flatNumber,
        }.Generate();
    }

    [Test]
    [TestCase(-1, ExpectedResult = "FlatNumber, -1, is out of range; It must be between 0 and 7.")]
    [TestCase(8, ExpectedResult = "FlatNumber, 8, is out of range; It must be between 0 and 7.")]
    public string ObjectStateIssueThrowsException(int flatNumber)
    {
        var builder = new SimpleAlphabetFlatBuilder
        {
            FlatNumber = flatNumber,
        };

        return Should.Throw<BuilderStatePropertyException>(() => builder.Generate())
            .Message;
    }
}