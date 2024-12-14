using Microsoft.EntityFrameworkCore;
using OlympicGames.Model;

namespace OlympicGames.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        DbSet<Area> Areas { get; set; }
        DbSet<Athlete> Athletes { get; set; }
        DbSet<Competition> Competitions { get; set; }
        DbSet<Country > Countries { get; set; }
        DbSet<Game> Games { get; set; }
        DbSet<Medal> Medals { get; set; }
        DbSet<OlympicEvent> OlympicEvents { get; set; }
        DbSet<Year> Years { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
