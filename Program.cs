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
            TestBatteryCheck(checker, 25, 70, 0.7f, 3.7f, true); // Added voltage

            // Test with temperature out of range
            TestBatteryCheck(checker, -1, 70, 0.7f, 3.7f, false);
            TestBatteryCheck(checker, 46, 70, 0.7f, 3.7f, false);

            // Test with state of charge out of range
            TestBatteryCheck(checker, 25, 19, 0.7f, 3.7f, false);
            TestBatteryCheck(checker, 25, 81, 0.7f, 3.7f, false);

            // Test with charge rate out of range
            TestBatteryCheck(checker, 25, 70, 0.9f, 3.7f, false);

            // Test with voltage out of range
            TestBatteryCheck(checker, 25, 70, 0.7f, 2.9f, false); // Voltage too low
            TestBatteryCheck(checker, 25, 70, 0.7f, 4.3f, false); // Voltage too high

            // Test with multiple out of range parameters
            TestBatteryCheck(checker, -1, 19, 0.9f, 2.9f, false);
            TestBatteryCheck(checker, 46, 81, 0.9f, 4.3f, false);

            // Test edge cases for temperature
            TestBatteryCheck(checker, 0, 70, 0.7f, 3.7f, true);
            TestBatteryCheck(checker, 45, 70, 0.7f, 3.7f, true);

            // Test edge cases for state of charge
            TestBatteryCheck(checker, 25, 20, 0.7f, 3.7f, true);
            TestBatteryCheck(checker, 25, 80, 0.7f, 3.7f, true);

            // Test edge cases for charge rate
            TestBatteryCheck(checker, 25, 70, 0.8f, 3.7f, true);
            
            // Test edge cases for voltage
            TestBatteryCheck(checker, 25, 70, 0.7f, 3.0f, true); // Lower edge case
            TestBatteryCheck(checker, 25, 70, 0.7f, 4.2f, true); // Upper edge case

            Console.WriteLine("All tests completed.");
        }

        static void TestBatteryCheck(BatteryChecker checker, float temperature, float soc, float chargeRate, float voltage, bool expectedOutcome)
        {
            bool result = checker.IsBatteryInGoodCondition(temperature, soc, chargeRate, voltage);
            Console.WriteLine(result == expectedOutcome ? "Test passed." : "Test failed.");
        }
    }
}
