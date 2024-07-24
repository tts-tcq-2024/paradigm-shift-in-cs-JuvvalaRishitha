using System;
using Xunit;
using Checker;

namespace Checker.Tests
{
    public class BatteryCheckerTests
    {
        /// <summary>
        /// Tests battery checking with various conditions and expects specific error messages.
        /// </summary>
        /// <param name="temperature">Temperature to test.</param>
        /// <param name="stateOfCharge">State of charge to test.</param>
        /// <param name="chargeRate">Charge rate to test.</param>
        /// <param name="expectedMessage">Expected error message.</param>
        private void TestBatteryCheck(float temperature, float stateOfCharge, float chargeRate, string expectedMessage)
        {
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);

            var checker = new BatteryChecker();
            checker.IsBatteryInGoodCondition(temperature, stateOfCharge, chargeRate);

            var output = consoleOutput.ToString().Trim();
            Assert.Contains(expectedMessage, output);
        }

        [Fact]
        public void TemperatureBelowRange_ShouldLogError() => TestBatteryCheck(-1, 70, 0.7f, "Temperature is out of range!");

        [Fact]
        public void TemperatureAboveRange_ShouldLogError() => TestBatteryCheck(46, 70, 0.7f, "Temperature is out of range!");

        [Fact]
        public void StateOfChargeBelowRange_ShouldLogError() => TestBatteryCheck(25, 19, 0.7f, "State of Charge is out of range!");

        [Fact]
        public void ChargeRateAboveRange_ShouldLogError() => TestBatteryCheck(25, 70, 0.9f, "Charge Rate is out of range!");

        [Fact]
        public void AllParametersInRange_ShouldPass()
        {
            var consoleOutput = new System.IO.StringWriter();
            Console.SetOut(consoleOutput);

            var checker = new BatteryChecker();
            bool result = checker.IsBatteryInGoodCondition(25, 70, 0.7f);

            var output = consoleOutput.ToString().Trim();
            Assert.Empty(output);
            Assert.True(result);
        }
    }
}
