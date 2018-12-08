using BookingSystem.Core.Entities;
using BookingSystem.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace BookingSystem.WebApi.Presenters
{
    public class GetBookingForDatePresenter : IGetBookingForDateResponseHandler
    {
        public IList<Booking> Bookings { get; set; }

        public void Success()
        {
            Console.WriteLine("SUCCESS");
        }

        public void Fail(string message)
        {
            Console.WriteLine("FAILURE");
        }

        public void Error(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
