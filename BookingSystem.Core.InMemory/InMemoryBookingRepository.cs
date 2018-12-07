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
            return Bookings.Where(booking => booking.Period.Contains(day)).ToList();
        }
    }
}