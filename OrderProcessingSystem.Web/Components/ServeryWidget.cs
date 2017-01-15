using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Web.Components
{
    /// <summary>
    ///     Servery Component Widget
    /// </summary>
    public class ServeryWidget : ViewComponent
    {
        /// <summary>
        ///     Servery Component
        /// </summary>
        /// <returns>List of ItemServeryViewModel</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Inventories = new List<ItemServeryViewModel>
            {
                new ItemServeryViewModel {Id = 1, Name = "Banner", Vote = 8},
                new ItemServeryViewModel {Id = 1, Name = "Markets", Vote = 3},
                new ItemServeryViewModel {Id = 1, Name = "Jackets", Vote = 1},
                new ItemServeryViewModel {Id = 1, Name = "Hoodie", Vote = 9},
                new ItemServeryViewModel {Id = 1, Name = "Posters", Vote = 1}
            };

            return View(Inventories);
        }
    }
}