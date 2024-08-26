using Microsoft.EntityFrameworkCore;
using NOAA_API.Models;

namespace NOAA_Track.Data
{
    public class SatelliteContext : DbContext
    {
        public SatelliteContext(DbContextOptions<SatelliteContext> options) : base(options) { }

        public DbSet<Satellite> Satellites { get; set; }
    }
}