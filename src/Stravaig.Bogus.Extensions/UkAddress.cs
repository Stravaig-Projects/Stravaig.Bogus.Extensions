namespace Stravaig.Bogus.Extensions;

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
}