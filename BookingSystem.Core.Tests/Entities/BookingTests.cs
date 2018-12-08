using BookingSystem.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BookingSystem.Core.Tests.Entities
{
    /// <summary>
    /// Tests for the behaviour of the booking class
    /// </summary>
    [TestClass]
    public class BookingTests
    {
        /// <summary>
        /// Tests that 2 bookings with a different space but same times is allowed
        /// </summary>
        [TestMethod]
        public void TestBookingsWithDifferentSpaceButSameTimeIsAllowed()
        {
            // Arrange
            var booking_a = new Booking { Space = new Space { Id = 0 }, Start = new DateTime(2018, 1, 1, 9, 0, 0), End = new DateTime(2018, 1, 1, 10, 0, 0) };
            var booking_b = new Booking { Space = new Space { Id = 1 }, Start = new DateTime(2018, 1, 1, 9, 0, 0), End = new DateTime(2018, 1, 1, 10, 0, 0) };

            // Act
            var result = booking_a.ConflictsWith(booking_b);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Tests that bookings on the same space but with times not overlapping is allowed
        /// </summary>
        [TestMethod]
        public void TestBookingsWithOverlappingSpaceButNotTimeIsAllowed()
        {
            // Arrange
            var booking_a = new Booking { Space = new Space { Id = 0 }, Start = new DateTime(2018, 1, 1, 9, 0, 0), End = new DateTime(2018, 1, 1, 10, 0, 0) };
            var booking_b = new Booking { Space = new Space { Id = 0 }, Start = new DateTime(2018, 1, 1, 11, 0, 0), End = new DateTime(2018, 1, 1, 12, 0, 0) };

            // Act
            var result = booking_a.ConflictsWith(booking_b);

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Tests that bookings with the same space and booking start time overlapping is not allowed
        /// </summary>
        [TestMethod]
        public void TestBookingsWithOverlappingSpaceAndStartIsNotAllowed()
        {
            // Arrange
            var booking_a = new Booking { Space = new Space { Id = 0 }, Start = new DateTime(2018, 1, 1, 9, 0, 0), End = new DateTime(2018, 1, 1, 10, 0, 0) };
            var booking_b = new Booking { Space = new Space { Id = 0 }, Start = new DateTime(2018, 1, 1, 9, 30, 0), End = new DateTime(2018, 1, 1, 10, 30, 0) };

            // Act
            var result = booking_a.ConflictsWith(booking_b);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests that bookings with the same space and booking end time overlapping is not allowed
        /// </summary>
        [TestMethod]
        public void TestBookingsWithOverlappingSpaceAndEndIsNotAllowed()
        {
            // Arrange
            var booking_a = new Booking { Space = new Space { Id = 0 }, Start = new DateTime(2018, 1, 1, 10, 30, 0), End = new DateTime(2018, 1, 1, 11, 30, 0) };
            var booking_b = new Booking { Space = new Space { Id = 0 }, Start = new DateTime(2018, 1, 1, 11, 0, 0), End = new DateTime(2018, 1, 1, 12, 0, 0) };

            // Act
            var result = booking_a.ConflictsWith(booking_b);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests that bookings with overlapping space and exact times is not allowed
        /// </summary>
        [TestMethod]
        public void TestBookingsWithOverlappingSpaceAndTimesIsNotAllowed()
        {
            // Arrange
            var booking_a = new Booking { Space = new Space { Id = 0 }, Start = new DateTime(2018, 1, 1, 9, 0, 0), End = new DateTime(2018, 1, 1, 10, 0, 0) };
            var booking_b = new Booking { Space = new Space { Id = 0 }, Start = new DateTime(2018, 1, 1, 9, 0, 0), End = new DateTime(2018, 1, 1, 10, 0, 0) };

            // Act
            var result = booking_a.ConflictsWith(booking_b);

            // Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Tests that booking side by side times is allowed in either direction
        /// </summary>
        [TestMethod]
        public void TestBookingSideBySideIsAllowed()
        {
            // Arrange
            var booking_a = new Booking { Space = new Space { Id = 0 }, Start = new DateTime(2018, 1, 1, 9, 0, 0), End = new DateTime(2018, 1, 1, 10, 0, 0) };
            var booking_b = new Booking { Space = new Space { Id = 0 }, Start = new DateTime(2018, 1, 1, 10, 0, 0), End = new DateTime(2018, 1, 1, 11, 0, 0) };

            // Act / Assert
            var result = booking_a.ConflictsWith(booking_b);
            Assert.IsFalse(result);
            result = booking_b.ConflictsWith(booking_a);
            Assert.IsFalse(result);
        }
    }
}
