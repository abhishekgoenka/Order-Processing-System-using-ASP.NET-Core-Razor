using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
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
            //only for debug
            var task = Task.Run(async () => await WriteOutIdentityInformation());
            task.Wait();

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

        public async Task WriteOutIdentityInformation()
        {
            // get the saved identity token
            var identityToken = await HttpContext.Authentication
                .GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            // write it out
            Debug.WriteLine($"Identity token: {identityToken}");

            // write out the user claims
            foreach (var claim in User.Claims)
            {
                Debug.WriteLine($"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }
        }
    }
}