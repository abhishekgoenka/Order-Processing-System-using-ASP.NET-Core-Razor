using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Contracts;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Web.Components
{
    /// <summary>
    ///     Inventory Widget view component
    /// </summary>
    public class InventoryWidget : ViewComponent
    {
        private const int QTY_THRESHOLD = 10;
        private readonly IOrderProcessingUow uow;

        public InventoryWidget(IOrderProcessingUow uow)
        {
            this.uow = uow;
        }

        /// <summary>
        ///     Inventory Widget
        /// </summary>
        /// <returns>Inventory Widget</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Inventories = new List<InventoryItemViewModel>();
            var lowItems = await uow.Items.GetAll().Where(e => e.Qty < QTY_THRESHOLD).ToListAsync();
            foreach (Item lowItem in lowItems)
            {
                Inventories.Add(new InventoryItemViewModel { Name = lowItem.Name, Count = lowItem.Qty});
            }

            
            return View(Inventories);
        }
    }
}