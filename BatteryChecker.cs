namespace Checker
{
    /// <summary>
    /// Aggregates different battery checks and validates battery condition.
    /// </summary>
    public class BatteryChecker
    {
        private readonly IBatteryCheck _temperatureCheck = new TemperatureCheck();
        private readonly IBatteryCheck _socCheck = new SocCheck();
        private readonly IBatteryCheck _chargeRateCheck = new ChargeRateCheck();
        private readonly IBatteryCheck _voltageCheck = new VoltageCheck(); // Add voltage check

        /// <summary>
        /// Checks if the battery is in good condition based on multiple parameters.
        /// </summary>
        /// <param name="temperature">The temperature to check.</param>
        /// <param name="stateOfCharge">The state of charge to check.</param>
        /// <param name="chargeRate">The charge rate to check.</param>
        /// <param name="voltage">The voltage to check.</param>
        /// <returns>True if all parameters are within the acceptable range, otherwise false.</returns>
        public bool IsBatteryInGoodCondition(float temperature, float stateOfCharge, float chargeRate, float voltage)
        {
            bool isTemperatureValid = ValidateCheck(_temperatureCheck, temperature);
            bool isSocValid = ValidateCheck(_socCheck, stateOfCharge);
            bool isChargeRateValid = ValidateCheck(_chargeRateCheck, chargeRate);
            bool isVoltageValid = ValidateCheck(_voltageCheck, voltage); // Validate voltage

            return isTemperatureValid && isSocValid && isChargeRateValid && isVoltageValid; // Include voltage check in the final validation
        }

        /// <summary>
        /// Validates a condition and logs an error if validation fails.
        /// </summary>
        /// <param name="check">The check to perform.</param>
        /// <param name="value">The value to check.</param>
        /// <returns>True if the check passes, otherwise false.</returns>
        private bool ValidateCheck(IBatteryCheck check, float value)
        {
            bool isValid = check.Check(value);
            if (!isValid)
            {
                LogError(check.GetErrorMessage());
            }
            return isValid;
        }

        /// <summary>
        /// Logs an error message to the console.
        /// </summary>
        /// <param name="message">The error message to log.</param>
        private void LogError(string message) => Console.WriteLine(message);
    }
}
