using Airport.Models.DTOs;
using Airport.Models.Logics;
using System.Diagnostics.Eventing.Reader;

namespace Airport.Services
{
    public class LogicService : ILogicService
    {
        private readonly Status _status;

        public LogicService(Status status)
        {
            _status = status;
        }

        public ICollection<PlaneDTO> GetPlaneDTOs()
        {
            var planes = new List<PlaneDTO>();
            foreach (var station in _status.Stations)
            {
                if (station.Plane != null)
                {
                    planes.Add(new PlaneDTO()
                    {
                        Id = station.Plane.Id,
                        Type = station.Plane.Type,
                        StationId = station.Id
                    });
                }
            }
            return planes;
        }

        public void AddPlane(bool type)
        {
            var plane = new Plane(_status.Planes.Max(p => p.Id) + 1, type);
            if (plane.Type == false && !GetStation(1).IsOccupied)
            {
                GetStation(1).Plane = plane;
            }
            else if (plane.Type == true)
            {
                if (!GetStation(6).IsOccupied)
                {
                    GetStation(6).Plane = plane;
                }
                else if (!GetStation(7).IsOccupied)
                {
                    GetStation(7).Plane = plane;
                }
            }
        }

        public void Start()
        {
            _status.Start();
        }

        public void Stop()
        {
            _status.Stop();
        }

        public Station GetStation(int id)
        {
            return _status.Stations.FirstOrDefault(s => s.Id == id);
        }
    }
}
