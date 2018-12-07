namespace BookingSystem.Core.Entities
{
    /// <summary>
    /// Represents a physical space that can be booked
    /// </summary>
    public class Space : DomainEntity
    {
        /// <summary>
        /// Gets or sets the name of the space
        /// </summary>
        public string Name { get; set; }
    }
}
