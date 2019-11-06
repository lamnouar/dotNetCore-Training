using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.DAL
{
    public class OdeToFoodDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
