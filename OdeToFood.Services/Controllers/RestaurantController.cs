using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //// GET: api/Restaurant/5
        // [HttpGet("{id}", Name = "Get")]
        // public IActionResult Get(int id)
        // {
        //     return Ok(_restaurantData.GetRestaurantById(id));
        // }

        // GET: api/Restaurant/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetAsync(int id)
        {
           return Ok(await _restaurantData.GetRestaurantByIdAsync(id));
        }

        // POST: api/Restaurant
        [HttpPost]
        [ValidateModel]
        public IActionResult Post([FromBody] Restaurant restaurant)
        {
            restaurant = _restaurantData.Add(restaurant);
            _restaurantData.Commit();

            return Ok(restaurant);
        }

        // PUT: api/Restaurant/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Restaurant restaurant)
        {
            if (id != restaurant.Id)
                return BadRequest();

            try
            {
                _restaurantData.Add(restaurant);
                _restaurantData.Commit();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_restaurantData.GetRestaurantById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var restaurant = _restaurantData.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _restaurantData.Delete(id);
            _restaurantData.Commit();

            return Ok(restaurant);
        }
    }
}
