using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Models
{
    public class GameLibraryDbContext : DbContext
    {
        public GameLibraryDbContext(DbContextOptions<GameLibraryDbContext> options) : base(options)
        { }
        public DbSet<Game> Games { get; set; }
    }
}
