using BookingSystem.Core.Entities;
using System;

namespace BookingSystem.WebApi.Requests
{
    /// <summary>
    /// Represents a request to make a booking
    /// </summary>
    public class MakeBookingRequest
    {
        /// <summary>
        /// Gets or sets the name of the booking
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the start of the booking
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the end of the booking
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the space to use
        /// </summary>
        public Space Space { get; set; }
    }
}
