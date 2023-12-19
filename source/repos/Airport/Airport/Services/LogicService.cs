using Airport.Logic;
using Airport.Models.DTOs;
using Airport.Models.Domains;

namespace Airport.Services
{
    public class LogicService : ILogicService
    {
        private readonly Manager _manager;

        public LogicService(Manager manager)
        {
            _manager = manager;
        }

        public async Task<ICollection<PlaneDTO>> GetPlaneDTOs()
        {
            return await _manager.GetPlanes();
        }

        public async Task AddPlane(bool type)
        {
            await _manager.AddPlane(type);
        }

        public async Task Run()
        {
            await _manager.MovePlanes();
        }
    }
}
