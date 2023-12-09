using Airport.Models.Entities;
using Airport.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
using Airport.Models.Logics;

namespace Airport.Services
{
    public class DataService : IDataService
    {
        private readonly IAirportRepository _repository;

        public DataService(IAirportRepository repository)
        {
            _repository = repository;
        }

        public ICollection<Plane> GetPlanes()
        {
            var planes = new List<Plane>();
            foreach (Station station in GetStations())
            {
                if (station.Plane != null)
                {
                    planes.Add(station.Plane);
                }
            }
            return planes;
        }

        public Plane GetPlane(int id)
        {
            foreach (ArrivelEntity arrivel in _repository.GetArrivels().Result)
            {
                if (arrivel.PlaneId == id)
                {
                    return new Plane(id, false);
                }
            }
            foreach (DepartureEntity departure in _repository.GetDepartures().Result)
            {
                if (departure.PlaneId == id)
                {
                    return new Plane(id, true);
                }
            }
            return null;
        }

        public ICollection<Station> GetStations()
        {
            var stations = new List<Station>();
            foreach (var station in _repository.GetStations().Result)
            {
                if (station.PlaneId != null)
                {
                    stations.Add(new Station(station.Id, GetPlane((int)station.PlaneId)));
                }
                else
                {
                    stations.Add(new Station(station.Id, null));
                }
            }
            return stations;
        }

        public Station GetStation(int id)
        {
            return GetStations().FirstOrDefault(s => s.Id == id);
        }

        public void UpdateStation(Station station)
        {
            _repository.UpdateStation(new StationEntity() { Id = station.Id, PlaneId = station.Id });
        }

        public void AddHistory(int planeId, int stationId)
        {
            var history = new HistoryEntity()
            {
                Id = _repository.GetHistory().Result.Max(h => h.Id) + 1,
                PlaneId = planeId,
                StationId = stationId,
                In = DateTime.Now
            };
            _repository.AddHistory(history);
        }

        public void UpdateHistory(int planeId)
        {
            var history = _repository.GetHistory().Result.OrderByDescending(h => h.Id).FirstOrDefault(h => h.PlaneId == planeId);
            history.Out = DateTime.Now;
            _repository.UpdateHistory(history);
        }

        public void AddDeparture(int planeId)
        {
            var departure = new DepartureEntity()
            {
                Id = _repository.GetDepartures().Result.Max(d => d.Id) + 1,
                PlaneId = planeId
            };
            _repository.AddDeparture(departure);
        }

        public void AddArrivel(int planeId)
        {
            var arrivel = new ArrivelEntity()
            {
                Id = _repository.GetArrivels().Result.Max(a => a.Id) + 1,
                PlaneId = planeId
            };
            _repository.AddArrivel(arrivel);
        }
    }
}
