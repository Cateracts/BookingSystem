using BookingSystem.Core.Entities;
using BookingSystem.Core.Interfaces;
using BookingSystem.Persistence.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace BookingSystem.Persistence.InMemory
{
    /// <summary>
    /// A concrete implementation of the space repository using Entity Framework
    /// </summary>
    public class EntityFrameworkSpaceRepository : ISpaceRepository
    {
        private BookingContext context;

        /// <summary>
        /// Constructs the repository
        /// </summary>
        /// <param name="context">Persistence context to use</param>
        public EntityFrameworkSpaceRepository(BookingContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets all the spaces
        /// </summary>
        /// <returns>A collection of spaces</returns>
        public IList<Space> Get()
        {
            return context.Spaces.ToList();
        }
    }
}
