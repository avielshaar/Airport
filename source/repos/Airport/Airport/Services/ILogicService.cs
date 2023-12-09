using Airport.Models.DTOs;
using Airport.Models.Logics;

namespace Airport.Services
{
    public interface ILogicService
    {
        public ICollection<PlaneDTO> GetPlaneDTOs();
        public void AddPlane(bool type);
        public void Start();
        public void Stop();
        public Station GetStation(int id);
    }
}
