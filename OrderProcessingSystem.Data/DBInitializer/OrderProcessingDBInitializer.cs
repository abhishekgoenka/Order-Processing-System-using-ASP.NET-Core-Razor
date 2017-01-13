using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Data.DBInitializer
{
    /// <summary>
    /// Custom DB initializer. This will seed data.
    /// </summary>
    public class OrderProcessingDBInitializer : CreateDatabaseIfNotExists<OrderProcessingDbContext>
    {
        /// <summary>
        /// Seed items
        /// </summary>
        /// <param name="context">DBContext</param>
        protected override void Seed(OrderProcessingDbContext context)
        {
            SeedOrders(context);
            base.Seed(context);
        }

        private void SeedOrders(OrderProcessingDbContext context)
        {
            context.Orders.Add(new Order
            {
                Name = "Hoodie",
                Description = "25 hoodies required for Mphasis",
                LastUpdated = DateTime.Now.AddDays(-15)
            });

            context.Orders.Add(new Order
            {
                Name = "Table Cloth",
                Description = "100 Table Cloth required for Larsen & Toubro Infotech",
                LastUpdated = DateTime.Now.AddDays(-1)
            });

            context.Orders.Add(new Order
            {
                Name = "T-Shirt",
                Description = "1000 T-Shirt required for ALTEN Calsoft Labs",
                LastUpdated = DateTime.Now.AddDays(-60)
            });

            context.Orders.Add(new Order
            {
                Name = "Banner",
                Description = "10 Banner required for Aftek",
                LastUpdated = DateTime.Now.AddDays(-2)
            });
        }
    }
}