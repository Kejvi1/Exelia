using BeerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerAPI.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Beer> Beers { get; set; }
    }
}