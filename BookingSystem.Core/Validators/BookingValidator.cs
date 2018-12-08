using BookingSystem.Core.Entities;
using FluentValidation;
using System;

namespace BookingSystem.Core.Rules
{
    /// <summary>
    /// A concrete validator for bookings
    /// </summary>
    public class BookingValidator : AbstractValidator<Booking>, IValidator<Booking>
    {
        /// <summary>
        /// Constructs a validator for bookings
        /// </summary>
        public BookingValidator()
        {
            RuleFor(booking => booking.Name).NotNull().NotEmpty();

            RuleFor(booking => booking.Start).NotEqual(DateTime.MinValue)
                                             .NotEqual(DateTime.MaxValue);

            RuleFor(booking => booking.End).GreaterThanOrEqualTo(booking => booking.Start)
                                           .NotEqual(DateTime.MaxValue);

            RuleFor(booking => booking.Space).NotNull();
        }
    }
}
