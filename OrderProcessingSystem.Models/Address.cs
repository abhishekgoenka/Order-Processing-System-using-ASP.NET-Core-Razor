namespace OrderProcessingSystem.Models
{
    /// <summary>
    ///     Address Model
    /// </summary>
    public class Address : Entity<int>
    {
        /// <summary>
        ///     Street value
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        ///     City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        ///     Zip code
        /// </summary>
        public string Zip { get; set; }
    }
}