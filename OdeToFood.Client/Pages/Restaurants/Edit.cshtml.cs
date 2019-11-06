using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Client.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData _restaurantData;
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public IHtmlHelper _htmlHelper { get; }

        public EditModel(IRestaurantData restaurantData,
                         IHtmlHelper htmlHelper)
        {
            _restaurantData = restaurantData;
            _htmlHelper = htmlHelper;

            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
        }
        public IActionResult OnGet(int? restaurantId)
        {
            if (restaurantId.HasValue)
            {
                Restaurant = _restaurantData.GetRestaurantById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }

            if (Restaurant == null)
                return RedirectToPage("./NotFound");


            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if (Restaurant.Id > 0)
            {
                Restaurant = _restaurantData.Update(Restaurant);
            }
            else
            {
                Restaurant = _restaurantData.Add(Restaurant);
                TempData["Message"] = "this restaurant has been added succefully !";
            }

            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}