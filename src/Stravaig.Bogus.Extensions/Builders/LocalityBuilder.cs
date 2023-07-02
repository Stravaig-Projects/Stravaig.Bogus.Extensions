using Bogus;
using Stravaig.Bogus.Extensions.Data;

namespace Stravaig.Bogus.Extensions.Builders;

internal class LocalityBuilder
{
    internal required string?[] Localities { get; init; }
    internal required int LocalityIndex { get; init; }

    internal static LocalityBuilder Create(LocationInformation data, Randomizer random)
    {
        return new LocalityBuilder
        {
            Localities = data.Localities,
            LocalityIndex = data.Localities.Length == 0
                ? 0
                : random.Number(0, data.Localities.Length - 1),
        };
    }
    
    internal string? Generate()
    {
        ThrowIfBadState();
        return Localities.Length == 0
            ? null
            : Localities[LocalityIndex];
    }

    private void ThrowIfBadState()
    {
        if (Localities == null)
            throw BuilderStatePropertyException.PropertyIsNull(nameof(Localities));

        if (Localities.Length == 0)
            return;
        
        if (LocalityIndex < 0 || LocalityIndex >= Localities.Length)
            throw BuilderStateIndexPropertyException.PropertyIsOutOfRangeIndex(nameof(LocalityIndex), Localities.Length - 1, LocalityIndex);
    }
}