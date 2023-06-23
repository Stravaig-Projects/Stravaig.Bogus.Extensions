using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// The address in sequences parts as an array.
    /// </summary>
    /// <returns>An array of sequenced parts of the address.</returns>
    public string[] AsPartsArray() => Parts.ToArray();

    /// <summary>
    /// The address in sequenced parts.
    /// </summary>
    public IEnumerable<string> Parts
    {
        get
        {
            if (SubBuilding.HasContent())
                yield return SubBuilding!;
            yield return StreetAddress;
            if (Locality.HasContent())
                yield return Locality!;
            yield return PostTown;
            if (County.HasContent())
                yield return County!;
            yield return Postcode;
        }
    }

    /// <summary>
    /// A string that represents the current address.
    /// </summary>
    /// <returns>The address.</returns>
    public override string ToString()
    {
        const string separator = ", ";
        StringBuilder sb = new StringBuilder(
            SubBuilding?.Length ?? 0 +
            StreetAddress.Length +
            Locality?.Length ?? 0 +
            PostTown.Length +
            County?.Length ?? 0 +
            Postcode.Length + 10);

        if (SubBuilding.HasContent())
            sb.Append(SubBuilding).Append(separator);
        sb.Append(StreetAddress).Append(separator);
        if (Locality.HasContent())
            sb.Append(Locality).Append(separator);
        sb.Append(PostTown).Append(separator);
        if (County.HasContent())
            sb.Append(County).Append(separator);
        sb.Append(Postcode);
        return sb.ToString();
    }
}