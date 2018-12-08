using BookingSystem.Core.Interfaces;
using System;

namespace BookingSystem.Core.Tests.Shared
{
    /// <summary>
    /// Simple, generic mock response handler
    /// </summary>
    public class MockResponseHandler : IResponseHandler
    {
        /// <summary>
        /// Gets or sets whether the operation was successful
        /// </summary>
        public bool WasSuccessful { get; set; }

        /// <summary>
        /// Gets or sets the exception that occurred in the handler
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// To be called upon when the operation was successful
        /// </summary>
        public void Success()
        {
            WasSuccessful = true;
        }

        /// <summary>
        /// To be called upon when the operation fails
        /// </summary>
        public void Fail(string message)
        {
            WasSuccessful = false;
        }

        /// <summary>
        /// Called upon when an error occurs
        /// </summary>
        /// <param name="e">The exception that occurred</param>
        public void Error(Exception e)
        {
            Exception = e;
        }
    }
}
