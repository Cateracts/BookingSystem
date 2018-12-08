using BookingSystem.Core.Entities;
using BookingSystem.Persistence.InMemory;
using BookingSystem.Core.Interactions;
using BookingSystem.Core.Interfaces;
using BookingSystem.Core.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.Core.Tests.Interactions
{
    /// <summary>
    /// Tests to examine the interactor for getting bookings for a given date
    /// </summary>
    [TestClass]
    public class GetBookingForDateInteractorTests
    {
        private IList<Booking> bookings;

        /// <summary>
        /// Initialise and isolate the test data for each test run
        /// </summary>
        [TestInitialize]
        public void SetupInMemoryRepositoryData()
        {
            bookings = new List<Booking>();
            bookings.Add(new Booking() { Id = 0, Name = "FirstName1, LastName1", Start = new DateTime(2018, 1, 2, 10, 0, 0), End = new DateTime(2018, 1, 2, 11, 0, 0) });
            bookings.Add(new Booking() { Id = 0, Name = "FirstName2, LastName2", Start = new DateTime(2018, 1, 2, 11, 0, 0), End = new DateTime(2018, 1, 2, 12, 0, 0) });
            bookings.Add(new Booking() { Id = 0, Name = "FirstName3, LastName3", Start = new DateTime(2018, 1, 3, 10, 0, 0), End = new DateTime(2018, 1, 3, 11, 0, 0) });
            bookings.Add(new Booking() { Id = 0, Name = "FirstName4, LastName4", Start = new DateTime(2018, 1, 4, 10, 0, 0), End = new DateTime(2018, 1, 4, 11, 0, 0) });
            bookings.Add(new Booking() { Id = 0, Name = "FirstName5, LastName5", Start = new DateTime(2018, 1, 4, 10, 0, 0), End = new DateTime(2018, 1, 4, 11, 0, 0) });
        }

        /// <summary>
        /// Tests that it's possible to get all of the bookings for the day
        /// </summary>
        [TestMethod]
        public void GetBookingsForToday()
        {
            // Arrange
            var today = new DateTime(2018, 1, 2, 10, 0, 0);
            var expected = bookings.Where(booking => booking.Start.Date == today.Date || booking.End.Date == today.Date).ToList();
            var response_handler = new GetBookingForDateResponseHandler();
            var booking_repository = new InMemoryBookingRepository();
            booking_repository.Bookings = bookings;
            var get_booking_for_date_interaction = new GetBookingForDateInteractor(response_handler, booking_repository);
            get_booking_for_date_interaction.Date = today;

            // Act
            get_booking_for_date_interaction.Execute();

            // Assert
            Assert.IsTrue(response_handler.Bookings.Count > 0);
            CollectionAssert.AreEqual(expected, response_handler.Bookings.ToList());
        }

        /// <summary>
        /// Tests that no bookings are returned when there are none for the day
        /// </summary>
        [TestMethod]
        public void GetBookingsForTodayWhenThereAreNone()
        {
            // Arrange
            var today = new DateTime(2018, 1, 1, 10, 0, 0);
            var expected = bookings.Where(booking => booking.Start.Date == today.Date || booking.End.Date == today.Date).ToList();
            var response_handler = new GetBookingForDateResponseHandler();
            var booking_repository = new InMemoryBookingRepository();
            booking_repository.Bookings = bookings;
            var get_booking_for_date_interaction = new GetBookingForDateInteractor(response_handler, booking_repository);
            get_booking_for_date_interaction.Date = today;

            // Act
            get_booking_for_date_interaction.Execute();

            // Assert
            Assert.IsTrue(response_handler.Bookings.Count == 0);
            CollectionAssert.AreEqual(expected, response_handler.Bookings.ToList());
        }

        /// <summary>
        /// Tests what would happen if the repository was faulty
        /// </summary>
        [TestMethod]
        public void GetBookingsForTodayWhenRepositoryIsFaulty()
        {
            // Arrange
            var response_handler = new GetBookingForDateResponseHandler();
            var booking_repository = new FaultyBookingRepository();
            var get_booking_for_date_interaction = new GetBookingForDateInteractor(response_handler, booking_repository);

            // Act
            get_booking_for_date_interaction.Execute();

            // Assert
            Assert.IsTrue(response_handler.Exception != null);
            Assert.IsTrue(response_handler.Bookings == null || response_handler.Bookings.Count == 0);
        }
    }

    /// <summary>
    /// A simple concrete implementation of a response handler for getting bookings for a given date
    /// </summary>
    public class GetBookingForDateResponseHandler : MockResponseHandler, IGetBookingForDateResponseHandler
    {
        /// <summary>
        /// Gets or sets the bookings for the handler
        /// </summary>
        public IList<Booking> Bookings { get; set; }
    }

    /// <summary>
    /// A simple, faulty repository
    /// </summary>
    public class FaultyBookingRepository : IBookingRepository
    {
        public IList<Booking> GetForDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        public bool HasOverlapping(Booking booking)
        {
            throw new NotImplementedException();
        }

        public void Add(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
