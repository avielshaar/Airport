using Airport.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Data
{
    public class AirportDbContext : DbContext
    {
        public DbSet<StationEntity> Stations { get; set; }
        public DbSet<HistoryEntity> History { get; set; }
        public DbSet<DepartureEntity> Departures { get; set; }
        public DbSet<ArrivelEntity> Arrivels { get; set; }

        public AirportDbContext(DbContextOptions<AirportDbContext> options) : base(options) { }
    }
}
