using System;

namespace BookingSystem.Core.Interfaces
{
    /// <summary>
    /// A contract that any response handler must implement
    /// </summary>
    public interface IResponseHandler
    {
        /// <summary>
        /// Calls an error on the response handler with the given exception
        /// </summary>
        /// <param name="e">The exception that occurred</param>
        void Error(Exception e);
    }
}
