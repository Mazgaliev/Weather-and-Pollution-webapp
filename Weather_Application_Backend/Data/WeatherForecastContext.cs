using Microsoft.EntityFrameworkCore;
using Weather_Application_Backend.Model.Entity;

namespace Weather_Application_Backend.Data
{
    public class WeatherForecastContext : DbContext
    {
        public DbSet<City> Cities { get; set; }

        public DbSet<Forecast> Forecasts { get; set; }

        public DbSet<Measurement> Measurement { get; set; }

        public DbSet<Station> Stations { get; set; }

        public DbSet<WeatherAppLogs> Logs { get; set; }

        public WeatherForecastContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<City>().HasMany(c => c.Stations)
                .WithOne(c => c.City)
                .HasForeignKey(s => s.CityId);

            modelBuilder.Entity<Measurement>().HasOne(m => m.Station)
                .WithMany(s => s.Measurements)
                .HasForeignKey(s => s.StationId);

            modelBuilder.Entity<Forecast>().HasOne(f => f.Station)
                .WithMany(s => s.Forecasts)
                .HasForeignKey(s => s.StationId);
        }
    }
}
