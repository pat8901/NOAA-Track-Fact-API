using Microsoft.EntityFrameworkCore;
using NOAA_API.Models;

namespace NOAA_API.Data
{
    public class SatelliteDbContext : DbContext
    {
        public SatelliteDbContext(DbContextOptions<SatelliteDbContext> options) : base(options) { }

        public DbSet<Satellite> Satellites { get; set; }
    }
}