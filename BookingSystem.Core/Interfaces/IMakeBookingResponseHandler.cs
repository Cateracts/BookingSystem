using BookingSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSystem.Core.Interfaces
{
    /// <summary>
    /// A contract that any response handler for making a booking must implement
    /// </summary>
    public interface IMakeBookingResponseHandler : IResponseHandler
    {
    }
}
