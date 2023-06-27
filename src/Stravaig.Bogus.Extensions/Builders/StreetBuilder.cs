using System;
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
}