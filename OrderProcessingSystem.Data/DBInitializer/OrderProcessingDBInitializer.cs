using System;
using System.Data.Entity;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Data.DBInitializer
{
    /// <summary>
    ///     Custom DB initializer. This will seed data.
    /// </summary>
    public class OrderProcessingDBInitializer : CreateDatabaseIfNotExists<OrderProcessingDbContext>
    {
        /// <summary>
        ///     Seed items
        /// </summary>
        /// <param name="context">DBContext</param>
        protected override void Seed(OrderProcessingDbContext context)
        {
            SeedOrders(context);
            SeedClient(context);
            SeedItem(context);
            SeedClientType(context);
            SeedOrderStages(context);
            base.Seed(context);
        }

        private void SeedOrders(OrderProcessingDbContext context)
        {
            //context.Orders.Add(new Order
            //{
            //    Name = "Hoodie",
            //    Description = "25 hoodies required for Mphasis",
            //    LastUpdated = DateTime.Now.AddDays(-15)
            //});

            //context.Orders.Add(new Order
            //{
            //    Name = "Table Cloth",
            //    Description = "100 Table Cloth required for Larsen & Toubro Infotech",
            //    LastUpdated = DateTime.Now.AddDays(-1)
            //});

            //context.Orders.Add(new Order
            //{
            //    Name = "T-Shirt",
            //    Description = "1000 T-Shirt required for ALTEN Calsoft Labs",
            //    LastUpdated = DateTime.Now.AddDays(-60)
            //});

            //context.Orders.Add(new Order
            //{
            //    Name = "Banner",
            //    Description = "10 Banner required for Aftek",
            //    LastUpdated = DateTime.Now.AddDays(-2)
            //});
        }

        private void SeedClient(OrderProcessingDbContext context)
        {
            context.Clients.Add(new Client
            {
                FirstName = "Abhishek",
                LastName = "Goenka",
                ClientType = "Individual",
                ContractDate = DateTime.Now.AddYears(-5),
                Email = "abhishek@nblog.in",
                Phone = "9008719714",
                Notes = "Test Notes",
                CompanyName = "No Company",
                BillingAddress =
                    new Address {Id = 1, Street = "ABV", City = "Bangalore", State = "Karnataka", Zip = "560102"},
                MailingAddress =
                    new Address {Id = 2, Street = "ABV", City = "Bangalore", State = "Karnataka", Zip = "560102"}
            });
        }

        private void SeedItem(OrderProcessingDbContext context)
        {
            context.Items.Add(new Item {Name = "Hoodie"});
            context.Items.Add(new Item {Name = "T-Shirt", Description = "This is fastest selling item"});
            context.Items.Add(new Item {Name = "Table Cloth"});
            context.Items.Add(new Item {Name = "Banner"});
            context.Items.Add(new Item {Name = "Streamers"});
        }

        private void SeedClientType(OrderProcessingDbContext context)
        {
            context.ClientTypes.Add(new ClientType {Text = "Small Business"});
            context.ClientTypes.Add(new ClientType { Text = "Individual" });
            context.ClientTypes.Add(new ClientType { Text = "Corporation" });
        }

        private void SeedOrderStages(OrderProcessingDbContext context)
        {
            context.OrderStages.Add(new OrderStage {Name = "Intake", PercentageComplete = 0});
            context.OrderStages.Add(new OrderStage { Name = "Fulfilling Inventory", PercentageComplete = 10 });
            context.OrderStages.Add(new OrderStage { Name = "Billing", PercentageComplete = 30 });
            context.OrderStages.Add(new OrderStage { Name = "Preparing for Shipment", PercentageComplete = 70 });
            context.OrderStages.Add(new OrderStage { Name = "Shipped", PercentageComplete = 95 });
            context.OrderStages.Add(new OrderStage { Name = "Delivery Confirmed", PercentageComplete = 100 });
            context.OrderStages.Add(new OrderStage { Name = "On Hold", PercentageComplete = 0 });
        }
    }
}