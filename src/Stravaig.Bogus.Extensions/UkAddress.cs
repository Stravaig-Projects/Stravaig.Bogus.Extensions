using System.Collections.Generic;
using System.Linq;
using Stravaig.Extensions.Core;

namespace Stravaig.Bogus.Extensions;

/// <summary>
/// An address that looks like it could be from the UK.
/// </summary>
public class UkAddress
{
    /// <summary>
    /// An apartment, flat or unit designation.
    /// </summary>
    public required string? SubBuilding { get; init; }
   
    /// <summary>
    /// The building number and street.
    /// </summary>
    public required string StreetAddress { get; init; }
   
    /// <summary>
    /// The locality within the post town. May be a neighbourhood in a city, a nearby village, etc.
    /// </summary>
    public required string? Locality { get; init; }
   
    /// <summary>
    /// The Post Town.
    /// </summary>
    public required string PostTown { get; init; }
   
    /// <summary>
    /// The Post County. Not required for addressing since 1996, but sometimes still used.
    /// </summary>
    public required string? County { get; init; }
   
    /// <summary>
    /// The Post Code.
    /// </summary>
    public required string Postcode { get; init; }
    
    /// <summary>
    /// The constituent country.
    /// </summary>
    public required string Country { get; init; }

    /// <summary>
    /// The address in sequences parts as an array.
    /// </summary>
    /// <returns>An array of sequenced parts of the address.</returns>
    public string[] AsPartsArray(Part parts = Part.All) => Parts(parts).ToArray();

    /// <summary>
    /// The address in sequenced parts.
    /// </summary>
    public IEnumerable<string> Parts(Part parts = Part.All)
    {
        if (parts.Includes(Part.SubBuilding) && SubBuilding.HasContent())
            yield return SubBuilding!;

        if (parts.Includes(Part.StreetAddress))
            yield return StreetAddress;
        
        if (parts.Includes(Part.Locality) && Locality.HasContent())
            yield return Locality!;
        
        if (parts.Includes(Part.PostTown))
            yield return PostTown;
        
        if (parts.Includes(Part.County) && County.HasContent())
            yield return County!;
        
        if (parts.Includes(Part.Postcode))
            yield return Postcode;
        
        if (parts.Includes(Part.Country))
            yield return Country;
    }

    /// <summary>
    /// A string that represents the address containing just the requested parts.
    /// </summary>
    /// <param name="parts">The parts of the address to appear in the string.</param>
    /// <returns>The address.</returns>
    public string ToString(Part parts)
    {
        return string.Join(", ", Parts(parts));
    }
    
    /// <summary>
    /// A string that represents the full address.
    /// </summary>
    /// <returns>The address.</returns>
    public override string ToString()
    {
        return ToString(Part.All);
    }
}