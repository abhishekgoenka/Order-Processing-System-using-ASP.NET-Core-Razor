using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Contracts;

namespace OrderProcessingSystem.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IOrderProcessingUow uow;

        public HomeController(IOrderProcessingUow uow)
        {
            this.uow = uow;
        }

        public IActionResult Index()
        {
            uow.Orders.Include("OrderStage");
            uow.Orders.Include("Item");

            var orders = uow.Orders.GetAll().Where(e => e.OrderStage.PercentageComplete != 100 ).OrderBy(e => e.LastUpdatedDTTM).ToList();
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