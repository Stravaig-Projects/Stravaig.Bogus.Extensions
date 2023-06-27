// using System;
// using Bogus;
// namespace Stravaig.Bogus.Extensions.Tests;
//
// public class GenerateTests
// {
//     [SetUp]
//     public void Setup()
//     {
//     }
//
//     [Test]
//     public void Generate100Addresses()
//     {
//         Randomizer.Seed = new Random(12345);
//         var faker = new Faker("en");
//
//         for (int i = 0; i < 100; i++)
//         {
//             var address = faker.Address.UkAddress();
//             Console.WriteLine(address);
//         }
//     }
//     
//     [Test]
//     public void Generate100Postcodes()
//     {
//         Randomizer.Seed = new Random(12345);
//         var faker = new Faker("en");
//
//         for (int i = 0; i < 100; i++)
//         {
//             var postCode = faker.Address.UkPostcode();
//             Console.WriteLine(postCode);
//         }
//     }
//     
// }