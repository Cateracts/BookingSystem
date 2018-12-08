using BookingSystem.Core.Entities;
using System;
using System.Collections.Generic;

namespace BookingSystem.Core.Interfaces
{
    /// <summary>
    /// A contract that any booking repository must implement
    /// </summary>
    public interface IBookingRepository
    {
        /// <summary>
        /// Gets all the bookings falling on a given day
        /// </summary>
        /// <param name="day">Day to search for bookings</param>
        /// <returns>A collection of bookings that fall on the given day</returns>
        IList<Booking> GetForDay(DateTime day);

        /// <summary>
        /// Checks to see if there is any booking overlapping with the given one
        /// </summary>
        /// <param name="booking">Booking to look for overlapping with</param>
        /// <returns>True if any booking overlaps it, false otherwise</returns>
        bool HasOverlapping(Booking booking);

        /// <summary>
        /// Adds a booking to the repository
        /// </summary>
        /// <param name="booking">Booking to add</param>
        void Add(Booking booking);
    }
}
