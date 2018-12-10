using FluentValidation.Results;
using System.Text;

namespace BookingSystem.Core.Extensions
{
    /// <summary>
    /// Extensions for the fluent validation result
    /// </summary>
    public static class ValidationResultExtensions
    {
        /// <summary>
        /// Flattens the validation result for easy consumption
        /// </summary>
        /// <param name="result">Result to flatten</param>
        /// <returns>A string containing the error messages from the validation result</returns>
        public static string Flatten(this ValidationResult result)
        {
            var builder = new StringBuilder();

            foreach (var error in result.Errors)
            {
                builder.AppendLine(error.ErrorMessage);
            }

            return builder.ToString();
        }
    }
}
