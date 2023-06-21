using System.Text.Json;

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