namespace Stravaig.Bogus.Extensions;

public class UkAddress
{
    /// <summary>
    /// An apartment, flat or unit designation.
    /// </summary>
    public string? SubBuilding { get; init; }
   
    /// <summary>
    /// The building number and street.
    /// </summary>
    public string StreetAddress { get; init; }
   
    /// <summary>
    /// The locality within the post town. May be a neighbourhood in a city, a nearby village, etc.
    /// </summary>
    public string Locality { get; init; }
   
    /// <summary>
    /// The Post Town.
    /// </summary>
    public string PostTown { get; init; }
   
    /// <summary>
    /// The Post County. Not required for addressing since 1996, but sometimes still used.
    /// </summary>
    public string County { get; init; }
   
    /// <summary>
    /// The Post Code.
    /// </summary>
    public string PostCode { get; init; }
}