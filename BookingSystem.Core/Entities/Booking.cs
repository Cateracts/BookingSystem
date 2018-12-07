using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Core.Entities
{
    /// <summary>
    /// Represents a booking made for a space
    /// </summary>
    public class Booking : DomainEntity
    {
        /// <summary>
        /// Gets or sets the name of the booking
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the period for which the space is booked
        /// </summary>
        public DateRange Period { get; set; }

        /// <summary>
        /// Gets or sets the space that the booking is for
        /// </summary>
        public Space Space { get; set; }
    }
}
