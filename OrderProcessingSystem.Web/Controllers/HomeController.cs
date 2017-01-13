using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Contracts;
using OrderProcessingSystem.Data;
using OrderProcessingSystem.Data.Helpers;

namespace OrderProcessingSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderProcessingUow uow = new OrderProcessingUow(new RepositoryProvider(new RepositoryFactories())); 

        public IActionResult Index()
        {
            try
            {
                var orders = uow.Orders.GetAll().ToList();
                return View(orders);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
