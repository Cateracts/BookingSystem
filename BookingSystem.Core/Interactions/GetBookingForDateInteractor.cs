using BookingSystem.Core.Interfaces;
using System;

namespace BookingSystem.Core.Interactions
{
    /// <summary>
    /// An interactor for getting bookings for a set date
    /// </summary>
    public class GetBookingForDateInteractor : IGetBookingForDateRequest
    {
        private readonly IGetBookingForDateResponseHandler responseHandler;

        private readonly IBookingRepository bookingRepository;

        /// <summary>
        /// Gets or sets the date to get bookings for
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Creates an interaction that will retrieve bookings for a set date
        /// </summary>
        /// <param name="responseHandler">The entity responsible for handling the response from the interactor</param>
        /// <param name="bookingRepository">Repository to search for bookings</param>
        public GetBookingForDateInteractor(IGetBookingForDateResponseHandler responseHandler, IBookingRepository bookingRepository)
        {
            this.responseHandler = responseHandler;
            this.bookingRepository = bookingRepository;
        }

        /// <summary>
        /// Executes the interactor
        /// </summary>
        public void Execute()
        {
            // TODO: Check for invalid date? ie: Pre-1900

            try
            {
                responseHandler.Bookings = bookingRepository.GetForDay(Date);
            }
            catch (Exception e)
            {
                responseHandler.Error(e);
            }
        }
    }
}
