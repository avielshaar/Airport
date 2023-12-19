using Airport.Models.DTOs;

namespace Airport.Services
{
    public interface ILogicService
    {
        public Task<ICollection<PlaneDTO>> GetPlaneDTOs();
        public Task AddPlane(bool type);
        public Task Run();
    }
}
