using System;

namespace OrderProcessingSystem.Models
{
    /// <summary>
    ///     Order Model
    /// </summary>
    public class Order : Entity<Int32>
    {
        /// <summary>
        ///     Order Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Order Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///     Last updated date and time of order
        /// </summary>
        public DateTime LastUpdated { get; set; }
    }
}