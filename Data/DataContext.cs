using System.Data.Entity;

namespace Data
{
    public class DataContext : DbContext
    {
        public DbSet<FilmSession> FilmSessions { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
