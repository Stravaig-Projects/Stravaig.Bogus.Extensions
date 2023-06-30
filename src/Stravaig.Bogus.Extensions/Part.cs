using System;

namespace Stravaig.Bogus.Extensions;

[Flags]
public enum Part
{
    SubBuilding   = 0x01,
    StreetAddress = 0x02,
    Locality      = 0x04,
    PostTown      = 0x08,
    County        = 0x10,
    Postcode      = 0x20,
    Country       = 0x40,
    All           = SubBuilding | StreetAddress | Locality | PostTown | County | Postcode | Country,
}

public static class UkAddressPartsExtensions
{
    public static bool Includes(this Part parts, Part part)
    {
        return (parts & part) != 0;
    }
}