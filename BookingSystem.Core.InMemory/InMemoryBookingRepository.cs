using BookingSystem.Core.Entities;
using BookingSystem.Core.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BookingSystem.Core.InMemory
{
    /// <summary>
    /// A concrete implementation of the booking repository that stores bookings in memory
    /// </summary>
    public class InMemoryBookingRepository : IBookingRepository
    {
        public IList<Booking> Bookings { get; set; } = new List<Booking>();

        /// <summary>
        /// Gets all the bookings falling on a given day
        /// </summary>
        /// <param name="day">Day to search for bookings</param>
        /// <returns>A collection of bookings that fall on the given day</returns>
        public IList<Booking> GetForDay(DateTime day)
        {
            return Bookings.Where(booking => day.Date == booking.Start.Date || day.Date == booking.End.Date).ToList();
        }

        /// <summary>
        /// Checks to see if there is any booking overlapping with the given one
        /// </summary>
        /// <param name="booking">Booking to look for overlapping with</param>
        /// <returns>True if any booking overlaps it, false otherwise</returns>
        public bool HasOverlapping(Booking booking)
        {
            return Bookings.Where(each_booking => each_booking.ConflictsWith(booking)).Count() > 0;
        }

        /// <summary>
        /// Adds a booking to the repository
        /// </summary>
        /// <param name="booking">Booking to add</param>
        public void Add(Booking booking)
        {
            Bookings.Add(booking);
        }
    }
}