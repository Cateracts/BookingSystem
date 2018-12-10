using System;

namespace BookingSystem.Core.Exceptions
{
    /// <summary>
    /// Represents an exception generated when there is an invalid booking present
    /// </summary>
    public class InvalidBookingException : Exception
    {
        /// <summary>
        /// Constructs a new invalid booking exception
        /// </summary>
        /// <param name="errors">The reasons as to why the booking is invalid</param>
        public InvalidBookingException(string errors)
            : base(errors)
        {            
        }
    }
}
