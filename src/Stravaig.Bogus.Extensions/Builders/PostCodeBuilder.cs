using System;
using System.Text;
using Bogus;
using Stravaig.Bogus.Extensions.Data;

namespace Stravaig.Bogus.Extensions.Builders;

internal class PostCodeBuilder : IBuilder
{
    private static readonly char[] ValidUnitLetters = "ABDEFGHJLNPQRSTUWXYZ".ToCharArray();
    private static readonly int ValidUnitLettersMaxIndex = ValidUnitLetters.Length - 1;
    
    public required LocationInformation Location { get; init; }
    
    public required int Number { get; init; }
    
    public required int Letter1Index { get; init; }
    
    public required int Letter2Index { get; init; }

    internal static PostCodeBuilder Create(LocationInformation location, Randomizer random)
    {
        return new PostCodeBuilder()
        {
            Location = location,
            Number = random.Number(1, 9),
            Letter1Index = random.Number(0, ValidUnitLettersMaxIndex),
            Letter2Index = random.Number(0, ValidUnitLettersMaxIndex),
        };
    }
    
    public string Generate()
    {
        ThrowIfBadState();
        return $"{Location.Code} {Number}{ValidUnitLetters[Letter1Index]}{ValidUnitLetters[Letter2Index]}";
    }

    public void Generate(StringBuilder sb)
    {
        if (sb == null) throw new ArgumentNullException(nameof(sb));
        sb.Append(Generate());
    }

    private void ThrowIfBadState()
    {
        if (Location == null)
            throw BuilderStatePropertyException.PropertyIsNull(nameof(Location));

        if (Number < 1 || Number > 9)
            throw BuilderStatePropertyOutOfRangeException.PropertyIsOutOfRange(nameof(Number), 1, 9, Number);
        
        if (Letter1Index < 0 || Letter1Index > ValidUnitLettersMaxIndex)
            throw BuilderStateIndexPropertyException.PropertyIsOutOfRangeIndex(nameof(Letter1Index), ValidUnitLettersMaxIndex, Letter1Index);

        if (Letter2Index < 0 || Letter2Index > ValidUnitLettersMaxIndex)
            throw BuilderStateIndexPropertyException.PropertyIsOutOfRangeIndex(nameof(Letter2Index), ValidUnitLettersMaxIndex, Letter2Index);
    }
}