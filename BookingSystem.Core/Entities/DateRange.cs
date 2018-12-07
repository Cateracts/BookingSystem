using System;

namespace BookingSystem.Core.Entities
{
    /// <summary>
    /// Represents the area between 2 dates
    /// </summary>
    public class DateRange
    {
        private DateTime start;
        private DateTime end;

        /// <summary>
        /// Constructs a new date range
        /// </summary>
        /// <exception cref="ArgumentException">Thrown if the end is less than or equal to the start</exception>
        /// <param name="start">Start of the date range</param>
        /// <param name="end">End of the date range</param>
        public DateRange(DateTime start, DateTime end)
        {
            if (end <= start)
                throw new ArgumentException("Date range is invalid. End of date range must be after start");

            this.start = start;
            this.end = end;
        }

        /// <summary>
        /// Determines if the date falls within the date range
        /// </summary>
        /// <param name="date">Date to examine</param>
        /// <returns>True if it does, false otherwise</returns>
        public bool Contains(DateTime date)
        {
            return Contains(start, end, date);
        }

        /// <summary>
        /// Determines if the date falls within the date range
        /// </summary>
        /// <param name="start">Start of the date range</param>
        /// <param name="end">End of the date range</param>
        /// <param name="date">Date to examine</param>
        /// <returns>True if it does, false otherwise</returns>
        public static bool Contains(DateTime start, DateTime end, DateTime date)
        {
            return date >= start && date < end;
        }
    }
}
