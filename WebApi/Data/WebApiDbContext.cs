
using Microsoft.EntityFrameworkCore;
using Agenzilla.Models;

namespace Agenzilla.Data
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> user { get; set; }
        public DbSet<Item> item { get; set; }
        public DbSet<Agenzilla.Models.Order> Order { get; set; }
        public DbSet<Agenzilla.Models.Stock> Stock { get; set; }
        public DbSet<Agenzilla.Models.Store> Store { get; set; }

    }
}