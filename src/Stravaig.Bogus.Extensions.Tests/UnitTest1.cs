using System;
using System.Text.Json;
using Bogus;
namespace Stravaig.Bogus.Extensions.Tests;

public static class JsonExtensions
{
    public static string ToJson<T>(this T obj)
    {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions
        {
            WriteIndented = true,
        });
    }
}
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        Randomizer.Seed = new Random(12345);
        var faker = new Faker("en");

        for (int i = 0; i < 10; i++)
        {
            var address = faker.Address.UK();
            Console.WriteLine(address.ToJson());
        }
    }
}