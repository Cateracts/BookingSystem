using BookingSystem.Core.Entities;
using BookingSystem.Core.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookingSystem.Core.Tests.Validators
{
    /// <summary>
    /// Tests for the booking validator
    /// </summary>
    [TestClass]
    public class BookingValidatorTests
    {
        /// <summary>
        /// Test that it's possible for a booking to be valid
        /// </summary>
        [TestMethod]
        public void ValidateBooking()
        {
            // Arrange
            var booking = new Booking
            {
                Id = 0,
                Name = "FirstName1 LastName1",
                Start = new DateTime(2018, 1, 1, 10, 0, 0),
                End = new DateTime(2018, 1, 1, 11, 0, 0),
                Space = new Space { Id = 0, Name = "Boardroom" }
            };

            var validator = new BookingValidator();

            // Act
            var results = validator.Validate(booking);

            // Assert
            Assert.IsTrue(results.IsValid);
        }

        /// <summary>
        /// Test that a booking without a name is invalid
        /// </summary>
        [TestMethod]
        public void BookingWithEmptyNameIsInvalid()
        {
            // Arrange
            var booking = new Booking
            {
                Id = 0,
                Name = "",
                Start = new DateTime(2018, 1, 1, 10, 0, 0),
                End = new DateTime(2018, 1, 1, 11, 0, 0),
                Space = new Space { Id = 0, Name = "Boardroom" }
            };

            var validator = new BookingValidator();

            // Act
            var results = validator.Validate(booking);

            // Assert
            Assert.IsFalse(results.IsValid);
        }

        /// <summary>
        /// Test that a booking without a name is invalid
        /// </summary>
        [TestMethod]
        public void BookingWithNoNameIsInvalid()
        {
            // Arrange
            var booking = new Booking
            {
                Id = 0,
                Start = new DateTime(2018, 1, 1, 10, 0, 0),
                End = new DateTime(2018, 1, 1, 11, 0, 0),
                Space = new Space { Id = 0, Name = "Boardroom" }
            };

            var validator = new BookingValidator();

            // Act
            var results = validator.Validate(booking);

            // Assert
            Assert.IsFalse(results.IsValid);
        }

        /// <summary>
        /// Test that a booking without a period is invalid
        /// </summary>
        [TestMethod]
        public void BookingWithNoPeriodIsInvalid()
        {
            // Arrange
            var booking = new Booking
            {
                Id = 0,
                Name = "FirstName1 LastName1",
                Space = new Space { Id = 0, Name = "Boardroom" }
            };

            var validator = new BookingValidator();

            // Act
            var results = validator.Validate(booking);

            // Assert
            Assert.IsFalse(results.IsValid);
        }

        /// <summary>
        /// Test that a booking without a space is invalid
        /// </summary>
        [TestMethod]
        public void BookingWithNoSpaceIsInvalid()
        {
            // Arrange
            var booking = new Booking
            {
                Id = 0,
                Name = "FirstName1 LastName1",
                Start = new DateTime(2018, 1, 1, 10, 0, 0),
                End = new DateTime(2018, 1, 1, 11, 0, 0)
            };

            var validator = new BookingValidator();

            // Act
            var results = validator.Validate(booking);

            // Assert
            Assert.IsFalse(results.IsValid);
        }
    }
}
