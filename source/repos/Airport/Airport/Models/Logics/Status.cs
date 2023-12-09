using Airport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models.Logics
{
    public class Status
    {
        private readonly IDataService _service;
        private bool _active;
        public List<Plane> Planes { get; set; } = new List<Plane>();
        public List<Station> Stations { get; set; } = new List<Station>();

        public Status(IDataService service)
        {
            _service = service;
            _active = false;
            Planes = _service.GetPlanes().ToList();
            Stations = _service.GetStations().ToList();
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    if (_active)
                    {
                        MovePlanes();
                    }
                    Thread.Sleep(1000);
                }
            });
            thread.Start();
        }

        public void MovePlanes()
        {
            foreach (var station in Stations)
            {
                if (station.Plane != null)
                {
                    if (station.Id == 5 && station.NextStation.IsOccupied && _service.GetStation(7).IsOccupied)
                    {
                        _service.GetStation(7).Plane = station.Plane;
                        station.Plane = null;
                    }
                    else if (station.Id == 6 && station.Plane.Type == true &&
                        _service.GetStation(7).Plane != null && station.Plane.Type == true)
                    {
                    }
                    else
                    {
                        station.MovePlane();
                    }
                }
            }
        }

        public void Start()
        {
            _active = true;
        }

        public void Stop()
        {
            _active = false;
        }
    }
}
