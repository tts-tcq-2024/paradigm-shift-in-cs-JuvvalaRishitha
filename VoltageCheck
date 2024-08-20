namespace Checker
{
    /// <summary>
    /// Checks if the battery voltage is within the valid range.
    /// </summary>
    public class VoltageCheck : IBatteryCheck
    {
        private string _errorMessage;

        /// <summary>
        /// Validates the battery voltage.
        /// </summary>
        /// <param name="voltage">The voltage to check.</param>
        /// <returns>True if the voltage is within the range, otherwise false.</returns>
        public bool Check(float voltage)
        {
            // Assuming voltage should be between 3.0V and 4.2V
            if (voltage < 3.0f)
            {
                _errorMessage = "Voltage is too low!";
                return false;
            }
            if (voltage > 4.2f)
            {
                _errorMessage = "Voltage is too high!";
                return false;
            }
            return true;
        }

        public string GetErrorMessage() => _errorMessage;
    }
}
