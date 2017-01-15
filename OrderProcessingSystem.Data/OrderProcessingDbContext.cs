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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //One to One RelationShip : Each client can have one Billing Address
            //modelBuilder.Entity<Address>()
            //    .HasRequired(e => e.Client)
            //    .WithOptional(e => e.BillingAddress)
            //    .WillCascadeOnDelete(true);
            //modelBuilder.Entity<Client>()
            //    .HasOptional(e => e.BillingAddress)
            //    .WithRequired(e => e.Client)
            //    .WillCascadeOnDelete(true);

            //One to One RelationShip : Each client can have one Mailing Address
            //modelBuilder.Entity<Address>()
            //    .HasRequired(e => e.Client)
            //    .WithOptional(e => e.MailingAddress);

            //One to Many relationship : ListItem can have my items, 
            //modelBuilder.Entity<ListItem>()
            //    .HasRequired(e => e.Item)
            //    .WithMany(e => e.ListItems)
            //    .HasForeignKey(e => e.ItemId)
            //    .WillCascadeOnDelete(true);



            base.OnModelCreating(modelBuilder);

            // Use singular table names
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}