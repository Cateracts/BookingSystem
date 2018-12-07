using BookingSystem.Core.Entities;
using System.Collections.Generic;

namespace BookingSystem.Core.Interfaces
{
    /// <summary>
    /// A contract that any response handler for get booking for date must implement
    /// </summary>
    public interface IGetBookingForDateResponseHandler : IResponseHandler
    {
        /// <summary>
        /// Gets or sets a list of bookings
        /// </summary>
        IList<Booking> Bookings { get; set; }
    }
}
