using BookingSystem.Core.Entities;
using BookingSystem.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.Persistence.InMemory
{
    /// <summary>
    /// A concrete implementation of the space repository that stores spaces in memory
    /// </summary>
    public class InMemorySpaceRepository : ISpaceRepository
    {
        public IList<Space> Spaces { get; set; } = new List<Space>();

        /// <summary>
        /// Gets all the spaces
        /// </summary>
        /// <returns>A collection of spaces</returns>
        public IList<Space> Get()
        {
            return Spaces.ToList();
        }
    }
}
