using Airport.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Airport.Data.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly AirportDbContext _context;

        public AirportRepository(AirportDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<StationEntity>> GetStations()
        {
            var stations = await _context.Stations.ToListAsync();
            return stations;
        }

        public async Task<StationEntity> GetStation(int id)
        {
            var station = await _context.Stations.FirstOrDefaultAsync(s => s.Id == id);
            return station;
        }

        public async Task UpdateStation(StationEntity station)
        {
            var oldStation = await GetStation(station.Id);
            if (station.PlaneId != null)
            {
                oldStation.PlaneId = station.PlaneId;
            }
            else
            {
                oldStation.PlaneId = null;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<HistoryEntity>> GetHistory()
        {
            var history = await _context.History.ToListAsync();
            return history;
        }

        public async Task<HistoryEntity> GetHistory(int id)
        {
            var history = await _context.History.FirstOrDefaultAsync(h => h.Id == id);
            return history;
        }

        public async Task AddHistory(HistoryEntity history)
        {
            _context.History.Add(history);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateHistory(HistoryEntity history)
        {
            var oldHistory = await GetHistory(history.Id);
            oldHistory.Out = history.Out;
            await _context.SaveChangesAsync();
        }

        public async Task AddDeparture(DepartureEntity departure)
        {
            _context.Departures.Add(departure);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<DepartureEntity>> GetDepartures()
        {
            var departures = await _context.Departures.ToListAsync();
            return departures;
        }

        public async Task AddArrivel(ArrivelEntity arrivel)
        {
            _context.Arrivels.Add(arrivel);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ArrivelEntity>> GetArrivels()
        {
            var arrivels = await _context.Arrivels.ToListAsync();
            return arrivels;
        }
    }
}
