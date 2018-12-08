using BookingSystem.Core.Interfaces;
using System;

namespace BookingSystem.WebApi.Presenters
{
    public class MakeBookingPresenter : IMakeBookingResponseHandler
    {
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
