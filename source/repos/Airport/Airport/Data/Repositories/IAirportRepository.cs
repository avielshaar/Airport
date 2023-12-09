using Airport.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Data.Repositories
{
    public interface IAirportRepository
    {
        public Task<ICollection<StationEntity>> GetStations();
        public Task<StationEntity> GetStation(int id);
        public void UpdateStation(StationEntity station);
        public Task<ICollection<HistoryEntity>> GetHistory();
        public Task<HistoryEntity> GetHistory(int id);
        public void AddHistory(HistoryEntity history);
        public void UpdateHistory(HistoryEntity history);
        public void AddDeparture(DepartureEntity departure);
        public Task<ICollection<DepartureEntity>> GetDepartures();
        public Task<DepartureEntity> GetDeparture(int planeId);
        public void AddArrivel(ArrivelEntity arrivel);
        public Task<ICollection<ArrivelEntity>> GetArrivels();
        public Task<ArrivelEntity> GetArrivel(int planeId);
    }
}
