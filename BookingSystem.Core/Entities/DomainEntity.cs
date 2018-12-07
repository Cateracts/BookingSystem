namespace BookingSystem.Core.Entities
{
    /// <summary>
    /// Represents an entity within this business domain
    /// </summary>
    public class DomainEntity
    {
        /// <summary>
        /// Gets or sets the identifier of this entity
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets whether the entity has been soft-deleted
        /// </summary>
        public bool SoftDeleted { get; set; }
    }
}
