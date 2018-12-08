using System;

namespace BookingSystem.Core.Interfaces
{
    /// <summary>
    /// A contract that a get booking for date request must implement
    /// </summary>
    public interface IGetBookingForDateRequest
    {
        /// <summary>
        /// Sets the date for the booking
        /// </summary>
        DateTime Date { set; }

        /// <summary>
        /// Executes the request
        /// </summary>
        void Execute();
    }
}
