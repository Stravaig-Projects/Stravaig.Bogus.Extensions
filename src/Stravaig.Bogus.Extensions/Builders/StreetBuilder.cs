using System;
using System.Collections.Immutable;
using System.Text;

namespace Stravaig.Bogus.Extensions.Builders;

internal class StreetBuilder
{
    internal required ArrayOfArrays<string> Prefixes { get; init; }
    internal required bool UsePrefix { get; init; }
    internal required int PrefixIndex { get; init; }
    
    internal required ArrayOfArrays<string> Names { get; init; }
    internal required int NameIndex { get; init; }
    
    internal required ArrayOfArrays<string> Suffixes { get; init; }
    internal required int SuffixIndex { get; init; }

    
    public void GenerateStreetName(StringBuilder sb)
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

    public string GenerateStreetName()
    {
        StringBuilder sb = new StringBuilder();
        GenerateStreetName(sb);
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