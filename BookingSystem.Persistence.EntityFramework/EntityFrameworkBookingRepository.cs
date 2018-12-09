using BookingSystem.Core.Entities;
using BookingSystem.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.Persistence.EntityFramework
{
    public class EntityFrameworkBookingRepository : IBookingRepository
    {
        private BookingContext context;

        public EntityFrameworkBookingRepository(BookingContext context)
        {
            this.context = context;
        }

        public IList<Booking> GetForDay(DateTime day)
        {
            return context.Bookings.Where(booking => day.Date == booking.Start.Date || day.Date == booking.End.Date).ToList();
        }

        public bool HasOverlapping(Booking booking)
        {
            return context.Bookings.Include(each_booking => each_booking.Space)
                                   .ToList()
                                   .Where(each_booking => each_booking.ConflictsWith(booking))
                                   .Count() > 0;
        }

        public void Add(Booking booking)
        {
            booking.Space = context.Spaces.Find(booking.Space.Id);
            context.Add(booking);
            context.SaveChanges();
        }
    }
}
