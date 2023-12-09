using Airport.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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

        public async void UpdateStation(StationEntity station)
        {
            var oldStation = GetStation(station.Id).Result;
            oldStation = station;
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

        public async void AddHistory(HistoryEntity history)
        {
            _context.History.Add(history);
            await _context.SaveChangesAsync();
        }

        public async void UpdateHistory(HistoryEntity history)
        {
            var oldHistory = GetHistory(history.PlaneId).Result;
            oldHistory = history;
            await _context.SaveChangesAsync();
        }

        public async void AddDeparture(DepartureEntity departure)
        {
            _context.Departures.Add(departure);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<DepartureEntity>> GetDepartures()
        {
            var departures = await _context.Departures.ToListAsync();
            return departures;
        }

        public async Task<DepartureEntity> GetDeparture(int planeId)
        {
            var departure = await _context.Departures.FirstOrDefaultAsync(d => d.PlaneId == planeId);
            return departure;
        }

        public async void AddArrivel(ArrivelEntity arrivel)
        {
            _context.Arrivels.Add(arrivel);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ArrivelEntity>> GetArrivels()
        {
            var arrivels = await _context.Arrivels.ToListAsync();
            return arrivels;
        }

        public async Task<ArrivelEntity> GetArrivel(int planeId)
        {
            var arrivel = await _context.Arrivels.FirstOrDefaultAsync(a => a.PlaneId == planeId);
            return arrivel;
        }
    }
}
