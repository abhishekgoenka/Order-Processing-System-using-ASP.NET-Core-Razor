using System;
using System.Data.Entity;
using System.Linq;
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
            SeedClient(context);
            SeedItem(context);
            SeedOrderStages(context);
            SeedClientType(context);
            context.SaveChanges();
            SeedOrders(context);
            base.Seed(context);
        }

        private void SeedOrders(OrderProcessingDbContext context)
        {
            context.Orders.Add(new Order
            {
                Item = context.Items.First(),
                Client = context.Clients.First(),
                AdditionalNotes = "The item is under process. Stay tuned for an update",
                LastUpdatedDTTM = DateTime.Now.AddDays(-5),
                OrderDate = DateTime.Now.AddDays(-10),
                OrderStage = context.OrderStages.FirstOrDefault(e => e.Name == "Billing"),
                ShippingAddress = "Mailing Address",
                SpecialOrderInstructions = String.Empty
            });

            context.Orders.Add(new Order
            {
                Item = context.Items.First(e => e.Name == "Table Cloth"),
                Client = context.Clients.First(),
                AdditionalNotes = "Order is shipped. You will soon receive the order.",
                LastUpdatedDTTM = DateTime.Now.AddDays(-1),
                OrderDate = DateTime.Now.AddDays(-9),
                OrderStage = context.OrderStages.FirstOrDefault(e => e.Name == "Shipped"),
                ShippingAddress = "Mailing Address",
                SpecialOrderInstructions = String.Empty
            });

            context.Orders.Add(new Order
            {
                Item = context.Items.First(e => e.Name == "T-Shirt"),
                Client = context.Clients.First(),
                AdditionalNotes = "Order received and is under processing.",
                LastUpdatedDTTM = DateTime.Now,
                OrderDate = DateTime.Now.AddDays(-1),
                OrderStage = context.OrderStages.FirstOrDefault(e => e.Name == "Intake"),
                ShippingAddress = "Mailing Address",
                SpecialOrderInstructions = String.Empty
            });

            context.Orders.Add(new Order
            {
                Item = context.Items.First(e => e.Name == "Streamers"),
                Client = context.Clients.First(),
                AdditionalNotes = "The item is under process. Stay tuned for an update",
                LastUpdatedDTTM = DateTime.Now.AddDays(-2),
                OrderDate = DateTime.Now.AddDays(-6),
                OrderStage = context.OrderStages.FirstOrDefault(e => e.Name == "Fulfilling Inventory"),
                ShippingAddress = "Mailing Address",
                SpecialOrderInstructions = String.Empty
            });
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
            context.OrderStages.Add(new OrderStage {Name = "Intake", PercentageComplete = 5});
            context.OrderStages.Add(new OrderStage { Name = "Fulfilling Inventory", PercentageComplete = 10 });
            context.OrderStages.Add(new OrderStage { Name = "Billing", PercentageComplete = 30 });
            context.OrderStages.Add(new OrderStage { Name = "Preparing for Shipment", PercentageComplete = 70 });
            context.OrderStages.Add(new OrderStage { Name = "Shipped", PercentageComplete = 95 });
            context.OrderStages.Add(new OrderStage { Name = "Delivery Confirmed", PercentageComplete = 100 });
            context.OrderStages.Add(new OrderStage { Name = "On Hold", PercentageComplete = 0 });
        }
    }
}