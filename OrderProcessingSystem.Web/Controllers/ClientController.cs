using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Web.Controllers
{
    /// <summary>
    ///     Client Controller
    /// </summary>
    public class ClientController : Controller
    {
        /// <summary>
        ///     Route to new client
        /// </summary>
        /// <returns>New Client View</returns>
        public IActionResult NewClient()
        {
            return View();
        }

        /// <summary>
        ///     Post : Adds new client to database
        /// </summary>
        /// <param name="newClient">Client</param>
        /// <returns>View</returns>
        [HttpPost]
        public IActionResult NewClient(Client newClient)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Index", "Home");

            // response is not valid. Return to same view
            return View(newClient);
        }
    }
}