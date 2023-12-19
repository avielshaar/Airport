using Airport.Models.Entities;
using Airport.Data.Repositories;
using Airport.Models.Domains;

namespace Airport.Services
{
    public class DataService : IDataService
    {
        private readonly IAirportRepository _repository;

        public DataService(IAirportRepository repository)
        {
            _repository = repository;
        }

        public async Task<Plane> GetPlane(int id)
        {
            foreach (ArrivelEntity arrivel in await _repository.GetArrivels())
            {
                if (arrivel.PlaneId == id)
                {
                    return new Plane(id, false);
                }
            }
            foreach (DepartureEntity departure in await _repository.GetDepartures())
            {
                if (departure.PlaneId == id)
                {
                    return new Plane(id, true);
                }
            }
            return null;
        }

        public async Task<ICollection<Station>> GetStations()
        {
            var stationsEntities = await _repository.GetStations();
            var stations = new List<Station>();
            stations.Add(null);
            foreach (var station in stationsEntities.OrderBy(s => s.Id))
            {
                if (station.PlaneId != null)
                {
                    stations.Add(new Station(station.Id, await GetPlane((int)station.PlaneId)));
                }
                else
                {
                    stations.Add(new Station(station.Id, null));
                }
            }
            return stations;
        }

        public async Task UpdateStations(ICollection<Station> stations)
        {
            foreach (var station in stations.Skip(1))
            {
                if (station.IsOccupied)
                {
                    await _repository.UpdateStation(new StationEntity() { Id = station.Id, PlaneId = station.Plane.Id });
                }
                else
                {
                    await _repository.UpdateStation(new StationEntity() { Id = station.Id });
                }
            }
        }

        public async Task AddHistory(int planeId, int stationId)
        {
            var history = new HistoryEntity()
            {
                PlaneId = planeId,
                StationId = stationId,
                In = DateTime.Now
            };
            await _repository.AddHistory(history);
        }

        public async Task UpdateHistory(int planeId)
        {
            var histories = await _repository.GetHistory();
            var history = histories.OrderByDescending(h => h.Id).FirstOrDefault(h => h.PlaneId == planeId);
            history.Out = DateTime.Now;
            await _repository.UpdateHistory(history);
        }

        public async Task AddPlane(int planeId, bool type)
        {
            if (type == false)
            {
                await _repository.AddArrivel(new ArrivelEntity() { PlaneId = planeId });
            }
            else
            {
                await _repository.AddDeparture(new DepartureEntity() { PlaneId = planeId });
            }
        }
    }
}
