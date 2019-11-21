using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.DAL;

namespace OdeToFood.Client.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        public Restaurant Restaurant { get; set; }

        public DeleteModel(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = _restaurantData.GetRestaurantById(restaurantId);

            if (Restaurant == null)
                return RedirectToPage("./NotFound");

            return Page();
        }

        public IActionResult onPost(int restaurantId)
        {
            var restaurant = _restaurantData.Delete(restaurantId);
            _restaurantData.Commit();

            if (restaurant == null)
                return RedirectToPage("./NotFound");

            TempData["Message"] = $"Your restaurant {restaurant.Name} has been deleted";
            return RedirectToPage("./List");
        }
    }
}