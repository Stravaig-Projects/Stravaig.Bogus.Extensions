// using System.Text;
// using Bogus.DataSets;
//
// namespace Stravaig.Bogus.Extensions;
//
// public static class ExtensionsForUkAddress
// {
//     private const float LikelihoodOfASubBuilding = 0.217f; // From office of national statistics.
//     private static readonly char[] ValidUnitLetters = "ABDEFGHJLNPQRSTUWXYZ".ToCharArray();
//     private static readonly int ValidUnitLettersMaxIndex = ValidUnitLetters.Length - 1;
//
//     private static char GenerateUnitLetter(this Address address) =>
//         ValidUnitLetters[address.Random.Number(0, ValidUnitLettersMaxIndex)];
//    
//     private static string GenerateInboundCode(this Address address) =>
//         $"{address.Random.Number(0, 9)}{address.GenerateUnitLetter()}{address.GenerateUnitLetter()}";
//
//     public static string UkPostcode(this Address address)
//     {
//         var data = OutwardPostalCodes.GetRandom(address);
//         return data.Code + " " + address.GenerateInboundCode();
//     }
//     
//    public static UkAddress UkAddress(this Address address)
//    { 
//        var data = OutwardPostalCodes.GetRandom(address);
//        string locality = data.GetRandomLocality(address);
//        string? subBuilding = GenerateSubBuilding(address);
//        
//        
//        return new()
//        {
//            SubBuilding = subBuilding,
//            StreetAddress = GenerateStreetAddress(address),
//            Locality = locality,
//            PostTown = data.PostTown,
//            Postcode = data.Code + " " + address.GenerateInboundCode(),
//            County = data.PostalCounty,
//        };
//    }
//
//    private static string GenerateStreetAddress(Address address)
//    {
//        StringBuilder sb = new StringBuilder();
//        sb.Append(address.Random.Number(1, 150).ToString());
//        sb.Append(" ");
//        return address.GenerateStreetName(sb);
//    }
//    
//     private static string? GenerateSubBuilding(Address address)
//     {
//         if (address.Random.Bool(LikelihoodOfASubBuilding) == false)
//             return null;
//
//         switch (address.Random.Number(1, 5))
//         {
//             case 1:
//                 return $"Flat {address.Random.Number(1, 10)}";
//             case 2:
//             {
//                 var floorNumber = address.Random.Number(-1, 6);
//                 string floor = floorNumber < 0
//                     ? "B"
//                     : floorNumber == 0
//                         ? "G"
//                         : floorNumber.ToString();
//                 return $"Flat {floor}/{address.Random.Number(1, 4)}";
//             }
//             case 3:
//             {
//                 char block = (char)('A' + address.Random.Number(0, 5));
//                 int floor = address.Random.Number(1, 12);
//                 int flat = address.Random.Number(1, 3);
//                 return $"Block {block}, Flat {floor}/{flat}";
//             }
//             case 4:
//             {
//                 int floor = address.Random.Number(1, 30);
//                 char flat = (char)('A' + address.Random.Number(0, 5));
//                 return $"Flat {floor}{flat}";
//             }
//             case 5:
//                 return $"Flat {(char)('A' + address.Random.Number(0, 10))}";
//         }
//
//         return null;
//     }
// }