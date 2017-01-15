using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderProcessingSystem.Contracts;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Web.Components
{
    /// <summary>
    ///     Servery Component Widget
    /// </summary>
    public class ServeryWidget : ViewComponent
    {
        private readonly IOrderProcessingUow uow;

        public ServeryWidget(IOrderProcessingUow uow)
        {
            this.uow = uow;
        }

        /// <summary>
        ///     Servery Component
        /// </summary>
        /// <returns>List of ItemServeryViewModel</returns>
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Inventories = new List<ItemServeryViewModel>();
            var list = await uow.Items.GetAll().ToListAsync();
            foreach (Item item in list)
            {
                Inventories.Add(new ItemServeryViewModel {Id  = item.Id, Name = item.Name, Vote = 3});
            }

            return View(Inventories);
        }
    }
}