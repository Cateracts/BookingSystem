using System;

namespace BookingSystem.Core.Interfaces
{
    /// <summary>
    /// A contract that any response handler must implement
    /// </summary>
    public interface IResponseHandler
    {
        /// <summary>
        /// Called upon when the operation was successful
        /// </summary>
        void Success();

        /// <summary>
        /// Called upon when failed
        /// </summary>
        /// <param name="message">Message to indicate why there wasa failure</param>
        void Fail(string message);

        /// <summary>
        /// Called upon when an error occurs
        /// </summary>
        /// <param name="e">The exception that occurred</param>
        void Error(Exception e);
    }
}
