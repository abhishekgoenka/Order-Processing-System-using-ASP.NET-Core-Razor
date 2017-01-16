using System;
using System.Collections.Generic;

namespace OrderProcessingSystem.Models
{
    /// <summary>
    /// All possible stages of Order
    /// </summary>
    public class OrderStage : Entity<Int32>
    {
        /// <summary>
        /// Order Stage Name
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Percentage of complete at this stage
        /// </summary>
        public Int32 PercentageComplete { get; set; }

        /// <summary>
        ///     Navigational Property: Orders
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }
    }
}