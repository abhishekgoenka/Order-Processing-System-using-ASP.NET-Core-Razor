using System;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Contracts;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Web.Controllers
{
    /// <summary>
    ///     Order Controller
    /// </summary>
    public class OrderController : Controller
    {
        private readonly IOrderProcessingUow uow;

        public OrderController(IOrderProcessingUow uow)
        {
            this.uow = uow;
        }

        /// <summary>
        ///     New order view
        /// </summary>
        /// <returns>New Order</returns>
        public IActionResult NewOrder()
        {
            return View(new Order());
        }

        /// <summary>
        ///     Save New Order
        /// </summary>
        /// <returns>Dashboard</returns>
        [HttpPost]
        public IActionResult SaveOrder(Order newOrder)
        {
            if (ModelState.IsValid)
            {
                newOrder.LastUpdatedDTTM = DateTime.Now;
                uow.Orders.Add(newOrder);
                uow.Commit();
                return RedirectToAction("Index", "Home");
            }


            // response is not valid. Return to same view
            return View("NewOrder", newOrder);
        }
    }
}