using BookingSystem.Core.Entities;
using System.Collections.Generic;

namespace BookingSystem.Core.Interfaces
{
    /// <summary>
    /// A contract that any space repository must implement
    /// </summary>
    public interface ISpaceRepository
    {
        /// <summary>
        /// Gets all the spaces
        /// </summary>
        /// <returns></returns>
        IList<Space> Get();
    }
}
