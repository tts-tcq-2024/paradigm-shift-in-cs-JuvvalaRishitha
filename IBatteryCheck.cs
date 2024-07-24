namespace Checker
{
    /// <summary>
    /// Defines the contract for a battery check.
    /// </summary>
    public interface IBatteryCheck
    {
        /// <summary>
        /// Checks if the provided value meets the criteria.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True if the value is valid, otherwise false.</returns>
        bool Check(float value);

        /// <summary>
        /// Gets the error message if the check fails.
        /// </summary>
        /// <returns>The error message.</returns>
        string GetErrorMessage();
    }
}
