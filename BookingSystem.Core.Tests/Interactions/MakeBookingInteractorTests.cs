using BookingSystem.Core.Entities;
using BookingSystem.Core.InMemory;
using BookingSystem.Core.Interactions;
using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Rules;
using BookingSystem.Core.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookingSystem.Core.Tests.Interactions
{
    /// <summary>
    /// Tests to examine the interactor for making a booking
    /// </summary>
    [TestClass]
    public class MakeBookingInteractorTests
    {
        /// <summary>
        /// Test that it's possible to make a booking
        /// </summary>
        [TestMethod]
        public void MakeBooking()
        {
            // Arrange
            var booking_repository = new InMemoryBookingRepository();
            var response_handler = new MakeBookingResponseHandler();
            var validator = new BookingValidator();
            var make_booking_interaction = new MakeBookingInteractor(response_handler, booking_repository, validator);
            make_booking_interaction.Booking = new Booking { Id = 5, Name = "FirstName1 LastName1", Start = new DateTime(2018, 1, 1, 10, 0, 0), End = new DateTime(2018, 1, 1, 11, 0, 0), Space = new Space { Name = "Boardroom" } };

            // Act
            make_booking_interaction.Execute();

            // Assert
            Assert.IsTrue(response_handler.WasSuccessful);
        }

        /// <summary>
        /// Test that a subsequent, conflicting booking is not possible to make
        /// </summary>
        [TestMethod]
        public void MakeASubsequentConflictingBooking()
        {
            // Arrange
            var booking_repository = new InMemoryBookingRepository();
            var response_handler = new MakeBookingResponseHandler();
            var validator = new BookingValidator();
            var make_booking_interaction = new MakeBookingInteractor(response_handler, booking_repository, validator);
            make_booking_interaction.Booking = new Booking { Id = 5, Name = "FirstName1 LastName1", Start = new DateTime(2018, 1, 1, 10, 0, 0), End = new DateTime(2018, 1, 1, 11, 0, 0), Space = new Space { Name = "Boardroom" } };

            // Act / Assert
            make_booking_interaction.Execute();

            Assert.IsTrue(response_handler.WasSuccessful);

            make_booking_interaction.Execute();

            Assert.IsFalse(response_handler.WasSuccessful);
        }

        /// <summary>
        /// Test that booking side by side for a space works
        /// </summary>
        [TestMethod]
        public void MakeSideBySideBookinForSameSpace()
        {
            // Arrange
            var booking_repository = new InMemoryBookingRepository();
            var response_handler = new MakeBookingResponseHandler();
            var validator = new BookingValidator();
            var booking_a = new Booking { Id = 4, Name = "FirstName1 LastName1", Start = new DateTime(2018, 1, 1, 10, 0, 0),End = new DateTime(2018, 1, 1, 11, 0, 0), Space = new Space { Name = "Boardroom" } };
            var booking_b = new Booking { Id = 5, Name = "FirstName1 LastName1", Start = new DateTime(2018, 1, 1, 11, 0, 0), End = new DateTime(2018, 1, 1, 12, 0, 0), Space = new Space { Name = "Boardroom" } };

            var make_booking_interaction = new MakeBookingInteractor(response_handler, booking_repository, validator);
            make_booking_interaction.Booking = booking_a;            

            // Act / Assert
            make_booking_interaction.Execute();

            Assert.IsTrue(response_handler.WasSuccessful);

            make_booking_interaction.Booking = booking_b;

            make_booking_interaction.Execute();

            Assert.IsTrue(response_handler.WasSuccessful);
        }

        /// <summary>
        /// Make a booking (A) beside an existing booking (B)
        /// </summary>
        [TestMethod]
        public void MakeBookingABesideBookingB()
        {
            // Arrange
            var booking_repository = new InMemoryBookingRepository();
            var response_handler = new MakeBookingResponseHandler();
            var validator = new BookingValidator();
            var booking_a = new Booking { Id = 4, Name = "FirstName1 LastName1", Start = new DateTime(2018, 1, 1, 10, 0, 0), End = new DateTime(2018, 1, 1, 11, 0, 0), Space = new Space { Name = "Boardroom" } };
            var booking_b = new Booking { Id = 5, Name = "FirstName1 LastName1", Start = new DateTime(2018, 1, 1, 11, 0, 0), End = new DateTime(2018, 1, 1, 12, 0, 0), Space = new Space { Name = "Boardroom" } };

            var make_booking_interaction = new MakeBookingInteractor(response_handler, booking_repository, validator);
            make_booking_interaction.Booking = booking_b;

            // Act / Assert
            make_booking_interaction.Execute();

            Assert.IsTrue(response_handler.WasSuccessful);

            make_booking_interaction.Booking = booking_a;

            make_booking_interaction.Execute();

            Assert.IsTrue(response_handler.WasSuccessful);
        }

        /// <summary>
        /// Test that it's not possible to make a null booking
        /// </summary>
        [TestMethod]
        public void MakeANullBooking()
        {
            // Arrange
            var booking_repository = new InMemoryBookingRepository();
            var response_handler = new MakeBookingResponseHandler();
            var validator = new BookingValidator();
            var make_booking_interaction = new MakeBookingInteractor(response_handler, booking_repository, validator);

            // Act
            make_booking_interaction.Execute();

            // Assert
            Assert.IsTrue(make_booking_interaction.Booking == null);
            Assert.IsTrue(response_handler.Exception != null);
            Assert.IsTrue(response_handler.Exception.GetType() == typeof(ArgumentException));
        }

        /// <summary>
        /// Test that it's not possible to make an invalid booking
        /// </summary>
        [TestMethod]
        public void MakeABookingWithoutAName()
        {
            // Arrange
            var booking_repository = new InMemoryBookingRepository();
            var response_handler = new MakeBookingResponseHandler();
            var validator = new BookingValidator();
            var make_booking_interaction = new MakeBookingInteractor(response_handler, booking_repository, validator);
            make_booking_interaction.Booking = new Booking { Start = new DateTime(2018, 1, 1, 10, 0, 0), End = new DateTime(2018, 1, 1, 11, 0, 0), Space = new Space { Name = "Boardroom" } };

            // Act
            make_booking_interaction.Execute();

            // Assert
            Assert.IsFalse(response_handler.WasSuccessful);
        }
    }

    /// <summary>
    /// A simple concrete implementation of a response handler for making a booking
    /// </summary>
    public class MakeBookingResponseHandler : MockResponseHandler, IMakeBookingResponseHandler
    {
    }
}
