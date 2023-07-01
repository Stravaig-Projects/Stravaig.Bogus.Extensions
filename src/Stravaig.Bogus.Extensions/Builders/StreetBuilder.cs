using System;
using System.Collections.Immutable;
using System.Text;
using Bogus;
using Stravaig.Bogus.Extensions.Data;

namespace Stravaig.Bogus.Extensions.Builders;

internal class StreetBuilder : IBuilder
{
    private const float LikelihoodOfPrefix = 0.02f;
    
    internal required ArrayOfArrays<string> Prefixes { get; init; }
    internal required bool UsePrefix { get; init; }
    internal required int PrefixIndex { get; init; }
    
    internal required ArrayOfArrays<string> Names { get; init; }
    internal required int NameIndex { get; init; }
    
    internal required ArrayOfArrays<string> Suffixes { get; init; }
    internal required int SuffixIndex { get; init; }

    internal static StreetBuilder Create(LocationInformation location, Randomizer random)
    {
        return new StreetBuilder
        {
            Prefixes = location.StreetPrefixLists,
            UsePrefix = random.Bool(LikelihoodOfPrefix),
            PrefixIndex = random.Number(0, location.StreetPrefixLists.MaxIndex),
            Names = location.StreetNameLists,
            NameIndex = random.Number(0, location.StreetNameLists.MaxIndex),
            Suffixes = location.StreetSuffixLists,
            SuffixIndex = random.Number(0, location.StreetSuffixLists.MaxIndex),
        };
    }
    
    public void Generate(StringBuilder sb)
    {
        if (sb == null) throw new ArgumentNullException(nameof(sb));
        ThrowIfBadState();

        string prefix = string.Empty;
        if (UsePrefix && Prefixes.HasContent)
        {
            prefix = Prefixes[PrefixIndex];
            sb.Append(prefix).Append(' ');
        }

        var name = Names[NameIndex];
        if (name.Equals(prefix, StringComparison.InvariantCultureIgnoreCase))
            name = Names[(NameIndex + 1) % Names.Count];
        sb.Append(name).Append(' ');

        var suffix = Suffixes[SuffixIndex];
        if (suffix.Equals(name, StringComparison.InvariantCultureIgnoreCase))
            suffix = Suffixes[(SuffixIndex + 1) % Suffixes.Count];

        sb.Append(suffix);
    }

    public string Generate()
    {
        StringBuilder sb = new StringBuilder();
        Generate(sb);
        return sb.ToString();
    }

    private void ThrowIfBadState()
    {
        if (UsePrefix)
        {
            if (Prefixes == null)
                throw BuilderStatePropertyException.PropertyIsNull(nameof(Prefixes));

            if (Prefixes.HasContent)
            {
                if (PrefixIndex > Prefixes.MaxIndex || PrefixIndex < 0)
                    throw BuilderStateIndexPropertyException.PropertyIsOutOfRangeIndex(nameof(PrefixIndex), Prefixes.MaxIndex, PrefixIndex);
            }
            else
                throw BuilderStatePropertyException.PropertyIsEmpty(nameof(Prefixes));
        }

        if (Names == null)
            throw BuilderStatePropertyException.PropertyIsNull(nameof(Names));

        if (Names.IsEmpty)
            throw BuilderStatePropertyException.PropertyIsEmpty(nameof(Names));

        if (NameIndex < 0 || NameIndex > Names.MaxIndex)
            throw BuilderStateIndexPropertyException.PropertyIsOutOfRangeIndex(nameof(NameIndex), Names.MaxIndex, NameIndex);

        if (Suffixes == null)
            throw BuilderStatePropertyException.PropertyIsNull(nameof(Suffixes));

        if (Suffixes.IsEmpty)
            throw BuilderStatePropertyException.PropertyIsEmpty(nameof(Suffixes));

        if (SuffixIndex < 0 || SuffixIndex > Suffixes.MaxIndex)
            throw BuilderStateIndexPropertyException.PropertyIsOutOfRangeIndex(nameof(SuffixIndex), Suffixes.MaxIndex, SuffixIndex);
    }
}