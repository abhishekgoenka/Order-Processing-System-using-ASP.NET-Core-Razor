using System;
using System.Data.Entity;
using OrderProcessingSystem.Data.DBInitializer;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Data
{
    /// <summary>
    /// Order Processing DBContext. This will create a database if not already exists
    /// </summary>
    public class OrderProcessingDbContext : DbContext
    {
        //todo : move to config file
        private const String CONNECTION_STRING = "Data Source=(local);Initial Catalog=OrderProcessing;Persist Security Info=True;User ID=sa;Password=Computer#1";
        public OrderProcessingDbContext()
            : base(CONNECTION_STRING)
        {
            Database.SetInitializer(new OrderProcessingDBInitializer());
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<OrderStage> OrderStages { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //One to Many relationship : Client can have multiple orders
            modelBuilder.Entity<Order>()
                .HasRequired(e => e.Client)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.ClientId)
                .WillCascadeOnDelete(true);

            //One to Many relationship : Multiple orders can have same Item
            modelBuilder.Entity<Order>()
                .HasRequired(e => e.Item)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.ItemId)
                .WillCascadeOnDelete(true);

            //One to Many relationship : Multiple orders can have same order stage
            modelBuilder.Entity<Order>()
                .HasRequired(e => e.OrderStage)
                .WithMany(e => e.Orders)
                .HasForeignKey(e => e.OrderStageId)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);

            // Use singular table names
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}