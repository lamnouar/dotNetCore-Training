using OdeToFood.Core;
using System.Collections.Generic;

namespace OdeToFood.DAL
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int Commit();
    }
}
