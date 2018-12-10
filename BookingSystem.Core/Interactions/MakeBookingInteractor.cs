using BookingSystem.Core.Entities;
using BookingSystem.Core.Exceptions;
using BookingSystem.Core.Extensions;
using BookingSystem.Core.Interfaces;
using FluentValidation;
using System;

namespace BookingSystem.Core.Interactions
{
    /// <summary>
    /// An interactor for making a booking
    /// </summary>
    public class MakeBookingInteractor : IMakeBookingRequest
    {
        private readonly IMakeBookingResponseHandler responseHandler;

        private readonly IBookingRepository bookingRepository;

        private readonly IValidator<Booking> validator;

        /// <summary>
        /// Gets or sets the booking to be made
        /// </summary>
        public Booking Booking { get; set; }

        /// <summary>
        /// Creates an interaction that will make a booking against a set space for a given period
        /// </summary>
        /// <param name="responseHandler">The entity responsible for handling the response</param>
        /// <param name="bookingRepository">Repository to search/add the booking to</param>
        /// <param name="validator">Validator used to ensure the booking is valid</param>"
        public MakeBookingInteractor(IMakeBookingResponseHandler responseHandler, IBookingRepository bookingRepository, IValidator<Booking> validator)
        {
            this.responseHandler = responseHandler;
            this.bookingRepository = bookingRepository;
            this.validator = validator;
        }

        /// <summary>
        /// Executes the interactor
        /// </summary>
        public void Execute()
        {
            try
            {
                if (Booking == null)
                    throw new ArgumentException("Booking cannot be null");

                var results = validator.Validate(Booking);

                if (results.IsValid == false)
                    throw new InvalidBookingException(results.Flatten());

                if (bookingRepository.HasOverlapping(Booking))
                {
                    responseHandler.Fail("Another booking overlaps with this one.");
                }
                else
                {
                    bookingRepository.Add(Booking);
                    responseHandler.Success();
                }
            }
            catch (Exception e)
            {
                responseHandler.Error(e);
            }
        }
    }
}
