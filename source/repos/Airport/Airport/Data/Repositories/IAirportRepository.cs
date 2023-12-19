using Airport.Models.Entities;

namespace Airport.Data.Repositories
{
    public interface IAirportRepository
    {
        public Task<ICollection<StationEntity>> GetStations();
        public Task<StationEntity> GetStation(int id);
        public Task UpdateStation(StationEntity station);
        public Task<ICollection<HistoryEntity>> GetHistory();
        public Task<HistoryEntity> GetHistory(int id);
        public Task AddHistory(HistoryEntity history);
        public Task UpdateHistory(HistoryEntity history);
        public Task AddDeparture(DepartureEntity departure);
        public Task<ICollection<DepartureEntity>> GetDepartures();
        public Task AddArrivel(ArrivelEntity arrivel);
        public Task<ICollection<ArrivelEntity>> GetArrivels();
    }
}
