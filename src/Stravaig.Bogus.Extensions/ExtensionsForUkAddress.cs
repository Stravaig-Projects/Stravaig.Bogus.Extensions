using System.Text;
using Bogus.DataSets;

namespace Stravaig.Bogus.Extensions;

public static class ExtensionsForUkAddress
{
    private const float LikelihoodOfASubBuilding = 0.217f; // From office of national statistics.
    private static readonly char[] ValidUnitLetters = "ABDEFGHJLNPQRSTUWXYZ".ToCharArray();
    private static readonly int ValidUnitLettersMaxIndex = ValidUnitLetters.Length - 1;

    private static char GenerateUnitLetter(this Address address) =>
        ValidUnitLetters[address.Random.Number(0, ValidUnitLettersMaxIndex)];
   
    private static string GenerateInboundCode(this Address address) =>
        $"{address.Random.Number(0, 9)}{address.GenerateUnitLetter()}{address.GenerateUnitLetter()}";
    
   public static UkAddress UK(this Address address)
   { 
       var data = OutwardPostalCodes.GetRandom(address);
       string locality = data.GetRandomLocality(address);
       string? subBuilding = GenerateSubBuilding(address);
       
       
       return new()
       {
           SubBuilding = subBuilding,
           StreetAddress = GenerateStreetAddress(address),
           Locality = locality,
           PostTown = data.PostTown,
           PostCode = data.Code + " " + address.GenerateInboundCode(),
           County = data.PostalCounty,
       };
   }

   private static string GenerateStreetAddress(Address address)
   {
       StringBuilder sb = new StringBuilder();
       sb.Append(address.Random.Number(1, 150).ToString());
       sb.Append(" ");
       return address.GenerateStreetName(sb);
   }
   
   private static string? GenerateSubBuilding(Address address)
   {
       if (address.Random.Bool(LikelihoodOfASubBuilding) == false)
           return null;

       return $"Flat {address.Random.Number(1, 10)}";
   }
}