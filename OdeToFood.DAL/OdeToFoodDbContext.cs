using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;

namespace OdeToFood.DAL
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
