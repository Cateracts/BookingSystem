using BookingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Persistence.EntityFramework
{
    /// <summary>
    /// A context for persisting objects within the booking system
    /// </summary>
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Space> Spaces { get; set; }
    }
}
