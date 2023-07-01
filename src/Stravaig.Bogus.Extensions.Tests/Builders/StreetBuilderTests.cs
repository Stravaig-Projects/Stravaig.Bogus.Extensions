using System;
using Shouldly;
using Stravaig.Bogus.Extensions.Builders;

namespace Stravaig.Bogus.Extensions.Tests.Builders;

[TestFixture]
public class StreetBuilderTests
{
    public enum A
    {
        Null,
        Empty,
        Content,
    }
    
    private static readonly ArrayOfArrays<string> Prefixes = new(new[]
        {
            "East",
            "West",
            "North",
            "South",
            "High",
            "Lower",
        });
    
    private static readonly ArrayOfArrays<string> Names = new(new[]
    {
        "High",
        "South",
        "Station",
        "Church",
        "School",
        "Main",
        "Hill",
    });
    
    private static readonly ArrayOfArrays<string> Suffixes = new(new[]
    {
        "Street",
        "Road",
        "Hill",
    });
    
    [Test]
    [TestCase(false, -1, 0, 0, ExpectedResult = "High Street")]
    [TestCase(true, 1, 1, 1, ExpectedResult = "West South Road")]
    [TestCase(true, 3, 1, 1, ExpectedResult = "South Station Road")]
    [TestCase(true, 4, 1, 1, ExpectedResult = "High South Road")]
    [TestCase(false, 4, 6, 2, ExpectedResult = "Hill Street")]
    [TestCase(false, 4, 6, 1, ExpectedResult = "Hill Road")]
    [TestCase(false, 4, 5, 2, ExpectedResult = "Main Hill")]
    public string TestHappyPathScenarios(bool usePrefix, int prefixIndex, int nameIndex, int suffixIndex)
    {
        return new StreetBuilder()
        {
            UsePrefix = usePrefix,
            PrefixIndex = prefixIndex,
            Prefixes = Prefixes,
            Names = Names,
            NameIndex = nameIndex,
            Suffixes = Suffixes,
            SuffixIndex = suffixIndex,
        }.Generate();
    }

    [Test]
    public void MissingStringBuilderThrowsException()
    {
        var builder = new StreetBuilder()
        {
            UsePrefix = false,
            PrefixIndex = -1,
            Prefixes = Prefixes,
            Names = Names,
            NameIndex = -1,
            Suffixes = Suffixes,
            SuffixIndex = -1,  
        };
        Should.Throw<ArgumentNullException>(() => builder.Generate(null!))
            .ParamName.ShouldBe("sb");
    }
    
    [Test]
    // Prefixes
    [TestCase(-1, A.Content, 0, A.Content, 0, A.Content, ExpectedResult = "PrefixIndex, -1, is out of range; It must be between 0 and 5.")]
    [TestCase(6, A.Content, 0, A.Content, 0, A.Content, ExpectedResult = "PrefixIndex, 6, is out of range; It must be between 0 and 5.")]
    [TestCase(0, A.Null, 0, A.Content, 0, A.Content, ExpectedResult = "Prefixes should have content, but was null.")]
    [TestCase(0, A.Empty, 0, A.Content, 0, A.Content, ExpectedResult = "Prefixes should have content, but was empty.")]

    // Names
    [TestCase(0, A.Content, -1, A.Content, 0, A.Content, ExpectedResult = "NameIndex, -1, is out of range; It must be between 0 and 6.")]
    [TestCase(0, A.Content, 7, A.Content, 0, A.Content, ExpectedResult = "NameIndex, 7, is out of range; It must be between 0 and 6.")]
    [TestCase(0, A.Content, 0, A.Null, 0, A.Content, ExpectedResult = "Names should have content, but was null.")]
    [TestCase(0, A.Content, 0, A.Empty, 0, A.Content, ExpectedResult = "Names should have content, but was empty.")]

    // Suffixes
    [TestCase(0, A.Content, 0, A.Content, -1, A.Content, ExpectedResult = "SuffixIndex, -1, is out of range; It must be between 0 and 2.")]
    [TestCase(0, A.Content, 0, A.Content, 3, A.Content, ExpectedResult = "SuffixIndex, 3, is out of range; It must be between 0 and 2.")]
    [TestCase(0, A.Content, 0, A.Content, 0, A.Null, ExpectedResult = "Suffixes should have content, but was null.")]
    [TestCase(0, A.Content, 0, A.Content, 0, A.Empty, ExpectedResult = "Suffixes should have content, but was empty.")]
    public string ObjectStateIssueThrowsException(int prefixIndex, A prefixes, int nameIndex, A names, int suffixIndex, A suffixes)
    {
        var builder = new StreetBuilder
        {
            UsePrefix = true,
            PrefixIndex = prefixIndex,
            Prefixes = prefixes switch
            {
                A.Content => Prefixes,
                A.Empty => ArrayOfArrays<string>.Empty(),
                _ => null!,
            },
            NameIndex = nameIndex,
            Names = names switch
            {
                A.Content => Names,
                A.Empty => ArrayOfArrays<string>.Empty(),
                _ => null!,
            },
            SuffixIndex = suffixIndex,
            Suffixes = suffixes switch
            {
                A.Content => Suffixes,
                A.Empty => ArrayOfArrays<string>.Empty(),
                _ => null!,
            },
        };
        return Should.Throw<BuilderStatePropertyException>(() => builder.Generate())
            .Message;
    }
}