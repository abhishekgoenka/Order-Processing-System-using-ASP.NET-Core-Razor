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
        public OrderProcessingDbContext()
            : base("Data Source=(local);Initial Catalog=OrderProcessing;Persist Security Info=True;User ID=sa;Password=Computer#1")
        {
            Database.SetInitializer(new OrderProcessingDBInitializer());
        }

        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

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