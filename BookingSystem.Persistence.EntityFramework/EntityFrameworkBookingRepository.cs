using BookingSystem.Core.Entities;
using BookingSystem.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.Persistence.EntityFramework
{
    /// <summary>
    /// A concrete implementation of the booking repository using Entity Framework
    /// </summary>
    public class EntityFrameworkBookingRepository : IBookingRepository
    {
        private BookingContext context;

        /// <summary>
        /// Constructs the repository
        /// </summary>
        /// <param name="context">Persistence context to use</param>
        public EntityFrameworkBookingRepository(BookingContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets all the bookings falling on a given day
        /// </summary>
        /// <param name="day">Day to search for bookings</param>
        /// <returns>A collection of bookings that fall on the given day</returns>
        public IList<Booking> GetForDay(DateTime day)
        {
            return context.Bookings.Include(booking => booking.Space)
                                   .Where(booking => day.Date == booking.Start.Date || day.Date == booking.End.Date)
                                   .ToList();
        }

        /// <summary>
        /// Checks to see if there is any booking overlapping with the given one
        /// </summary>
        /// <param name="booking">Booking to look for overlapping with</param>
        /// <returns>True if any booking overlaps it, false otherwise</returns>
        public bool HasOverlapping(Booking booking)
        {
            return context.Bookings.Include(each_booking => each_booking.Space)
                                   .ToList()
                                   .Where(each_booking => each_booking.ConflictsWith(booking))
                                   .Count() > 0;
        }

        /// <summary>
        /// Adds a booking to the repository
        /// </summary>
        /// <param name="booking">Booking to add</param>
        public void Add(Booking booking)
        {
            booking.Space = context.Spaces.Find(booking.Space.Id);
            context.Add(booking);
            context.SaveChanges();
        }
    }
}
