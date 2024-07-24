namespace Checker
{
    /// <summary>
    /// Checks if the state of charge is within the valid range.
    /// </summary>
    public class SocCheck : IBatteryCheck
    {
        private string _errorMessage;

        /// <summary>
        /// Validates the state of charge.
        /// </summary>
        /// <param name="stateOfCharge">The state of charge to check.</param>
        /// <returns>True if the state of charge is within the range, otherwise false.</returns>
        public bool Check(float stateOfCharge)
        {
            if (stateOfCharge < 20)
            {
                _errorMessage = "State of Charge is too low!";
                return false;
            }
            if (stateOfCharge > 80)
            {
                _errorMessage = "State of Charge is too high!";
                return false;
            }
            return true;
        }

        public string GetErrorMessage() => _errorMessage;
    }
}
