using Microsoft.EntityFrameworkCore;
using GameLibrary.Models;

namespace GameLibrary.Models
{
    public class GameLibraryDbContext : DbContext
    {
        public GameLibraryDbContext(DbContextOptions<GameLibraryDbContext> options) : base(options)
        { }
        public DbSet<Game> Games { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<GameSale> GameSales { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
