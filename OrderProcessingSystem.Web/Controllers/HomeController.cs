using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Contracts;
using OrderProcessingSystem.Data;
using OrderProcessingSystem.Data.Helpers;

namespace OrderProcessingSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderProcessingUow uow =
            new OrderProcessingUow(new RepositoryProvider(new RepositoryFactories()));

        public IActionResult Index()
        {
            var orders = uow.Orders.GetAll().ToList();
            ViewBag.Orders = orders;
            return View();
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