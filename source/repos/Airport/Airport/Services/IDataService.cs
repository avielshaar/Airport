using Airport.Models.Domains;

namespace Airport.Services
{
    public interface IDataService
    {
        public Task<Plane> GetPlane(int id);
        public Task<ICollection<Station>> GetStations();
        public Task UpdateStations(ICollection<Station> stations);
        public Task AddHistory(int planeId, int stationId);
        public Task UpdateHistory(int planeId);
        public Task AddPlane(int planeId, bool type);
    }
}
