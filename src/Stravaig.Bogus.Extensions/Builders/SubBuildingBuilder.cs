using Bogus;

namespace Stravaig.Bogus.Extensions.Builders;

internal abstract class SubBuildingBuilder
{
    private const float LikelihoodOfASubBuilding = 0.217f; // From office of national statistics. 

    internal static SubBuildingBuilder Create(Randomizer random)
    {
        if (!random.Bool(LikelihoodOfASubBuilding))
            return NullSubBuildingBuilder.Instance;

        int style = random.Number(1, 5);

        return style switch
        {
            1 => new SimpleNumericFlatBuilder
            {
                FlatNumber = random.Number(1, 10),
            },
            2 => new SimpleAlphabetFlatBuilder
            {
                FlatNumber = random.Number(0, 7),
            },
            3 => new FlatWithFloorBuilder
            {
                FloorNumber = random.Number(-1, 6),
                FlatNumber = random.Number(1,4),
            },
            4 => new FlatWithBlockAndFloorBuilder
            {
                BlockNumber = random.Number(0,5),
                FloorNumber = random.Number(1,12),
                FlatNumber = random.Number(1,4),
            },
            _ => NullSubBuildingBuilder.Instance
        };
    }

    internal abstract string? Generate();
}

//  private static string? GenerateSubBuilding(Address address)
    //  {
    //      if (address.Random.Bool(LikelihoodOfASubBuilding) == false)
    //          return null;
    //
    //      switch (address.Random.Number(1, 5))
    //      {
    //          case 1:
    //              return $"Flat {address.Random.Number(1, 10)}";
    //          case 2:
    //          {
    //              var floorNumber = address.Random.Number(-1, 6);
    //              string floor = floorNumber < 0
    //                  ? "B"
    //                  : floorNumber == 0
    //                      ? "G"
    //                      : floorNumber.ToString();
    //              return $"Flat {floor}/{address.Random.Number(1, 4)}";
    //          }
    //          case 3:
    //          {
    //              char block = (char)('A' + address.Random.Number(0, 5));
    //              int floor = address.Random.Number(1, 12);
    //              int flat = address.Random.Number(1, 3);
    //              return $"Block {block}, Flat {floor}/{flat}";
    //          }
    //          case 4:
    //          {
    //              int floor = address.Random.Number(1, 30);
    //              char flat = (char)('A' + address.Random.Number(0, 5));
    //              return $"Flat {floor}{flat}";
    //          }
    //          case 5:
    //              return $"Flat {(char)('A' + address.Random.Number(0, 10))}";
    //      }
    //
    //      return null;
    //  }
//}