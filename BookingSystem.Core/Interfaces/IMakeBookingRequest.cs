using BookingSystem.Core.Entities;

namespace BookingSystem.Core.Interfaces
{
    /// <summary>
    /// A contract that an make booking request must implement
    /// </summary>
    public interface IMakeBookingRequest
    {
        /// <summary>
        /// Sets the booking to be made
        /// </summary>
        Booking Booking { set; }

        /// <summary>
        /// Executes the request
        /// </summary>
        void Execute();
    }
}
