using System.Data.Entity.Infrastructure;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Data
{
    public class OrderProcessingContextFactory : IDbContextFactory<OrderProcessingDbContext>
    {
        public OrderProcessingDbContext Create()
        {
            //return new OrderProcessingDbContext("Server=(localdb)\\mssqllocaldb;Database=OrderProcessingV2;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new OrderProcessingDbContext("Server=tcp:orderprocessing.database.windows.net;Initial Catalog=orderprocessing;Persist Security Info=True;User ID=orderprocessing@orderprocessing;Password=Computer#1");
        }
    }
}