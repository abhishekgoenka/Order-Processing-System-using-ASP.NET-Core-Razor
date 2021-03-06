﻿using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Contracts;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Web.Controllers
{
    /// <summary>
    ///     Item Controller
    /// </summary>
    [Authorize]
    public class ItemController : Controller
    {
        private readonly IOrderProcessingUow uow;

        public ItemController(IOrderProcessingUow uow)
        {
            this.uow = uow;
        }

        /// <summary>
        ///     Show add new item page
        /// </summary>
        /// <returns>New Item Page</returns>
        public IActionResult NewItem()
        {
            return View(new Item());
        }

        /// <summary>
        ///     POST : Add new item to database
        /// </summary>
        /// <param name="newItem">Item</param>
        /// <returns>Route to home page</returns>
        [HttpPost]
        [Authorize(Roles = "administrator")]
        public IActionResult NewItem(Item newItem)
        {
            if (ModelState.IsValid)
            {
                if (newItem.Id == 0)
                {
                    // New Item
                    uow.Items.Add(newItem);
                    uow.Commit();
                    return RedirectToAction("Index", "Home");
                }


                // Update Item
                var item = uow.Items.GetById(newItem.Id);
                if (item == null) return NotFound("Item not found");

                item.Name = newItem.Name;
                item.Qty = newItem.Qty;
                item.Description = newItem.Description;
                uow.Items.Update(item);
                uow.Commit();
                return RedirectToAction("CurrentInventory", "Item");
            }


            // response is not valid. Return to same view
            return View(newItem);
        }

        /// <summary>
        ///     Show current inventory page
        /// </summary>
        /// <returns>Current Inventory</returns>
        public IActionResult CurrentInventory()
        {
            return View(uow.Items.GetAll().ToList());
        }

        /// <summary>
        ///     Update Inventory
        /// </summary>
        /// <param name="Id">Item Id</param>
        /// <returns>Item page</returns>
        [Authorize(Roles = "administrator")]
        public IActionResult UpdateInventory(int Id)
        {
            var item = uow.Items.GetById(Id);
            if (item == null) return NotFound("Item not found");

            return View("NewItem", item);
        }
    }
}