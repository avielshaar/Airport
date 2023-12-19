using Airport.Models.Domains;
using Airport.Models.DTOs;
using Airport.Services;
using System;
using static System.Collections.Specialized.BitVector32;

namespace Airport.Logic
{
    public class Manager
    {
        private readonly IDataService _service;
        private List<Station> _stations;

        public Manager(IDataService service)
        {
            _service = service;
        }

        public async Task<ICollection<PlaneDTO>> GetPlanes()
        {
            _stations = (await _service.GetStations()).ToList();
            var planes = new List<PlaneDTO>();
            foreach (var station in _stations.Skip(1))
            {
                if (station.IsOccupied)
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

        public async Task AddPlane(bool type)
        {
            _stations = (await _service.GetStations()).ToList();
            if (type == false && !_stations[1].IsOccupied)
            {
                await GeneratePlane(1, type);
            }
            else if (type == true)
            {
                if (!_stations[6].IsOccupied)
                {
                    await GeneratePlane(6, type);
                }
                else if (!_stations[7].IsOccupied)
                {
                    await GeneratePlane(7, type);
                }
            }
        }

        public async Task MovePlanes()
        {
            _stations = (await _service.GetStations()).ToList();
            if (_stations[4].IsOccupied && _stations[4].Plane.Type == true)
            {
                await EndMove(4);
            }
            await RegularMove(8, 4);
            if (_stations[7].IsOccupied && _stations[7].Plane.Type == true)
            {
                await RegularMove(7, 8);
            }
            else
            {
                await EndMove(7);
            }
            if (_stations[6].IsOccupied && _stations[6].Plane.Type == true)
            {
                await RegularMove(6, 8);
            }
            else
            {
                await EndMove(6);
            }
            if (await RegularMove(5, 6) == false)
            {
                await RegularMove(5, 7);
            }
            if (_stations[4].IsOccupied && _stations[4].Plane.Type == false)
            {
                await RegularMove(4, 5);
            }
            await RegularMove(3, 4);
            await RegularMove(2, 3);
            await RegularMove(1, 2);
            
            await _service.UpdateStations(_stations);
        }

        public async Task GeneratePlane(int stationId, bool type)
        {
            Random randomId = new Random();
            var plane = new Plane(randomId.Next(100000, 1000000), type);
            _stations[stationId].Plane = plane;
            await _service.AddPlane(plane.Id, type);
            await _service.AddHistory(plane.Id, stationId);
            await _service.UpdateStations(_stations);
        }

        public async Task<bool> RegularMove(int currentId, int nextId)
        {
            if (_stations[currentId].IsOccupied && !_stations[nextId].IsOccupied)
            {
                await _service.UpdateHistory(_stations[currentId].Plane.Id);
                _stations[nextId].Plane = _stations[currentId].Plane;
                await _service.AddHistory(_stations[nextId].Plane.Id, nextId);
                _stations[currentId].Plane = null;
                return true;
            }
            return false;
        }

        public async Task EndMove(int id)
        {
            if (_stations[id].IsOccupied)
            {
                await _service.UpdateHistory(_stations[id].Plane.Id);
                _stations[id].Plane = null;
            }
        }
    }
}
