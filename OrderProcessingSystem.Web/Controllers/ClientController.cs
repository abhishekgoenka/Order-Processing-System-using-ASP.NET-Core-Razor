using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Contracts;
using OrderProcessingSystem.Data;
using OrderProcessingSystem.Data.Helpers;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Web.Controllers
{
    /// <summary>
    ///     Client Controller
    /// </summary>
    public class ClientController : Controller
    {
        private readonly IOrderProcessingUow uow =
            new OrderProcessingUow(new RepositoryProvider(new RepositoryFactories()));

        /// <summary>
        ///     Route to new client
        /// </summary>
        /// <returns>New Client View</returns>
        public IActionResult NewClient()
        {
            return View();
        }

        /// <summary>
        ///     Route to Show All Clients
        /// </summary>
        /// <returns>Show All Clients View</returns>
        public IActionResult ShowAllClients()
        {
            return View(uow.Clients.GetAll().ToList());
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
            {
                uow.Clients.Add(newClient);
                uow.Commit();
                return RedirectToAction("Index", "Home");
            }
                

            // response is not valid. Return to same view
            return View(newClient);
        }
    }
}