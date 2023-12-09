using Airport.Models.Logics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Airport.Services
{
    public interface IDataService
    {
        public ICollection<Plane> GetPlanes();
        public Plane GetPlane(int id);
        public ICollection<Station> GetStations();
        public Station GetStation(int id);
        public void UpdateStation(Station station);
        public void AddHistory(int planeId, int stationId);
        public void UpdateHistory(int planeId);
        public void AddDeparture(int planeId);
        public void AddArrivel(int planeId);
    }
}
