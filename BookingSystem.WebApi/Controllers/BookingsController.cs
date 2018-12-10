using BookingSystem.Core.Entities;
using BookingSystem.Core.Interfaces;
using BookingSystem.WebApi.Presenters;
using BookingSystem.WebApi.Requests;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookingSystem.WebApi.Controllers
{
    /// <summary>
    /// Controller for all things booking related
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IGetBookingForDateRequest getBookingsForDateRequest;
        private readonly IGetBookingForDateResponseHandler getBookingsForDateResponseHandler;

        private readonly IMakeBookingRequest makeBookingRequest;
        private readonly IMakeBookingResponseHandler makeBookingResponseHandler;

        public BookingsController(IGetBookingForDateRequest getBookingsForDateRequest,
                                  IGetBookingForDateResponseHandler getBookingsForDateResponseHandler,
                                  IMakeBookingRequest makeBookingRequest,
                                  IMakeBookingResponseHandler makeBookingResponseHandler)
        {
            this.getBookingsForDateRequest = getBookingsForDateRequest;
            this.getBookingsForDateResponseHandler = getBookingsForDateResponseHandler;

            this.makeBookingRequest = makeBookingRequest;
            this.makeBookingResponseHandler = makeBookingResponseHandler;
        }
        
        [HttpGet]
        public ActionResult<Booking> Get()
        {
            getBookingsForDateRequest.Date = DateTime.Today;
            getBookingsForDateRequest.Execute();

            return (getBookingsForDateResponseHandler as GetBookingForDatePresenter).Result;
        }

        [HttpPost]
        public ActionResult Post([FromBody] MakeBookingRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            makeBookingRequest.Booking = new Booking
            {
                Name = request.Name,
                Start = request.Start,
                End = request.End,
                Space = request.Space
            };

            makeBookingRequest.Execute();

            return (makeBookingResponseHandler as MakeBookingPresenter).Result;
        }
    }
}
