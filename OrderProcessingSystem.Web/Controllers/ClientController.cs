using Microsoft.AspNetCore.Mvc;

namespace OrderProcessingSystem.Web.Controllers
{
    /// <summary>
    /// Client Controller
    /// </summary>
    public class ClientController : Controller
    {
        /// <summary>
        /// Route to new client
        /// </summary>
        /// <returns>New Client View</returns>
        public IActionResult NewClient()
        {
            return View();
        }
    }
}