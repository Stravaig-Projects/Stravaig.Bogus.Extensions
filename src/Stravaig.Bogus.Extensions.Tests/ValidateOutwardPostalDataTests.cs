using System;
using Shouldly;
using Stravaig.Jailbreak;

namespace Stravaig.Bogus.Extensions.Tests;

[TestFixture]
public class ValidateOutwardPostalDataTests
{
    [Test]
    public void AllDate()
    {
        dynamic cracked = typeof(OutwardPostalCodes).Jailbreak();
        var data = (OutwardPostalCodes[])cracked.Data;
        for (int i = 0; i < data.Length; i++)
        {
            Console.WriteLine($"{i}: {data[i]}");
        }
    }
    
    [Test]
    public void ValidateAllData()
    {
        dynamic cracked = typeof(OutwardPostalCodes).Jailbreak();
        var data = (OutwardPostalCodes[])cracked.Data;

        int issueCount = 0;
        for (int i = 0; i < data.Length; i++)
        {
            var item = data[i];
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (item == null)
            {
                Console.WriteLine($"{i}: Null.");
                issueCount++;
                continue;
            }

            if (string.IsNullOrWhiteSpace(item.Code))
            {
                issueCount++;
                Console.WriteLine($"{i}: No code. {item}");
            }

            if (string.IsNullOrWhiteSpace(item.PostalCounty))
            {
                issueCount++;
                Console.WriteLine($"{i}: No PostalCounty. {item}");
            }

            if (string.IsNullOrWhiteSpace(item.PostTown))
            {
                issueCount++;
                Console.WriteLine($"{i}: No PostTown. {item}");
            }

            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (item.Localities == null)
            {
                issueCount++;
                Console.WriteLine($"{i}: Localities is null. {item}");
            }

            issueCount.ShouldBe(0);
        }
    }
}