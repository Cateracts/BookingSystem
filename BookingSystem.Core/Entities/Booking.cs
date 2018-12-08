using System;

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
        /// Gets or sets the start of the booking
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Gets or sets the end of the booking
        /// </summary>
        public DateTime End { get; set; }

        /// <summary>
        /// Gets or sets the space that the booking is for
        /// </summary>
        public Space Space { get; set; }

        /// <summary>
        /// Determines if the given booking overlaps with the current booking
        /// </summary>
        /// <param name="booking">Booking to examine for overlapping</param>
        /// <returns>True if there is an overlap, false otherwise</returns>
        public bool ConflictsWith(Booking booking)
        {
            if (Space.Id == booking.Space.Id)
            {
                var booking_times_are_the_same = Start == booking.Start && End == booking.End;
                var booking_start_inside_booking_period = Start > booking.Start && Start < booking.End;
                var booking_end_inside_booking_period = End > booking.Start && End < booking.End;

                return booking_times_are_the_same || booking_start_inside_booking_period || booking_end_inside_booking_period;
            }

            return false;
        }
    }
}
