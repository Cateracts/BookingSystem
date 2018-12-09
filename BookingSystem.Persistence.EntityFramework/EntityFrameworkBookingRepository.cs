using BookingSystem.Core.Entities;
using BookingSystem.Core.Interfaces;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public bool HasOverlapping(Booking booking)
        {
            return false;
        }

        public void Add(Booking booking)
        {
            context.Add(booking);
            context.SaveChanges();
        }
    }
}
