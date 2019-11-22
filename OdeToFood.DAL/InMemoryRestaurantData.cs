using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.DAL
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private IList<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>
            {
                new Restaurant{Id = 1, Name="Luigi Pizza", Cuisine = CuisineType.Italian, Location="14 fleet street, London UK" },
                new Restaurant{Id = 2, Name="Curry chicken", Cuisine = CuisineType.Indian, Location="1480 fleet street, London UK" }
            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Task<int> CommitAsync()
        {
            throw new System.NotImplementedException();
        }

        public Restaurant Delete(int id)
        {
            var restauant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restauant != null)
            {
                restaurants.Remove(restauant);
            }

            return restauant;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Task<Restaurant> GetRestaurantByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Task<IEnumerable<Restaurant>> GetRestaurantsByNameAsync(string name)
        {
            throw new System.NotImplementedException();
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }
    }
}