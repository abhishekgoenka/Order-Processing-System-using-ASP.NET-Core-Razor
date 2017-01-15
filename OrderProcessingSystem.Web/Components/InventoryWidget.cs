using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Web.Components
{
    /// <summary>
    ///     Inventory Widget view component
    /// </summary>
    public class InventoryWidget : ViewComponent
    {
        /// <summary>
        ///     Inventory Widget
        /// </summary>
        /// <returns>Inventory Widget</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Inventories = new List<InventoryItemViewModel>
            {
                new InventoryItemViewModel {Name = "Banner", Count = 8},
                new InventoryItemViewModel {Name = "Markets", Count = 3},
                new InventoryItemViewModel {Name = "Jackets", Count = 1},
                new InventoryItemViewModel {Name = "Hoodie", Count = 9},
                new InventoryItemViewModel {Name = "Posters", Count = 1}
            };

            return View(Inventories);
        }
    }
}