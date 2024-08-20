namespace Checker
{
    /// <summary>
    /// Checks if the charge rate is within the valid range.
    /// </summary>
    public class ChargeRateCheck : IBatteryCheck
    {
        private string _errorMessage;

        /// <summary>
        /// Validates the charge rate.
        /// </summary>
        /// <param name="chargeRate">The charge rate to check.</param>
        /// <returns>True if the charge rate is within the range, otherwise false.</returns>
        public bool Check(float chargeRate)
        {
            if (chargeRate > 0.8)
            {
                _errorMessage = "Charge Rate is too high!";
                return false;
            }
            return true;
        }

        public string GetErrorMessage() => _errorMessage;
    }
}
