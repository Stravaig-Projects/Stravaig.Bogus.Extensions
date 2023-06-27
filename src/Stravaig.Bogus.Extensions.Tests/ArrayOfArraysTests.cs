using System;
using System.Linq;
using Shouldly;

namespace Stravaig.Bogus.Extensions.Tests;

[TestFixture]
public class ArrayOfArraysTests
{
    [Test]
    public void EmptyArrayHasCountOfZero()
    {
        var emptyAoA = new ArrayOfArrays<string>(Array.Empty<string[]>());
        emptyAoA.Count.ShouldBe(0);
        emptyAoA.Any().ShouldBeFalse();
    }

    [Test]
    public void SingleArrayEnumeratesLikeSource()
    {
        var source = new[] {"a", "b", "c", "d", "e"};
        var aOfA = new ArrayOfArrays<string>(source);
        
        aOfA.Count.ShouldBe(source.Length);
        for (int i = 0; i < aOfA.Count; i++)
        {
            aOfA[i].ShouldBe(source[i], $"{nameof(aOfA)}[{i}].ShouldBe({source[i]})");
        }
    }
    
    [Test]
    public void DoubleArrayEnumeratesLikeSourceTwiceOver()
    {
        var source = new[] {"a", "b", "c", "d", "e"};
        var aOfA = new ArrayOfArrays<string>(source, source);
        
        aOfA.Count.ShouldBe(source.Length * 2);
        for (int i = 0; i < aOfA.Count; i++)
        {
            aOfA[i].ShouldBe(source[i % source.Length], $"{nameof(aOfA)}[{i}].ShouldBe({source[i % source.Length]})");
        }
    }

    [Test]
    public void TripleArrayEnumeratesLikeSourceTwiceOver()
    {
        var source = new[] {"a", "b", "c", "d", "e"};
        var aOfA = new ArrayOfArrays<string>(source, source, source);
        
        aOfA.Count.ShouldBe(source.Length * 3);
        for (int i = 0; i < aOfA.Count; i++)
        {
            aOfA[i].ShouldBe(source[i % source.Length], $"{nameof(aOfA)}[{i}].ShouldBe({source[i % source.Length]})");
        }
    }
}