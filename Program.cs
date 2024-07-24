using System;
using Checker;

namespace ParadigmShiftCSharp
{
    class Program
    {
        static void Main()
        {
            var checker = new BatteryChecker();

            // Test with valid parameters
            bool result1 = checker.IsBatteryInGoodCondition(25, 70, 0.7f);
            Console.WriteLine(result1 ? "Battery is OK." : "Battery has issues.");

            // Test with invalid parameters
            bool result2 = checker.IsBatteryInGoodCondition(50, 85, 0.0f);
            Console.WriteLine(result2 ? "Battery is OK." : "Battery has issues.");
        }
    }
}
