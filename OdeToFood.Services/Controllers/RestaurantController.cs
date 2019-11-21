using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Core;
using OdeToFood.DAL;
using OdeToFood.Services.Filters;

namespace OdeToFood.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantData _restaurantData;

        public RestaurantController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        // GET: api/Restaurant
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_restaurantData.GetRestaurantsByName(string.Empty));
        }

        // GET: api/Restaurant/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return Ok(_restaurantData.GetRestaurantById(id));
        }

        // POST: api/Restaurant
        [HttpPost]
        [ValidateModel]
        public IActionResult Post([FromBody] Restaurant restaurant)
        {
            //if (!ModelState.IsValid)
            //    return new BadRequestObjectResult(ModelState);

            restaurant = _restaurantData.Add(restaurant);
            _restaurantData.Commit();

            return Ok(restaurant);
        }

        // PUT: api/Restaurant/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
