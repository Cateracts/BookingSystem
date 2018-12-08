using BookingSystem.Core.Entities;
using BookingSystem.Core.Interfaces;
using BookingSystem.WebApi.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        // GET api/values
        [HttpGet]
        public ActionResult<Booking> Get()
        {
            getBookingsForDateRequest.Date = DateTime.Today;
            getBookingsForDateRequest.Execute();

            return Ok(getBookingsForDateResponseHandler.Bookings);
        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody] MakeBookingRequest request)
        {
            makeBookingRequest.Booking = new Booking
            {
                Name = request.Name,
                Start = request.Start,
                End = request.End,
                Space = new Space { Id = request.SpaceId }
            };

            makeBookingRequest.Execute();
        }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
