using OdeToFood.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OdeToFood.DAL
{
    public interface IRestaurantData
    {
        #region Sync
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int Commit();
        #endregion

        #region Async
        Task<IEnumerable<Restaurant>> GetRestaurantsByNameAsync(string name);
        Task<Restaurant> GetRestaurantByIdAsync(int id);
        Task<int> CommitAsync();
        #endregion
    }
}
