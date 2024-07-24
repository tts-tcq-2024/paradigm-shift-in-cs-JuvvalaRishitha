namespace Checker
{
    /// <summary>
    /// Checks if the temperature is within the valid range.
    /// </summary>
    public class TemperatureCheck : IBatteryCheck
    {
        private string _errorMessage;

        /// <summary>
        /// Validates the temperature.
        /// </summary>
        /// <param name="temperature">The temperature to check.</param>
        /// <returns>True if the temperature is within the range, otherwise false.</returns>
        public bool Check(float temperature)
        {
            if (temperature < 0)
            {
                _errorMessage = "Temperature is too low!";
                return false;
            }
            if (temperature > 45)
            {
                _errorMessage = "Temperature is too high!";
                return false;
            }
            return true;
        }

        public string GetErrorMessage() => _errorMessage;
    }
}
