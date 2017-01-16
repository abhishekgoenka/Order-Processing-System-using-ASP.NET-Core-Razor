using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderProcessingSystem.Models
{
    /// <summary>
    ///     Item model
    /// </summary>
    public class Item : Entity<int>
    {
        /// <summary>
        ///     Item name
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        ///     Item Description
        /// </summary>
        [StringLength(255)]
        public string Description { get; set; }

        /// <summary>
        ///     Current Item Qty. Default is 0
        /// </summary>
        public int Qty { get; set; } = 0;

        /// <summary>
        ///     Navigational Property: Orders
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }
    }
}